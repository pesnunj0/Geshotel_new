
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class UnidadesCalculoGrid extends Serenity.EntityGrid<UnidadesCalculoRow, any> {
        protected getColumnsKey() { return 'Portal.UnidadesCalculo'; }
        protected getDialogType() { return UnidadesCalculoDialog; }
        protected getIdProperty() { return UnidadesCalculoRow.idProperty; }
        protected getLocalTextPrefix() { return UnidadesCalculoRow.localTextPrefix; }
        protected getService() { return UnidadesCalculoService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}