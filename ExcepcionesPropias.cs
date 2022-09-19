using System;

namespace GestionTelefoniaCable
{
	
	public class NoExistePersonaException: Exception
	{
		public string motivo;
		
		public NoExistePersonaException(string motivo)
		{
			this.motivo = motivo;
		}
	}
	
	
	public class FechaLimiteExedidaException: Exception
    {
        public string motivo;
        
        public FechaLimiteExedidaException(string motivo)
        {
            this.motivo = motivo;
        }
    }
	
	public class CupoInsuficienteException: Exception
    {
        public string motivo;
        
        public CupoInsuficienteException(string motivo)
        {
            this.motivo = motivo;
        }
    }
}
