
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class CanalesReservaGrid extends Serenity.EntityGrid<CanalesReservaRow, any> {
        protected getColumnsKey() { return 'Contratos.CanalesReserva'; }
        protected getDialogType() { return CanalesReservaDialog; }
        protected getIdProperty() { return CanalesReservaRow.idProperty; }
        protected getLocalTextPrefix() { return CanalesReservaRow.localTextPrefix; }
        protected getService() { return CanalesReservaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}