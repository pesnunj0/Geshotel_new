
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasContratosGrid extends Serenity.EntityGrid<ReservasContratosRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasContratos'; }
        protected getDialogType() { return ReservasContratosDialog; }
        protected getIdProperty() { return ReservasContratosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasContratosRow.localTextPrefix; }
        protected getService() { return ReservasContratosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}