using System;
using System.Collections;

namespace GestionTelefoniaCable
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            

            ControladorMenu menu = new ControladorMenu();
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            menu.seleccionarEventos();
            
            Console.ReadKey(true);
        }
    }
}



/*
            DateTime fechaActual = DateTime.Today;
            DateTime fechaLimite = new DateTime(2022, 6, 11);
            
            int result = DateTime.Compare(fechaLimite, fechaActual);
            
            Console.WriteLine(result);
            
            string relationship;
            if (result < 0)     //MAYOR A 0
                relationship = "fecha limite vencida";
            
            else if (result > 0)
                relationship = " No ha llegado a la fechaLimite ";
            
            else
                relationship = "hoy es el ultimo dia ";
            Console.WriteLine("fechalimite{0} {1} fechaActual{2}", fechaLimite , relationship, fechaActual);
 */

//Console.WriteLine(Validacion.pedirNumero("Ingrese Dni", 8));


//LotePrueba objetos = new LotePrueba();
//ArrayList periodos = ((Cliente)objetos.clientes[1]).PeriodosConsumos;

//Console.WriteLine (menu.hallarPeriodo(periodos).ToString());


/*private static void imprimirLocalidades(int pos){
			for (int i = 1; i < 8 ; i++) {
        		string miLocalidad = ((Localidad)i).ToString();
        		miLocalidad = miLocalidad.Replace('_', ' ');
        		Console.WriteLine(miLocalidad);
        	}
		}*/