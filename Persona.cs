using System;

namespace GestionTelefoniaCable
{

    public class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        
        public Persona(string nombre, string apellido, int dni) {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }
        
        public string Nombre
        {
            set { nombre = value;}
            get { return nombre;}
            
        }
        
        public string Apellido
        {
            set {apellido = value;}
            get {return apellido;}
        }
        
        public int Dni
        {
            set {dni = value;}
            get {return dni;}
        }
    }
}
