namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosCuposGrid extends Serenity.EntityGrid<CuposGrid, any> {
        protected getColumnsKey() { return 'Contratos.Cupos'; }
        protected getIdProperty() { return CuposRow.idProperty; }
        protected getLocalTextPrefix() { return CuposRow.localTextPrefix; }
        protected getService() { return CuposService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected addButtonClick() {
            this.editItem({ clienteID: this.clienteID });
            this.editItem({ hotelID: this.hotelID });
        }

        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
            return true;
//            return this.contratoID != null;
            
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




