using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class VentaRespuestos
    {
        List<Repuesto> _listaProductos;
        string _nombreComercio;
        string _direccion;

        public VentaRespuestos(string nombre, string direccion)
        {
            _listaCategoria = new List<Categoria>();
            _listaProductos = new List<Repuesto>();
            this._nombreComercio = nombre;
            this._direccion = direccion;
            this._CodigoCategoria = 0;
            this._CodigoRespuesto = 1000;
            this._CodigoCategoriaInicial = _CodigoCategoria;
            this._CodigoRespuestoInicial = _CodigoRespuesto;
        }

        public void AgregarRespuesto(Repuesto repuesto)
        {
            this._listaProductos.Add(repuesto);
        }
        public void AgregarRespuesto(string nombre,double precio, int codcategoria)
        {
            Repuesto repuesto = new Repuesto(this.ProximoCodigoRepuesto(),nombre,precio,this.TraerCategoriaPorCodigo(codcategoria));
            this.AgregarRespuesto(repuesto);
        }
        public void QuitarRepuesto(int numero)
        {
            Repuesto repuesto = this._listaProductos.SingleOrDefault(x => x.Codigo == numero);

            if (repuesto == null)
                throw new NoEncuentraCodigoException("El producto no se encuentra para eliminar");
            if (repuesto.Stock > 0)
                throw new TieneStockException("No se puede eliminar porque tiene stock de " + repuesto.Stock);
            else
                this._listaProductos.Remove(repuesto);
            
        }
        public void ModificarPrecio(int numero, double importe)
        {
            Repuesto repuesto = this._listaProductos.SingleOrDefault(X => X.Codigo == numero);
            if (repuesto == null)
                throw new NoEncuentraCodigoException("No se encuentra el codigo ingresado. reintente");
            else
            {
                repuesto.Precio = importe;
            }
        }
        public void AgregarStock(int numero, int stock)
        {
            Repuesto repuesto = this._listaProductos.SingleOrDefault(X => X.Codigo == numero);
            if (repuesto == null)
                throw new NoEncuentraCodigoException("No se encuentra el codigo ingresado. reintente");
            else
            {
                repuesto.Stock+= stock;
            }
        }
        public void QuitarStock(int numero, int stock)
        {
            Repuesto repuesto = this._listaProductos.SingleOrDefault(X => X.Codigo == numero);
            if (repuesto == null)
                throw new NoEncuentraCodigoException("No se encuentra el codigo ingresado. reintente");
            if (repuesto.Stock < stock)
                throw new StockNegativoException("No puede quedar el stock en negativo. Cantidades disponibles: " + repuesto.Stock);
            else
                repuesto.Stock -= stock;
            
        }
        public List<Repuesto> TraerPorCategoria(int numero)
        {
            List<Repuesto> retorno = new List<Repuesto>();
            foreach (Repuesto a in _listaProductos)
            {
                if (a.Categoria.Codigo == numero)
                    retorno.Add(a);
            }
            return retorno;
        }

        public string TraerProductos()
        {
            string retorno = "";
            foreach (Repuesto a in _listaProductos)
                retorno +="\n"+ a.ToString();
            return retorno;
        }

        //Agrego lista de categoria para poder usarla en opcion.
        int _CodigoRespuesto;
        int _CodigoCategoria;
        int _CodigoRespuestoInicial;
        int _CodigoCategoriaInicial;
        List<Categoria> _listaCategoria;
        Categoria categoria;
        public string TraerCategorias()
        {
            string retorno="";
            foreach (Categoria a in _listaCategoria)
            {
                retorno += "\n" + a.ToString();
            }
            return retorno;
        }
        public int CapacidadCategorias()
        {
            return this._listaCategoria.Count;
        }
        public int ProximoCodigoRepuesto()
        {
            return this._CodigoRespuesto += 1;
        }
        public int ProximoCodigoCategoria()
        {
            return this._CodigoCategoria += 1;
        }
        public Categoria TraerCategoriaPorCodigo(int codigo)
        {
            Categoria retorno=null;
            foreach (Categoria a in _listaCategoria)
            {
                if(a.Codigo == codigo)
                    retorno = a;
            }
            return retorno;
        }
        public void CargaInicialCategoria(string nombre)
        {
            this._listaCategoria.Add(new Categoria(this.ProximoCodigoCategoria(), nombre));
        }
        public int CodigoRepuestoInicial
        {
            get { return this._CodigoRespuestoInicial+1; }
        }
        public int CodigoRepuesto
        {
            get { return this._CodigoRespuesto; }
        }
        public int CodigoCategoriaInicial
        {
            get { return this._CodigoCategoriaInicial+1; }
        }
        public int CodigoCategoriaFinal
        {
            get { return this._CodigoCategoria; }
        }
    }
}
