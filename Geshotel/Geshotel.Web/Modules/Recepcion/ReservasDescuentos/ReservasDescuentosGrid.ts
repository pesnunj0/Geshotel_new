
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
        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
            return this.reservaID != null;

        }

        private _reservaID: number;

        get reservaID() {
            return this._reservaID;
        }

        set reservaID(value: number) {
            if (this._reservaID !== value) {
                this._reservaID = value;
                this.setEquality(ReservasDescuentosRow.Fields.ReservaId, value);
                this.refresh();
            }
        }
    }
}