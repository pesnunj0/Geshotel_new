namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosEdadesGrid extends Serenity.EntityGrid<EdadesGrid, any> {
        protected getColumnsKey() { return 'Contratos.Edades'; }
        protected getIdProperty() { return EdadesRow.idProperty; }
        protected getLocalTextPrefix() { return EdadesRow.localTextPrefix; }
        protected getService() { return EdadesService.baseUrl; }
        protected getDialogType() { return ContratosEdadesDialog; }

        constructor(container: JQuery) {
            super(container);
        }

        protected addButtonClick() {
            this.editItem(<EdadesRow>{
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

        protected onViewSubmit() {
            if (!super.onViewSubmit())
                return false;

            var fld = EdadesRow.Fields;
            var request = this.view.params as Serenity.ListRequest;
            request.Criteria = Serenity.Criteria.and(request.Criteria,
                Serenity.Criteria.or(
                    Serenity.Criteria.and([[fld.FechaDesde], '>=', this.fechaDesde], [[fld.FechaDesde], '<=', this.fechaHasta]),
                    Serenity.Criteria.and([[fld.FechaHasta], '>=', this.fechaDesde], [[fld.FechaHasta], '<=', this.fechaHasta]),
                    Serenity.Criteria.and([[fld.FechaDesde], '<=', this.fechaDesde], [[fld.FechaHasta], '>', this.fechaHasta])));

            return true;
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

        private _fechaDesde: string;

        get fechaDesde() {
            return this._fechaDesde;
        }

        set fechaDesde(value: string) {
            if (this._fechaDesde !== value) {
                this._fechaDesde = value;
                this.refresh();
            }
        }

        private _fechaHasta: string;

        get fechaHasta() {
            return this._fechaHasta;
        }

        set fechaHasta(value: string) {
            if (this._fechaHasta !== value) {
                this._fechaHasta = value;
                this.refresh();
            }
        }
    }
}




