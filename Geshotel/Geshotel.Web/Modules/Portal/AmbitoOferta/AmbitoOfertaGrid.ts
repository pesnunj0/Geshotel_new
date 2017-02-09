
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class AmbitoOfertaGrid extends Serenity.EntityGrid<AmbitoOfertaRow, any> {
        protected getColumnsKey() { return 'Portal.AmbitoOferta'; }
        protected getDialogType() { return AmbitoOfertaDialog; }
        protected getIdProperty() { return AmbitoOfertaRow.idProperty; }
        protected getLocalTextPrefix() { return AmbitoOfertaRow.localTextPrefix; }
        protected getService() { return AmbitoOfertaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}