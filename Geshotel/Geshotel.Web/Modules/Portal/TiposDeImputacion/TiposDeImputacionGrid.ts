
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposDeImputacionGrid extends Serenity.EntityGrid<TiposDeImputacionRow, any> {
        protected getColumnsKey() { return 'Portal.TiposDeImputacion'; }
        protected getDialogType() { return TiposDeImputacionDialog; }
        protected getIdProperty() { return TiposDeImputacionRow.idProperty; }
        protected getLocalTextPrefix() { return TiposDeImputacionRow.localTextPrefix; }
        protected getService() { return TiposDeImputacionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}