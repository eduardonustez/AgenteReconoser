// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Dispositivos.Implementaciones;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using SignalRHubs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Microsoft.AspNet.SignalR.Samples.Hubs.DemoHub
{
    [HubName("wacom")]
    public class WacomHub : Hub
    {
        private static wacomImplementation _objWacom = new wacomImplementation();
        private static List<ImageChunk> ImageChunks = new List<ImageChunk>();
        private static MemoryCache _cache = new MemoryCache("ImagesCache");
        private static string lastKeyImage = "";
        public void ConnectWacom()
        {
            try
            {
                if (_objWacom != null && _objWacom.IsConnected())
                {
                    _objWacom.DisconnectDevice();
                }
            }
            catch (Exception ex)
            {
                CustomHubLogger.LogException($"Método ConnectWacom {ex.Message}");
            }
            try
            {
                _objWacom = new wacomImplementation();
                _objWacom.SetListening(onButtonPressed, onErrorOcurred);
                CustomHubLogger.LogInformation("Se crea instancia de wgssSTU.Tablet");
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException($"Método ConnectWacom {e.Message}");
                throw new HubException(e.Message);
            }
        }
        public void SetCapturedImageSize(int height, int width, float lineWidth)
        {
            try
            {
                _objWacom.SetImageSize(height, width, lineWidth);
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException($"SetCapturedImageSize {e.Message}");
                throw new HubException(e.Message);
            }
        }

        public void DisconnectWacom()
        {
            try
            {
                if (_objWacom.IsConnected())
                {
                    _objWacom.DisconnectDevice();
                }
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException($"DisconnectWacom {e.Message}");
                throw new HubException(e.Message);
            }
        }
        public bool IsConnectedWacom()
        {
            return _objWacom.IsConnected();
        }
        public async Task<string> RequireSignature()
        {
            try
            {
                if (GetConnectionWacom())
                    return await _objWacom.GetImage();
                return null;
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException(e.Message);
                throw new HubException(e.Message);
            }
        }

        public void WriteImage(ImageChunk bigImage)
        {
            try
            {
                if (!GetConnectionWacom())
                    return;
                if (ImageChunks.Count > 0 && bigImage.Id != ImageChunks.FirstOrDefault().Id)
                    ImageChunks.Clear();
                ImageChunks.Add(bigImage);
                if (bigImage.IsLast)
                {
                    int size = ImageChunks.Sum(i => i.Bytes.Length);
                    byte[] bytes = new byte[size];
                    int indexDst = 0;
                    ImageChunks.ForEach(i =>
                    {
                        Buffer.BlockCopy(i.Bytes, 0, bytes, indexDst, i.Bytes.Length);
                        indexDst += i.Bytes.Length;
                    }
                    );
                    _objWacom.writeImage(Convert.ToBase64String(bytes));
                    ImageChunks.Clear();
                }
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException($"WriteImage {e.Message}");
                throw new HubException(e.Message);
            }
        }
        public void WriteImageFromCache(string keyImage,bool force=false)
        {
            try
            {
                
                var bytes = (byte[]) _cache.Get(keyImage);
                if (bytes != null && (lastKeyImage != keyImage || force==true))
                {
                    _objWacom.writeImage(Convert.ToBase64String(bytes));
                    lastKeyImage = keyImage;
                }
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException($"WriteImage {e.Message}");
                throw new HubException(e.Message);
            }
        }
        public void AddImage(string keyImage, byte[] image)
        {
            if (!_cache.Contains(keyImage))
            {
                _cache.Add(keyImage, image, DateTimeOffset.Now.AddDays(1));
            }
        }
        public async Task<bool> ImageExist(string keyName)
        {
            return _cache.Contains(keyName);
        }
        public void SetInkingMode(byte inkingMode)
        {
            try
            {
                if (GetConnectionWacom())
                    _objWacom.SetInkingMode(inkingMode);
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException($"SetInkingMode {e.Message}");
                throw new HubException(e.Message);
            }
        }
        public void AddButtons(string botonesJson, bool habilitarFirma)
        {
            try
            {
                if (GetConnectionWacom())
                {
                    var botones = JsonConvert.DeserializeObject<Rectangle[]>(botonesJson);
                    _objWacom.AddButtons(botones, habilitarFirma);
                }
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException($"AddButtons {e.Message}");
                throw new HubException(e.Message);
            }

        }

        private void onButtonPressed(int btn)
        {
            Clients.Caller.onButtonPressed(btn);
        }
        private void onSignatureReady(string capturedSignature)
        {
            Clients.Caller.onSignatureReady(capturedSignature);
        }
        private void onErrorOcurred(string msgError)
        {
            Clients.Caller.onErrorOcurred(msgError);
        }
        private bool GetConnectionWacom()
        {
            if (_objWacom.IsConnected())
            {
                return tryConnection();
            }
            try
            {
                _objWacom.ConnectDevice();
                _objWacom.SetListening(onButtonPressed, onErrorOcurred);
                return true;
            }
            catch (Exception e)
            {
                CustomHubLogger.LogException($"GetConnectionWacom {e.Message}");
            }
            return false;
        }
        private bool tryConnection()
        {
            string errorMessage = "";
            try
            {
                var wacomStatus = _objWacom.GetStatus();
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
                if (e.Message == "device_removed_error")
                {
                    _objWacom.ConnectDevice();
                    _objWacom.SetListening(onButtonPressed, onErrorOcurred);
                }
            }
            return errorMessage == "";
        }
        public class ImageChunk
        {
            public Guid Id { get; set; }
            public byte[] Bytes { get; set; }
            public bool IsLast { get; set; }
        }
    }


}
