
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class HuespedesGrid extends Serenity.EntityGrid<HuespedesRow, any> {
        protected getColumnsKey() { return 'Recepcion.Huespedes'; }
        protected getDialogType() { return HuespedesDialog; }
        protected getIdProperty() { return HuespedesRow.idProperty; }
        protected getLocalTextPrefix() { return HuespedesRow.localTextPrefix; }
        protected getService() { return HuespedesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}