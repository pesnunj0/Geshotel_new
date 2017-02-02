
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class OfertasRejillasGrid extends Serenity.EntityGrid<OfertasRejillasRow, any> {
        protected getColumnsKey() { return 'Contratos.OfertasRejillas'; }
        protected getDialogType() { return OfertasRejillasDialog; }
        protected getIdProperty() { return OfertasRejillasRow.idProperty; }
        protected getLocalTextPrefix() { return OfertasRejillasRow.localTextPrefix; }
        protected getService() { return OfertasRejillasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}