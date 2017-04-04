
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class ContadoresGrid extends Serenity.EntityGrid<ContadoresRow, any> {
        protected getColumnsKey() { return 'Contratos.Contadores'; }
        protected getDialogType() { return ContadoresDialog; }
        protected getIdProperty() { return ContadoresRow.idProperty; }
        protected getLocalTextPrefix() { return ContadoresRow.localTextPrefix; }
        protected getService() { return ContadoresService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}