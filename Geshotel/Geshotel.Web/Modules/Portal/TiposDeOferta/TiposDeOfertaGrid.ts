
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposDeOfertaGrid extends Serenity.EntityGrid<TiposDeOfertaRow, any> {
        protected getColumnsKey() { return 'Portal.TiposDeOferta'; }
        protected getDialogType() { return TiposDeOfertaDialog; }
        protected getIdProperty() { return TiposDeOfertaRow.idProperty; }
        protected getLocalTextPrefix() { return TiposDeOfertaRow.localTextPrefix; }
        protected getService() { return TiposDeOfertaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}