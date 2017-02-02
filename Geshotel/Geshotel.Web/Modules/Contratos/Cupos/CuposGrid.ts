
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class CuposGrid extends Serenity.EntityGrid<CuposRow, any> {
        protected getColumnsKey() { return 'Contratos.Cupos'; }
        protected getDialogType() { return CuposDialog; }
        protected getIdProperty() { return CuposRow.idProperty; }
        protected getLocalTextPrefix() { return CuposRow.localTextPrefix; }
        protected getService() { return CuposService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}