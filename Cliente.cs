using System;
using System.Collections;

namespace GestionTelefoniaCable
{
	public class Cliente : Persona
	{
	    private int idCliente;
		private static int contadorCliente;
		private int codigo;
		private DateTime fechaAlta;
		private Direccion direccionCliente;
		private PlanCliente planFinal;
		private ArrayList periodosConsumos;
		private ArrayList facturas;
		private Tecnico tecnicoCliente;
		private Estado estadoCliente;
		
		public Cliente(string nombre, string apellido, int dni, Direccion direccion) : 
		    base(nombre, apellido, dni)
		{
		    this.codigo = dni;
		    this.fechaAlta = DateTime.Today;
		    this.direccionCliente = direccion;
		    this.periodosConsumos = new ArrayList();
		    this.facturas = new ArrayList();
			this.idCliente = ++Cliente.contadorCliente;
			estadoCliente = Estado.Activo;
		}
		
		public Cliente(string nombre, string apellido, int dni, int codigo, Direccion direccion, PlanCliente planFinal) : 
		    base(nombre, apellido, dni)
		{
		    this.codigo = codigo;
		    this.fechaAlta = DateTime.Today;
			this.planFinal = planFinal;
		    this.direccionCliente = direccion;
		    this.periodosConsumos = new ArrayList();
		    this.facturas = new ArrayList();
			this.idCliente = ++Cliente.contadorCliente;
			estadoCliente = Estado.Activo;
		}
		
		public Cliente(string nombre, string apellido, int dni, int codigo, Direccion direccion) : 
		    base(nombre, apellido, dni)
		{
		    this.codigo = codigo;
		    this.fechaAlta = DateTime.Today;
		    this.direccionCliente = direccion;
		    this.periodosConsumos = new ArrayList();
		    this.facturas = new ArrayList();
			this.idCliente = ++Cliente.contadorCliente;
			estadoCliente = Estado.Activo;
		}
		
		public Estado EstadoCliente{
			set{this.estadoCliente = value;}
			get{return this.estadoCliente;}
		}

		public int Codigo
		{
		    set { codigo = value;}
			get { return codigo;}
		}
		
		
		public DateTime FechaAlta
		{
			set {this.fechaAlta = value;}
			get {return fechaAlta;}
		}
		
		public PlanCliente PlanFinal
		{
		    set {this.planFinal = value;}
			get {return this.planFinal;}
		}
		
		public Direccion DireccionCliente
		{
			set { direccionCliente = value;}
			get { return direccionCliente;}
		}
		
		public ArrayList PeriodosConsumos
		{
			get { return periodosConsumos;}
		}
		
		public ArrayList Facturas
		{
			get { return facturas;}
		}
		
		public Tecnico TecnicoCliente{
		    set{this.tecnicoCliente = value;}
		    get{return this.tecnicoCliente;}
		}
		
		public int IdCliente
		{
			get {return idCliente;}
		}
		
		public void agregarPeriodoConsumo(PeriodoConsumo periodo)
		{
		    this.periodosConsumos.Add(periodo);   
		}
		
		public void eliminarPeriodoConsumo(PeriodoConsumo periodo)
		{
		    this.periodosConsumos.Remove(periodo);
		}
		
		public void agregarFactura(Factura factura){
		    this.facturas.Add(factura);
		}
		
		public void eliminarFactura(Factura factura){
		    this.facturas.Remove(factura);
		}
		
		
		
		public override string ToString()
        {
            return string.Format("DATOS PERSONALES \n   Id Cliente: {0} \n   Codigo: {1} \n   Apellido y Nombre: {2} {3} \n   DNI: {4} \n" +
			                     "   Direccion: {5} \nFecha de Alta: {6}\nDETALLE DEL PLAN{7}\nTecnico asignado: {8} \nEstado: {9}",
		                         this.idCliente, this.codigo, base.Apellido, base.Nombre, base.Dni, 
		                         this.direccionCliente, this.fechaAlta, this.planFinal, this.tecnicoCliente, this.estadoCliente.ToString().Replace('_',' '));
        }
		
		public string mostrarDatosPersonales(){
            return string.Format("DATOS PERSONALES \n   Id Cliente: {0} \n   Codigo: {1} \n   Apellido y Nombre: {2} {3} \n   DNI: {4} \n" +
			                     "   Direccion: {5}\nEstado: {6}",
		                         this.idCliente, this.codigo, base.Apellido, base.Nombre, base.Dni, 
		                         this.direccionCliente, this.estadoCliente.ToString().Replace('_',' '));
        }

	}
	
	public enum Estado
	{
	   Activo,
	   Inactivo, 
	   En_Proceso_de_Suscripcion
	}
}