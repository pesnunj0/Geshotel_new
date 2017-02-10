namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosCuposGrid extends Serenity.EntityGrid<CuposGrid, any> {
        protected getColumnsKey() { return 'Contratos.Cupos'; }
        protected getIdProperty() { return CuposRow.idProperty; }
        protected getLocalTextPrefix() { return CuposRow.localTextPrefix; }
        protected getService() { return CuposService.baseUrl; }
        protected getDialogType() { return ContratosCuposDialog; }

        constructor(container: JQuery) {
            super(container);
        }

        protected addButtonClick() {
            this.editItem(<CuposRow>{
                ClienteId: this.clienteID,
                HotelId: this.hotelID
            });
        }

        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
            return this.clienteID != null && this.hotelID != null;
        }

        private _hotelID: number;
        
        get hotelID() {
            return this._hotelID;
        }

        set hotelID(value: number) {
            if (this._hotelID !== value) {
                this._hotelID = value;
                this.setEquality(ContratosRow.Fields.HotelId, value);
                this.refresh();
            }
        }

        private _clienteID: number;

        get clienteID() {
            return this._clienteID;
        }

        set clienteID(value: number) {
            if (this._clienteID !== value) {
                this._clienteID = value;
                this.setEquality(ContratosRow.Fields.ClienteId, value);
                this.refresh();
            }
        }
    }
}




