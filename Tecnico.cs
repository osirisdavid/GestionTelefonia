using System;

namespace GestionTelefoniaCable
{
    public class Tecnico:Persona
    {
        private int idTecnico;
        private Localidad zonaTecnico;
        private static int contadorTecnico;
        private int totalClientes;
        
        public Tecnico(string nombre, string apellido, int dni, Localidad zonaTecnico) : base(nombre, apellido, dni)
        {
            this.zonaTecnico = zonaTecnico;
            this.idTecnico = ++contadorTecnico;
        }

        public int IdTecnico
        {
            get { return idTecnico; }
        }
        
        public Localidad ZonaTecnico
        {
            set {this.zonaTecnico = value;}
            get { return this.zonaTecnico;}
        }
        
        public int TotalClientes
        {
            set {this.totalClientes = value;}
            get { return this.totalClientes;}
        }

        public override string ToString()
        {
            return string.Format("Id Tecnico: {0}, Apellido y Nombre: {1} {2}, DNI: {3}, Zona: {4}\n   Clientes Asignados: {5}",
                                 idTecnico, base.Apellido, base.Nombre, base.Dni, zonaTecnico.ToString().Replace('_', ' '), this.totalClientes);
        }

    }
}