using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.IO;
using Entidades.Parametrizacion;
using OfficeOpenXml;
using System.Collections;
using System.Diagnostics;
using Entidades.Parametrizacion;

namespace CapturaHuellaBanco.ControlesParametrizacion
{
    public partial class ctrlImportarExcel : UserControl
    {
        static LogErrores error = null;
        private Banco.ServicioBanco sb = new Banco.ServicioBanco();
        private Banco.ServicioParametrizacion Sp = new Banco.ServicioParametrizacion();
        private List<ErrorListaExcel> errorListaExcel = new List<ErrorListaExcel>();
        private frmBase _Base;
        public frmBase Base
        {
            get { return _Base; }
            set { _Base = value; }
        }

        List<Zona> zona = new List<Zona>();
        List<Oficina> oficina = new List<Oficina>();
        List<Usuario> usuario = new List<Usuario>();
        List<Rol> rol = new List<Rol>();
        List<Producto> producto = new List<Producto>();

        List<Zona> lstZonaExcel = new List<Zona>();
        private string EncabezadoZona = "Zona,Descripcion";

        List<Oficina> lstOficinaExcel = new List<Oficina>();
        private string EncabezadoOficina = "Oficina,Zona,Direccion,Codigo,Ciudad";

        List<Usuario> lstUsuarioExcel = new List<Usuario>();
        private string EncabezadoUsuario = "Login,Rol,Nombre,TipoIdentificacion,NumeroIdentificacion,Oficina,Cargo,Area";

        List<Producto> lstProductoExcel = new List<Producto>();
        private string EncabezadoProducto = "Producto,Descripcion";

        private string parametro;
        public string Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ctrlImportarExcel()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            RespuestaListas<Zona> Rlz = Sp.ConsultarTodosZonas(true);
            if (Rlz.Estado == Estado.Ok)
            {
                zona = Rlz.Lista;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rlz.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RespuestaListas<Oficina> Rlo = Sp.ConsultarTodosOficinas(true);
            if (Rlo.Estado == Estado.Ok)
            {
                oficina = Rlo.Lista;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rlo.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RespuestaListas<Usuario> Rlu = Sp.ConsultarTodosUsuarios(true);
            if (Rlu.Estado == Estado.Ok)
            {
                usuario = Rlu.Lista;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rlu.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RespuestaListas<Rol> Rlr = Sp.ConsultarTodosRoles(true);
            if (Rlr.Estado == Estado.Ok)
            {
                rol = Rlr.Lista;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rlr.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RespuestaListas<Producto> Rlp = Sp.ConsultarTodosProductos(true);
            if (Rlp.Estado == Estado.Ok)
            {
                producto = Rlp.Lista;
            }
            else
            {
                MessageBox.Show(/*Rl.CodigoError + ": " +*/ Rlp.DescripcionError, "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                this.ParentForm.Close();
                this.Hide();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "ImportarExcel";
                error.Metodo = "ctrlImportarExcel : btnCerrar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnBuscar_EventoClick(object sender, EventArgs e)
        {
            errorListaExcel = new List<ErrorListaExcel>();
            lstZonaExcel = new List<Zona>();
            lstOficinaExcel = new List<Oficina>();
            lstUsuarioExcel = new List<Usuario>();
            lstProductoExcel = new List<Producto>();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            dialog.Title = "Seleccione el archivo de Excel";
            dialog.FileName = string.Empty;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string pathToExcelFile = dialog.FileName;
                FileInfo Archivoxlsx = new FileInfo(pathToExcelFile);
                try
                {

                    using (ExcelPackage package = new ExcelPackage(Archivoxlsx))
                    {
                        ExcelWorksheet worksheet = Obtenerworksheet(package);
                        if (worksheet == null)
                            throw new Exception("El archivo no contiene el nombre de la hoja correcto.");

                        int rowEnd = worksheet.Dimension == null ? 0 : worksheet.Dimension.End.Row;
                        int maxCol = worksheet.Dimension == null ? 0 : worksheet.Dimension.End.Column;
                        int rowContent = 2;

                        if (rowEnd < rowContent)
                        {
                            throw new Exception("El archivo no contiene registros para cargar.");
                        }

                        try
                        {
                            ArrayList arrTitulo = CargarEncabezado();
                            if (!EsTituloValido(worksheet, arrTitulo))
                            {
                                throw new Exception("Se presento un inconveniente al cargar el archivo. El formato del archivo no es correcto. Los titulos del archivo (o el orden de los mismos) no coinciden con los esperados.");
                            }

                            while (rowContent <= rowEnd)
                            {
                                bool EsFilaValida = true;
                                for (int i = 1; i <= maxCol; i++)
                                {
                                    switch (parametro)
                                    {
                                        case "ctrlZona":
                                            EsFilaValida = ValidacionesZona(i, worksheet, rowContent, arrTitulo, ref EsFilaValida);
                                            break;
                                        case "ctrlOficina":
                                            EsFilaValida = ValidacionesOficina(i, worksheet, rowContent, arrTitulo, ref EsFilaValida);
                                            break;
                                        case "ctrlUsuario":
                                            EsFilaValida = ValidacionesUsuario(i, worksheet, rowContent, arrTitulo, ref EsFilaValida);
                                            break;
                                        case "ctrlProducto":
                                            EsFilaValida = ValidacionesProducto(i, worksheet, rowContent, arrTitulo, ref EsFilaValida);
                                            break;
                                    }
                                }

                                if (EsFilaValida)
                                {
                                    switch (parametro)
                                    {
                                        case "ctrlZona":
                                            AdicionarRegistroZona(worksheet, rowContent);
                                            break;
                                        case "ctrlOficina":
                                            AdicionarRegistroOficina(worksheet, rowContent);
                                            break;
                                        case "ctrlUsuario":
                                            AdicionarRegistroUsuario(worksheet, rowContent);
                                            break;
                                        case "ctrlProducto":
                                            AdicionarRegistroProducto(worksheet, rowContent);
                                            break;
                                    }
                                }

                                rowContent++;
                            }
                        }
                        catch (Exception ex)
                        {
                            error = new LogErrores();
                            error.UsuarioLogin = _Base.Usuario;
                            error.Capa = "ImportarExcel";
                            error.Metodo = "ctrlImportarExcel : btnBuscar_EventoClick";
                            error.Fecha = DateTime.Now;
                            error.Descripcion = ex.Message;
                            sb.InsertarLogError(error);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Buscar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (errorListaExcel.Count == 0)
                {
                    try
                    {
                        switch (parametro)
                        {
                            case "ctrlZona":
                                dgvLista.DataSource = lstZonaExcel;
                                dgvLista.Columns[1].HeaderText = "Zona";
                                dgvLista.Columns[2].HeaderText = "Descripción";
                                break;
                            case "ctrlOficina":
                                dgvLista.DataSource = lstOficinaExcel;
                                dgvLista.Columns[0].HeaderText = "Oficina";
                                dgvLista.Columns[1].HeaderText = "Zona";
                                dgvLista.Columns[2].HeaderText = "Dirección";
                                dgvLista.Columns[3].HeaderText = "Código";
                                dgvLista.Columns[4].HeaderText = "Ciudad";
                                break;
                            case "ctrlUsuario":
                                dgvLista.DataSource = lstUsuarioExcel;
                                dgvLista.Columns[0].HeaderText = "Login";
                                dgvLista.Columns[1].Visible = false;
                                dgvLista.Columns[2].HeaderText = "Rol";
                                dgvLista.Columns[3].HeaderText = "Nombre";
                                dgvLista.Columns[4].Visible = false;
                                dgvLista.Columns[5].HeaderText = "Tipo de Identificación";
                                dgvLista.Columns[6].HeaderText = "No. Identificación";
                                dgvLista.Columns[7].HeaderText = "Oficina";
                                dgvLista.Columns[8].Visible = false;
                                dgvLista.Columns[9].Visible = false;
                                dgvLista.Columns[10].Visible = false;
                                dgvLista.Columns[1].HeaderText = "Cargo";
                                dgvLista.Columns[12].HeaderText = "Área";
                                dgvLista.Columns[13].Visible = false;
                                dgvLista.Columns[14].Visible = false;
                                dgvLista.Columns[15].Visible = false;
                                dgvLista.Columns[16].Visible = false;
                                break;
                            case "ctrlProducto":
                                dgvLista.DataSource = lstProductoExcel;
                                dgvLista.Columns[0].Visible = false;
                                dgvLista.Columns[1].Visible = false;
                                dgvLista.Columns[2].Visible = false;
                                dgvLista.Columns[3].HeaderText = "Código";
                                dgvLista.Columns[4].HeaderText = "Descripción";
                                dgvLista.Columns[5].Visible = false;
                                break;
                        }
                        if (dgvLista.RowCount > 0)
                        {
                            btnPlantilla.Visible = false;
                            label1.Visible = false;
                            pnlRegistros.Visible = true;

                            label3.Text = "Exitosos";
                            btnGuardar.Visible = true;
                            //btnBuscar.Enabled = false;
                            MessageBox.Show("Los registros del documento se encuentran listos para ser almacenados correctamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se presento un inconveniente al guardar los datos el archivo. " + ex.Message);
                    }
                }
                else
                {
                    dgvLista.DataSource = errorListaExcel;
                    btnPlantilla.Visible = false;
                    label1.Visible = false;
                    pnlRegistros.Visible = true;
                    MessageBox.Show("Se presentan errores en el archivo validelos y cargue nuevamente.");
                }
            }

        }

        private void AdicionarRegistroZona(ExcelWorksheet worksheet, int rowContent)
        {
            Zona zonaExcel = new Zona();
            zonaExcel.IdZona = worksheet.Cells[rowContent, 1].Value.ToString().Trim();
            zonaExcel.Descripcion = worksheet.Cells[rowContent, 2].Value.ToString().Trim();
            lstZonaExcel.Add(zonaExcel);
        }

        private void AdicionarRegistroOficina(ExcelWorksheet worksheet, int rowContent)
        {
            Oficina oficinaExcel = new Oficina();
            oficinaExcel.IdOficina = worksheet.Cells[rowContent, 1].Value.ToString().Trim();
            oficinaExcel.IdZona = worksheet.Cells[rowContent, 2].Value.ToString().Trim();
            oficinaExcel.Direccion = worksheet.Cells[rowContent, 3].Value.ToString().Trim();
            oficinaExcel.Codigo = worksheet.Cells[rowContent, 4].Value.ToString().Trim();
            oficinaExcel.Ciudad = worksheet.Cells[rowContent, 5].Value.ToString().Trim();
            oficinaExcel.Habilitado = true;
            lstOficinaExcel.Add(oficinaExcel);
        }

        private void AdicionarRegistroUsuario(ExcelWorksheet worksheet, int rowContent)
        {
            Usuario usuarioExcel = new Usuario();
            usuarioExcel.IdUsuario = worksheet.Cells[rowContent, 1].Value.ToString().Trim();
            usuarioExcel.IdRol = rol.Where(r => r.Codigo.ToUpper() == worksheet.Cells[rowContent, 2].Value.ToString().Trim().ToUpper()).Single().IdRol;
            usuarioExcel.Rol = rol.Where(r => r.Codigo.ToUpper() == worksheet.Cells[rowContent, 2].Value.ToString().Trim().ToUpper()).Single().Codigo;
            usuarioExcel.Nombre = worksheet.Cells[rowContent, 3].Value.ToString().Trim();
            usuarioExcel.TipoIdentificacion = worksheet.Cells[rowContent, 4].Value.ToString().Trim();
            usuarioExcel.NumeroIdentificacion = worksheet.Cells[rowContent, 5].Value.ToString().Trim();
            usuarioExcel.IdOficina = worksheet.Cells[rowContent, 6].Value.ToString().Trim();
            usuarioExcel.Cargo = worksheet.Cells[rowContent, 7].Value.ToString().Trim();
            usuarioExcel.Area = worksheet.Cells[rowContent, 8].Value.ToString().Trim();
            usuarioExcel.usuario = _Base.Usuario;
            usuarioExcel.Habilitado = true;
            lstUsuarioExcel.Add(usuarioExcel);
        }

        private void AdicionarRegistroProducto(ExcelWorksheet worksheet, int rowContent)
        {
            Producto productoExcel = new Producto();
            productoExcel.IdServicio = 1;
            productoExcel.Codigo = worksheet.Cells[rowContent, 1].Value.ToString().Trim();
            productoExcel.Descripcion = worksheet.Cells[rowContent, 2].Value.ToString().Trim();
            productoExcel.Habilitado = true;
            lstProductoExcel.Add(productoExcel);
        }

        private ExcelWorksheet Obtenerworksheet(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
            if (parametro == "ctrlZona")
            {
                worksheet = package.Workbook.Worksheets["Zonas"];
            }
            else if (parametro == "ctrlOficina")
            {
                worksheet = package.Workbook.Worksheets["Oficinas"];
            }
            else if (parametro == "ctrlUsuario")
            {
                worksheet = package.Workbook.Worksheets["Usuarios"];
            }
            else if (parametro == "ctrlProducto")
            {
                worksheet = package.Workbook.Worksheets["Productos"];
            }
            return worksheet;
        }

        private bool ValidacionesZona(int i, ExcelWorksheet worksheet, int rowContent, ArrayList arrTitulo, ref bool EsFilaValida)
        {
            if (EsNuloOVacio(worksheet.Cells[rowContent, i].Value))
            {
                EsFilaValida = false;
                ErrorListaExcel errorExcel = new ErrorListaExcel();
                errorExcel.linea = rowContent;
                errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " No puede ser vacio.";
                errorListaExcel.Add(errorExcel);
            }
            else
            {
                if (i == 1 && zona.Exists(r => r.IdZona.ToUpper() == worksheet.Cells[rowContent, 1].Value.ToString().Trim().ToUpper()))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + " El registro ya éxiste en la BD.";
                    errorListaExcel.Add(errorExcel);
                }

                if (worksheet.Cells[rowContent, i].Value.ToString().Length > 100)
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " no puede ser mayor a 100 caracteres.";
                    errorListaExcel.Add(errorExcel);
                }
            }
            return EsFilaValida;
        }

        private bool ValidacionesOficina(int i, ExcelWorksheet worksheet, int rowContent, ArrayList arrTitulo, ref bool EsFilaValida)
        {
            if (EsNuloOVacio(worksheet.Cells[rowContent, i].Value))
            {
                EsFilaValida = false;
                ErrorListaExcel errorExcel = new ErrorListaExcel();
                errorExcel.linea = rowContent;
                errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " No puede ser vacio.";
                errorListaExcel.Add(errorExcel);
            }
            else
            {
                if (i == 1 && oficina.Exists(r => r.IdOficina.ToUpper() == worksheet.Cells[rowContent, 1].Value.ToString().Trim().ToUpper()))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + " El registro ya éxiste en la BD.";
                    errorListaExcel.Add(errorExcel);
                }

                if (i == 4 || i == 5)
                {
                    if (worksheet.Cells[rowContent, i].Value.ToString().Length > 50)
                    {
                        EsFilaValida = false;
                        ErrorListaExcel errorExcel = new ErrorListaExcel();
                        errorExcel.linea = rowContent;
                        errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " no puede ser mayor a 50 caracteres.";
                        errorListaExcel.Add(errorExcel);
                    }
                }
                else
                {
                    if (worksheet.Cells[rowContent, i].Value.ToString().Length > 100)
                    {
                        EsFilaValida = false;
                        ErrorListaExcel errorExcel = new ErrorListaExcel();
                        errorExcel.linea = rowContent;
                        errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " no puede ser mayor a 100 caracteres.";
                        errorListaExcel.Add(errorExcel);
                    }
                }

                if (i == 2 && !zona.Exists(r => r.IdZona.ToUpper() == worksheet.Cells[rowContent, 2].Value.ToString().Trim().ToUpper()))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + "Valide el valor del Campo " + arrTitulo[i - 1] + ", no corresponde a los registros de la BD.";
                    errorListaExcel.Add(errorExcel);
                }


            }
            return EsFilaValida;
        }

        private bool ValidacionesUsuario(int i, ExcelWorksheet worksheet, int rowContent, ArrayList arrTitulo, ref bool EsFilaValida)
        {
            if (EsNuloOVacio(worksheet.Cells[rowContent, i].Value))
            {
                EsFilaValida = false;
                ErrorListaExcel errorExcel = new ErrorListaExcel();
                errorExcel.linea = rowContent;
                errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " No puede ser vacio.";
                errorListaExcel.Add(errorExcel);
            }
            else
            {
                if (i == 1 && usuario.Exists(r => r.IdUsuario.ToUpper() == worksheet.Cells[rowContent, 1].Value.ToString().Trim().ToUpper()))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + " El registro ya éxiste en la BD.";
                    errorListaExcel.Add(errorExcel);
                }

                if (i == 4 || i == 5)
                {
                    if (worksheet.Cells[rowContent, i].Value.ToString().Length > 20)
                    {
                        EsFilaValida = false;
                        ErrorListaExcel errorExcel = new ErrorListaExcel();
                        errorExcel.linea = rowContent;
                        errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " no puede ser mayor a 20 caracteres.";
                        errorListaExcel.Add(errorExcel);
                    }
                }
                else if (i == 1)
                {
                    if (worksheet.Cells[rowContent, i].Value.ToString().Length > 50)
                    {
                        EsFilaValida = false;
                        ErrorListaExcel errorExcel = new ErrorListaExcel();
                        errorExcel.linea = rowContent;
                        errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " no puede ser mayor a 50 caracteres.";
                        errorListaExcel.Add(errorExcel);
                    }
                }
                else
                {
                    if (worksheet.Cells[rowContent, i].Value.ToString().Length > 100)
                    {
                        EsFilaValida = false;
                        ErrorListaExcel errorExcel = new ErrorListaExcel();
                        errorExcel.linea = rowContent;
                        errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " no puede ser mayor a 100 caracteres.";
                        errorListaExcel.Add(errorExcel);
                    }
                }

                if (i == 2 && !rol.Exists(r => r.Codigo.ToUpper() == worksheet.Cells[rowContent, 2].Value.ToString().Trim().ToUpper()))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + "Valide el valor del Campo " + arrTitulo[i - 1] + ", no corresponde a los registros de la BD.";
                    errorListaExcel.Add(errorExcel);
                }

                if (i == 4 && !EnumParametrizacion.TipoIdentificacion.IsDefined(typeof(EnumParametrizacion.TipoIdentificacion), worksheet.Cells[rowContent, 4].Value.ToString().Trim().ToUpper()))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + "Valide el valor del Campo " + arrTitulo[i - 1] + ", no corresponde a los registros de la BD.";
                    errorListaExcel.Add(errorExcel);
                }

                long number1 = 0;
                if (i == 5 && !long.TryParse(worksheet.Cells[rowContent, 5].Value.ToString(), out number1))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " debe ser numérico.";
                    errorListaExcel.Add(errorExcel);
                }

                if (i == 6 && !oficina.Exists(r => r.IdOficina.ToUpper() == worksheet.Cells[rowContent, 6].Value.ToString().Trim().ToUpper()))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + "Valide el valor del Campo " + arrTitulo[i - 1] + ", no corresponde a los registros de la BD.";
                    errorListaExcel.Add(errorExcel);
                }
            }
            return EsFilaValida;
        }

        private bool ValidacionesProducto(int i, ExcelWorksheet worksheet, int rowContent, ArrayList arrTitulo, ref bool EsFilaValida)
        {
            if (EsNuloOVacio(worksheet.Cells[rowContent, i].Value))
            {
                EsFilaValida = false;
                ErrorListaExcel errorExcel = new ErrorListaExcel();
                errorExcel.linea = rowContent;
                errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " No puede ser vacio.";
                errorListaExcel.Add(errorExcel);
            }
            else
            {
                if (i == 1 && producto.Exists(r => r.Codigo.ToUpper() == worksheet.Cells[rowContent, 1].Value.ToString().Trim().ToUpper()))
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + " El registro ya éxiste en la BD.";
                    errorListaExcel.Add(errorExcel);
                }

                if (i == 1 && worksheet.Cells[rowContent, i].Value.ToString().Length > 20)
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " no puede ser mayor a 20 caracteres.";
                    errorListaExcel.Add(errorExcel);
                }

                if (i == 2 && worksheet.Cells[rowContent, i].Value.ToString().Length > 100)
                {
                    EsFilaValida = false;
                    ErrorListaExcel errorExcel = new ErrorListaExcel();
                    errorExcel.linea = rowContent;
                    errorExcel.Descripcion = errorExcel.Descripcion + "El valor del Campo " + arrTitulo[i - 1] + " no puede ser mayor a 100 caracteres.";
                    errorListaExcel.Add(errorExcel);
                }
            }
            return EsFilaValida;
        }

        private ArrayList CargarEncabezado()
        {
            ArrayList arrTitulo = new ArrayList();
            switch (parametro)
            {
                case "ctrlZona":
                    arrTitulo = new ArrayList(EncabezadoZona.Split(','));
                    break;
                case "ctrlOficina":
                    arrTitulo = new ArrayList(EncabezadoOficina.Split(','));
                    break;
                case "ctrlUsuario":
                    arrTitulo = new ArrayList(EncabezadoUsuario.Split(','));
                    break;
                case "ctrlProducto":
                    arrTitulo = new ArrayList(EncabezadoProducto.Split(','));
                    break;
            }
            return arrTitulo;
        }

        private bool EsTituloValido(ExcelWorksheet worksheet, ArrayList arrTitulo)
        {
            bool resultado = true;

            for (int index = 0; index <= arrTitulo.Count - 1; index++)
            {
                if (EsNuloOVacio(worksheet.Cells[1, index + 1].Value) || worksheet.Cells[1, index + 1].Value.ToString().ToUpper() != arrTitulo[index].ToString().ToUpper())
                {
                    resultado = false;
                    break;
                }

            }
            return resultado;
        }

        public bool EsNuloOVacio(object cadena)
        {
            if (cadena != null && cadena.ToString().Trim().Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnGuardar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                switch (parametro)
                {
                    case "ctrlZona":
                        GuardarRegistroZona(lstZonaExcel);
                        break;
                    case "ctrlOficina":
                        GuardarRegistroOficina(lstOficinaExcel);
                        break;
                    case "ctrlUsuario":
                        GuardarRegistroUsuario(lstUsuarioExcel);
                        break;
                    case "ctrlProducto":
                        GuardarRegistroProducto(lstProductoExcel);
                        break;
                }

                MessageBox.Show("Se almacenaron correctamente los registros del archivo.");
                this.ParentForm.Close();
                this.Hide();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "ImportarExcel";
                error.Metodo = "ctrlImportarExcel : btnGuardar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }
        private void GuardarRegistroZona(List<Zona> lstZonaExcel)
        {
            try
            {
                foreach (Zona item in lstZonaExcel)
                {
                    Sp.CrearActualizarZona(item);
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "ImportarExcel";
                error.Metodo = "ctrlImportarExcel : GuardarRegistroZona";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void GuardarRegistroOficina(List<Oficina> lstOficinaExcel)
        {
            try
            {
                foreach (Oficina item in lstOficinaExcel)
                {
                    Sp.CrearActualizarOficina(item);
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "ImportarExcel";
                error.Metodo = "ctrlImportarExcel : GuardarRegistroOficina";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void GuardarRegistroUsuario(List<Usuario> lstUsuarioExcel)
        {
            try
            {
                foreach (Usuario item in lstUsuarioExcel)
                {
                    Sp.CrearActualizarUsuario(item);
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "ImportarExcel";
                error.Metodo = "ctrlImportarExcel : GuardarRegistroUsuario";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void GuardarRegistroProducto(List<Producto> lstProductoExcel)
        {
            try
            {
                foreach (Producto item in lstProductoExcel)
                {
                    Sp.CrearActualizarProducto(item);
                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "ImportarExcel";
                error.Metodo = "ctrlImportarExcel : GuardarRegistroProducto";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }

        private void btnPlantilla_EventoClick(object sender, EventArgs e)
        {
            try
            {
                string sourcePath = Directory.GetCurrentDirectory() + @"\Plantillas\";
                string fileName = "PlantillaCargueMasivo.xlsx";
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);

                string targetPath = @"C:\";
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    targetPath = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    return;
                }

                string destFile = System.IO.Path.Combine(targetPath, fileName);

                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                System.IO.File.Copy(sourceFile, destFile, true);

                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    foreach (string s in files)
                    {
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                        MessageBox.Show("Se ha descargo correctamente la plantilla.\r\nRecuerde que la ruta donde  se almaceno es: \r\n" + destFile, "Descargar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    throw new Exception("La ruta no existe, por favor verifique!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Descargar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "ImportarExcel";
                error.Metodo = "ctrlImportarExcel : btnPlantilla_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
            }
        }
    }

    internal class ErrorListaExcel
    {
        public int linea { get; set; }
        public string Descripcion { get; set; }
    }
}
