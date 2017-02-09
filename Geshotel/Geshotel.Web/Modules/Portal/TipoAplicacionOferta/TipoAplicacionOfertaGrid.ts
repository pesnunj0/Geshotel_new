
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TipoAplicacionOfertaGrid extends Serenity.EntityGrid<TipoAplicacionOfertaRow, any> {
        protected getColumnsKey() { return 'Portal.TipoAplicacionOferta'; }
        protected getDialogType() { return TipoAplicacionOfertaDialog; }
        protected getIdProperty() { return TipoAplicacionOfertaRow.idProperty; }
        protected getLocalTextPrefix() { return TipoAplicacionOfertaRow.localTextPrefix; }
        protected getService() { return TipoAplicacionOfertaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}