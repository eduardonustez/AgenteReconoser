using System;
using System.Windows.Forms;

namespace Utilidades
{
    public class Excel
    {
        public static void ExportarExcel(DataGridView dgv, string ruta)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workbook.Sheets[1];
                worksheet = workbook.ActiveSheet;

                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value != null)
                        {
                            if (dgv.Rows[i].Cells[j].ValueType.Name == "Bitmap" || dgv.Rows[i].Cells[j].ValueType.Name == "Image")
                            {
                                var obj = (System.Drawing.Bitmap)dgv.Rows[i].Cells[j].Value;
                                try
                                {
                                    worksheet.Cells[i + 2, j + 1] = obj.Tag.ToString();
                                }
                                catch
                                {
                                    worksheet.Cells[i + 2, j + 1] = "";
                                }
                            }
                            else
                            {
                                if (dgv.Columns[j].Name == "FechaExpedicion")
                                {
                                    try
                                    {
                                        DateTime fechaExo = Convert.ToDateTime(dgv.Rows[i].Cells[j].Value);
                                        if (fechaExo.Hour > 0)
                                        {
                                            //Fue No Hit
                                            worksheet.Cells[i + 2, j + 1] = "";
                                        }
                                        else
                                        {
                                            worksheet.Cells[i + 2, j + 1] = fechaExo.ToShortDateString();
                                        }
                                    }
                                    catch
                                    {
                                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                else
                                {
                                    worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = "";
                        }
                    }
                }

                worksheet.SaveAs(ruta);
                app.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}