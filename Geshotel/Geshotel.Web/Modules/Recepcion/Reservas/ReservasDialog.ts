
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReservasDialog extends Serenity.EntityDialog<ReservasRow, any> {
        protected getFormKey() { return ReservasForm.formKey; }
        protected getIdProperty() { return ReservasRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasRow.localTextPrefix; }
        protected getNameProperty() { return ReservasRow.nameProperty; }
        protected getService() { return ReservasService.baseUrl; }

        protected form = new ReservasForm(this.idPrefix);

        private HabitacionesBloqueosGrid: ReservasHabitacionesBloqueosGrid;
        private ReservasServiciosGrid: ReservasServiciosGrid;
        private ReservasHuespedesGrid: ReservasHuespedesGrid;


        constructor() {
            super();

            this.HabitacionesBloqueosGrid = new ReservasHabitacionesBloqueosGrid(this.byId("HabitacionesBloqueosGrid"));
            this.ReservasServiciosGrid = new ReservasServiciosGrid(this.byId("ReservasServiciosGrid"));
            this.ReservasHuespedesGrid = new ReservasHuespedesGrid(this.byId("ReservasHuespedesGrid"));
            this.tabs.on('tabsactivate', (e, i) => {
                this.arrange();
            });
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();

            this.HabitacionesBloqueosGrid.reservaID = this.entityId;
            this.HabitacionesBloqueosGrid.tipoBloqueoID = 1;
        }

        protected updateInterface() {
            super.updateInterface();

            var fechaHotel = this.entity.HotelId == null ? null : Portal.HotelesRow.getLookup().itemById[this.entity.HotelId].FechaHotel;

            this.toolbar.findButton('cancel-button').toggle(this.entity.EstadoReservaId != 2);
            this.toolbar.findButton('cancel-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 1);
            this.toolbar.findButton('undo-cancel-button').toggle(this.entity.EstadoReservaId == 2);
            this.toolbar.findButton('undo-cancel-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 2 || fechaHotel > this.entity.FechaPrevistaLlegada);

            this.toolbar.findButton('check-in-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 1);

            this.toolbar.findButton('check-out-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 3 || fechaHotel != this.entity.FechaPrevistaSalida);

            this.toolbar.findButton('no-show-button').toggleClass('disabled',
                this.isNew() || this.entity.EstadoReservaId != 1 || fechaHotel != this.entity.FechaPrevistaLlegada);
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({
                title: 'Cancel',
                cssClass: 'cancel-button',
                icon: 'fa-times text-red',
                onClick: () => {
                }
            });

            buttons.push({
                title: 'Undo Cancel',
                cssClass: 'undo-cancel-button',
                icon: 'fa-times text-red',
                onClick: () => {
                }
            });

            buttons.push({
                title: 'Checkin',
                cssClass: 'check-in-button',
                icon: 'fa-chevron-circle-right text-green',
                onClick: () => {
                }
            });

            buttons.push({
                title: 'Checkout',
                cssClass: 'check-out-button',
                icon: 'fa-chevron-circle-left text-blue',
                onClick: () => {
                }
            });

            buttons.push({
                title: 'No Show',
                cssClass: 'no-show-button',
                icon: 'fa-hand-o-down text-maroon',
                onClick: () => {
                }
            });

            return buttons;
        }
    }
}