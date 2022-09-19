using System;

namespace GestionTelefoniaCable
{

	public class Canal
	{
		
		private int codigo;
		private string nombre;
		private static int cotadorCanal;
		private int idCanal;
		
		
		public Canal()
		{
			this.idCanal = ++ Canal.cotadorCanal;
		}
		
		public Canal(int codigo, string nombre){
			this.codigo = codigo;
			this.nombre = nombre;
			this.idCanal = ++ Canal.cotadorCanal;
		}
		
		public int IdCanal{
			get{return this.idCanal;}
		}
		
		public int Codigo{
			set{this.codigo = value;}
			get{return this.codigo;}
		}
		
		public string Nombre{
			set{this.nombre = value;}
			get{return this.nombre;}
		}
		
		public override string ToString()
		{
			return string.Format("Canal IdCanal:{0}, Codigo:{1}, Nombre:{2}", 
		                         idCanal, codigo, nombre);
		}

	}
}

