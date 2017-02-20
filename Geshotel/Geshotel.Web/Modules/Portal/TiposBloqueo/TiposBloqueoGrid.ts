
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposBloqueoGrid extends Serenity.EntityGrid<TiposBloqueoRow, any> {
        protected getColumnsKey() { return 'Portal.TiposBloqueo'; }
        protected getDialogType() { return TiposBloqueoDialog; }
        protected getIdProperty() { return TiposBloqueoRow.idProperty; }
        protected getLocalTextPrefix() { return TiposBloqueoRow.localTextPrefix; }
        protected getService() { return TiposBloqueoService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}