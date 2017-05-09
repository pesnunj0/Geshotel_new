
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
                this.setEquality(ReservasExtrasRow.Fields.ReservaId, value);
                this.refresh();
            }
        }
    }
}