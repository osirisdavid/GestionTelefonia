using System;

namespace GestionTelefoniaCable
{
	public class Direccion
	{
		private string calle;
		private string numero;
		private Localidad localidadCliente;

		public Direccion(string calle, string numero, Localidad localidad){
		    this.calle = calle;
		    this.numero = numero;
		    this.localidadCliente = localidad;
		}
		
		public Direccion(string calle, string numero, int piso, string departamento, Localidad localidad) {
			this.calle = calle;
			this.numero = numero;
			this.localidadCliente = localidad;
		}
		
		public string Calle
		{
			set { calle = value;}
			get { return calle;}
		}
		
		public string Numero
		{
			set { numero = value;}
			get { return numero;}
		}
		
		public Localidad LocalidadCliente
		{
			set { localidadCliente = value;}
			get { return localidadCliente;}
		}
		
		public override string ToString()
		{
		    return string.Format("{0} {1}, {2}", calle, numero, localidadCliente.ToString().Replace('_', ' '));
		}

	}
	
	public enum Localidad 
	{
	    Florencio_Varela = 1,
	    Quilmes = 2,
	    Berazategui = 3,
	    La_Plata = 4,
        Lomas_de_Zamora = 5,
        Lanus = 6,
        Ezeiza = 7
	}
}

