using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Repuesto
    {
        int _codigo;
        string _nombre;
        double _precio;
        int _stock;
        Categoria _categoria;

        public Repuesto(int codigo, string nombre, double precio, Categoria categoria)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._precio = precio;
            this._stock = 0;
            this._categoria = categoria;
        }
        public int Codigo
        {
            get { return this._codigo; }
        }
        public int Stock
        {
            get { return this._stock; }
            set { this._stock = value; }
        }
        public double Precio
        {
            get { return this._precio; }
            set { this._precio = value; }
        }
        public Categoria Categoria
        {
            get { return this._categoria; }
        }
        public override string ToString()
        {
            return string.Format("Codigo {0} - {1} \t Precio: ${2}\tStock: {3} - Categoria: {4} - {5}",
                this._codigo,this._nombre,this._precio.ToString("0.##"),this._stock,this._categoria.Codigo,this._categoria.Nombre);
        }
    }
}
