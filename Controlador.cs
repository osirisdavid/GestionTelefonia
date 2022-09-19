using System;
using System.Collections;



namespace GestionTelefoniaCable
{
    
    public class ControladorMenu
    {
        private LotePrueba miLoteObjetos;
        
        public ControladorMenu()
        {
            miLoteObjetos = new LotePrueba();
        }
        
        public LotePrueba MiLoteObjetos{
            set{this.miLoteObjetos = value;}
            get{return this.miLoteObjetos;}
        }
        
        
        public void seleccionarEventos()
        {
            tituloMenu(70);
            miMenu();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ingrese una Opcion: ");
            Console.ForegroundColor = ConsoleColor.White;
            string opcion = Console.ReadLine();
            while (opcion != "0"){
                switch (opcion){
                        
                    case "1":
                        /*      Crear Cliente:
                         *						->  pedir datos personales (algunos validados como el DNI)
                         *						->  crearle nueva direccion
                         *						->  verificar vigencia y cupos del ComboPlus
                         *						->  asignarle un plan, dentro de los que estan actualizados
                         *						->  asignale Tenico segun direccion (Localidad)
                         *						->
                         */
                        
                        suscripcionNuevoCliente();
                        Console.ReadKey();
                        break;
                        
                    case "2":
                        /*      Eliminar Cliente     (Inactivar Cliente) */
                        
                        Console.Clear();
                        inactivarCliente();
                        Console.ReadKey();
                        break;
                        
                    case "3":
                        /*      Crear Tecnico     */
                        
                        Console.Clear();
                        agregarTecnico();
                        Console.ReadKey();
                        break;
                        
                    case "4":
                        /*      Tecnico segun Zona     */
                        
                        Console.Clear();
                        elegirTecnicoSegunZona();
                        Console.ReadKey();
                        break;
                        
                    case "5":
                        /*      Cliente segun Codigo     */
                        Console.Clear();
                        imprimirClienteSegunCodigo();
                        Console.ReadKey();
                        break;
                        
                    case "6":
                        /*      Consumir minutos de un Clientes     */
                        
                        Console.Clear();
                        
                        consumirMinutosDeCliente();
                        
                        Console.ReadKey();
                        break;
                        
                        
                    case "7":
                        /*      Facutra de un Cliente     */
                        
                        Console.Clear();
                        menuFactura(miLoteObjetos.ClientesActivos);
                        Console.ReadKey();
                        break;
                    case "8":
                        /*      Todos los Clientes     */
                        
                        Console.Clear();
                        imprimirTablaClientes(this.miLoteObjetos.ClientesActivos, 160, "CLIENTES ACTIVOS");
                        imprimirTablaClientes(this.miLoteObjetos.ClientesInactivos, 160, "CLIENTES INACTIVOS");
                        Console.ReadKey();
                        break;
                        
                    case "9":
                        /*      Todos los Tecnicos     */
                        
                        Console.Clear();
                        
                        ordenarTecnicosPorID(miLoteObjetos.Tecnicos);
                        imprimirTablaTecnicos(this.miLoteObjetos.Tecnicos, 100);
                        
                        Console.ReadKey();
                        break;
                        
                    case "10":
                        /*      Grilla de Canales     */
                        
                        Console.Clear();
                        imprimirTablaGrillaDeCanales(this.miLoteObjetos.CableHDBasico.CanalesHD, 70, this.miLoteObjetos.ComboPlus);
                        Console.ReadKey();
                        break;
                        
                    case "11":
                        /*      Combo Plus     */
                        
                        Console.Clear();
                        Console.WriteLine(this.miLoteObjetos.ComboPlus.ToString());
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
                tituloMenu(70);
                miMenu();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Ingrese una Opcion: ");
                Console.ForegroundColor = ConsoleColor.White;
                opcion = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cerrando App...");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        
        
        
        
        
        
        
        /*	--------------------------------------- Metodos Reutilizables ---------------------------------------  */
        
        // Retorna localidad seleccionada (utilizada en case 3 y case 4)

        private Localidad elegirLocalidad()
        {
            Console.WriteLine ("\n   Elige Localidad");
            imprimirLocalidades();
            int opcion = Validacion.pedirNumeroEntero("\n   Numero de Localidad: ", 1, 7);
            Localidad miLocalidad = (Localidad)opcion;
            Console.WriteLine(miLocalidad.ToString().Replace('_', ' '));
            Console.ReadKey();
            return miLocalidad;
        }
        
        //Esta funcion arroja de manera recursiva en que posicion esta el tecnico, si no existe, arroja -1 (Utilizado en la funcion case 1 y case 4)
        public int existeTecnicoSegunZonaRecursivo(ArrayList tecnicos, Localidad localidad, int pos)
        {
            if(pos == tecnicos.Count)
                return -1;
            if(((Tecnico)tecnicos[pos]).ZonaTecnico == localidad)
                return pos;
            return existeTecnicoSegunZonaRecursivo(tecnicos, localidad, pos + 1);
        }
        
        //Metodo RECURSIVO que me retorna el indice del Cliente buscado segun CODIGO,
        //si no existe el cliente retorna -1 (utilizado en case 1, case 5 y case 6)
        
        public int existeClientePorCodigoRecursivo(ArrayList clientes, int codigoCliente, int pos)
        {
            if(pos == clientes.Count)
                return -1;
            if(((Cliente)clientes[pos]).Codigo == codigoCliente)
                return pos;
            return existeClientePorCodigoRecursivo(clientes, codigoCliente, pos + 1);
        }
        
        /*	--------------------------------------- CASE 1 ---------------------------------------  */
        
        private void suscripcionNuevoCliente()
        {
            Cliente nuevoCliente;
            PlanCableTelefonia miPlan;
            PeriodoConsumo periodoConsumo;
            Periodo periodo;
            PlanCliente planCliente;
            
            int indiceCliente;
            bool existeClienteInactivo = false;
            
            nuevoCliente = pedirDatosNuevoCliente();
            
            if(existeClientePorDniRecursivo(this.miLoteObjetos.ClientesActivos, nuevoCliente.Dni, 0) != -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El dni ingresado pertenece a un Cliente Activo." +
                                  "\nIntentelo nuevamente o llame a un representante.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("El numero de atencion al cliente es 0810 111 9999.");
                Console.ReadKey();
                return;
            }
            indiceCliente = existeClientePorDniRecursivo(this.miLoteObjetos.ClientesInactivos, nuevoCliente.Dni, 0);
            if(indiceCliente != -1)
            {
                Console.Clear();
                existeClienteInactivo = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El dni ingresado pertenece a un Cliente Inactivo.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(((Cliente)this.miLoteObjetos.ClientesInactivos[indiceCliente]).mostrarDatosPersonales());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nDesea Activar su suscripcion: ");
                Console.ForegroundColor = ConsoleColor.White;
                if(continuar()){
                    nuevoCliente = (Cliente)this.miLoteObjetos.ClientesInactivos[indiceCliente];
                    
                }
                else{
                    return;
                }
            }
            asignarTecnicoACliente(nuevoCliente, this.miLoteObjetos.Tecnicos);
            Console.Clear();
            Console.WriteLine("Pulse cualquier tecla para continuar con la eleccion de planes.");
            Console.ReadKey();
            Console.Clear();
            
            miPlan = eligePlan();
            Console.WriteLine(miPlan.ToString());
            Console.ReadKey();
            
            planCliente = new PlanCliente(miPlan);
            
            nuevoCliente.PlanFinal = planCliente;
            
            periodo = new Periodo(nuevoCliente.FechaAlta, new DateTime(DateTime.Today.Year, (DateTime.Today.Month + 1), 5));
            periodoConsumo = new PeriodoConsumo(periodo, planCliente);
            nuevoCliente.agregarPeriodoConsumo(periodoConsumo);
            
            //AHORA VERIFICARA LA EXISTENCIA DE COMBO PLUS DISPONIBLE
            Console.Clear();
            bool comboPlusDisponible = verificaComboPlus(this.miLoteObjetos.ComboPlus);
            Console.ReadKey();
            Console.Clear();
            if(comboPlusDisponible == false)
            {
                Console.WriteLine("¿Sucribirse de todas formas?. \nRecuerde que no podra contar Combo Plus.");
                bool continuarSuscripcion = continuar();
                if(continuarSuscripcion == true)
                {
                    Console.Clear();
                    Console.WriteLine("A continuacion debera confirmar la suscripcion...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("CONFIRMACION DEL NUEVO CLIENTE\n");
                    
                    nuevoCliente.EstadoCliente = Estado.En_Proceso_de_Suscripcion;
                    Console.WriteLine (nuevoCliente.ToString());
                    Console.WriteLine("\nDesea confirmar suscripcion.");
                    
                    bool confirmarSuscripcion = continuar();
                    
                    if(confirmarSuscripcion == true)
                    {
                        nuevoCliente.EstadoCliente = Estado.Activo;
                        this.miLoteObjetos.agregarClienteActivo(nuevoCliente);
                        
                        ++nuevoCliente.TecnicoCliente.TotalClientes;
                        
                        if(existeClienteInactivo == true)
                        {
                            nuevoCliente.FechaAlta = DateTime.Today;
                            this.miLoteObjetos.eliminarClienteInactivo(nuevoCliente);
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Felicitaciones!! Se ha generado un nuevo Cliente.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        if(existeClienteInactivo == true)
                        {
                            ((Cliente)this.miLoteObjetos.ClientesInactivos[indiceCliente]).EstadoCliente = Estado.Inactivo;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No se ha Activado al cliente. Por lo tanto quedara Inactivo");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se ha inscripto el Cliente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se ha inscripto el Cliente.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                nuevoCliente.PlanFinal = new PlanCliente(this.miLoteObjetos.ComboPlus, miPlan);
                Console.Clear();
                Console.WriteLine("A continuacion debera confirmar la suscripcion...");
                Console.ReadKey();
                Console.Clear();
                
                Console.WriteLine("CONFIRMACION DEL NUEVO CLIENTE\n");
                nuevoCliente.EstadoCliente = Estado.En_Proceso_de_Suscripcion;
                Console.WriteLine (nuevoCliente.ToString());
                
                Console.WriteLine("\nDesea confirmar suscripcion.");
                bool confirmarSuscripcion = continuar();
                if(confirmarSuscripcion == true){
                    nuevoCliente.EstadoCliente = Estado.Activo;
                    
                    ++nuevoCliente.TecnicoCliente.TotalClientes;
                    
                    if(existeClienteInactivo == true)
                    {
                        nuevoCliente.FechaAlta = DateTime.Today;
                        
                        this.miLoteObjetos.eliminarClienteInactivo(nuevoCliente);
                    }
                    this.miLoteObjetos.agregarClienteActivo(nuevoCliente);
                    --this.miLoteObjetos.ComboPlus.CupoDispinible;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Felicitaciones!! Se ha generado un nuevo Cliente.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else{
                    if(existeClienteInactivo == true)
                    {
                        ((Cliente)this.miLoteObjetos.ClientesInactivos[indiceCliente]).EstadoCliente = Estado.Inactivo;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se ha Activado al cliente. Por lo tanto quedara Inactivo");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se ha inscripto el Cliente.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ReadKey();
                Console.Clear();
            }
            
        }
        
        /*	Metodo para crear cliente con datos personales (se utiliza en case 1)	*/
        
        private Cliente pedirDatosNuevoCliente()
        {
            Cliente nuevoCliente;
            Console.WriteLine("Datos Personales");
            Console.Write("   Ingrese nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("   Ingrese apellido: ");
            string apellido = Console.ReadLine();
            int dni = Validacion.pedirNumeroEntero("   Ingrese DNI: ", 8);
            
            Direccion nuevaDireccion = crearNuevaDireccion();
            nuevoCliente = new Cliente(nombre, apellido, dni, nuevaDireccion);
            return nuevoCliente;
        }
        
        

        //Metodo RECURSIVO que me retorna el indice del Cliente buscado segun DNI,
        //si no existe el cliente retorna -1 (utilizado en case 1)
        private int existeClientePorDniRecursivo(ArrayList clientes, int dniCliente, int pos)
        {
            if(pos == clientes.Count)
                return -1;
            if(((Cliente)clientes[pos]).Dni == dniCliente)
                return pos;
            return existeClientePorCodigoRecursivo(clientes, dniCliente, pos + 1);
        }
        
        // Asigna tecnico a cliente (Utilizado en case 1)
        
        private void asignarTecnicoACliente(Cliente cliente, ArrayList tecnicos)
        {
            Localidad localidadCliente = cliente.DireccionCliente.LocalidadCliente;
            
            
            ordenarTecnicosPorCantidadClientesAsignados(tecnicos);
            
            int indiceTecnico = existeTecnicoSegunZonaRecursivo(tecnicos, localidadCliente, 0);
            if(indiceTecnico != -1)
            {
                cliente.TecnicoCliente = (Tecnico)tecnicos[indiceTecnico];
            }
            else{Console.WriteLine("Por el momento no existe tecnico disponible para el Cliente segun su Zona");}
        }
        
        // Muestra los planes disponibles y retorna el plan elegido (Utilizado en case 1)
        
        private PlanCableTelefonia eligePlan()
        {
            PlanCableTelefonia plan;
            double costoTelefonia;
            Console.WriteLine("PLANES CABLEVISION Y TELEFONIA DIPONIBLES\n\n");
            for (int i = 0; i < this.miLoteObjetos.Planes.Count; i++)
            {
                plan = (PlanCableTelefonia)this.miLoteObjetos.Planes[i];
                costoTelefonia = plan.Telef.Minutos* plan.Telef.CostoMinuto;
                Console.WriteLine(string.Format("[{0}] {1} {2} canales HD ${3}\n    " +
                                                "Telefonia: {4} minutos, ${5} el minuto, subtotal Telefonia ${6}\n    TOTAL ${7}",
                                                (i + 1), plan.Nombre, plan.Cable.CanalesHD.Count, plan.Cable.Precio, plan.Telef.Minutos,
                                                plan.Telef.CostoMinuto, (costoTelefonia), (plan.Cable.Precio + costoTelefonia)));
            }
            int opcion = Validacion.pedirNumeroEntero("\nElija un Plan: ", 1, 4);
            while (opcion < 0 && opcion > this.miLoteObjetos.Planes.Count)
            {
                opcion = Validacion.pedirNumeroEntero("\nElija un Plan: ", 1, 4);
            }
            plan = (PlanCableTelefonia)this.miLoteObjetos.Planes[opcion-1];
            return plan;
        }
        
        // Verifica si hay combo plus disponible retorna true o false (Utilizado en case 1)
        
        private bool verificaComboPlus(ComboPlus comboPlus)
        {
            Console.WriteLine("Verificando la Existencia de Combo Promocional...\n\n" +
                              "Pulse cualquier tecla para obtener informacion.");
            Console.ReadKey();
            Console.Clear();
            string msj = "Lo sentimos, se han terminado los Cupos para el Combo Plus en Promocion.";
            string msj2 = "El combo ha expirado ya que vencio el dia " + comboPlus.FechaLimite;
            DateTime fechaActual = DateTime.Today;
            bool comboDisponible = false;
            try
            {
                int vencimientoActual = DateTime.Compare(DateTime.Today, comboPlus.FechaLimite);
                if (vencimientoActual <= 0){
                    if (comboPlus.CupoDispinible > 0)
                    {
                        Console.WriteLine("Se encuentra disponible el Combo Plus, el cual se le agregara a cualquier Plan que elija sin costo adicional.\n" +
                                          "Este combo cuenta con los canales del Pack Futbol y Disney Channel.\n" +
                                          "Tiene tiempo hasta el " + comboPlus.FechaLimite + " para aprovechar la promocion.\n\n" +
                                          "Pulse cualquier tecla para comenzar la suscripcion...");
                        comboDisponible = true;
                    }
                    else{throw new CupoInsuficienteException(msj);}}
                else{throw new FechaLimiteExedidaException(msj2);}
            }
            catch (CupoInsuficienteException e)
            {
                Console.WriteLine(e.motivo);
                Console.WriteLine(e.StackTrace);
            }
            catch (FechaLimiteExedidaException e)
            {
                Console.WriteLine(e.motivo);
            }
            return comboDisponible;
        }
        
        // Pregunta por si o no y retorna true o false (Utilizado en case 1)
        
        private bool continuar()
        {
            bool continuar = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ingrese 'SI' o 'NO': ");
            string opcionSiNo = Console.ReadLine();
            while(opcionSiNo.ToLower() != "si" && opcionSiNo.ToLower() != "no")
            {
                Console.Write("Ingrese 'SI' o 'NO': ");
                opcionSiNo = Console.ReadLine();
                
            }
            if(opcionSiNo.ToLower() == "si"){
                continuar = true;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return continuar;
        }
        
        /*	--------------------------------------- CASE 2 ---------------------------------------  */
        
        //Inactiva un CLIENTE, lo pone en estado INACTIVO,
        //Lo agrega a la lista de Clientes INACTIVOS
        //Y es eliminado de la lista de Clientes ACTIVOS
        
        private void inactivarCliente ()
        {
            int codigo = Validacion.pedirNumeroEntero("Ingrese codigo del Cliente que desea Inactivar: ", 8);
            Cliente cliente;
            bool existeCliente = false;
            for (int i = 0; i < this.miLoteObjetos.ClientesActivos.Count; i++)
            {
                cliente = (Cliente)this.miLoteObjetos.ClientesActivos[i];
                if(cliente.Codigo == codigo)
                {
                    existeCliente = true;
                    Console.WriteLine("¿Esta seguro que desea inactivar al Cliente?");
                    Console.WriteLine(cliente.mostrarDatosPersonales());
                    if(continuar() == true){
                        cliente.EstadoCliente = Estado.Inactivo;
                        this.miLoteObjetos.agregarClienteInactivo(cliente);
                        this.miLoteObjetos.eliminarClienteActivo(cliente);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Se ha inactivado el Cliente con Codigo n° " + codigo);
                        Console.WriteLine("Ingrese cualquier tecla para ver la Facturacion...");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        hallarPeriodo(cliente.PeriodosConsumos).Periodo.FechaFin = DateTime.Today;
                        facturarCliente(cliente);
                        break;
                    }
                }
            }
            if(existeCliente == false)
            {
                Console.WriteLine("El Cliente ingresado No existe.");
                Console.WriteLine("¡¡¡Intente nuevamente!!!");
            }
        }
        
        /*	--------------------------------------- CASE 3 ---------------------------------------  */
        
        private void agregarTecnico()
        {
            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            string apellido = Console.ReadLine();
            
            int dni = Validacion.pedirNumeroEntero("Ingrese Dni: ", 8);
            Localidad miLocalidad = elegirLocalidad();
            Tecnico nuevoTecnico = new Tecnico(nombre, apellido, dni, miLocalidad);
            Console.Clear();
            
            Console.WriteLine("A continuacion debera confirmar la carga del Tecnico...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("CONFIRMACION DEL NUEVO TECNICO\n");
            Console.WriteLine(nuevoTecnico.ToString());
            Console.WriteLine("\n¿Desea confirmar al nuevo Tecnico?.");
            bool confirmarSuscripcion = continuar();
            if(confirmarSuscripcion == true)
            {
                this.miLoteObjetos.agregarTecnico(nuevoTecnico);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine ("Se ha agregado un nuevo Tecnico!!!");
                Console.ForegroundColor = ConsoleColor.White;
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se ha generado el Tecnico.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadKey();
            Console.Clear();
        }
        
        
        
        // Imprime las localidades (Utilizada en el metodo elegirLocalidad)
        private void imprimirLocalidades()
        {
            for (int i = 1; i < 8; i++)
            {
                string miLocalidad = ((Localidad)i).ToString();
                miLocalidad = miLocalidad.Replace('_', ' ');
                Console.WriteLine(string.Format("    [{0}] {1}", i, miLocalidad));
            }
        }
        
        /*	--------------------------------------- CASE 4 ---------------------------------------  */
        
        private void elegirTecnicoSegunZona()
        {
            Localidad localidad = elegirLocalidad();
            int indiceTecnico = existeTecnicoSegunZonaRecursivo(this.miLoteObjetos.Tecnicos, localidad, 0);
            if(indiceTecnico != -1)
            {
                Console.WriteLine("Existe una Tecnico disponible en la Zona ingresada." +
                                  "\nPresione cualquier tecla para ver su informacion.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(((Tecnico)this.miLoteObjetos.Tecnicos[indiceTecnico]).ToString());
            }
            else{ Console.WriteLine("No se ha encontrado Tecnico disponible en la Zona ingresada.");}
        }
        
        /*	--------------------------------------- CASE 5 ---------------------------------------  */
        
        private void imprimirClienteSegunCodigo()
        {
            
            int codigo = Validacion.pedirNumeroEntero("Ingrese CODIGO del Cliente a buscar: ", 8);
            
            int indiceCliente = existeClientePorCodigoRecursivo(this.miLoteObjetos.ClientesActivos, codigo, 0);
            if (indiceCliente != -1)
                Console.WriteLine (((Cliente)this.miLoteObjetos.ClientesActivos[indiceCliente]).ToString());
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontro ningun Cliente con el Codigo ingresado");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nIntente nuevamente.");
            }
        }
        
        /*	--------------------------------------- CASE 6 ---------------------------------------  */
        
        private void consumirMinutosDeCliente()
        {
            Console.WriteLine("");
            imprimirTablaClientes(miLoteObjetos.ClientesActivos, 170, "Elija el CODIGO del CLIENTE del cual desea consumir minutos");
            int codigo = Validacion.pedirNumeroEntero("Codigo del Cliente: ", 8);
            int indiceCliente = existeClientePorCodigoRecursivo(this.miLoteObjetos.ClientesActivos, codigo, 0);
            if(indiceCliente != -1)
            {
                Cliente cliente = (Cliente)this.miLoteObjetos.ClientesActivos[indiceCliente];
                ArrayList periodos = cliente.PeriodosConsumos;
                try
                {
                    PeriodoConsumo periodo = hallarPeriodo(cliente.PeriodosConsumos);
                    Console.WriteLine(string.Format("¿Cuantos minutos desea consumir del Cliente con Codigo {0}?\n" +
                                                    "◄ Minutos Disponibles {1}\n◄ Minutos Consumidos {2}\n",
                                                    codigo, periodo.MinutosDisponibles, periodo.MinutosConsumidos));
                    double minutos = Validacion.pedirDecimal("Ingrese minutos: ");
                    periodo.consumirMinutos(minutos);
                    
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n"+cliente.mostrarDatosPersonales());
                    Console.WriteLine(periodo.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
                catch(NullReferenceException e)
                {
                    Console.WriteLine("\nEl Cliente ingresado no se encuentra activo." +
                                      "\nYa que no cuenta con un periodo de consumo vigente.");
                    Console.WriteLine(e.StackTrace);
                }
                
            }
        }

        
        // Busca el periodo actual de un cliente (utilizado en case 6)
   
        public PeriodoConsumo hallarPeriodo (ArrayList periodos)
        {
            PeriodoConsumo periodo = null;
            for (int i = 0; i < periodos.Count; i++)
            {
                if(((PeriodoConsumo)periodos[i]).Vigente == false){
                    periodo = (PeriodoConsumo)periodos[i];
                    break;
                }
            }
            return periodo;
        }
        
        /*	--------------------------------------- CASE 7 ---------------------------------------  */
        
        /*private void imprimirFacturaSegunCodigoCliente(ArrayList clientes, int codigoCliente)
        {
            Cliente cliente;
            int indiceCliente = existeClientePorCodigoRecursivo(clientes, codigoCliente, 0);
            if(indiceCliente != -1)
            {
                cliente = (Cliente)clientes[indiceCliente];
                if(cliente.EstadoCliente == Estado.Activo)
                {
                    
                }
            }
        }*/
        
        private void miMenuFacturacion()
        {
            string [] vector = {"Volver atras", "Imprimir ultima Factura", "Facturar Periodo"};
            
            for (int i = 0; i < vector.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("    ["+ (i + 1) + "]    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(vector[i]);
            }
            Console.WriteLine();
        }
        
        private void menuFactura(ArrayList clientes)
        {
            Cliente cliente;
            Console.Clear();
            Console.WriteLine(" \nAntes de ver OPCIONES de menu de FACTURACION se le pedira la siguiente informacion:\n");
            int codigo = Validacion.pedirNumeroEntero("CODIGO del Cliente: ", 8);
            Console.ReadKey();
            Console.Clear();
            int indiceCliente = existeClientePorCodigoRecursivo(clientes, codigo, 0);
            if(indiceCliente != -1)
            {
                cliente = (Cliente)clientes[indiceCliente];
                Console.WriteLine("\nFACTURACION\n");
                miMenuFacturacion();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Ingrese una Opcion: ");
                Console.ForegroundColor = ConsoleColor.White;
                string opcion = Console.ReadLine();
                while(opcion != "1")
                {
                    switch(opcion)
                    {
                        case "2":
                            Console.Clear();
                            imprimirUltimaFactura(cliente);
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.Clear();
                            facturarCliente(cliente);
                            Console.ReadKey();
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("\nFACTURACION\n");
                    miMenuFacturacion();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Ingrese una Opcion: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    opcion = Console.ReadLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontrar Cliente con el CODIGO ingresado. Vuelva a Intetarlo.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        
        
        private void facturarCliente(Cliente cliente){
            Factura nuevaFactura;
            int numeroFactura = 1;
            PeriodoConsumo nuevoPeriodoConsumo;
            PeriodoConsumo periodoConsumo = hallarPeriodo(cliente.PeriodosConsumos);
            
            //Si hoy es el ultimo dia de consumo se Factura al Cliente
            if(periodoConsumo.Periodo.FechaFin == DateTime.Today)
            {
                if(cliente.Facturas.Count != 0){
                    numeroFactura = cliente.Facturas.Count + 1;
                }
                
                periodoConsumo.Vigente = true;
                
                nuevaFactura = new Factura(numeroFactura, periodoConsumo);
                cliente.agregarFactura(nuevaFactura);
                periodoConsumo.Vigente = true;
                
                imprimirUltimaFactura(cliente);
                
                Periodo periodoTiempo;
                if(periodoConsumo.Periodo.FechaFin.Month != 12){
                    periodoTiempo = new Periodo(
                        periodoConsumo.Periodo.FechaFin,
                        new DateTime(periodoConsumo.Periodo.FechaFin.Year, (periodoConsumo.Periodo.FechaFin.Month + 1), periodoConsumo.Periodo.FechaFin.Day)
                       );
                }
                else{
                    periodoTiempo = new Periodo(
                        new DateTime(periodoConsumo.Periodo.FechaFin.Year, periodoConsumo.Periodo.FechaFin.Month, periodoConsumo.Periodo.FechaFin.Day ),
                        new DateTime(periodoConsumo.Periodo.FechaFin.Year + 1, 01, periodoConsumo.Periodo.FechaFin.Day)
                       );
                }
                nuevoPeriodoConsumo = new PeriodoConsumo(periodoTiempo, cliente.PlanFinal);
                cliente.agregarPeriodoConsumo(nuevoPeriodoConsumo);
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El Cliente no puede ser Facturado antes que termine su Periodo de Consumo.\n" +
                                  "A menos que inactive el Cliente.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }
        
        
        private void imprimirUltimaFactura(Cliente cliente)
        {
            if(cliente.Facturas.Count != 0){
                ordenarFacturasPorFecha(cliente.Facturas);
                Factura factura = (Factura)cliente.Facturas[0];
                imprimirDobleLinea(100);
                Console.WriteLine("     Numero de Factura: " + factura.Numero + "               Codigo de Cliente: " + cliente.Codigo);
                imprimirLinea(100);
                Console.WriteLine(string.Format("         							        " +
                                                "Periodo de Consumo \n	         						        " +
                                                "Fecha Inicio:      {0} \n         							        " +
                                                "Fecha Fin:         {1}",
                                                factura.PeriodoConsu.Periodo.FechaInicio.ToString("d"), factura.PeriodoConsu.Periodo.FechaFin.ToString("d")));
                imprimirLinea(100);
                Console.WriteLine(factura.PeriodoConsu.PlanFinal.Plan.ToString());
                imprimirLinea(100);
                Console.WriteLine(string.Format("   MinutosConsumidos: {0} \n" +
                                                "   MinutosDisponibles: {1}", factura.PeriodoConsu.MinutosConsumidos, factura.PeriodoConsu.MinutosDisponibles));
                imprimirLinea(100);
                Console.WriteLine("Cantidad de Facturas: " + cliente.Facturas.Count);
                Console.WriteLine(string.Format(
                    "   MontoOriginal _________________________________________________________________________  $ {0}"+
                    "\n   Bonificacion _________________________________________________________________________   $ {1} "+
                    "\n   MontoFinalPagar _______________________________________________________________________  $ {2} ",
                    factura.MontoPlanSinDesc, factura.Bonificacion, factura.MontoFinalPagar));
                imprimirDobleLinea(100);
            }
            else{Console.WriteLine("El cliente con Codigo: " + cliente.Codigo + " aun no cuenta con una factura emitida.");}
            
        }
        
        private void ordenarFacturasPorFecha(ArrayList facturas)
        {
            int tam = facturas.Count;
            for(int i=0; i<(tam-1); i++)
            {
                int menor = i;
                TimeSpan diferenciaFecha;
                
                for(int j=i+1; j<tam; j++)
                {
                    diferenciaFecha = ((Factura)facturas[j]).PeriodoConsu.Periodo.FechaFin - (((Factura)facturas[menor]).PeriodoConsu.Periodo.FechaFin);
                    double result = diferenciaFecha.TotalDays;
                    if(result > 1)
                        menor = j;
                }
                if(menor != i)
                {
                    object swap = facturas[i];
                    facturas[i] = facturas[menor];
                    facturas[menor] = swap;
                }
            }
        }
        
        
        
        /*	--------------------------------------- CASE 8 ---------------------------------------  */
        
        //Imprime la tabla de todos los clientes (Tambien es utilizada en case 6)
        
        private void imprimirTablaClientes(ArrayList clientes, int tablaAncho, string titulo)
        {
            Cliente cliente;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    " + titulo+ "\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            imprimirDobleLinea(tablaAncho);
            imprimirFila(tablaAncho, "ID - Codigo", "Apellido y Nombre", "Dni", "Direccion", "Tecnico: ID - Zona", "Plan: ID - Nombre", "Canales Combo Plus", "Estado");
            imprimirDobleLinea(tablaAncho);
            for (int i = 0; i < clientes.Count; i++) {
                cliente = ((Cliente)clientes[i]);
                imprimirFila(tablaAncho, "("+cliente.IdCliente.ToString() +") - "+ cliente.Codigo.ToString(), cliente.Apellido +" "+  cliente.Nombre, cliente.Dni.ToString(),
                             cliente.DireccionCliente.ToString(), "("+cliente.TecnicoCliente.IdTecnico.ToString() +") "+ cliente.TecnicoCliente.ZonaTecnico.ToString().Replace('_', ' '),
                             "("+cliente.PlanFinal.Plan.IdPlan.ToString() +") "+cliente.PlanFinal.Plan.Nombre, cliente.PlanFinal.retornaNombreCanalesEspeciales(), cliente.EstadoCliente.ToString());
                if(i == clientes.Count - 1){
                    imprimirDobleLinea(tablaAncho);
                }
                else{imprimirLinea(tablaAncho);}
            }
        }
        
        /*	--------------------------------------- CASE 9 ---------------------------------------  */
        
        // Imprime tabla de todos los tecnicos
        
        private void imprimirTablaTecnicos(ArrayList tecnicos, int tablaAncho)
        {
            Tecnico tecnico;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n   TECNICOS\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            imprimirDobleLinea(tablaAncho);
            imprimirFila(tablaAncho, "ID", "Apellido y Nombre", "Dni", "Zona", "Clientes Asignados");
            imprimirDobleLinea(tablaAncho);
            for (int i = 0; i < tecnicos.Count; i++)
            {
                tecnico = ((Tecnico)tecnicos[i]);
                
                imprimirFila(tablaAncho, tecnico.IdTecnico.ToString(), tecnico.Apellido +" "+tecnico.Nombre,
                             tecnico.Dni.ToString(), tecnico.ZonaTecnico.ToString().Replace('_', ' '), tecnico.TotalClientes.ToString());
                
                if(i == tecnicos.Count - 1)
                    imprimirDobleLinea(tablaAncho);
                else{imprimirLinea(tablaAncho);}
            }
        }
        
        private void ordenarTecnicosPorCantidadClientesAsignados(ArrayList tecnicos)
        {
            int tam = tecnicos.Count;
            for(int i=0; i<(tam-1); i++)
            {
                int menor = i;
                
                for(int j=i+1; j<tam; j++)
                    if(((Tecnico)tecnicos[j]).TotalClientes < (((Tecnico)tecnicos[menor]).TotalClientes))
                        menor = j;
                if(menor != i)
                {
                    object swap = (Tecnico)tecnicos[i];
                    tecnicos[i] = tecnicos[menor];
                    tecnicos[menor] = swap;
                }
            }
        }

        private void ordenarTecnicosPorID(ArrayList tecnicos)
        {
            int n = tecnicos.Count;
            for(int i=0; i<(n-1); i++)
            {
                int menor = i;
                
                for(int j=i+1; j<n; j++)
                    if(((Tecnico)tecnicos[j]).IdTecnico < (((Tecnico)tecnicos[menor]).IdTecnico))
                        menor = j;
                if(menor != i)
                {
                    object swap = (Tecnico)tecnicos[i];
                    tecnicos[i] = tecnicos[menor];
                    tecnicos[menor] = swap;
                }
            }
        }
        
        /*	--------------------------------------- CASE 10 ---------------------------------------  */
        
        // Imprime la grilla de todos los canales
        
        private void imprimirTablaGrillaDeCanales(ArrayList canales, int tablaAncho, ComboPlus miComboPlus)
        {
            Canal canal;
            Console.WriteLine("\n   GRILLA DE CANALES \n");
            imprimirDobleLinea(tablaAncho);
            imprimirFila(tablaAncho, "ID ", "Codigo", "Nombre");
            imprimirDobleLinea(tablaAncho);
            for (int i = 0; i < canales.Count; i++)
            {
                canal = ((Canal)canales[i]);
                imprimirFila(tablaAncho, "("+canal.IdCanal+")", canal.Codigo.ToString(), canal.Nombre);
                imprimirLinea(tablaAncho);
            }
            
            for (int i = 0; i < miComboPlus.CanalesEspeciales.Count; i++)
            {
                canal = ((Canal)miComboPlus.CanalesEspeciales[i]);
                imprimirFila(tablaAncho, "("+canal.IdCanal+")", canal.Codigo.ToString(), canal.Nombre);
                if(i == miComboPlus.CanalesEspeciales.Count - 1)
                {
                    imprimirDobleLinea(tablaAncho);
                }
                else{imprimirLinea(tablaAncho);}
            }
        }
        
        /*	--------------------------------------- CASE 11 ---------------------------------------  */
        
        // Imprime el toString de la clase comboPlus
        
        
        private Direccion crearNuevaDireccion()
        {
            Direccion nuevaDireccion;
            Console.Write("Direccion:\n");
            Console.Write("   Ingrese calle: ");
            string calle = Console.ReadLine();
            Console.Write("   Ingrese numero: ");
            string numero = Console.ReadLine();
            Localidad miLocalidad = elegirLocalidad();
            nuevaDireccion = new Direccion(calle, numero, miLocalidad);
            return nuevaDireccion;
        }
        

        
        /*	--------------------------------------- Menu y Tablas ---------------------------------------  */
        
        // Metodos para imprimir el menu principal y los metodos para imprimir las tablas
        
        private void tituloMenu(int anchoEncabezado)
        {
            imprimirDobleLinea(anchoEncabezado);
            imprimirFila(anchoEncabezado, "                                                ");
            imprimirFila(anchoEncabezado, "                                                ");
            imprimirFila(anchoEncabezado, " CABLEVISION Y TELEFONIA");
            imprimirFila(anchoEncabezado, "  Sistema de Gestion");
            imprimirFila(anchoEncabezado, "                                                ");
            imprimirFila(anchoEncabezado, "                                                ");
            imprimirDobleLinea(anchoEncabezado);
        }
        
        private void miMenu()
        {
            string [] vector = {"Salir", "Agregar Cliente", "Eliminar Cliente (Inactivar al Cliente)", "Agregar Tecnico", "Imprimir Tecnico según Zona",
                "Imprimir Cliente según CODIGO", "Modificar minutos consumidos de un Cliente",
                "Facturacion", "Listado de Clientes", "Listado de Tecnicos", "Grilla de Canales",
                "Mostrar Combo Plus actual"};
            
            for (int i = 0; i < vector.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("    ["+ (i) + "]    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(vector[i]);
            }
            Console.WriteLine();
        }
        
        private void imprimirDobleLinea(int tablaAncho)
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" " + new string ('═', tablaAncho));
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        private void imprimirLinea(int tablaAncho)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" " + new string ('-', tablaAncho));
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        private void imprimirFila(int tablaAncho, params string[] columna)
        {
            int ancho = (tablaAncho - columna.Length)/columna.Length;
            string fila = "║";
            foreach (string column in columna)
            {
                fila += alinearAlCentro(column, ancho) + "║";
            }
            foreach (char caracter in fila) {
                if(caracter == '|' || caracter == '║'){
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(caracter);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else{
                    Console.Write(caracter);
                }
            }
            Console.WriteLine();
        }
        
        private string alinearAlCentro(string texto, int ancho)
        {
            texto = texto.Length > ancho ? texto.Substring(0, ancho - 3) + "..." : texto;
            if(string.IsNullOrEmpty(texto))
            {
                return new string(' ', ancho);
            }
            else
            {
                return texto.PadRight(ancho - (ancho- texto.Length)/2).PadLeft(ancho);
            }
        }
    }
}
