using System;

namespace GestionTelefoniaCable
{
	
	public class Factura
	{
		private int numero;
		private PeriodoConsumo periodoConsu;
		private double montoPlanSinDesc;
		private double bonificacion;
		private double montoFinalPagar;
		private int idFactura;
		private static int contadorFactura;
		
		
		public Factura(int numero, PeriodoConsumo periodo)
		{
			this.idFactura = ++ Factura.contadorFactura;
			this.numero = numero;
			this.periodoConsu = periodo;
			this.montoPlanSinDesc = (periodo.PlanFinal.Plan.Telef.CostoMinuto*periodo.PlanFinal.Plan.Telef.Minutos) + periodo.PlanFinal.Plan.Cable.Precio;
			this.bonificacion = montoBonificacion();
			this.montoFinalPagar = montoPlanSinDesc - this.bonificacion;
		}
		
		//metodo es privado y solo se utiliza cuando se llama al costructor
		private double descuentoPromocion()
		{
			/*    Cantidad de minutos maximos que puede consumir el cliente
			      para que se le aplique la promocion del 15%               */
			double minutosMax = (periodoConsu.PlanFinal.Plan.Telef.Minutos*85)/100;
			
			if(periodoConsu.MinutosConsumidos <= minutosMax)
			{
				return 15;
			}
			else{
				return 0;
			}
		}
		
		/*Generar el monto a pagar con el descuento si es que corresponde*/
		private double montoBonificacion()
		{
			return ((montoPlanSinDesc * descuentoPromocion())/100);
		}
		public double Bonificacion{
		    get{return this.bonificacion;}
		}
		
		public int Numero{
			set{this.numero = value;}
			get{return this.numero;}
		}
		
		public double MontoFinalPagar{
			get{return this.montoFinalPagar;}
		}
		
		public double MontoPlanSinDesc{
		    set{this.montoPlanSinDesc = value;}
			get{return this.montoPlanSinDesc;}
		}
		
		public int IdFactura{
			get{return this.idFactura;}
		}
		
		public PeriodoConsumo PeriodoConsu{
		    set{this.periodoConsu = value;}
		    get{return this.periodoConsu;}
		}

		public override string ToString()
		{
			return string.Format("Factura IdFactura: {0}   \nNumero: {1} \n{2}" +
			                     "\n							" +
			                     "MontoOriginal: ${3} "+
			                     "\n							" +
			                     "Bonificacion: ${4} "+
			                     "\n							" +
			                     "MontoFinalPagar: ${5} ",
			                     idFactura, numero, periodoConsu, this.montoPlanSinDesc, bonificacion, montoFinalPagar);
		}
		
	}
}

