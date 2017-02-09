
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class ContratosEdadesGrid extends Serenity.EntityGrid<ContratosEdadesRow, any> {
        protected getColumnsKey() { return 'Contratos.ContratosEdades'; }
        protected getDialogType() { return ContratosEdadesDialog; }
        protected getIdProperty() { return ContratosEdadesRow.idProperty; }
        protected getLocalTextPrefix() { return ContratosEdadesRow.localTextPrefix; }
        protected getService() { return ContratosEdadesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}