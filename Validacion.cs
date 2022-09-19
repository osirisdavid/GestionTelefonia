
using System;


namespace GestionTelefoniaCable
{
    public class Validacion
    {
        public Validacion()
        {
        }
        
        private static bool esNumero (string digitos){
            char digito;
            bool esDigito = true;
            for(int i = 0; i < digitos.Length; i++){
                digito = (char)digitos[i];
                if(char.IsDigit(digito) == false){
                    esDigito = false;
                    break;
                }
            }
            if(digitos.Length == 0)
                esDigito = false;
            return esDigito;
        }
        
        private static bool esDecimal (string digitos){
            char digito;
            bool esDigito = true;
            for(int i = 0; i < digitos.Length; i++)
            {
                digito = (char)digitos[i];
                if(char.IsDigit(digito) == false)
                {
                    if(digito !='.'){
                        esDigito = false;
                        break;
                    }
                }
                
            }
            if(digitos.Length == 0)
                esDigito = false;
            return esDigito;
        }
        
        
        public static int pedirNumeroEntero(string msj)
        {
            Console.Write(msj);
            string caracteres = Console.ReadLine();
            while (Validacion.esNumero(caracteres) == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error. Vuelva a intentarlo.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(msj);
                caracteres = Console.ReadLine();
            }
            int numero = int.Parse(caracteres);
            return numero;
        }
        
        public static int pedirNumeroEntero(string msj, int cantidadDigitos)
        {
            Console.Write(msj);
            string caracteres = Console.ReadLine();
            while (Validacion.esNumero(caracteres) == false || cantidadDigitos != caracteres.Length)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error. Vuelva a intentarlo.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(msj);
                caracteres = Console.ReadLine();
            }
            int numero = int.Parse(caracteres);
            return numero;
        }
        
        public static int pedirNumeroEntero(string msj, int inicioDeRango, int finDeRango)
        {
            int numero = pedirNumeroEntero(msj);
            while (numero < inicioDeRango || numero > finDeRango)
            {
                numero = pedirNumeroEntero(msj);
            }
            return numero;
        }
        
        public static double pedirDecimal(string msj){
            Console.Write(msj);
            string caracteres = Console.ReadLine();
            while (Validacion.esDecimal(caracteres) == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error. Vuelva a intentarlo.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(msj);
                caracteres = Console.ReadLine();
            }
            double numero = double.Parse(caracteres);
            return numero;
        }
    }
}
