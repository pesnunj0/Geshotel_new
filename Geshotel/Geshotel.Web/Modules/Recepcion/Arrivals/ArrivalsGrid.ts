/************************************************************************************************************************************************************
Arrivals List
What I try to do is the following:

1.- Filter Reservations with status = ArrivalPending and FechaPervistaLLegada = FechaHotel. As I do not know how to get it, i use currentdate instead
2.- Select Reservations end user wants to checkIn and Add a button to do it

Javier Núñez : APRIL 2017
*************************************************************************************************************************************************************/

/// <reference path="../Reservas/ReservasGrid.ts" />

namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ArrivalsGrid extends Recepcion.ReservasGrid {

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
            return Q.text("Db.Recepcion.Arrivals.EntityPlural")
        }

        getButtons() {
            return [{
                title: Q.text('Controls.EntityGrid.CheckInArrivalsButton'),
                cssClass: 'check-in-button',
                icon: 'fa-chevron-circle-right text-green',
                onClick: () => {
                    if (!this.onViewSubmit()) {
                        return;
                    }

                    var action = new CheckInAction();
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
            // Let's filter Reservations with arrival (fecha_prevista_llegada) = today
            // and withs status = ReservationStatus.ArrivalPending


            // get quick filter list from base class
            let filters = super.getQuickFilters();

            // get a reference to reservas row field names
            let fld = Recepcion.ReservasRow.Fields;

            // quick filter init method is a good place to set initial
            // value for a quick filter editor, just after it is created

            // ****************************************************************
            // Here should be good to get FechaHotel instead of CurrentDate
            // Asking Volkan how to
            // ****************************************************************
            var dateini = new Date();
            var datefin = dateini;
            dateini.setHours(0, 0, 0, 0);
            datefin.setHours(23, 59, 59, 0);
            
 
            Q.first(filters, x => x.field == fld.FechaPrevistaLlegada).init = w => {
                // w is a reference to the editor for this quick filter widget
                // here we cast it to DateEditor, and set its value as date.
                // note that in Javascript, months are 0 based, so date below
                // is actually 2016-05-01
                (w as Serenity.DateEditor).valueAsDate = dateini;

                // setting start date was simple. but this quick filter is actually
                // a combination of two date editors. to get reference to second one,
                // need to find its next sibling element by its class
                let endDate = w.element.nextAll(".s-DateEditor").getWidget(Serenity.DateEditor);
                endDate.valueAsDate = datefin;
            };

            Q.first(filters, x => x.field == fld.EstadoReservaId).init = w => {
                // enum editor has a string value, so need to call toString()
                (w as Serenity.EnumEditor).value = ReservationStatus.ArrivalPending.toString();
            };

            return filters;
        }

    }
}