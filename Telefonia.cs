using System;

namespace GestionTelefoniaCable
{
	
	public class Telefonia
	{
		private double minutos;
		private double costoMinuto;
		
		private static int contadorTelefonia;
		private int idTelefonia;
		
		public Telefonia()
		{
			this.idTelefonia = ++Telefonia.contadorTelefonia;
		}
		
		public Telefonia(double minutos, double costoMinuto)
		{
			this.idTelefonia = ++Telefonia.contadorTelefonia;
			this.minutos = minutos;
			this.costoMinuto = costoMinuto;
		}
		
		public double Minutos{
			set{this.minutos = value;}
			get{return this.minutos;}
		}
		
		public double CostoMinuto{
			set{this.costoMinuto = value;}
			get{return this.costoMinuto;}
		}
		
		public int IdTelefonia{
			get{return this.idTelefonia;}
		}

		
		public override string ToString()
		{
			return string.Format("Telefonia\n      Id Telefonia: {0}\n      Minutos: {1}, CostoMinuto: ${2} \n      Costo Total Telefonia:_______________${3}", 
		                         idTelefonia, minutos, costoMinuto, (minutos*costoMinuto));
		}

	}
}

