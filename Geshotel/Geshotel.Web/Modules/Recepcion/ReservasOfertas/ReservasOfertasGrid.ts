
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasOfertasGrid extends Serenity.EntityGrid<ReservasOfertasRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasOfertas'; }
        protected getDialogType() { return ReservasOfertasDialog; }
        protected getIdProperty() { return ReservasOfertasRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasOfertasRow.localTextPrefix; }
        protected getService() { return ReservasOfertasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}