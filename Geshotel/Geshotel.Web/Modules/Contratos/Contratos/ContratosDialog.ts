
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

        private LineasGrid: ContratosLineasGrid;
        private CuposGrid: ContratosCuposGrid;

        constructor() {
            super();
            this.LineasGrid = new ContratosLineasGrid(this.byId("LineasGrid"));
            this.CuposGrid = new ContratosCuposGrid(this.byId("CuposGrid"));
            this.tabs.on('tabsactivate', (e, i) => {
                this.arrange();
            });
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();
            this.LineasGrid.contratoID = this.entityId;
            // I don´t know how to set clienteID and hotelID values with the corresponding value. I force them to 1 and 2 for testing
            this.CuposGrid.hotelID = 1
            this.CuposGrid.clienteID = 2
        }
    }
}