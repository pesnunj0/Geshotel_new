
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasExtrasGrid extends Serenity.EntityGrid<ReservasServiciosRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasExtras'; }
        protected getDialogType() { return ReservasExtrasDialog; }
        protected getIdProperty() { return ReservasServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasServiciosRow.localTextPrefix; }
        protected getService() { return ReservasExtrasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getInitialTitle() {
            return null;
        }

        protected addButtonClick() {
            // Javascript is case sensitive, so reservaID didn't work here.
            // To get intellisense, use a TS cast like below <ReservasServiciosRow>
            this.editItem(<ReservasServiciosRow>{
                ReservaId: this.reservaID,
                FlagContrato: 2,   // Los añadidos son manuales. es importante para que no sean destruidos en caso de regrabar reserva
                ServicioExtra:1
            });
        }

        protected getGridCanLoad() {
            return this.reservaID != null;
        }

        private _reservaID: number;
        private _flagcontrato: number;

        get flagcontrato() {
            return 2;
        }

        get reservaID() {
            return this._reservaID;
        }

        set reservaID(value: number) {
            if (this._reservaID !== value) {
                this._reservaID = value;
                this.setEquality(ReservasServiciosRow.Fields.ReservaId, value);
                this.refresh();
            }
        }
    }
}