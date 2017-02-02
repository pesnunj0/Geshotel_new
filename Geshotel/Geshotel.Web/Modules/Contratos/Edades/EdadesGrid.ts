
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class EdadesGrid extends Serenity.EntityGrid<EdadesRow, any> {
        protected getColumnsKey() { return 'Contratos.Edades'; }
        protected getDialogType() { return EdadesDialog; }
        protected getIdProperty() { return EdadesRow.idProperty; }
        protected getLocalTextPrefix() { return EdadesRow.localTextPrefix; }
        protected getService() { return EdadesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}