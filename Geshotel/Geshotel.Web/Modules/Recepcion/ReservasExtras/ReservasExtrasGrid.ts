
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasExtrasGrid extends Serenity.EntityGrid<ReservasExtrasRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasExtras'; }
        protected getDialogType() { return ReservasExtrasDialog; }
        protected getIdProperty() { return ReservasExtrasRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasExtrasRow.localTextPrefix; }
        protected getService() { return ReservasExtrasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}