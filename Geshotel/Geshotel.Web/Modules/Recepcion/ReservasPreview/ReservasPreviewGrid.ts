/*
    Este es un Grid un tantos especial, ya que pertenece a un tab de reservas y por lo tanto, será llamado con numero de reserva
    Además, se elimina el AddButton
    Finalmente ponemos un custom link, el link sobre contratoId nos llevará a ver el contrato segun ContratoId
    Javier Nuñez Abril 2017
*/
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ReservasPreviewGrid extends Serenity.EntityGrid<ReservasPreviewItem, any > {
        protected getIdProperty() { return null; }
        protected getLocalTextPrefix() { return "Recepcion.ReservasPreview"; }
        protected getService() { return ReservasContratosService.baseUrl; }

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
                this.setEquality(ReservasContratosRow.Fields.ReservaId, value);
                this.refresh();
            }
        }

        /**
  * This method is called to get list of buttons to be created.
  */
        protected getButtons(): Serenity.ToolButton[] {

            // As Grid and items are readonly
            // All Buttons are removed
            var buttons = super.getButtons();
            return [];
        }
        protected getColumns(): Slick.Column[] {

            var columns: Slick.Column[] = [];
            columns.push({ field: 'Fecha', width: 80, sortable: false });
            columns.push({ field: 'Descripcion', width: 100, sortable: false });
            columns.push({ field: 'DescTipo', width: 90, sortable: false });
            columns.push({ field: 'DescUCReserva', width: 90, sortable: false });
            columns.push({ field: 'Cantidad', width: 80, sortable: false });
            columns.push({ field: 'Precio', width: 80, sortable: false });
            columns.push({ field: 'PrecioProduccion', width: 80, sortable: false });
            columns.push({ field: 'Importe', width: 80, sortable: false });
            return columns;

        }
    }
}