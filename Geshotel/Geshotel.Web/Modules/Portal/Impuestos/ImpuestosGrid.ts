
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class ImpuestosGrid extends Serenity.EntityGrid<ImpuestosRow, any> {
        protected getColumnsKey() { return 'Portal.Impuestos'; }
        protected getDialogType() { return ImpuestosDialog; }
        protected getIdProperty() { return ImpuestosRow.idProperty; }
        protected getLocalTextPrefix() { return ImpuestosRow.localTextPrefix; }
        protected getService() { return ImpuestosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}