using System;
using FluentMigrator;


namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170307224500)]
    public class DefaultDB_20170307_224500_SampleData : Migration
    {
        public override void Up()
        {
            //  Create Users Booking2 with Permission Hotel. Can create only Bookings for HotelId= 2 EmpresaId =1
            // I suposse UserId = 2 
            Insert.IntoTable("Users").Row(new
            {
                Username = "Booking2",
                DisplayName = "Booking Hotel 2",
                Email = "admin@geshotel.com",
                Source = "site",
                PasswordHash = "aHiFfYAhHkNIzrkAUc29ovqX4tZR/Q67tUsD3tr+eKc+8oWmDY6e9EAY5zSS7zXYKAQEEXcqCLU7dMicKbh5Zg",
                PasswordSalt = "m.DQR",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                EmpresaId = 1,
                HotelId = 2,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "jnunez",
                DisplayName = "Javier Nuñez",
                Email = "admin@geshotel.com",
                Source = "site",
                PasswordHash = "fwYru7Z3kliO8Wr5pg3Bi4TkdWMiZtZR28QqyBonGhuaO+ViSS4PvTiWmoaj21Bjyr09+88lnk6VAU7Ig2Ozjg",
                PasswordSalt = "(zAu-",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                EmpresaId = 1,
                HotelId = 1,
                IsActive = 1
            });
            // Booking 2 is receptionist
            Insert.IntoTable("userroles").Row(new
            {
                UserId = 2,
                RoleId = 1
            });
            // jnunez is receptionist and Head of Reception
            Insert.IntoTable("userroles").Row(new
            {
                UserId = 3,
                RoleId = 1
            });
            Insert.IntoTable("userroles").Row(new
            {
                UserId = 3,
                RoleId = 2
            });
            // Now we add RolePermissions
            Insert.IntoTable("rolepermissions").Row(new
            {               
                RoleId = 1,
                PermissionKey = "Recepcion:Hotel"
            });
            Insert.IntoTable("rolepermissions").Row(new
            {
                RoleId = 1,
                PermissionKey = "Todos:General"
            });
            Insert.IntoTable("rolepermissions").Row(new
            {
                RoleId = 2,
                PermissionKey = "Todos:General"
            });

            // Head of Reception has Empresa, hotel and All
            Insert.IntoTable("rolepermissions").Row(new
            {
                RoleId = 2,
                PermissionKey = "Contratos:Empresa"
            });
            Insert.IntoTable("rolepermissions").Row(new
            {
                RoleId = 2,
                PermissionKey = "Contratos:General"
            });
            Insert.IntoTable("rolepermissions").Row(new
            {
                RoleId = 2,
                PermissionKey = "Recepcion:Hotel"
            });

            Insert.IntoTable("clientes").Row(new
            {
                razon = "Clientes Directos empresa 1",
                desc_corta = "DIR",
                empresa_id = 1,
                grupo_cliente_id = 1,
                cliente_defecto = 0,
                tipo_documento_id = "C",
                nif = "99999999",
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("clientes").Row(new
            {
                razon = "Clientes Extra Contado 1",
                desc_corta = "EXTRA",
                empresa_id = 1,
                agencia_id = 1,
                grupo_cliente_id = 2,
                cliente_defecto = 1,
                tipo_documento_id = "C",
                nif = "99999999",
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("clientes").Row(new
            {
                razon = "Clientes Directos empresa 2",
                desc_corta = "DIR",
                empresa_id = 2,
                grupo_cliente_id = 1,
                cliente_defecto = 0,
                tipo_documento_id = "C",
                nif = "99999999",
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("clientes").Row(new
            {
                razon = "Clientes Extra Contado 2",
                desc_corta = "EXTRA",
                empresa_id = 2,
                agencia_id = 3,
                grupo_cliente_id = 2,
                cliente_defecto = 1,
                tipo_documento_id = "C",
                nif = "99999999",
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 1,
                hotel_id = 2,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 10,
                hotel_id = 2,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 3,
                hotel_id = 2,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 91,
                hotel_id = 2,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 91,
                hotel_id = 1,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 38,
                hotel_id = 1,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 39,
                hotel_id = 1,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 40,
                hotel_id = 1,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 41,
                hotel_id = 1,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });



            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 2,
                hotel_id = 1,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 6,
                hotel_id = 2,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });
            Insert.IntoTable("servicios_hotel").Row(new
            {
                servicio_id = 11,
                hotel_id = 2,
                impuesto_id = 3,
                cta_contable = 7051000,
                dpto_contable = 100,
                permite_credito = 0
            });

            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                servicio_id = 11,    // B2
                hotel_id = 2,        // H2
                tipo_habitacion_id = 2 //B2
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {                
                hotel_id = 2,           // H2
                tipo_habitacion_id = 7 // Desvios
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                hotel_id = 2,           // H2
                tipo_habitacion_id = 20 // No Show
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                servicio_id = 10,  // B1
                hotel_id = 2,
                tipo_habitacion_id = 1  //B1
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                hotel_id = 1,               // H1
                tipo_habitacion_id = 20    // No Show
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                hotel_id = 1,               // H1
                tipo_habitacion_id = 7     // Desvios
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                servicio_id = 40,           // PRE
                hotel_id = 1,               // H1
                tipo_habitacion_id = 4      // PRE
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                servicio_id = 41,           // KS
                hotel_id = 1,               
                tipo_habitacion_id = 5      //  KS
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                servicio_id = 72,           // SUITE1
                hotel_id = 1,
                tipo_habitacion_id = 3      // SUITE 1
            });
            Insert.IntoTable("tipos_habitacion_hotel").Row(new
            {
                servicio_id = 73,          // SUITE 2
                hotel_id = 1,
                tipo_habitacion_id = 6     // SUITE 2
            });


            Insert.IntoTable("reservas").Row(new
            {
                fecha_creacion = DateTime.Now,
                hotel_id = 1,
                estado_reserva_id = 0,
                tipo_habitacion_id = 40,
                pension_id = 4,
                cliente_id = 2,
                adultos = 2,
                child_50 = 1,
                child_free = 0,
                bebes = 0,
                fecha_reserva = new DateTime(2017, 2, 1),
                nombre_reserva = "Javier Nuñez",
                fecha_prevista_llegada = new DateTime(2017,5,1,14,0,0),
                fecha_prevista_salida = new DateTime(2017, 5, 10, 14, 0, 0),
                bono_referencia = "123456789"
            });
            Insert.IntoTable("reservas").Row(new
            {
                fecha_creacion = DateTime.Now,
                hotel_id = 2,
                estado_reserva_id = 0,
                tipo_habitacion_id = 11,
                pension_id = 91,
                cliente_id = 2,
                adultos = 2,
                child_50 = 1,
                child_free = 1,
                bebes = 1,
                fecha_reserva = new DateTime(2017, 2, 1),
                nombre_reserva = "Javier Nuñez",
                fecha_prevista_llegada = new DateTime(2017, 5, 1, 14, 0, 0),
                fecha_prevista_salida = new DateTime(2017, 5, 10, 14, 0, 0),
                bono_referencia = "123456789"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "001"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "002"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "003"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "004"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "005"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "006"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "007"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "008"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "009"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 4,
                numero_habitacion = "010"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 5,
                numero_habitacion = "011"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 5,
                numero_habitacion = "012"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 5,
                numero_habitacion = "013"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 5,
                numero_habitacion = "014"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 5,
                numero_habitacion = "015"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 5,
                numero_habitacion = "016"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 5,
                numero_habitacion = "017"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 5,
                numero_habitacion = "018"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 7,
                numero_habitacion = "999"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 1,
                tipo_habitacion_id = 20,
                numero_habitacion = "888"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 7,
                numero_habitacion = "999"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 20,
                numero_habitacion = "888"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "001"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "002"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "003"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "004"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "005"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "006"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "007"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "008"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "009"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 1,
                numero_habitacion = "010"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 2,
                numero_habitacion = "011"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 2,
                numero_habitacion = "012"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 2,
                numero_habitacion = "013"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 2,
                numero_habitacion = "014"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 2,
                numero_habitacion = "015"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 2,
                numero_habitacion = "016"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 2,
                numero_habitacion = "017"
            });
            Insert.IntoTable("habitaciones").Row(new
            {
                hotel_id = 2,
                tipo_habitacion_id = 2,
                numero_habitacion = "018"
            });
        }

        public override void Down()
        {
        }

    }
}