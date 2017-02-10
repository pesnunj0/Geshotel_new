
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ContratosDialog extends Serenity.EntityDialog<ContratosRow, any> {
        protected getFormKey() { return ContratosForm.formKey; }
        protected getIdProperty() { return ContratosRow.idProperty; }
        protected getLocalTextPrefix() { return ContratosRow.localTextPrefix; }
        protected getNameProperty() { return ContratosRow.nameProperty; }
        protected getService() { return ContratosService.baseUrl; }

        protected form = new ContratosForm(this.idPrefix);

        // Adding the following to instantiate ContratosLineasGrid.ts

        private lineasGrid: ContratosLineasGrid;
        private cuposGrid: ContratosCuposGrid;

        constructor() {
            super();

            this.lineasGrid = new ContratosLineasGrid(this.byId("LineasGrid"));
            this.cuposGrid = new ContratosCuposGrid(this.byId("CuposGrid"));

            this.form.ClienteId.change(e => this.cuposGrid.clienteID = Q.toId(this.form.ClienteId));
            this.form.HotelId.change(e => this.cuposGrid.hotelID = Q.toId(this.form.HotelId));
            this.form.FechaDesde.change(e => this.cuposGrid.fechaDesde = this.form.FechaDesde.value);
            this.form.FechaHasta.change(e => this.cuposGrid.fechaHasta = this.form.FechaHasta.value);

            this.tabs.on('tabsactivate', (e, i) => {
                this.arrange();
            });
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();

            this.lineasGrid.contratoID = this.entityId;
            this.cuposGrid.fechaDesde = this.entity.FechaDesde;
            this.cuposGrid.fechaHasta = this.entity.FechaHasta;
            this.cuposGrid.clienteID = this.entity.ClienteId;
            this.cuposGrid.hotelID = this.entity.HotelId;
            
        }
    }
}