
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposCondicionGrid extends Serenity.EntityGrid<TiposCondicionRow, any> {
        protected getColumnsKey() { return 'Portal.TiposCondicion'; }
        protected getDialogType() { return TiposCondicionDialog; }
        protected getIdProperty() { return TiposCondicionRow.idProperty; }
        protected getLocalTextPrefix() { return TiposCondicionRow.localTextPrefix; }
        protected getService() { return TiposCondicionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}