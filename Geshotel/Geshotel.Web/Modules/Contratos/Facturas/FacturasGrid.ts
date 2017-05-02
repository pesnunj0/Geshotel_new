
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class FacturasGrid extends Serenity.EntityGrid<FacturasRow, any> {
        protected getColumnsKey() { return 'Contratos.Facturas'; }
        protected getDialogType() { return FacturasDialog; }
        protected getIdProperty() { return FacturasRow.idProperty; }
        protected getLocalTextPrefix() { return FacturasRow.localTextPrefix; }
        protected getService() { return FacturasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}