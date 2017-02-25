
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasServiciosGrid extends Serenity.EntityGrid<ReservasServiciosRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasServicios'; }
        protected getDialogType() { return ReservasServiciosDialog; }
        protected getIdProperty() { return ReservasServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasServiciosRow.localTextPrefix; }
        protected getService() { return ReservasServiciosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}