/***********************************************************************************************************************************
* En este Grid hacemos varias cosas.
* 1.- Eliminamos el Botón añadir nuevo registro para evitar usarlo de mantenimiento
* 2.- Ponemos los botones de exportar a PDF y Excel
* 3.- Ponemos los quickFilter por defecto de EmpresaId, HotelId y EstadoReservaId = Check-in y PreCheck-Out (3 y 4)
*     Para ello usamos la función getQuickFilters() y como no se poner en esta función varios valores posibles para un campo,
*     utilizo la subrutina createQuickFilters(): void
*
* Javier Nuñez
* Mayo 2017
*************************************************************************************************************************************/


namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ClientesAlojadosGrid extends Serenity.EntityGrid<ReservasHuespedesRow, any> {
        protected getColumnsKey() { return 'Recepcion.ClientesAlojados'; }
        protected getDialogType() { return ReservasHuespedesDialog; }
        protected getIdProperty() { return ReservasHuespedesRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasHuespedesRow.localTextPrefix; }
        protected getService() { return ClientesAlojadosService.baseUrl; }


        getInitialTitle() {
            super.getInitialTitle()
            return Q.text("Db.Recepcion.ClientesAlojados.EntityPlural")
        }

        getButtons() {
            var buttons = super.getButtons();

            // Quitamos el botón de añadir nuevo huesped para evitar la creación aqui
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);

            // Añadimos la posibilidad de exportar a excel y PDF
            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Recepcion/ClientesAlojados/ListExcel',
                separator: true
            }));

            buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }

        protected getColumns() {
            var columns = super.getColumns();
            return columns;
        }

        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            // Let's filter Reservations with arrival (fecha_llegada) = today
            // and withs status = ReservationStatus.CheckedIn
            // get quick filter list from base class
            let filters = super.getQuickFilters();

            // get a reference to reservas row field names
            let fld = Recepcion.ReservasHuespedesRow.Fields;            

            var user = Q.Authorization.userDefinition as ScriptUserDefinition;

            Q.first(filters, x => x.field == fld.EmpresaId).init = w => {
                (w as Serenity.LookupEditor).value = user.EmpresaId == null ? "" : user.EmpresaId.toString();
            };

            Q.first(filters, x => x.field == fld.HotelId).init = w => {
                (w as Serenity.LookupEditor).value = user.HotelId == null ? "" : user.HotelId.toString();
            };

            //Q.first(filters, x => x.field == fld.ReservaEstadoReservaId).init = w => {
            //    // enum editor has a string value, so need to call toString()
            //    (w as Serenity.EnumEditor).value = "3" || (w as Serenity.EnumEditor).value = "3" ;
            //};

            return filters;
        }
         /**
         * This method is another possible place to modify quick filter widgets.
         * It is where the quick filter widgets are actually created.
         * 
         * By default, it calls getQuickFilters() then renders UI for these
         * quick filters.
         *
         * We could use getQuickFilters() method for EstadoReserva too,
         * but this is for demonstration purposes and I do not know how to place several values
         * Javier Nuñez Mayo 2017
         */
        protected createQuickFilters(): void {

            // let base class to create quick filters first
            super.createQuickFilters();

            // get a reference to order row field names
            let fld = Recepcion.ReservasHuespedesRow.Fields; 

            // find a quick filter widget by its field name
            this.findQuickFilter(Serenity.LookupEditor, fld.ReservaEstadoReservaId).values = ["3", "4"];
        }

    }
}