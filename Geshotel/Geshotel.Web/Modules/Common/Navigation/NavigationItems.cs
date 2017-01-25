﻿using Serenity.Navigation;
using Administration = Geshotel.Administration.Pages;
using Portal = Geshotel.Portal.Pages;

[assembly: NavigationLink(1000, "Dashboard", url: "~/", permission: "", icon: "icon-speedometer")]

[assembly: NavigationLink(8000, "Contratos/Clientes", typeof(Geshotel.Contratos.Pages.ClientesController))]


[assembly: NavigationMenu(9000, "Settings", icon: "icon-settings")]

[assembly: NavigationMenu(9100, "Settings/Administration", icon: "icon-screen-desktop")]

[assembly: NavigationLink(9100, "Settings/Administration/Exceptions Log", url: "~/errorlog.axd", permission: Geshotel.Administration.PermissionKeys.Security, icon: "icon-ban", Target = "_blank")]
[assembly: NavigationLink(9100, "Settings/Administration/Languages", typeof(Administration.LanguageController), icon: "icon-bubbles")]
[assembly: NavigationLink(9100, "Settings/Administration/Translations", typeof(Administration.TranslationController), icon: "icon-speech")]
[assembly: NavigationLink(9100, "Settings/Administration/Roles", typeof(Administration.RoleController), icon: "icon-lock")]
[assembly: NavigationLink(9100, "Settings/Administration/User Management", typeof(Administration.UserController), icon: "icon-people")]


[assembly: NavigationMenu(9200, "Settings/Customers", icon: "icon-screen-desktop")]

[assembly: NavigationLink(9200, "Settings/Customers/Servicios", typeof(Geshotel.Portal.Pages.ServiciosController), icon: "icon-basket")]
[assembly: NavigationLink(9200, "Settings/Customers/Hoteles", typeof(Geshotel.Portal.Pages.HotelesController), icon: "fa-building-o")]
[assembly: NavigationLink(9200, "Settings/Customers/Empresas", typeof(Geshotel.Portal.Pages.EmpresasController), icon: "fa-industry")]

[assembly: NavigationMenu(9300, "Settings/CommonData", icon: "icon-screen-desktop")]

[assembly: NavigationLink(9300, "Settings/CommonData/CategoriaHoteles", typeof(Geshotel.Portal.Pages.CategoriaHotelesController), icon: "icon-star")]
[assembly: NavigationLink(9300, "Settings/CommonData/GruposDeServicios", typeof(Geshotel.Portal.Pages.GruposDeServiciosController), icon: "icon-basket-loaded")]
[assembly: NavigationLink(9300, "Settings/CommonData/GruposHabitacion", typeof(Geshotel.Portal.Pages.GruposHabitacionController), icon: "fa-bed")]
[assembly: NavigationLink(9300, "Settings/CommonData/TiposHabitacion", typeof(Geshotel.Portal.Pages.TiposHabitacionController), icon: "fa-bed")]
[assembly: NavigationLink(9300, "Settings/CommonData/TiposHotel", typeof(Geshotel.Portal.Pages.TiposHotelController), icon: "fa-home")]
[assembly: NavigationLink(9300, "Settings/CommonData/TiposHuesped", typeof(Geshotel.Portal.Pages.TiposHuespedController), icon: "icon-people")]
[assembly: NavigationLink(9300, "Settings/CommonData/TiposServicio", typeof(Geshotel.Portal.Pages.TiposServicioController), icon: "fa-opencart")]
[assembly: NavigationLink(9300, "Settings/CommonData/UnidadesCalculo", typeof(Geshotel.Portal.Pages.UnidadesCalculoController), icon: "fa-pencil")]
[assembly: NavigationLink(9300, "Settings/CommonData/ComunidadesAutonomas", typeof(Geshotel.Portal.Pages.ComunidadesAutonomasController), icon: "icon-speech")]
[assembly: NavigationLink(9300, "Settings/CommonData/FormasDePago", typeof(Geshotel.Portal.Pages.FormasDePagoController), icon: "fa-money")]
[assembly: NavigationLink(9300, "Settings/CommonData/Monedas", typeof(Geshotel.Portal.Pages.MonedasController), icon: "fa-eur")]
[assembly: NavigationLink(9300, "Settings/CommonData/Naciones", typeof(Geshotel.Portal.Pages.NacionesController), icon: "icon-globe")]
[assembly: NavigationLink(9300, "Settings/CommonData/Provincias", typeof(Geshotel.Portal.Pages.ProvinciasController), icon: "icon-flag")]

