
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class LineasFacturaGrid extends Serenity.EntityGrid<LineasFacturaRow, any> {
        protected getColumnsKey() { return 'Contratos.LineasFactura'; }
        protected getDialogType() { return LineasFacturaDialog; }
        protected getIdProperty() { return LineasFacturaRow.idProperty; }
        protected getLocalTextPrefix() { return LineasFacturaRow.localTextPrefix; }
        protected getService() { return LineasFacturaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}