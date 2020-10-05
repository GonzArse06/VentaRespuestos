using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Categoria
    {
        int _codigo;
        string _nombre;

        public Categoria(int codigo, string nombre)
        {
            this._codigo = codigo;
            this._nombre = nombre;
        }

        public int Codigo { get { return this._codigo; } set { this._codigo = value; } }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }

        public override string ToString()
        {
            return string.Format("Codigo: {0} - {1}",this._codigo,this._nombre);
        }
    }
}
