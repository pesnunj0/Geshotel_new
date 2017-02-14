
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

        // Adding the following to instantiate ContratosLineasGrid.ts & rest

        private lineasGrid: ContratosLineasGrid;
        private cuposGrid: ContratosCuposGrid;
        private ofertasGrid: ContratosOfertasGrid;
        private releasesGrid: ContratosReleasesGrid;
        private edadesGrid: ContratosEdadesGrid;

        constructor() {
            super();

            this.lineasGrid = new ContratosLineasGrid(this.byId("LineasGrid"));
            this.cuposGrid = new ContratosCuposGrid(this.byId("CuposGrid"));
            this.ofertasGrid = new ContratosOfertasGrid(this.byId("OfertasGrid"));
            this.releasesGrid = new ContratosReleasesGrid(this.byId("ReleasesGrid"));
            this.edadesGrid = new ContratosEdadesGrid(this.byId("EdadesGrid"));

            this.form.ClienteId.change(e => this.cuposGrid.clienteID = Q.toId(this.form.ClienteId));
            this.form.HotelId.change(e => this.cuposGrid.hotelID = Q.toId(this.form.HotelId));
            this.form.FechaDesde.change(e => this.cuposGrid.fechaDesde = this.form.FechaDesde.value);
            this.form.FechaHasta.change(e => this.cuposGrid.fechaHasta = this.form.FechaHasta.value);

            this.form.ClienteId.change(e => this.releasesGrid.clienteID = Q.toId(this.form.ClienteId));
            this.form.HotelId.change(e => this.releasesGrid.hotelID = Q.toId(this.form.HotelId));
            this.form.FechaDesde.change(e => this.releasesGrid.fechaDesde = this.form.FechaDesde.value);
            this.form.FechaHasta.change(e => this.releasesGrid.fechaHasta = this.form.FechaHasta.value);

            this.form.ClienteId.change(e => this.edadesGrid.clienteID = Q.toId(this.form.ClienteId));
            this.form.HotelId.change(e => this.edadesGrid.hotelID = Q.toId(this.form.HotelId));
            this.form.FechaDesde.change(e => this.edadesGrid.fechaDesde = this.form.FechaDesde.value);
            this.form.FechaHasta.change(e => this.edadesGrid.fechaHasta = this.form.FechaHasta.value);

            this.tabs.on('tabsactivate', (e, i) => {
                this.arrange();
            });
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();

            this.lineasGrid.contratoID = this.entityId;
            this.ofertasGrid.contratoID = this.entityId;

            this.cuposGrid.fechaDesde = this.entity.FechaDesde;
            this.cuposGrid.fechaHasta = this.entity.FechaHasta;
            this.cuposGrid.clienteID = this.entity.ClienteId;
            this.cuposGrid.hotelID = this.entity.HotelId;

            this.releasesGrid.fechaDesde = this.entity.FechaDesde;
            this.releasesGrid.fechaHasta = this.entity.FechaHasta;
            this.releasesGrid.clienteID = this.entity.ClienteId;
            this.releasesGrid.hotelID = this.entity.HotelId;

            this.edadesGrid.fechaDesde = this.entity.FechaDesde;
            this.edadesGrid.fechaHasta = this.entity.FechaHasta;
            this.edadesGrid.clienteID = this.entity.ClienteId;
            this.edadesGrid.hotelID = this.entity.HotelId;
            
        }
    }
}