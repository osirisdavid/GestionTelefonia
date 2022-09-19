using System;
using System.Collections;

namespace GestionTelefoniaCable
{
    
    public class LotePrueba
    {
        private ArrayList planes;
        
        private ArrayList clientesActivos;
        
        private ArrayList clientesInactivos;
        
        private ArrayList tecnicos;
        
        private ArrayList telefonias;
        
        private CableVision cableHDBasico;
        
        private ComboPlus comboPlus;
        
        public LotePrueba()
        {
            //CABLE
            cableHDBasico = new CableVision (1900);
            
            //AGREGO CANALES AL CABLE
            
            cableHDBasico.agregarCanal (new Canal(0101, "Fox Sports"));
            cableHDBasico.agregarCanal(new Canal(0102, "Fox Sports 2"));
            cableHDBasico.agregarCanal(new Canal(0103, "Fox Sports 3"));
            cableHDBasico.agregarCanal(new Canal(0104, "Fox Sports 4"));
            cableHDBasico.agregarCanal(new Canal(0105, "Fox Sports 5"));
            cableHDBasico.agregarCanal(new Canal(0106, "ESPN"));
            cableHDBasico.agregarCanal(new Canal(0107, "ESPN 2"));
            cableHDBasico.agregarCanal(new Canal(0108, "ESPN 3"));
            cableHDBasico.agregarCanal(new Canal(0109, "ESPN 4"));
            cableHDBasico.agregarCanal(new Canal(0110, "ESPN 5"));
            cableHDBasico.agregarCanal(new Canal(0111, "TyC Sports"));
            cableHDBasico.agregarCanal(new Canal(0112, "Paka Paka"));
            cableHDBasico.agregarCanal(new Canal(0113, "Disney Junior"));
            cableHDBasico.agregarCanal(new Canal(0114, "Cartoon NetWork"));
            cableHDBasico.agregarCanal(new Canal(0115, "Nik"));
            cableHDBasico.agregarCanal(new Canal(0116, "Cartoonito"));
            cableHDBasico.agregarCanal(new Canal(0117, "Discovery Kids"));
            cableHDBasico.agregarCanal(new Canal(0118, "Nik Jr"));
            cableHDBasico.agregarCanal(new Canal(0119, "Baby TV"));
            cableHDBasico.agregarCanal(new Canal(0120, "Tooscast"));
            cableHDBasico.agregarCanal(new Canal(0121, "Telesur"));
            cableHDBasico.agregarCanal(new Canal(0122, "RAI"));
            cableHDBasico.agregarCanal(new Canal(0123, "TVE"));
            cableHDBasico.agregarCanal(new Canal(0124, "CNN"));
            cableHDBasico.agregarCanal(new Canal(0125, "CNN Español"));
            cableHDBasico.agregarCanal(new Canal(0126, "BBC"));
            cableHDBasico.agregarCanal(new Canal(0127, "DW"));
            cableHDBasico.agregarCanal(new Canal(0128, "TV5"));
            cableHDBasico.agregarCanal(new Canal(0129, "ABC TV"));
            cableHDBasico.agregarCanal(new Canal(0130, "Telemundo"));
            cableHDBasico.agregarCanal(new Canal(0002, "America TV"));
            cableHDBasico.agregarCanal(new Canal(0007, "TV Publica"));
            cableHDBasico.agregarCanal(new Canal(0009, "Elnueve"));
            cableHDBasico.agregarCanal(new Canal(0011, "Telefe"));
            cableHDBasico.agregarCanal(new Canal(0013, "Eltrece"));
            
            
            
            
            
            

            //COMBOPLUS
            Canal disney = new Canal (1200, "Disney Channel");
            Canal tnt = new Canal (1012, "TNT Sports");
            Canal fox = new Canal (1013, "Fox Sports Premiun");
            comboPlus = new ComboPlus(new DateTime(2022, 07, 25), 100); //fecha Limite y Cupos
            comboPlus.agregarCanalPlus(disney);
            comboPlus.agregarCanalPlus(tnt);
            comboPlus.agregarCanalPlus(fox);
            
            //CombosPlusList = new ArrayList();
            
            //CombosPlusList.Add(comboPlus);

            //TELEFONIA (4 Telefonias)
            Telefonia telefonia1 = new Telefonia(100, 2.5);
            Telefonia telefonia2 = new Telefonia(300, 2);
            Telefonia telefonia3 = new Telefonia(500, 1.7);
            Telefonia telefonia4 = new Telefonia(1000, 1);
            
            telefonias = new ArrayList (){telefonia1, telefonia2, telefonia3, telefonia4};
            
            //PLAN (4 Planes)
            PlanCableTelefonia planBasico = new PlanCableTelefonia("Plan Basico", telefonia1, cableHDBasico);
            PlanCableTelefonia planSimple = new PlanCableTelefonia ("Plan Simple", telefonia2, cableHDBasico);
            PlanCableTelefonia planPremium = new PlanCableTelefonia ("Plan Premiun", telefonia3, cableHDBasico);
            PlanCableTelefonia planFree = new PlanCableTelefonia ("Plan Free", telefonia4, cableHDBasico);
            
            planes = new ArrayList(){planBasico, planSimple, planPremium, planFree};
            
            //PERIODO
            
            Periodo marzo = new Periodo (new DateTime(2022, 02, 28), new DateTime(2022, 03, 28));

            Periodo abril = new Periodo (new DateTime(2022, 03, 28), new DateTime(2022, 04, 28));
            
            Periodo mayo = new Periodo (new DateTime(2022, 04, 28), new DateTime(2022, 05, 28));
            
            Periodo junio = new Periodo (new DateTime(2022, 05, 28), new DateTime(2022, 06, 28));
            
            Periodo julio = new Periodo (new DateTime(2022, 06, 28), new DateTime(2022, 07, 23));
            
            //Periodo no utilizado
            Periodo agosto = new Periodo (new DateTime(2022, 07, 28), new DateTime(2022, 08, 28));
            
            //DIRECCIONES
            Direccion direccion1 = new Direccion ("Portugal", "633 bis", Localidad.Florencio_Varela);
            Direccion direccion2 = new Direccion ("Milan", "312", Localidad.Florencio_Varela);
            Direccion direccion3 = new Direccion ("Uruguay", "1250", Localidad.Berazategui);
            Direccion direccion4 = new Direccion ("San Martin", "4578", Localidad.Quilmes);
            Direccion direccion5 = new Direccion ("13", "1578", Localidad.La_Plata);
            

            //CREO TECNICOS
            Tecnico tecnico1 = new Tecnico("Martin", "Perez", 32345675, Localidad.Quilmes);
            Tecnico tecnico2 = new Tecnico("Facundo", "Gonzalez", 22355675, Localidad.Florencio_Varela);
            Tecnico tecnico3 = new Tecnico("Matias", "Suarez", 43234675, Localidad.Berazategui);
            Tecnico tecnico4 = new Tecnico("Romina", "Diaz", 35976457, Localidad.La_Plata);
            Tecnico tecnico5 = new Tecnico("Juan", "Ramirez", 30301302, Localidad.Lanus);
            Tecnico tecnico6 = new Tecnico("Lucas", "Martinez", 25345897, Localidad.Lomas_de_Zamora);
            Tecnico tecnico7 = new Tecnico("Matias", "Rodriguez", 27345976, Localidad.Ezeiza);
            Tecnico tecnico8 = new Tecnico("Joaquin", "Guevara", 27345976, Localidad.Florencio_Varela);
            
            
            
            //CREO ARRAYLIST DE TECNICOS
            tecnicos = new ArrayList(){tecnico1, tecnico2, tecnico3, tecnico4, tecnico5, tecnico6, tecnico7, tecnico8};
            
            //CLIENTES
            //Cliente 1
            
            
            Cliente cliente1 = new Cliente("David", "Ayala", 11111111, 11111111, direccion1, new PlanCliente(comboPlus, planBasico));
            cliente1.FechaAlta = new DateTime (2022, 03, 07);
            cliente1.PlanFinal.agregarCanalComboPlus(disney);
            cliente1.PlanFinal.agregarCanalComboPlus(tnt);
            cliente1.PlanFinal.agregarCanalComboPlus(fox);
            cliente1.TecnicoCliente = tecnico2;
            ++tecnico2.TotalClientes;
            
            //periodos Cliente 1
            PeriodoConsumo marzoPeriodo = new PeriodoConsumo(marzo, cliente1.PlanFinal);
            PeriodoConsumo abrilPeriodo = new PeriodoConsumo(abril, cliente1.PlanFinal);
            PeriodoConsumo mayoPeriodo = new PeriodoConsumo(mayo, cliente1.PlanFinal);
            PeriodoConsumo junioPeriodo = new PeriodoConsumo(junio, cliente1.PlanFinal);
            
            marzoPeriodo.Vigente = true;
            abrilPeriodo.Vigente = true;
            mayoPeriodo.Vigente = true;
            junioPeriodo.Vigente = true;
            
            junioPeriodo.MinutosConsumidos = junioPeriodo.MinutosDisponibles - 10;
            junioPeriodo.MinutosDisponibles = 10;
            
            PeriodoConsumo julioPeriodo = new PeriodoConsumo(julio, cliente1.PlanFinal);
            
            cliente1.agregarPeriodoConsumo(marzoPeriodo);
            cliente1.agregarPeriodoConsumo(abrilPeriodo);
            cliente1.agregarPeriodoConsumo(mayoPeriodo);
            cliente1.agregarPeriodoConsumo(junioPeriodo);
            cliente1.agregarPeriodoConsumo(julioPeriodo);
            
            
            cliente1.agregarFactura(new Factura(1, marzoPeriodo));
            cliente1.agregarFactura(new Factura(2, abrilPeriodo));
            cliente1.agregarFactura(new Factura(3, mayoPeriodo));
            cliente1.agregarFactura(new Factura(4, junioPeriodo));
            
            //Cliente 2
            Cliente cliente2 = new Cliente("Juan", "Cruz", 22222222, 22222222, direccion2, new PlanCliente(planSimple));
            cliente2.FechaAlta = new DateTime (2021, 03, 15);
            cliente2.TecnicoCliente = tecnico2;
            ++tecnico2.TotalClientes;

            marzoPeriodo = new PeriodoConsumo(marzo, cliente2.PlanFinal);
            abrilPeriodo = new PeriodoConsumo(abril, cliente2.PlanFinal);
            mayoPeriodo = new PeriodoConsumo(mayo, cliente2.PlanFinal);
            junioPeriodo = new PeriodoConsumo(junio, cliente2.PlanFinal);
            julioPeriodo = new PeriodoConsumo(julio, cliente2.PlanFinal);
            
            marzoPeriodo.Vigente = true;
            abrilPeriodo.Vigente = true;
            mayoPeriodo.Vigente = true;
            junioPeriodo.Vigente = true;
            
            junioPeriodo.MinutosConsumidos = junioPeriodo.MinutosDisponibles - 30;
            junioPeriodo.MinutosDisponibles = 30;
            
            cliente2.agregarPeriodoConsumo(marzoPeriodo);
            cliente2.agregarPeriodoConsumo(abrilPeriodo);
            cliente2.agregarPeriodoConsumo(mayoPeriodo);
            cliente2.agregarPeriodoConsumo(junioPeriodo);
            julioPeriodo.Vigente = false;
            cliente2.agregarPeriodoConsumo(julioPeriodo);
            
            cliente2.agregarFactura(new Factura(1, marzoPeriodo));
            cliente2.agregarFactura(new Factura(2, abrilPeriodo));
            cliente2.agregarFactura(new Factura(3, mayoPeriodo));
            cliente2.agregarFactura(new Factura(4, junioPeriodo));
            
            //Cliente 3
            Cliente cliente3 = new Cliente("Jorge", "Gomez", 33333333, 33333333, direccion3, new PlanCliente(planPremium));
            cliente3.FechaAlta = new DateTime (2022, 04, 15);
            cliente3.TecnicoCliente = tecnico3;
            ++tecnico3.TotalClientes;
            
            abrilPeriodo = new PeriodoConsumo(abril, cliente3.PlanFinal);
            mayoPeriodo = new PeriodoConsumo(mayo, cliente3.PlanFinal);
            junioPeriodo = new PeriodoConsumo(junio, cliente3.PlanFinal);
            julioPeriodo = new PeriodoConsumo(julio, cliente3.PlanFinal);
            
            abrilPeriodo.Vigente = true;
            mayoPeriodo.Vigente = true;
            junioPeriodo.Vigente = true;
            
            junioPeriodo.MinutosConsumidos = junioPeriodo.MinutosDisponibles - 50;
            junioPeriodo.MinutosDisponibles = 50;
            
            cliente3.agregarPeriodoConsumo(abrilPeriodo);
            cliente3.agregarPeriodoConsumo(mayoPeriodo);
            cliente3.agregarPeriodoConsumo(junioPeriodo);
            julioPeriodo.Vigente = false;
            cliente3.agregarPeriodoConsumo(julioPeriodo);
            
            
            cliente3.agregarFactura(new Factura(1, abrilPeriodo));
            cliente3.agregarFactura(new Factura(2, mayoPeriodo));
            cliente3.agregarFactura(new Factura(3, junioPeriodo));
            
            //Cliente 4
            Cliente cliente4 = new Cliente("Luis", "Enrique", 44444444, 44444444, direccion4 , new PlanCliente(planFree));
            cliente4.FechaAlta = new DateTime (2022, 05, 10);
            cliente4.TecnicoCliente = tecnico1;
            ++tecnico1.TotalClientes;
            
            mayoPeriodo = new PeriodoConsumo(mayo, cliente4.PlanFinal);
            junioPeriodo = new PeriodoConsumo(junio, cliente4.PlanFinal);
            julioPeriodo = new PeriodoConsumo(julio, cliente4.PlanFinal);
            
            mayoPeriodo.Vigente = true;
            junioPeriodo.Vigente = true;
            
            junioPeriodo.MinutosConsumidos = junioPeriodo.MinutosDisponibles - 50;
            junioPeriodo.MinutosDisponibles = 50;
            
            cliente4.agregarPeriodoConsumo(mayoPeriodo);
            cliente4.agregarPeriodoConsumo(junioPeriodo);
            julioPeriodo.Vigente = false;
            cliente4.agregarPeriodoConsumo(julioPeriodo);
            
            cliente4.agregarFactura(new Factura(3, mayoPeriodo));
            cliente4.agregarFactura(new Factura(1, junioPeriodo));
            
            //Cliente 5
            Cliente cliente5 = new Cliente("Raul", "Gimenez", 55555555, 55555555, direccion5, new PlanCliente(planFree));
            cliente5.FechaAlta = new DateTime (2022, 05, 17);
            cliente5.TecnicoCliente = tecnico4;
            ++tecnico4.TotalClientes;

            mayoPeriodo = new PeriodoConsumo(mayo, cliente5.PlanFinal);
            junioPeriodo = new PeriodoConsumo(junio, cliente5.PlanFinal);
            julioPeriodo = new PeriodoConsumo(julio, cliente5.PlanFinal);
            
            mayoPeriodo.Vigente = true;
            junioPeriodo.Vigente = true;
            
            junioPeriodo.MinutosConsumidos = junioPeriodo.MinutosDisponibles - 60;
            junioPeriodo.MinutosDisponibles = 60;

            cliente5.agregarPeriodoConsumo(mayoPeriodo);
            cliente5.agregarPeriodoConsumo(junioPeriodo);
            cliente5.agregarPeriodoConsumo(julioPeriodo);
 
			cliente5.agregarFactura(new Factura(1, mayoPeriodo));
			cliente5.agregarFactura(new Factura(2, junioPeriodo));
            
            //CREO ARRAYLIST DE CLIENTES
            
            clientesActivos = new ArrayList(){cliente1, cliente2, cliente3, cliente4, cliente5};
            
            clientesInactivos = new ArrayList();
            
        }
        
        public ArrayList Planes{get{return this.planes;}}
        
        public ArrayList ClientesActivos {get{return this.clientesActivos;}}
        
        public ArrayList ClientesInactivos {get{return this.clientesInactivos;}}
        
        public ArrayList Tecnicos{get{return this.tecnicos;}}
        
        public ArrayList Telefonias{get{return this.telefonias;}}
        
        public CableVision CableHDBasico
        {
            set{this.cableHDBasico = value;}
            get{return this.cableHDBasico;}
        }
        
        public ComboPlus ComboPlus
        {
            set{this.comboPlus = value;}
            get{return this.comboPlus;}
        }

        public void agregarPlan (PlanCableTelefonia plan){
            this.planes.Add(plan);
        }
        public void eliminarPlan (PlanCableTelefonia plan){
            this.planes.Remove(plan);
        }
        
        public void agregarClienteActivo (Cliente cliente){
            this.clientesActivos.Add(cliente);
        }
        public void eliminarClienteActivo (Cliente cliente){
            this.clientesActivos.Remove(cliente);
        }
        public void agregarClienteInactivo (Cliente cliente){
            this.clientesInactivos.Add(cliente);
        }
        public void eliminarClienteInactivo (Cliente cliente){
            this.clientesInactivos.Remove(cliente);
        }
        
        public void agregarTecnico (Tecnico tecnico){
            this.tecnicos.Add(tecnico);
        }
        public void eliminarTecnico (Tecnico tecnico){
            this.tecnicos.Remove(tecnico);
        }
        
        public void agregarTelefonia (Telefonia telefonia){
            this.telefonias.Add(telefonia);
        }
        public void eliminarTelefonia (Telefonia telefonia){
            this.telefonias.Remove(telefonia);
        }
        
        
        
    }
}



