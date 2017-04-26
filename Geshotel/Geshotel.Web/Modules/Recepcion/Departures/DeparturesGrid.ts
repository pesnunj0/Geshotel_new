/************************************************************************************************************************************************************
Departures List
What I try to do is the following:

1.- Filter Reservations with status = PreCheckedOut and FechaSalida = FechaHotel. As I do not know how to get it, i use currentdate instead
2.- Select Reservations end user wants to checkOut and Add a button to do it

Javier Núñez : APRIL 2017
*************************************************************************************************************************************************************/

/// <reference path="../Reservas/ReservasGrid.ts" />

namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class DeparturesGrid extends Recepcion.ReservasGrid {

        private rowSelection: Serenity.GridRowSelectionMixin;

        constructor(container: JQuery) {
            super(container);
        }

        protected createToolbarExtensions() {           
            super.createToolbarExtensions();
            this.rowSelection = new Serenity.GridRowSelectionMixin(this);
        }


        getInitialTitle() {
            super.getInitialTitle()
            return Q.text("Db.Recepcion.Departures.EntityPlural")
        }

        getButtons() {
            return [{
                title: Q.text('Controls.EntityGrid.CheckOutDeparturesButton'),
                cssClass: 'check-out-button',
                icon: 'fa-chevron-circle-left text-green',
                onClick: () => {
                    if (!this.onViewSubmit()) {
                        return;
                    }

                    var action = new CheckOutAction();
                    action.done = () => this.rowSelection.resetCheckedAndRefresh();
                    action.execute(this.rowSelection.getSelectedKeys());
                }
            }];
        }
        protected getColumns() {
            var columns = super.getColumns();
            columns.splice(0, 0, Serenity.GridRowSelectionMixin.createSelectColumn(() => this.rowSelection));
            return columns;
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 2500;
            return opt;
        }

        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            // Let's filter Reservations with Departure (fecha_salida) = FechaHotel
            // and withs status = ReservationStatus.ArrivalPending


            // get quick filter list from base class
            let filters = super.getQuickFilters();

            // get a reference to reservas row field names
            let fld = Recepcion.ReservasRow.Fields;

            var user = Q.Authorization.userDefinition as ScriptUserDefinition;

            Q.first(filters, x => x.field == fld.FechaSalida).init = w => {
                var date = new Date();  // La fecha actual es por defecto la fecha del hotel si no hay cierres
                date.setHours(0, 0, 0, 0);
                if (user.HotelId != null) {
                    var hotel = Portal.HotelesRow.getLookup().itemById[user.HotelId];
                    if (hotel != null && !Q.isEmptyOrNull(hotel.FechaHotel))
                        date = Q.parseDate(hotel.FechaHotel);                   
                }

                var dateini = new Date(date.getTime());
                (w as Serenity.DateEditor).valueAsDate = dateini;

                var datefin = new Date(date.getTime());
                datefin.setHours(23, 55, 0, 0);
                // Aqui en caso de que quisieramos llamar a FechaPrevistaLlegada que tiene fecha y hora,
                // En vez de .s-DateEditor.dateQ pondremos .s-DateTimeEditor.dateQ y en vez de Serenity.DateEditor
                // pondremos Serenity.DateTimeEditor
                let endDate = w.element.nextAll(".s-DateEditor.dateQ").getWidget(Serenity.DateEditor);
                endDate.valueAsDate = datefin;
            };

            Q.first(filters, x => x.field == fld.EstadoReservaId).init = w => {
                // enum editor has a string value, so need to call toString()
                (w as Serenity.EnumEditor).value = ReservationStatus.PreCheckedOut.toString();
            };

            return filters;
        }

    }
}