
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class CajasGrid extends Serenity.EntityGrid<CajasRow, any> {
        protected getColumnsKey() { return 'Contratos.Cajas'; }
        protected getDialogType() { return CajasDialog; }
        protected getIdProperty() { return CajasRow.idProperty; }
        protected getLocalTextPrefix() { return CajasRow.localTextPrefix; }
        protected getService() { return CajasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}