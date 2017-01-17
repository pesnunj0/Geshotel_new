
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposServicioGrid extends Serenity.EntityGrid<TiposServicioRow, any> {
        protected getColumnsKey() { return 'Portal.TiposServicio'; }
        protected getDialogType() { return TiposServicioDialog; }
        protected getIdProperty() { return TiposServicioRow.idProperty; }
        protected getLocalTextPrefix() { return TiposServicioRow.localTextPrefix; }
        protected getService() { return TiposServicioService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}