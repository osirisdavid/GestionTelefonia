using System.Collections;
using System;

namespace GestionTelefoniaCable
{

    public class PlanCableTelefonia
    {
        private string nombre;
        private Telefonia telef;
        private CableVision cable;
        private static int contadorPlan;
        private int idPlan;

        public PlanCableTelefonia(string nombre, Telefonia telef, CableVision cable)
        {
            this.telef = telef;
            this.cable = cable;
            this.nombre = nombre;
            this.idPlan = ++PlanCableTelefonia.contadorPlan;
        }
        
        public int IdPlan{
            get{return this.idPlan;}
        }
        
        public Telefonia Telef{
            set{this.telef = value;}
            get{return this.telef;}
        }
        
        public CableVision Cable{
            set{this.cable = value;}
            get{return this.cable;}
        }
        
        public string Nombre{
            set{this.nombre = value;}
            get{return this.nombre;}
        }
        
        public override string ToString()
        {
            return string.Format("\n   Id Plan={0}\n   Nombre del Plan: {1}\n  {2}\n  {3}",
                                 idPlan, nombre, telef.ToString(), cable.ToString());
        }
    }
}       
