
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class LineasGrid extends Serenity.EntityGrid<LineasRow, any> {
        protected getColumnsKey() { return 'Contratos.Lineas'; }
        protected getDialogType() { return LineasDialog; }
        protected getIdProperty() { return LineasRow.idProperty; }
        protected getLocalTextPrefix() { return LineasRow.localTextPrefix; }
        protected getService() { return LineasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}