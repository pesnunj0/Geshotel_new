
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasDescuentosGrid extends Serenity.EntityGrid<ReservasDescuentosRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasDescuentos'; }
        protected getDialogType() { return ReservasDescuentosDialog; }
        protected getIdProperty() { return ReservasDescuentosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasDescuentosRow.localTextPrefix; }
        protected getService() { return ReservasDescuentosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}