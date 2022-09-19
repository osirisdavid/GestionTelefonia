using System;
using System.Collections;

namespace GestionTelefoniaCable
{
	
	public class CableVision
	{
		
		private double precio;
		private ArrayList canalesHD;
		
		private static int contadorCableVision;
		private int idCableVision;
		
		
		public CableVision()
		{
			this.idCableVision = ++CableVision.contadorCableVision;
			this.canalesHD = new ArrayList();
		}
		
		public CableVision(double precio){
			this.precio = precio;
			this.idCableVision = ++CableVision.contadorCableVision;
			canalesHD = new ArrayList();
		}
		
		public ArrayList CanalesHD{
			get{return this.canalesHD;}
		}
		
		public double Precio{
			set{this.precio = value;}
			get{return this.precio;}
		}
		
		public int IdCableVision{
			get{return this.idCableVision;}
		}
		
		public void agregarCanal(Canal canal){
			this.canalesHD.Add(canal);
		}
		
		public void eliminarCanal(Canal canal){
			this.canalesHD.Remove(canal);
		}
		
		public override string ToString()
		{
			return string.Format("CableVision:\n      Id CableVision: {0}\n      Cantidad Canales HD: {1}\n      PrecioCable:_________________________${2}", 
			                     this.idCableVision, this.canalesHD.Count, this.precio);
		}

		
	}
}

