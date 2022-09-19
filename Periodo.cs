
using System;

namespace GestionTelefoniaCable
{

    public class Periodo
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;
        
        public Periodo()
        { 
        }
        
        public Periodo(DateTime fechaInicio, DateTime fechaFin){
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
        }
        
        public DateTime FechaInicio{
            set{this.fechaInicio = value;}
            get{return this.fechaInicio;}
        }
        
        public DateTime FechaFin{
            set{this.fechaFin = value;}
            get{return this.fechaFin;}
        }
        
        public override string ToString()
        {
            return string.Format("Periodo FechaInicio: {0}, FechaFin: {1}", fechaInicio, fechaFin);
        }

    }
}
