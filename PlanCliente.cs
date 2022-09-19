using System;
using System.Collections;

namespace GestionTelefoniaCable
{
    public class PlanCliente
    {
        private ArrayList canalesComboPlus;
        private PlanCableTelefonia plan;
        
        public PlanCliente ()
        {
            canalesComboPlus = new ArrayList();
        }
        
        public PlanCliente (PlanCableTelefonia plan)
        {
            canalesComboPlus = new ArrayList();
            this.plan = plan;
        }
        
        public PlanCliente(ComboPlus comboPlus, PlanCableTelefonia plan)
        {
            canalesComboPlus = new ArrayList();
            for (int i = 0; i < comboPlus.CanalesEspeciales.Count; i++) {
                canalesComboPlus.Add(comboPlus.CanalesEspeciales[i]);
            }
            this.plan = plan;
        }

        public ArrayList CanalesComboPlus{
            get{return this.canalesComboPlus;}
        }
        
        public PlanCableTelefonia Plan{
            set{this.plan = value;}
            get{return this.plan;}
        }
        
        public void agregarCanalComboPlus(Canal canal){
            this.canalesComboPlus.Add(canal);
        }
        public void eliminarCanalComboPlus(Canal canal){
            this.canalesComboPlus.Remove(canal);
        }

        public string retornaNombreCanalesEspeciales(){
            string listaCanales = "";
            if(canalesComboPlus.Count == 0)
                listaCanales = "No tiene ComboPlus";
            foreach (Canal canal in canalesComboPlus) {
                listaCanales += canal.Nombre.ToString() + ", ";
            }
            return listaCanales;
        }
        
        public override string ToString()
        {
            return string.Format("{0}\n{1}", plan.ToString(), 
                                 "Canales del Combo Plus: " + retornaNombreCanalesEspeciales());
        }

    }
}
