using Serenity.Navigation;
using Administration = Geshotel.Administration.Pages;
using Portal = Geshotel.Portal.Pages;

[assembly: NavigationLink(1000, "Dashboard", url: "~/", permission: "", icon: "icon-speedometer")]

[assembly: NavigationMenu(4000, "Recepcion", icon: "icon-people")]

[assembly: NavigationLink(4000, "Recepcion/Reservas", typeof(Geshotel.Recepcion.Pages.ReservasController),icon:"icon-note")]
[assembly: NavigationLink(4000, "Recepcion/Scheduler", typeof(Geshotel.Recepcion.Pages.SchedulerController), icon: "icon-calendar")]
[assembly: NavigationLink(4000, "Recepcion/Llegadas", typeof(Geshotel.Recepcion.Pages.ArrivalsController), icon: "fa-briefcase")]
[assembly: NavigationLink(4000, "Recepcion/Salidas", typeof(Geshotel.Recepcion.Pages.DeparturesController), icon: "fa-plane")]
[assembly: NavigationLink(4000, "Recepcion/ClientesAlojados", typeof(Geshotel.Recepcion.Pages.ClientesAlojadosController), icon:"icon-people")]
[assembly: NavigationLink(4000, "Recepcion/HabitacionesBloqueos", typeof(Geshotel.Recepcion.Pages.HabitacionesBloqueosController),icon:"icon-lock")]

[assembly: NavigationMenu(6000, "Contratos", icon:"icon-layers")]

[assembly: NavigationLink(6000, "Contratos/Agencias", typeof(Geshotel.Contratos.Pages.AgenciasController), icon: "icon-people")]
[assembly: NavigationLink(6000, "Contratos/Touroperadores", typeof(Geshotel.Contratos.Pages.ClientesController),icon: "icon-user")]
[assembly: NavigationLink(6000, "Contratos/Habitaciones", typeof(Geshotel.Contratos.Pages.HabitacionesController),icon:"fa-bed")]
[assembly: NavigationLink(6000, "Contratos/Contratos", typeof(Geshotel.Contratos.Pages.ContratosController), icon:"icon-note")]
[assembly: NavigationLink(6000, "Contratos/Mercados", typeof(Geshotel.Contratos.Pages.MercadosController), icon: "icon-chart")]
[assembly: NavigationLink(6000, "Contratos/LineasFactura", typeof(Geshotel.Contratos.Pages.LineasFacturaController))]
[assembly: NavigationLink(6000, "Contratos/Temporadas", typeof(Geshotel.Contratos.Pages.TemporadasController), icon: "icon-calendar")]
[assembly: NavigationLink(6000, "Contratos/TiposHabitacionHotel", typeof(Geshotel.Contratos.Pages.TiposHabitacionHotelController), icon: "fa-bed")]
[assembly: NavigationLink(6000, "Contratos/ServiciosHotel", typeof(Geshotel.Contratos.Pages.ServiciosHotelController), icon: "icon-basket")]
[assembly: NavigationLink(6000, "Contratos/Impuestos", typeof(Geshotel.Portal.Pages.ImpuestosController), icon: "fa-money")]
[assembly: NavigationLink(6000, "Contratos/CanalesReserva", typeof(Geshotel.Contratos.Pages.CanalesReservaController))]
[assembly: NavigationLink(6000, "Contratos/Cajas", typeof(Geshotel.Contratos.Pages.CajasController),icon:"fa-eur")]
[assembly: NavigationLink(6000, "Contratos/Contadores", typeof(Geshotel.Contratos.Pages.ContadoresController),icon:"icon-calculator")]
[assembly: NavigationLink(6000, "Contratos/Series", typeof(Geshotel.Contratos.Pages.SeriesController),icon:"icon-bubbles")]

//[assembly: NavigationLink(6000, "Contratos/Lineas de Contrato", typeof(Geshotel.Contratos.Pages.LineasController), icon: "icon-note")]
//[assembly: NavigationLink(6000, "Contratos/Cupos", typeof(Geshotel.Contratos.Pages.CuposController))]
//[assembly: NavigationLink(6000, "Contratos/Ofertas", typeof(Geshotel.Contratos.Pages.OfertasController))]
//[assembly: NavigationLink(6000, "Contratos/Edades", typeof(Geshotel.Contratos.Pages.EdadesController))]

[assembly: NavigationMenu(8000, "Informes", icon: "icon-printer")]

[assembly: NavigationMenu(9000, "Settings", icon: "icon-settings")]

[assembly: NavigationMenu(9100, "Settings/Administration", icon: "icon-screen-desktop")]

[assembly: NavigationLink(9100, "Settings/Administration/Exceptions Log", url: "~/errorlog.axd", permission: Geshotel.Administration.PermissionKeys.Security, icon: "icon-ban", Target = "_blank")]
[assembly: NavigationLink(9100, "Settings/Administration/Languages", typeof(Administration.LanguageController), icon: "icon-bubbles")]
[assembly: NavigationLink(9100, "Settings/Administration/Translations", typeof(Administration.TranslationController), icon: "icon-speech")]
[assembly: NavigationLink(9100, "Settings/Administration/Roles", typeof(Administration.RoleController), icon: "icon-lock")]
[assembly: NavigationLink(9100, "Settings/Administration/User Management", typeof(Administration.UserController), icon: "icon-people")]
[assembly: NavigationLink(9100, "Settings/Administration/ComunidadesAutonomas", typeof(Geshotel.Portal.Pages.ComunidadesAutonomasController), icon: "icon-speech")]
[assembly: NavigationLink(9100, "Settings/Administration/Monedas", typeof(Geshotel.Portal.Pages.MonedasController), icon: "fa-eur")]
[assembly: NavigationLink(9100, "Settings/Administration/Naciones", typeof(Geshotel.Portal.Pages.NacionesController), icon: "icon-globe")]
[assembly: NavigationLink(9100, "Settings/Administration/Provincias", typeof(Geshotel.Portal.Pages.ProvinciasController), icon: "icon-flag")]


[assembly: NavigationMenu(9200, "Settings/Hotels", icon: "fa-industry")]

[assembly: NavigationLink(9200, "Settings/Hotels/Hoteles", typeof(Geshotel.Portal.Pages.HotelesController), icon: "fa-building-o")]
[assembly: NavigationLink(9200, "Settings/Hotels/Empresas", typeof(Geshotel.Portal.Pages.EmpresasController), icon: "fa-industry")]
[assembly: NavigationLink(9200, "Settings/Hotels/CategoriaHoteles", typeof(Geshotel.Portal.Pages.CategoriaHotelesController), icon: "icon-star")]
[assembly: NavigationLink(9200, "Settings/Hotels/GruposDeCliente", typeof(Geshotel.Portal.Pages.GruposDeClienteController), icon: "icon-people")]
[assembly: NavigationLink(9200, "Settings/Hotels/GruposHabitacion", typeof(Geshotel.Portal.Pages.GruposHabitacionController), icon: "fa-bed")]
[assembly: NavigationLink(9200, "Settings/Hotels/TiposHabitacion", typeof(Geshotel.Portal.Pages.TiposHabitacionController), icon: "fa-bed")]
[assembly: NavigationLink(9200, "Settings/Hotels/TiposHotel", typeof(Geshotel.Portal.Pages.TiposHotelController), icon: "fa-home")]
[assembly: NavigationLink(9200, "Settings/Hotels/TiposHuesped", typeof(Geshotel.Portal.Pages.TiposHuespedController), icon: "icon-people")]
[assembly: NavigationLink(9200, "Settings/Hotels/TiposBloqueoHabitacion", typeof(Geshotel.Portal.Pages.TiposBloqueoController),icon: "fa-hand-stop-o")]
[assembly: NavigationLink(9200, "Settings/Hotels/EstadoHabitaciones", typeof(Geshotel.Portal.Pages.HabitacionesSituacionController))]



[assembly: NavigationMenu(9300, "Settings/Accounting", icon: "fa-money")]

[assembly: NavigationLink(9200, "Settings/Accounting/Servicios", typeof(Geshotel.Portal.Pages.ServiciosController), icon: "icon-basket")]
[assembly: NavigationLink(9300, "Settings/Accounting/GruposDeServicios", typeof(Geshotel.Portal.Pages.GruposDeServiciosController), icon: "icon-basket-loaded")]
[assembly: NavigationLink(9300, "Settings/Accounting/TiposServicio", typeof(Geshotel.Portal.Pages.TiposServicioController), icon: "fa-opencart")]
[assembly: NavigationLink(9300, "Settings/Accounting/UnidadesCalculo", typeof(Geshotel.Portal.Pages.UnidadesCalculoController), icon: "fa-pencil")]
[assembly: NavigationLink(9300, "Settings/Accounting/TipoAplicacionOferta", typeof(Geshotel.Portal.Pages.TipoAplicacionOfertaController))]
[assembly: NavigationLink(9300, "Settings/Accounting/FormasDePago", typeof(Geshotel.Portal.Pages.FormasDePagoController), icon: "fa-credit-card")]
[assembly: NavigationLink(9300, "Settings/Accounting/AmbitoOferta", typeof(Geshotel.Portal.Pages.AmbitoOfertaController))]
[assembly: NavigationLink(9300, "Settings/Accounting/TiposCondicion", typeof(Geshotel.Portal.Pages.TiposCondicionController))]
[assembly: NavigationLink(9300, "Settings/Accounting/TiposDeImputacion", typeof(Geshotel.Portal.Pages.TiposDeImputacionController))]
[assembly: NavigationLink(9300, "Settings/Accounting/TiposDeOferta", typeof(Geshotel.Portal.Pages.TiposDeOfertaController),icon:"fa-usd")]
[assembly: NavigationLink(9300, "Settings/Accounting/FrecuenciaFacturacion", typeof(Geshotel.Portal.Pages.FrecuenciaFacturacionController),icon:"fa-calendar")]
[assembly: NavigationLink(9300, "Settings/Accounting/TiposDeTarjeta", typeof(Geshotel.Portal.Pages.TiposDeTarjetaController),icon:"fa-credit-card")]

