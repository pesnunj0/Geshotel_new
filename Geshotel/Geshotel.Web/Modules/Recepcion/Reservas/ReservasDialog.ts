
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
            this.ReservasHuespedesGrid.rese
          

        }

    }
}