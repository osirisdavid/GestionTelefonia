using System;

namespace GestionTelefoniaCable
{
    public class PeriodoConsumo
    {
        private Periodo periodo;
        private PlanCliente planFinal;
        private double minutosConsumidos;
        private double minutosDisponibles;
        private bool vigente;
        
        public PeriodoConsumo(Periodo periodo, PlanCliente planFinal)
        {
            this.periodo = periodo;
            this.planFinal = planFinal;
            this.minutosDisponibles = planFinal.Plan.Telef.Minutos;//Asigno a minutosDisponibles la cantidad de minutos que tien el Plan que paso por paramentro
            this.vigente = false;
        }
        
        public Periodo Periodo{
            set{this.periodo = value;}
            get{return this.periodo;}
        }
        
        public PlanCliente PlanFinal{
            set{this.planFinal = value;}
            get{return this.planFinal;}
        }
        
        public double MinutosDisponibles{
            set{this.minutosDisponibles = value;}
            get{return this.minutosDisponibles;}
        }
        
        public double MinutosConsumidos{
            set{this.minutosConsumidos = value;}
            get{return this.minutosConsumidos;}
        }
        
        public bool Vigente{
            set{this.vigente = value;}
            get{return this.vigente;}
        }
        
        public void consumirMinutos(double minutos){
            if(this.minutosDisponibles > 0){
                if(this.minutosDisponibles >= minutos){
                    this.minutosDisponibles -= minutos;
                    this.minutosConsumidos += minutos;
                }
                else{
                    Console.WriteLine("Ha solicitado consumir " + minutos + " mintuos");
                    Console.WriteLine ("De los cuales solo pudo consumir " + (this.minutosDisponibles));
                    Console.WriteLine ("Usted NO pudo consumir " + (minutos - minutosDisponibles)+ " minutos, ya que ha llegado al limite de consumision");
                    this.minutosDisponibles = 0;
                    this.minutosConsumidos = planFinal.Plan.Telef.Minutos;
                }
            }
            else{
                Console.WriteLine("Ha solicitado consumir " + minutos + " mintuos");
                Console.WriteLine ("Cuanta con " + (this.minutosDisponibles) + " minutos disponible");
            }
        }

        public override string ToString()
        {
            return string.Format("							" +
                                 "PeriodoConsumo \n							" +
                                 "Fecha Inicio: {0} \n							" +
                                 "Fecha Fin: {1} \n{2} \n" +
                                 "MinutosConsumidos: {3} \n" +
                                 "MinutosDisponibles: {4}",
                                 periodo.FechaInicio, periodo.FechaFin, planFinal.Plan.ToString(), minutosConsumidos, minutosDisponibles);
        }
    }     
}