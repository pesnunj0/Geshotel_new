
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class AgenciasGrid extends Serenity.EntityGrid<AgenciasRow, any> {
        protected getColumnsKey() { return 'Contratos.Agencias'; }
        protected getDialogType() { return AgenciasDialog; }
        protected getIdProperty() { return AgenciasRow.idProperty; }
        protected getLocalTextPrefix() { return AgenciasRow.localTextPrefix; }
        protected getService() { return AgenciasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}