
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class ContratosGrid extends Serenity.EntityGrid<ContratosRow, any> {
        protected getColumnsKey() { return 'Contratos.Contratos'; }
        protected getDialogType() { return ContratosDialog; }
        protected getIdProperty() { return ContratosRow.idProperty; }
        protected getLocalTextPrefix() { return ContratosRow.localTextPrefix; }
        protected getService() { return ContratosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}