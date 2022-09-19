using System;
using System.Collections;

namespace GestionTelefoniaCable
{
    public class ComboPlus
	{
		
		private DateTime fechaLimite;
		private int cupoDispinible;
		private ArrayList canalesEspeciales;
		private int idComboPlus;
		private static int contadorComboPlus;
		
		public ComboPlus()
		{
			this.canalesEspeciales = new ArrayList();
			this.idComboPlus = ++ComboPlus.contadorComboPlus;
		}
		
		public ComboPlus(DateTime fechaLimite, int cupos)
		{
			this.fechaLimite = fechaLimite;
			this.cupoDispinible = cupos;
			canalesEspeciales = new ArrayList();
			this.idComboPlus = ++ComboPlus.contadorComboPlus;
		}

		public ArrayList CanalesEspeciales{
			get{return this.canalesEspeciales;}
		}
		
		public DateTime FechaLimite{
			set{this.fechaLimite = value;}
			get{return this.fechaLimite;}
		}
		
		public int CupoDispinible{
			set{this.cupoDispinible = value;}
			get{return this.cupoDispinible;}
		}
		
		public int IdComboPlus{
			get{return this.idComboPlus;}
		}
		
		public void agregarCanalPlus(Canal canal){
			this.canalesEspeciales.Add(canal);
		}
		public void eliminarCanalPlus(Canal canal){
			this.canalesEspeciales.Remove(canal);
		}
		
		private string retornarCanalesEspeciales(){
		    string canales = "";
		    foreach (Canal canal in canalesEspeciales) {
		        canales += canal.Nombre + ", ";
		    }
		    return canales;
		}
		
		public override string ToString()
        {
		    return string.Format("ComboPlus \n   FechaLimite: {0} \n   Cupo disponibles: {1},\n   Canales: {2}", 
		                                           fechaLimite, cupoDispinible, retornarCanalesEspeciales());
        }

		
	}
}
