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
        protected getIdProperty()  { return "Key"; } 
        protected getLocalTextPrefix() { return "Recepcion.ReservasPreview"; }
        protected getService() { return ReservasPreviewService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
            return this.reservaID != null;
        }

        protected usePager() {
            return false;
        }

        private _reservaID: number;

        get reservaID() {
            return this._reservaID;
        }

        set reservaID(value: number) {
            if (this._reservaID !== value) {
                this._reservaID = value;
                //this.setEquality(ReservasContratosRow.Fields.ReservaId, value);
                this.refresh();
            }
        }

        protected onViewSubmit() {
            if (!super.onViewSubmit())
                return false;

            (this.view.params as ReservasPreviewListRequest).ReservaId = this._reservaID;

            return true;
        }

        protected getButtons(): Serenity.ToolButton[] {

            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }

        protected getColumns(): Slick.Column[] {

            var columns: Slick.Column[] = [];
            // Key and Reserva are not Necesary
            // columns.push({ field: 'Key', width: 50, sortable: false });
            //columns.push({ field: 'Reserva', width: 70, sortable: false });
            columns.push({ field: 'Fecha', width: 80, sortable: true });
            columns.push({ field: 'Descripcion', width: 120, sortable: true });
            columns.push({ field: 'DescTipo', width: 90, sortable: false });
            columns.push({ field: 'DescUCReserva', width: 90, sortable: false });
            columns.push({ field: 'Cantidad', width: 80, sortable: false });
            columns.push({ field: 'Precio', width: 80, sortable: false });
            columns.push({ field: 'PrecioProduccion', width: 80, sortable: false });
            columns.push({ field: 'Importe', width: 80, sortable: true });
            return columns;

        }
    }
}