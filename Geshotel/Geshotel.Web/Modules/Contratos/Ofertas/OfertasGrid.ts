
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class OfertasGrid extends Serenity.EntityGrid<OfertasRow, any> {
        protected getColumnsKey() { return 'Contratos.Ofertas'; }
        protected getDialogType() { return OfertasDialog; }
        protected getIdProperty() { return OfertasRow.idProperty; }
        protected getLocalTextPrefix() { return OfertasRow.localTextPrefix; }
        protected getService() { return OfertasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}