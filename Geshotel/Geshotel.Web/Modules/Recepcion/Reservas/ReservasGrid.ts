/*********************************************************************************************************************************
Cambiamos el css si el estado de la reserva es con errores, la ponemos en rojo " out-of-stock"
Si está pendiente de entrar o de salir la pondremos en Naranja (estado = 2 y llegada = hoy o estado =3 o 4 y salida = hoy)
Gris si estado =1 o si estado= 5. Normal el resto.
Seems no working
Javier Núñez : ABRIL 2017
**********************************************************************************************************************************/

namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ReservasGrid extends Serenity.EntityGrid<ReservasRow, any> {
        protected getColumnsKey() { return 'Recepcion.Reservas'; }
        protected getDialogType() { return ReservasDialog; }
        protected getIdProperty() { return ReservasRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasRow.localTextPrefix; }
        protected getService() { return ReservasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Recepcion/Reservas/ListExcel',
                separator: true
            }));

            buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }
        /**
 * This method is called for all rows
 * @param item Data item for current row
 * @param index Index of the row in grid
 */
        protected getItemCssClass(item: Recepcion.ReservasRow, index: number): string {
            var fechaHotel = item.HotelId == null ? null : Portal.HotelesRow.getLookup().itemById[item.HotelId].FechaHotel;

            let klass: string = "";
            if (item.EstadoReservaId == 0)
                klass += " con-errores";
            else if (item.EstadoReservaId == 5)
                klass += " facturada";
            else if (item.EstadoReservaId == 2)
                klass += " anulada";
            else if (item.EstadoReservaId == 6)
                klass += " no-show";
            else if (Q.formatDate(fechaHotel, 'yyyy-MM-dd') == Q.formatDate(item.FechaPrevistaLlegada, 'yyyy-MM-dd') && item.EstadoReservaId == 1)
                klass += " pendiente";
            else if (Q.formatDate(fechaHotel, 'yyyy-MM-dd') == Q.formatDate(item.FechaPrevistaSalida, 'yyyy-MM-dd') && item.EstadoReservaId >= 3)
                klass += " pendiente";
            else if (item.EstadoReservaId == 3)
                klass += " checked-in"

            return Q.trimToNull(klass);
        }

        /**
         * This method is called to get list of quick filters to be created for this grid.
         * By default, it returns quick filter objects corresponding to properties that
         * have a [QuickFilter] attribute at server side OrderColumns.cs
         */
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {

            // get quick filter list from base class
            let filters = super.getQuickFilters();

            // get a reference to order row field names
            let fld = Recepcion.ReservasRow.Fields;

            // quick filter init method is a good place to set initial
            // value for a quick filter editor, just after it is created
            // *************************************************************************
            // Here I would like to get QuickFilter By default EmpresaId and HotelId 
            // corresponding to users record for current userId

            //var user = fld.UserId;
            

            //Q.first(filters, x => x.field == fld.EmpresaId).init = w => {
 
            //    (w as Serenity.EnumEditor).value = fld.EmpresaId.toString();

            //};

            //Q.first(filters, x => x.field == fld.HotelId).init = w => {
            //    (w as Serenity.EnumEditor).value = Northwind.OrderShippingState.NotShipped.toString()
            //};
            
            return filters;
        }
    }
}