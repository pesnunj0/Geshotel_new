

namespace Geshotel.Recepcion.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Configuration;
    using System.Data;
    using MyRow = Entities.ReservasHuespedesRow;

    public class ReservasHuespedesRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {

            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            public static Int32 GetGuest(IDbConnection connection, String query)
            {
                
                var huespedid = 0;

                var result = connection.Query<Int32>(query);
                foreach (Int32 id in result)
                {
                    huespedid = id;
                }
                

                if (result == null)
                    return 0;

                return huespedid;
            }
            public static Boolean UpdateGuest(IDbConnection connection, MyRow row, Int32 Id )
            {
                var user = (UserDefinition)Authorization.UserDefinition;
                string sqlQuery = "UPDATE huespedes SET nombre=@nombre,apellidos=@apellidos";
                if (row.TipoDocumentoId != null)
                    sqlQuery += ",tipo_documento_id='" + row.TipoDocumentoId + "'";
                if (row.Nif != null)
                    sqlQuery += ",nif='" + row.Nif + "'";
                if (row.FechaDocumento != null)
                    sqlQuery += ",fecha_documento='" + Convert.ToDateTime(row.FechaDocumento).ToString("yyyy-MM-dd") + "'";
                if (row.SexoId != null)
                    sqlQuery += ",sexo_id='" + row.SexoId + "'";
                if (row.Direccion != null)
                    sqlQuery += ",direccion='" + row.Direccion + "'";
                if (row.Poblacion != null)
                    sqlQuery += ",poblacion='" + row.Poblacion + "'";
                if (row.Zip != null)
                    sqlQuery += ",zip='" + row.Zip + "'";
                if (row.NacionId != null)
                    sqlQuery += ",nacion_id='" + row.NacionId + "'";
                if (row.ProvinciaId != null)
                    sqlQuery += ",provincia_id='" + row.ProvinciaId + "'";
                if (row.FechaNacimiento != null)
                    sqlQuery += ",fecha_nacimiento='" + Convert.ToDateTime(row.FechaNacimiento).ToString("yyyy-MM-dd") + "'";
                if (row.Telefono != null)
                    sqlQuery += ",telefono='" + row.Telefono + "'";
                if (row.Email != null)
                    sqlQuery += ",email='" + row.Email + "'";
                if (row.TarjetaFidelizacion != null)
                    sqlQuery += ",tarjeta_fidelizacion='" + row.TarjetaFidelizacion + "'";
                sqlQuery += ",user_id =" + user.UserId + ",fecha_modificacion ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                sqlQuery += " WHERE huesped_id=@id";

                //string sqlQuery = "UPDATE huespedes SET nombre=@nombre,apellidos=@apellidos,tipo_documento_id=@tipo_documento,nif=@nif,fecha_documento=@fecha_dcumento, ";
                //sqlQuery += "sexo_id=@sexo_id,direccion=@direccion,poblacion=@poblacion,zip=@zip,nacion_id=@nacion_id,provincia_id=@provincia_id,telefono=@telefono,email=@email,fecha_naciomento=@fecha_nacimiento=@fecha_nacimiento,user_id=@user_id,fecha_modificacion=@fecha_modificacion";

                var cont = connection.Execute(sqlQuery,
                    new
                    {
                        row.Nombre,
                        row.Apellidos,
                        //    row.TipoDocumentoId,
                        //    row.Nif,
                        //    row.FechaDocumento,
                        //    row.SexoId,
                        //    row.Direccion,
                        //    row.Poblacion,
                        //    row.Zip,
                        //    row.NacionId,
                        //    row.ProvinciaId,
                        //    row.Telefono,
                        //    row.Email,
                        //    Convert.ToDateTime(row.FechaNacimiento).ToString("yyyy-MM-dd"),
                        //    (int)user.UserId,
                        //    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Id
                    });
                return true;
            }
            // *************************************************************************
            // Funcion que calcula la edad de una persona con respecto al día de Hoy
            // Pillada por internet
            // *************************************************************************
            public Int16 Edad(DateTime fechaNacimiento)
            {
                //Obtengo la diferencia en años.
                int edad = DateTime.Now.Year - fechaNacimiento.Year;

                //Obtengo la fecha de cumpleaños de este año.
                DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);
                //Le resto un año si la fecha actual es anterior 
                //al día de nacimiento.
                if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
                {
                    edad--;
                }

                return (short)edad;
            }
            public static Int32 CreateGuest(IDbConnection connection, MyRow row)
            {
                var user = (UserDefinition)Authorization.UserDefinition;

                string sqlQuery = "INSERT INTO huespedes (nombre,apellidos,empresa_id";
                string Values = "VALUES(@nombre,@apellidos," + row.EmpresaId;
                if (row.TipoDocumentoId != null)
                {
                    sqlQuery += ",tipo_documento_id";
                    Values += ",'" + row.TipoDocumentoId + "'";
                }
                if (row.Nif != null)
                {
                    sqlQuery += ",nif";
                    Values += ",'" + row.Nif + "'";
                }
                if (row.FechaDocumento != null)
                {
                    sqlQuery += ",fecha_documento";
                    Values += ",'" + Convert.ToDateTime(row.FechaDocumento).ToString("yyyy-MM-dd") + "'";
                }
                if (row.SexoId != null)
                {
                    sqlQuery += ",sexo_id";
                    Values += ",'" + row.SexoId + "'";
                }
                if (row.Direccion != null)
                {
                    sqlQuery += ",direccion";
                    Values += ",'" + row.Direccion + "'";
                }

                if (row.Poblacion != null)
                {
                    sqlQuery += ",poblacion";
                    Values += ",'" + row.Poblacion + "'";
                }
                if (row.Zip != null)
                {
                    sqlQuery += ",zip";
                    Values += ",'" + row.Zip + "'";
                }
                if (row.NacionId != null)
                {
                    sqlQuery += ",nacion_id";
                    Values += ",'" + row.NacionId + "'";
                }
                if (row.ProvinciaId != null)
                {
                    sqlQuery += ",provincia_id";
                    Values += ",'" + row.ProvinciaId + "'";
                }
                if (row.FechaNacimiento != null)
                {
                    sqlQuery += ",fecha_nacimiento";
                    Values += ",'" + Convert.ToDateTime(row.FechaNacimiento).ToString("yyyy-MM-dd") + "'";
                }
                if (row.Telefono != null)
                {
                    sqlQuery += ",telefono";
                    Values += ",'" + row.Telefono + "'";
                }
                if (row.Email != null)
                {
                    sqlQuery += ",email"; 
                    Values += ",'" + row.Email + "'";
                }
                if (row.TarjetaFidelizacion != null)
                {
                    sqlQuery += ",tarjeta_fidelizacion";
                    Values += ",'"+ row.TarjetaFidelizacion + "'";
                }
                sqlQuery += ",user_id,fecha_modificacion) ";
                Values +=  "," + user.UserId + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                sqlQuery += Values;
                
                
                //string sqlQuery = "UPDATE huespedes SET nombre=@nombre,apellidos=@apellidos,tipo_documento_id=@tipo_documento,nif=@nif,fecha_documento=@fecha_dcumento, ";
                //sqlQuery += "sexo_id=@sexo_id,direccion=@direccion,poblacion=@poblacion,zip=@zip,nacion_id=@nacion_id,provincia_id=@provincia_id,telefono=@telefono,email=@email,fecha_naciomento=@fecha_nacimiento=@fecha_nacimiento,user_id=@user_id,fecha_modificacion=@fecha_modificacion";

                var cont = connection.Execute(sqlQuery,
                    new
                    {
                        row.Nombre,
                        row.Apellidos,
                        //row.EmpresaId
                        //    row.TipoDocumentoId,
                        //    row.Nif,
                        //    row.FechaDocumento,
                        //    row.SexoId,
                        //    row.Direccion,
                        //    row.Poblacion,
                        //    row.Zip,
                        //    row.NacionId,
                        //    row.ProvinciaId,
                        //    row.Telefono,
                        //    row.Email,
                        //    Convert.ToDateTime(row.FechaNacimiento).ToString("yyyy-MM-dd"),
                        //    (int)user.UserId,
                        //    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        
                    });
                
                sqlQuery = "SELECT Last_insert_id()";
                string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
                if (provider == "System.Data.SqlClient")
                    sqlQuery= "SELECT SCOPE_IDENTITY()";

                var result = connection.Query<ulong>("SELECT LAST_INSERT_ID();");
                int huespedid = 0;
                foreach (Int64 id in result)
                {
                    huespedid = Convert.ToInt32(id);
                }
                return huespedid;
            }
            public static Boolean DeleteGuest(IDbConnection connection, Int32 Id)
            {
                string sqlQuery = "DELETE FROM huespedes WHERE huesped_id = @id";
                var cont = connection.Execute(sqlQuery,
                    new
                    {
                        Id
                    });
                return true;
            }
            protected override void SetInternalFields()
            {
                base.SetInternalFields();
                // Buscamos un huesped de la empresa que tenga el mismo nombre y apellidos
                // y que tenga el mismo dni o el mismo mail
                Int32 HuespedID = 0;
                Boolean error = false;
                // Si los dos son nulos entonces lo considero uno nuevo pero incompleto ==> HuespedID = 0
                if (Row.Nif != null | Row.Email != null)   
                {
                    String query = "SELECT huesped_id FROM huespedes WHERE empresa_id = " + Row.EmpresaId;
                    query += " AND nombre ='" + Row.Nombre + "' AND Apellidos = '" + Row.Apellidos + "'";

                    if (Row.Nif != null)                    
                        query += " AND nif ='" + Row.Nif + "'";                  
                    else
                        query += "AND email ='" + Row.Email + "'";

                    HuespedID = GetGuest(this.Connection, query);
                    // Aquí puede suceder que 
                    // 1.- HuespedID = 0 y Row.HuespedId != null entonces UPDATE de huespedes con los campos de Row
                    // 2.- HuespedID = 0 y Row.HuespedId == null entonces INSERT en huespedes con los campos de Row. Esto me dara nuevo HuespedId que lo pondré en Row.HuespedId
                    // 3.- HuespedID == Row.HuespedId entonces UPDATE con los campos de Row
                    // 4.- HuespedID != Row.HuespedID entonces borramos el huesped Row.HuespedID y UPDATE de huespedes con los campos de Row

                    if (HuespedID == 0 & Row.HuespedId != null)  // Ha cambiado algún campo principal y por eso no lo encuentra
                    {
                        error = UpdateGuest(this.Connection, Row, (int)Row.HuespedId);
                        HuespedID = (int)Row.HuespedId;
                    }
                    else if (HuespedID == 0 & Row.HuespedId == null)
                        HuespedID = CreateGuest(this.Connection, Row);
                    else if (HuespedID == Row.HuespedId)
                        error = UpdateGuest(this.Connection, Row, (int)Row.HuespedId);
                    else // Caso 4
                    {
                        error = DeleteGuest(this.Connection, (int)Row.HuespedId);
                        error = UpdateGuest(this.Connection, Row, HuespedID);
                    } 
                }else
                {
                    if (Row.HuespedId==null)
                        HuespedID = CreateGuest(this.Connection, Row);
                    else
                    {
                        error = UpdateGuest(this.Connection, Row, (int)Row.HuespedId);
                        HuespedID = (int)Row.HuespedId;
                    }
                }
                if (Row.FechaNacimiento != null)
                    Row.Edad = Edad(Convert.ToDateTime(Row.FechaNacimiento));                             
                Row.HuespedId = HuespedID ;
            }
        }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}