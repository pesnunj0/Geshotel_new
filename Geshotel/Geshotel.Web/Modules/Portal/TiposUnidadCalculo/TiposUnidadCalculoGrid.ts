
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposUnidadCalculoGrid extends Serenity.EntityGrid<TiposUnidadCalculoRow, any> {
        protected getColumnsKey() { return 'Portal.TiposUnidadCalculo'; }
        protected getDialogType() { return TiposUnidadCalculoDialog; }
        protected getIdProperty() { return TiposUnidadCalculoRow.idProperty; }
        protected getLocalTextPrefix() { return TiposUnidadCalculoRow.localTextPrefix; }
        protected getService() { return TiposUnidadCalculoService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}