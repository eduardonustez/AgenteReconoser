using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace Dispositivos.Implementaciones
{
    public class wacomImplementation
    {
        public int penDataType;
        //private wgssSTU.Tablet m_tablet;
        private wgssSTU.ICapability m_capability;
        private wgssSTU.IInformation m_information;
        private wgssSTU.IUsbDevice usbDevice;
        private wgssSTU.Tablet m_tablet;
        private wgssSTU.inkThreshold m_inkThreshold;
        private string signature;
        private Action<int> onButtonPressed;
        private Action<string> onErrorOcurred;
        private delegate void ButtonClick();
        int ImageHeight;
        int ImageWidth; 
        float ImageLineWidth;
        private struct Button
        {
            public System.Drawing.Rectangle Bounds; // in Screen coordinates
            public String Text;
            public EventHandler Click;

            public void PerformClick()
            {
                Click(this, null);
            }
        };

        private Pen m_penInk;  // cached object.

        // The isDown flag is used like this:
        // 0 = up
        // +ve = down, pressed on button number
        // -1 = down, inking
        // -2 = down, ignoring
        private int m_isDown;

        private List<wgssSTU.IPenData> m_penData; // Array of data being stored. This can be subsequently used as desired.
        private List<wgssSTU.IPenDataTimeCountSequence> m_penTimeData; // Array of data being stored. This can be subsequently used as desired.

        private Button[] m_btns; // The array of buttons that we are emulating.

        private Bitmap m_bitmap; // This bitmap that we display on the screen.
        private wgssSTU.encodingMode m_encodingMode; // How we send the bitmap to the device.
        private byte[] m_bitmapData; // This is the flattened data of the bitmap that we send to the device.
        private int m_penDataOptionMode;  // The pen data option mode flag - basic or with time and sequence counts

        private bool m_useEncryption;
        bool useColor = false;
        wgssSTU.ProtocolHelper protocolHelper;
        public wacomImplementation()
        {
            m_tablet = new wgssSTU.Tablet();
        }
        private void FindDevices()
        {
            int penDataType;
            List<wgssSTU.IPenDataTimeCountSequence> penTimeData = null;
            List<wgssSTU.IPenData> penData = null;

            wgssSTU.UsbDevices usbDevices = new wgssSTU.UsbDevices();
            if (usbDevices.Count != 0)
            {
                usbDevice = usbDevices[0]; // select a device
            }
            else
            {
                throw new ArgumentException("No se encontro ninguna Wacom conectada por USB");
            }
        }
        public void ConnectDevice()
        {
            FindDevices();
            //m_tablet = new wgssSTU.Tablet();
            int currentPenDataOptionMode;
            m_penDataOptionMode = -1;
            m_penData = new List<wgssSTU.IPenData>();
            wgssSTU.IErrorCode ec = m_tablet.usbConnect(usbDevice, false);
            if (ec.value == 0)
            {
                m_capability = m_tablet.getCapability();
                m_information = m_tablet.getInformation();
                m_inkThreshold = m_tablet.getInkThreshold();
                currentPenDataOptionMode = getPenDataOptionMode();
                setPenDataOptionMode(currentPenDataOptionMode);
                ImageWidth = m_capability.screenWidth;
                ImageHeight = m_capability.screenHeight;
                SizeF s = new System.Drawing.SizeF(96F, 96F);
                float inkWidthMM = 0.7F;
                ImageLineWidth = inkWidthMM / 25.4F * ((s.Width + s.Height) / 2F);
                m_penInk = new Pen(Color.Black, ImageLineWidth);
                m_penInk.StartCap = m_penInk.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                m_penInk.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            }
            else
            {
                onErrorOcurred(ec.message);
                throw new Exception(ec.message);
            }
            ushort idP = m_tablet.getProductId();
             protocolHelper = new wgssSTU.ProtocolHelper();
            wgssSTU.encodingFlag encodingFlag = (wgssSTU.encodingFlag)protocolHelper.simulateEncodingFlag(idP, 0);
            if ((encodingFlag & (wgssSTU.encodingFlag.EncodingFlag_16bit | wgssSTU.encodingFlag.EncodingFlag_24bit)) != 0)
            {
                if (m_tablet.supportsWrite())
                    useColor = true;
            }
            if ((encodingFlag & wgssSTU.encodingFlag.EncodingFlag_24bit) != 0)
            {
                m_encodingMode = m_tablet.supportsWrite() ? wgssSTU.encodingMode.EncodingMode_24bit_Bulk : wgssSTU.encodingMode.EncodingMode_24bit;
            }
            else if ((encodingFlag & wgssSTU.encodingFlag.EncodingFlag_16bit) != 0)
            {
                m_encodingMode = m_tablet.supportsWrite() ? wgssSTU.encodingMode.EncodingMode_16bit_Bulk : wgssSTU.encodingMode.EncodingMode_16bit;
            }
            else
            {
                m_encodingMode = wgssSTU.encodingMode.EncodingMode_1bit;
            }
            addDelegates();
            //clearScreen();
        }
        public void DisconnectDevice()
        {
                //m_tablet.setClearScreen();
                m_tablet.disconnect();   
            //m_tablet = null;
            //m_penData = null;
            //m_penTimeData = null;

        }
        public bool IsConnected()
        {
            return m_tablet.isConnected();
        }
        public ushort GetStatus()
        {
            return m_tablet.getStatus().statusWord;
        }
        public void AddButtons(Rectangle[] botones, bool habilitarFirma)
        {
            m_btns = new Button[botones.Length];
            for (var i = 0; i < botones.Length; i++)
            {
                m_btns[i].Text = i.ToString();
                m_btns[i].Bounds = botones[i];
                if(habilitarFirma)
                    m_btns[i].Click = new EventHandler(CaptureImage_Click);
                else
                    m_btns[i].Click = new EventHandler(defaultButton_Click);
            }
            if (habilitarFirma)
                SetInkingMode(0x01);
            else
                SetInkingMode(0x00);
            //m_btns[0].Click = new EventHandler(btnOk_Click);
            //m_btns[1].Click = new EventHandler(btnClear_Click);
            //m_btns[2].Click = new EventHandler(btnCancel_Click);

        }

        public void writeImage(string base64String)
        {

            base64String = base64String.Replace("data:image/jpeg;base64,", "");
            base64String = base64String.Replace("data:image/png;base64,", "");
            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream stream = new MemoryStream(byteBuffer);
            m_bitmapData = (byte[])protocolHelper.resizeAndFlatten(stream.ToArray(), 0, 0, 0, 0, m_capability.screenWidth, m_capability.screenHeight, (byte)m_encodingMode, wgssSTU.Scale.Scale_Fit, 0, 0);
            //protocolHelper = null;
            stream.Dispose();
            bool useZlibCompression = false;
            if (!useColor && useZlibCompression)
            {
                m_encodingMode |= wgssSTU.encodingMode.EncodingMode_Zlib;
            }
            //addDelegates();
            clearScreen();
        }
        public void SetInkingMode(byte inkingMode)
        {
            // m_tablet.setInkingMode(0x01); //Habilita o deshabilita la wacom para capturar grafo
            m_tablet.setInkingMode(inkingMode);
        }
        public void SetListening(Action<int> buttonPressed, Action<string> errorOcurred)
        {
            onButtonPressed = buttonPressed;
            onErrorOcurred = errorOcurred;
        }
        public void SetImageSize(int height, int width, float lineWidth)
        {
            ImageHeight = height;
            ImageWidth = width;
            ImageLineWidth = lineWidth * 0.8F;            
        }

        #region Private Methods
        private int getPenDataOptionMode()
        {
            int penDataOptionMode;

            try
            {
                penDataOptionMode = m_tablet.getPenDataOptionMode();
            }
            catch (Exception optionModeException)
            {
                //m_parent.print("Tablet doesn't support getPenDataOptionMode");
                penDataOptionMode = -1;
            }
            //m_parent.print("Pen data option mode: " + m_penDataOptionMode);

            return penDataOptionMode;
        }

        private void setPenDataOptionMode(int currentPenDataOptionMode)
        {
            // If the current option mode is TimeCount then this is a 520 so we must reset the mode
            // to basic data only as there is no handler for TimeCount

            //m_parent.print("current mode: " + currentPenDataOptionMode);

            switch (currentPenDataOptionMode)
            {
                case -1:
                    // THis must be the 300 which doesn't support getPenDataOptionMode at all so only basic data
                    m_penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_None;
                    break;

                case (int)PenDataOptionMode.PenDataOptionMode_None:
                    // If the current option mode is "none" then it could be any pad so try setting the full option
                    // and if it fails or ends up as TimeCount then set it to none
                    try
                    {
                        m_tablet.setPenDataOptionMode((byte)wgssSTU.penDataOptionMode.PenDataOptionMode_TimeCountSequence);
                        m_penDataOptionMode = m_tablet.getPenDataOptionMode();
                        if (m_penDataOptionMode == (int)PenDataOptionMode.PenDataOptionMode_TimeCount)
                        {
                            m_tablet.setPenDataOptionMode((byte)wgssSTU.penDataOptionMode.PenDataOptionMode_None);
                            m_penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_None;
                        }
                        else
                        {
                            m_penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence;
                        }
                    }
                    catch (Exception ex)
                    {
                        // THis shouldn't happen but just in case...
                        //m_parent.print("Using basic pen data");
                        m_penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_None;
                    }
                    break;

                case (int)PenDataOptionMode.PenDataOptionMode_TimeCount:
                    m_tablet.setPenDataOptionMode((byte)wgssSTU.penDataOptionMode.PenDataOptionMode_None);
                    m_penDataOptionMode = (int)PenDataOptionMode.PenDataOptionMode_None;
                    break;

                case (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence:
                    // If the current mode is timecountsequence then leave it at that
                    m_penDataOptionMode = currentPenDataOptionMode;
                    break;
            }

            switch ((int)m_penDataOptionMode)
            {
                case (int)PenDataOptionMode.PenDataOptionMode_None:
                    m_penData = new List<wgssSTU.IPenData>();
                    //m_parent.print("None");
                    break;
                case (int)PenDataOptionMode.PenDataOptionMode_TimeCount:
                    m_penData = new List<wgssSTU.IPenData>();
                    //m_parent.print("Time count");
                    break;
                case (int)PenDataOptionMode.PenDataOptionMode_SequenceNumber:
                    m_penData = new List<wgssSTU.IPenData>();
                    //m_parent.print("Seq number");
                    break;
                case (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence:
                    m_penTimeData = new List<wgssSTU.IPenDataTimeCountSequence>();
                    //m_parent.print("Time count + seq");
                    break;
                default:
                    m_penData = new List<wgssSTU.IPenData>();
                    break;
            }
        }

        private void addDelegates()
        {
            // Add the delegates that receive pen data.
            m_tablet.onGetReportException += new wgssSTU.ITabletEvents2_onGetReportExceptionEventHandler(onGetReportException);

            m_tablet.onPenData += new wgssSTU.ITabletEvents2_onPenDataEventHandler(onPenData);
            m_tablet.onPenDataEncrypted += new wgssSTU.ITabletEvents2_onPenDataEncryptedEventHandler(onPenDataEncrypted);

            m_tablet.onPenDataTimeCountSequence += new wgssSTU.ITabletEvents2_onPenDataTimeCountSequenceEventHandler(onPenDataTimeCountSequence);
            m_tablet.onPenDataTimeCountSequenceEncrypted += new wgssSTU.ITabletEvents2_onPenDataTimeCountSequenceEncryptedEventHandler(onPenDataTimeCountSequenceEncrypted);
        }
        private void clearScreen()
        {
            // note: There is no need to clear the tablet screen prior to writing an image.

            if (m_useEncryption)
                m_tablet.endCapture();

            m_tablet.writeImage((byte)m_encodingMode, m_bitmapData);

            if (m_penDataOptionMode == (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
            {
                m_penTimeData.Clear();
            }
            else
            {
                m_penData.Clear();
            }

            if (m_useEncryption)
                m_tablet.startCapture(0xc0ffee);

            m_isDown = 0;
        }

        private void onGetReportException(wgssSTU.ITabletEventsException tabletEventsException)
        {
            try
            {
                tabletEventsException.getException();
            }
            catch (Exception e)
            {
                onErrorOcurred(e.Message);
                //Trace.TraceError("Error: " + e.Message);
                //m_tablet.disconnect();
                //m_tablet = null;
                //m_penData = null;
                //m_penTimeData = null;
            }
        }
        private void onPenDataEncrypted(wgssSTU.IPenDataEncrypted penData) // Process incoming pen data
        {
            onPenData(penData.penData1);
            onPenData(penData.penData2);
        }
        private void onPenDataTimeCountSequence(wgssSTU.IPenDataTimeCountSequence penTimeData)
        {
            UInt16 penSequence;
            UInt16 penTimeStamp;
            UInt16 penPressure;
            UInt16 x;
            UInt16 y;

            penPressure = penTimeData.pressure;
            penTimeStamp = penTimeData.timeCount;
            penSequence = penTimeData.sequence;
            x = penTimeData.x;
            y = penTimeData.y;

            Point pt = tabletToScreen(penTimeData);
            int btn = buttonClicked(pt); // Check if a button was clicked

            bool isDown = (penTimeData.sw != 0);

            //m_parent.print("Handling pen data timed");

            // This code uses a model of four states the pen can be in:
            // down or up, and whether this is the first sample of that state.

            if (isDown)
            {
                if (m_isDown == 0)
                {
                    // transition to down
                    if (btn > 0)
                    {
                        // We have put the pen down on a button.
                        // Track the pen without inking on the client.

                        m_isDown = btn;
                    }
                    else
                    {
                        // We have put the pen down somewhere else.
                        // Treat it as part of the signature.

                        m_isDown = -1;
                    }
                }
                else
                {
                    // already down, keep doing what we're doing!
                }

                // draw
                //if (m_penTimeData.Count != 0 && m_isDown == -1)
                //{
                //    // Draw a line from the previous down point to this down point.
                //    // This is the simplist thing you can do; a more sophisticated program
                //    // can perform higher quality rendering than this!

                //    Graphics gfx = setQualityGraphics(this);
                //    wgssSTU.IPenDataTimeCountSequence prevPenData = m_penTimeData[m_penTimeData.Count - 1];
                //    PointF prev = tabletToClient(prevPenData);

                //    gfx.DrawLine(m_penInk, prev, tabletToClientTimed(penTimeData));
                //    gfx.Dispose();
                //}

                // The pen is down, store it for use later.
                if (m_isDown == -1)
                    m_penTimeData.Add(penTimeData);
            }
            else
            {
                if (m_isDown != 0)
                {
                    // transition to up
                    if (btn > 0)
                    {
                        // The pen is over a button

                        if (btn == m_isDown)
                        {
                            // The pen was pressed down over the same button as is was lifted now. 
                            // Consider that as a click!
                            //m_parent.print("Performing button " + btn);
                            m_btns[btn - 1].PerformClick();
                        }
                    }
                    m_isDown = 0;
                }
                else
                {
                    // still up
                }

                // Add up data once we have collected some down data.
                if (m_penTimeData != null)
                {
                    if (m_penTimeData.Count != 0)
                        m_penTimeData.Add(penTimeData);
                }
            }
        }

        private void onPenDataTimeCountSequenceEncrypted(wgssSTU.IPenDataTimeCountSequenceEncrypted penTimeCountSequenceDataEncrypted) // Process incoming pen data
        {
            onPenDataTimeCountSequence(penTimeCountSequenceDataEncrypted);
            //onPenDataTimeCountSequence(penTimeCountSequenceDataEncrypted);
        }


        private void onPenData(wgssSTU.IPenData penData) // Process incoming pen data
        {
            Point pt = tabletToScreen(penData);

            int btn = 0; // will be +ve if the pen is over a button.
            {
                for (int i = 0; i < m_btns.Length; ++i)
                {
                    if (m_btns[i].Bounds.Contains(pt))
                    {
                        btn = i + 1;
                        break;
                    }
                }
            }

            bool isDown = (penData.sw != 0);

            // This code uses a model of four states the pen can be in:
            // down or up, and whether this is the first sample of that state.

            if (isDown)
            {
                if (m_isDown == 0)
                {
                    // transition to down
                    if (btn > 0)
                    {
                        // We have put the pen down on a button.
                        // Track the pen without inking on the client.

                        m_isDown = btn;
                    }
                    else
                    {
                        // We have put the pen down somewhere else.
                        // Treat it as part of the signature.

                        m_isDown = -1;
                    }
                }
                else
                {
                    // already down, keep doing what we're doing!
                }

                //// draw
                //if (m_penData.Count != 0 && m_isDown == -1)
                //{
                //    // Draw a line from the previous down point to this down point.
                //    // This is the simplist thing you can do; a more sophisticated program
                //    // can perform higher quality rendering than this!

                //    Graphics gfx = this.CreateGraphics();
                //    gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //    gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                //    gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                //    gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //    wgssSTU.IPenData prevPenData = m_penData[m_penData.Count - 1];

                //    PointF prev = tabletToClient(prevPenData);

                //    gfx.DrawLine(m_penInk, prev, tabletToClient(penData));
                //    gfx.Dispose();
                //}

                // The pen is down, store it for use later.
                if (m_isDown == -1)
                    m_penData.Add(penData);
            }
            else
            {
                if (m_isDown != 0)
                {
                    // transition to up
                    if (btn > 0)
                    {
                        // The pen is over a button

                        if (btn == m_isDown)
                        {
                            // The pen was pressed down over the same button as is was lifted now. 
                            // Consider that as a click!
                            m_btns[btn - 1].PerformClick();
                        }
                    }
                    m_isDown = 0;
                }
                else
                {
                    // still up
                }

                // Add up data once we have collected some down data.
                if (m_penData != null)
                {
                    if (m_penData.Count != 0)
                        m_penData.Add(penData);
                }
            }
        }

        private Point tabletToScreen(wgssSTU.IPenData penData)
        {
            // Screen means LCD screen of the tablet.
            return Point.Round(new PointF((float)penData.x * m_capability.screenWidth / m_capability.tabletMaxX, (float)penData.y * m_capability.screenHeight / m_capability.tabletMaxY));
        }
        private int buttonClicked(Point pt)
        {
            int btn = 0; // will be +ve if the pen is over a button.
            {
                if (m_btns != null)
                {
                    for (int i = 0; i < m_btns.Length; ++i)
                    {
                        if (m_btns[i].Bounds.Contains(pt))
                        {
                            btn = i + 1;
                            //m_parent.print("Pressed button " + btn);
                            break;
                        }
                    }
                }
            }
            return btn;
        }
        private void defaultButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;            
            penDataType = m_penDataOptionMode;
            onButtonPressed(Convert.ToInt32(button.Text));
        }
        private void CaptureImage_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            SaveImage();
            penDataType = m_penDataOptionMode;
            onButtonPressed(Convert.ToInt32(button.Text));
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_penDataOptionMode == (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
            {
                this.m_penTimeData = null;
            }
            else
            {
                this.m_penData = null;
            }

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            if (m_penData.Count != 0 || m_penTimeData.Count != 0)
            {
                clearScreen();
            }
        }

        #endregion

        //public Bitmap GetImage(Rectangle rect)
        //{
        //    Bitmap retVal = null;
        //    Bitmap bitmap = null;
        //    SolidBrush brush = null;
        //    try
        //    {
        //        bitmap = new Bitmap(rect.Width, rect.Height);
        //        Graphics graphics = Graphics.FromImage(bitmap);

        //        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //        brush = new SolidBrush(Color.White);
        //        graphics.FillRectangle(brush, 0, 0, rect.Width, rect.Height);

        //        if (m_penDataOptionMode == (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
        //        {
        //            for (int i = 1; i < m_penTimeData.Count; i++)
        //            {
        //                PointF p1 = tabletToScreen(m_penTimeData[i - 1]);
        //                PointF p2 = tabletToScreen(m_penTimeData[i]);

        //                if (m_penTimeData[i - 1].sw > 0 || m_penTimeData[i].sw > 0)
        //                {
        //                    graphics.DrawLine(m_penInk, p1, p2);
        //                }
        //                else
        //                {
        //                    var prueab = "aqui entro";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            for (int i = 1; i < m_penData.Count; i++)
        //            {
        //                PointF p1 = tabletToScreen(m_penData[i - 1]);
        //                PointF p2 = tabletToScreen(m_penData[i]);

        //                if (m_penData[i - 1].sw > 0 || m_penData[i].sw > 0)
        //                {
        //                    graphics.DrawLine(m_penInk, p1, p2);
        //                }
        //            }
        //        }

        //        retVal = bitmap;
        //        bitmap = null;
        //    }
        //    finally
        //    {
        //        if (brush != null)
        //            brush.Dispose();
        //        if (bitmap != null)
        //            bitmap.Dispose();
        //    }
        //    return retVal;
        //}
        public async Task<string> GetImage()
        {
            string response = string.Concat("data:image/png;base64,", signature);
            signature = null;
            return response;
        }
        private void SaveImage()
        {
            try
            {
                //Stopwatch stopWatch = new Stopwatch();
                //stopWatch.Start();
                var rat = FindRatio();
                //stopWatch.Stop();
                //TimeSpan ts = stopWatch.Elapsed;
                //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                //    ts.Hours, ts.Minutes, ts.Seconds,
                //    ts.Milliseconds / 10);
                //Debug.WriteLine("Tiempo en encontrar el ratio " + elapsedTime);
                int customHeight = Math.Min((int)(ImageHeight * rat), m_capability.tabletMaxY);
                int customWidth = Math.Min((int)(ImageWidth * rat), m_capability.tabletMaxX);

                //Bitmap bitmap = GetImage(new Rectangle(0, 0, m_capability.screenWidth, m_capability.screenHeight));
                Bitmap bitmap = new Bitmap(customWidth, customHeight);
                Graphics graphics = Graphics.FromImage(bitmap);

                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //SolidBrush brush = new SolidBrush(Color.White);
                //graphics.FillRectangle(brush, 0, 0, customWidth, customHeight);
                bool isDown = false;
                Point lastPoint = new Point(0, 0);
                Rectangle m_actArea = new Rectangle();
                m_penInk.Width = ImageLineWidth;
                //Stopwatch stopWatch2 = new Stopwatch();
                //stopWatch2.Start();
                for (var i = 0; i < m_penTimeData.Count; i++)
                {
                    ProcessPoint(m_penTimeData[i], bitmap, graphics,ref isDown,ref lastPoint,ref m_actArea);
                }
                //TimeSpan ts2 = stopWatch2.Elapsed;
                //string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                //    ts2.Hours, ts2.Minutes, ts2.Seconds,
                //    ts2.Milliseconds / 10);
                //Debug.WriteLine($"{DateTime.Now} Tiempo en procesar puntos {elapsedTime2}");

                Bitmap target = ImageResizing(bitmap, m_actArea, ImageWidth, ImageHeight);
                using (System.IO.MemoryStream ms = new MemoryStream())
                {
                    target.Save(ms, ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    signature = Convert.ToBase64String(byteImage);
                    //m_penInk.Dispose();
                    //onSignatureReady(signature);
                    m_tablet.setInkingMode(0x00);
                    // We have to disable encryption before sending any image to the pad (even just to clear it)
                    if (m_useEncryption)
                        m_tablet.endCapture();

                    //m_tablet.setClearScreen();
                }
            }
            catch (Exception ex)
            {
                //Trace.TraceError("Exception: " + ex.Message);
                onErrorOcurred(ex.Message);
            }
        }
        private Bitmap ImageResizing(Bitmap srcImg,Rectangle ClippingArea, int Width, int Height)
        {
            int sourceWidth = ClippingArea.Width;
            int sourceHeight = ClippingArea.Height;
            int sourceX = ClippingArea.X;
            int sourceY = ClippingArea.Y;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            if(sourceWidth>0)
                nPercentW = ((float)Width / (float)sourceWidth);
            if(sourceHeight>0)
                nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap dstImg = new Bitmap(Width, Height);
            //dstImg.SetResolution(srcImg.HorizontalResolution,
            //                 srcImg.VerticalResolution);

            Graphics gpx = Graphics.FromImage(dstImg);
            //grPhoto.Clear(Color.Red);
            //grPhoto.InterpolationMode =InterpolationMode.HighQualityBicubic;

            gpx.DrawImage(srcImg,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            gpx.Dispose();
            return dstImg;
        }
        private double FindRatio()
        {
            //var points = m_penData;
            var points = m_penTimeData;
            Rectangle myArea=default;

            bool isDown = false;
            for (var i = 0; i < points.Count; i++)
            {
                var nextPoint = new Point();
                nextPoint.X = points[i].x;
                nextPoint.Y = points[i].y;
                var isDown2 = (isDown ? !(points[i].pressure <= m_inkThreshold.offPressureMark) : (points[i].pressure > m_inkThreshold.onPressureMark));

                if (isDown2)
                {
                    if (myArea == default)
                    {
                        myArea = new Rectangle(nextPoint.X, nextPoint.Y,0, 0);
                    }
                    if (nextPoint.X < myArea.X)
                    {
                        myArea.Width += myArea.X - nextPoint.X;
                        myArea.X = nextPoint.X;
                    }
                    if (nextPoint.Y < myArea.Y)
                    {
                        myArea.Height += myArea.Y - nextPoint.Y;
                        myArea.Y = nextPoint.Y;
                    }
                    if (nextPoint.X > myArea.X + myArea.Width)
                    {
                        myArea.Width = nextPoint.X - myArea.X;
                    }
                    if (nextPoint.Y > myArea.Y + myArea.Height)
                    {
                        myArea.Height = nextPoint.Y - myArea.Y;
                    }
                }
            }
            if (myArea.Width == 0 || myArea.Height == 0)
                return 1;
            return Math.Min(m_capability.tabletMaxX / myArea.Width, m_capability.tabletMaxY / myArea.Height);
        }

        private void ProcessPoint(wgssSTU.IPenDataTimeCountSequence point,Bitmap in_canvas,Graphics gfx, ref bool isDown, ref Point lastPoint,ref Rectangle m_actArea)
        {
            var nextPoint = new Point();
            nextPoint.X = (int)Math.Round((decimal)in_canvas.Width * point.x / m_capability.tabletMaxX);
            nextPoint.Y = (int)Math.Round((decimal)in_canvas.Height * point.y / m_capability.tabletMaxY);
            var isDown2 = (isDown ? !(point.pressure <= m_inkThreshold.offPressureMark) : (point.pressure > m_inkThreshold.onPressureMark));

            if (isDown2)
            {
                if (m_actArea.X == 0)
                {
                    m_actArea.X = nextPoint.X;
                    m_actArea.Y = nextPoint.Y;
                    m_actArea.Width = 0;
                    m_actArea.Height = 0;
                    //m_actArea = new Rectangle(nextPoint.X, nextPoint.Y,0, 0);
                }
                if (nextPoint.X < m_actArea.X)
                {
                    m_actArea.Width += m_actArea.X - nextPoint.X;
                    m_actArea.X = nextPoint.X;
                }
                if (nextPoint.Y < m_actArea.Y)
                {
                    m_actArea.Height += m_actArea.Y - nextPoint.Y;
                    m_actArea.Y = nextPoint.Y;
                }
                if (nextPoint.X > m_actArea.X + m_actArea.Width)
                {
                    m_actArea.Width = nextPoint.X - m_actArea.X;
                }
                if (nextPoint.Y > m_actArea.Y + m_actArea.Height)
                {
                    m_actArea.Height = nextPoint.Y - m_actArea.Y;
                }
            }

            if (!isDown && isDown2)
            {
                lastPoint = nextPoint;
            }
            if ((isDown2 && 10 < distance(lastPoint, nextPoint)) || (isDown && !isDown2))
            {
                gfx.DrawLine(m_penInk, lastPoint, nextPoint);
                lastPoint = nextPoint;
            }

            isDown = isDown2;
        }
        private double distance(Point a, Point b)
        {
            return Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2);
        }
    }
}
