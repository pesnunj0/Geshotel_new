
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasHuespedesGrid extends Serenity.EntityGrid<ReservasHuespedesRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasHuespedes'; }
        protected getDialogType() { return ReservasHuespedesDialog; }
        protected getIdProperty() { return ReservasHuespedesRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasHuespedesRow.localTextPrefix; }
        protected getService() { return ReservasHuespedesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}