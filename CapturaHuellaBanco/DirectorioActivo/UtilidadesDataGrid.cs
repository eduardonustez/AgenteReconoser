using System.Drawing;
using System.Windows.Forms;

namespace Utilidades
{
    public class UtilidadesDataGrid
    {
        public static DataGridView EstiloGrid(DataGridView dgv)
        {
            dgv.AllowUserToResizeRows = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.InactiveCaption;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(58, 73, 95);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(58, 73, 95);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.DimGray;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgv.RowHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersVisible = false;
            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            return dgv;
        }

        public static DataGridView EstiloGridDetalle(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoGenerateColumns = false;
            dgv.ScrollBars = ScrollBars.Horizontal;
            dgv.AllowUserToResizeRows = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.InactiveCaption;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(58, 73, 95);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.DimGray;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgv.RowHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dgv.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersVisible = false;
            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            return dgv;
        }
    }
}