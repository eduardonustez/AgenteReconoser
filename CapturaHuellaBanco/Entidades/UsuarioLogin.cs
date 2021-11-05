using System;
using System.Drawing;

namespace Entidades
{
    public class UsuarioLogin
    {
        private string _CodigoRol;
        private string _DisplayName;
        private string _Dominio;
        private bool _EsValido;
        private long _IdAutenticacion;
        private string _IdOficina;
        private int _IdRol;
        private Bitmap _Imagen;
        private string _Mail;
        private string _Title;
        private string _Usuario;

        public string CodigoRol
        {
            get { return _CodigoRol; }
            set { _CodigoRol = value; }
        }

        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        public string Dominio
        {
            get { return _Dominio; }
            set { _Dominio = value; }
        }

        public bool EsValido
        {
            get { return _EsValido; }
            set { _EsValido = value; }
        }

        public long IdAutenticacion
        {
            get { return _IdAutenticacion; }
            set { _IdAutenticacion = value; }
        }

        public string IdOficina
        {
            get { return _IdOficina; }
            set { _IdOficina = value; }
        }

        public int IdRol
        {
            get { return _IdRol; }
            set { _IdRol = value; }
        }

        public Bitmap Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
    }

    public class UsuarioLoginCache
    {
        private DateTime _Fecha;
        private string _IP;
        private string _Login;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }
    }
}