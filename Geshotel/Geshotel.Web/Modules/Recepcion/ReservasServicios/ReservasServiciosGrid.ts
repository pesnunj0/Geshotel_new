
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ReservasServiciosGrid extends Serenity.EntityGrid<ReservasServiciosRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasServicios'; }
        protected getDialogType() { return ReservasServiciosDialog; }
        protected getIdProperty() { return ReservasServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasServiciosRow.localTextPrefix; }
        protected getService() { return ReservasServiciosService.baseUrl; }

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
                FlagContrato: 1   // Los añadidos son manuales. es importante para que no sean destruidos en caso de regrabar reserva
            });
        }

        protected getGridCanLoad() {
            return this.reservaID != null;

        }

        private _reservaID: number;
        private _flagcontrato: number;

        get flagcontrato() {
            return 1;
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
        set flagcontrato(value: number) {
            this._flagcontrato = 1;
            this.setEquality(ReservasServiciosRow.Fields.FlagContrato, 1);
            this.refresh();
        }
    }
}