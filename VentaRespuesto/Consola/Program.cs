using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Libreria;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const int minMenu= 1;
            const int maxMenu = 7;
            string menu = "***************** Menu *****************\n\n";
            menu += "Opciones:\n\n1. Agregar repuesto\n2. Modificar repuesto\n3. Eliminar repuesto\n4. Agregar stock\n5. Quitar stock\n6. Listar repuestos por categoria\n7. Salir";
            int opcion;

            VentaRespuestos venta = new VentaRespuestos("Repuestos Gerli","Donovan y Camino General Chamizo, Gerli");
            CargaInicialCatalogo(venta);

            do
            {
                Console.Clear();
                Console.WriteLine(menu);
                opcion = Validaciones.Entero("una opcion", minMenu, maxMenu);
                switch (opcion)
                {
                    case 1:
                        AgregarRepuesto(venta);
                        break;
                    case 2:
                        ModificarRepuesto(venta);
                        break;
                    case 3:
                        EliminarRepuesto(venta);
                        break;
                    case 4:
                        AgregarStock(venta);
                        break;
                    case 5:
                        QuitarStock(venta);
                        break;
                    case 6:
                        ListarRepuestos(venta);
                        break;
                    case 7:
                        Console.WriteLine("Saliendo......");
                        break;

                }
                Console.WriteLine("\nEnter para continuar.....");
                Console.ReadKey();
            } while (opcion != 7);            
        }

        public static void AgregarRepuesto(VentaRespuestos venta)
        {
            string nombre = Validaciones.Texto("nombre");
            double precio = Validaciones.Importe("precio",0,9999999);
            Console.WriteLine("Categorias\n" + venta.TraerCategorias());
            int codigo = Validaciones.Entero("codigo de categoria", 1, venta.CapacidadCategorias());

            try
            {
                venta.AgregarRespuesto(nombre, precio, codigo);
                Console.WriteLine("El repuesto se agrego con exito!");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }

        }
        public static void ModificarRepuesto(VentaRespuestos venta)
        {
            Console.WriteLine(venta.TraerCategorias());
            int codCategoria = Validaciones.Entero("categoria de producto a editar", venta.CodigoCategoriaInicial, venta.CodigoCategoriaFinal);
            List<Repuesto> productos = venta.TraerPorCategoria(codCategoria);

            if (productos.Count == 0)
                Console.WriteLine("No hay productos con esa categoria");
            else
            {
                foreach (Repuesto a in productos)
                    Console.WriteLine(a.ToString());
            
                try
                {
                    venta.ModificarPrecio(Validaciones.Entero("codigo producto", venta.CodigoRepuestoInicial, venta.CodigoRepuesto),
                        Validaciones.Importe("nuevo importe", 0, 999999));
                    Console.WriteLine("Importe modificado exitosamente.");
                }
                catch (NoEncuentraCodigoException e)
                {
                    Console.WriteLine("ERROR - " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR - " + e.Message);
                }
            }


        }
        public static void EliminarRepuesto(VentaRespuestos venta)
        {
            Console.WriteLine(venta.TraerProductos());
            try
            { 
                venta.QuitarRepuesto(Validaciones.Entero("codigo producto a eliminar",venta.CodigoRepuestoInicial,venta.CodigoRepuesto));
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            catch (NoEncuentraCodigoException e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }
            catch (TieneStockException e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }
        }
        public static void AgregarStock(VentaRespuestos venta)
        {
            Console.WriteLine(venta.TraerProductos());
            try
            {
                venta.AgregarStock(Validaciones.Entero("codigo producto a agregar stock", venta.CodigoRepuestoInicial, venta.CodigoRepuesto),Validaciones.Entero("cantidades",1,999999));
                Console.WriteLine("El stock se agrego exitosamente.");
            }
            catch (NoEncuentraCodigoException e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }            
            catch (Exception e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }
        }
        public static void QuitarStock(VentaRespuestos venta)
        {
            Console.WriteLine(venta.TraerProductos());
            try
            {
                venta.QuitarStock(Validaciones.Entero("codigo producto a quitar stock", venta.CodigoRepuestoInicial, venta.CodigoRepuesto), Validaciones.Entero("cantidades", 1, 999999));
                Console.WriteLine("El stock quitado exitosamente.");
            }
            catch (NoEncuentraCodigoException e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }
            catch (StockNegativoException e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }
        }
        public static void ListarRepuestos(VentaRespuestos venta)
        {
            Console.WriteLine(venta.TraerCategorias());
            int codCategoria = Validaciones.Entero("categoria de producto", venta.CodigoCategoriaInicial, venta.CodigoCategoriaFinal);
            List<Repuesto> productos = venta.TraerPorCategoria(codCategoria);

            if (productos.Count == 0)
                Console.WriteLine("No hay productos con esa categoria");
            else
            {
                foreach (Repuesto a in productos)
                    Console.WriteLine(a.ToString());
            }
        }
        public static void CargaInicialCatalogo(VentaRespuestos venta)
        {
            venta.CargaInicialCategoria("Frenos");
            venta.CargaInicialCategoria("Tren delantero");
            venta.CargaInicialCategoria("Motor");
            venta.CargaInicialCategoria("Bateria");

            venta.AgregarRespuesto("Pastillas freno Chrevrolet", 1500, 1);
            venta.AgregarRespuesto("Pastillas freno Ford", 2500, 1);
            venta.AgregarRespuesto("Amortiguadores Chrevrolet", 5000, 2);
            venta.AgregarRespuesto("Amortiguadores Ford", 8000, 2);
            venta.AgregarRespuesto("Levas Chrevrolet", 1500, 3);
            venta.AgregarRespuesto("Carter freno Ford", 2500, 3);
            venta.AgregarRespuesto("Mouras", 5000, 4);
            venta.AgregarRespuesto("AC delco", 5500, 4);
        }
    }
}
