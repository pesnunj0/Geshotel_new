/*
    Este es un Grid un tantos especial, ya que pertenece a un tab de reservas y por lo tanto, será llamado con numero de reserva
    Además, se elimina el AddButton
    Finalmente ponemos un custom link, el link sobre contratoId nos llevará a ver el contrato segun ContratoId
    Javier Nuñez Abril 2017
*/
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ReservasContratosGrid extends Serenity.EntityGrid<ReservasContratosRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasContratos'; }
        protected getDialogType() { return ReservasContratosDialog; }
        protected getIdProperty() { return ReservasContratosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasContratosRow.localTextPrefix; }
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

            // call base method to get list of buttons
            // by default, base entity grid adds a few buttons, 
            // add, refresh, column selection in order.
            var buttons = super.getButtons();

            // here is several methods to remove add button
            // only one is enabled, others are commented

            // METHOD 1
            // we would be able to simply return an empty button list,
            // but this would also remove all other buttons
            // return [];

            // METHOD 2
            // remove by splicing (something like delete by index)
            // here we hard code add button index (not nice!)
            // buttons.splice(0, 1);

            // METHOD 3 - recommended
            // remove by splicing, but this time find button index
            // by its css class. it is the best and safer method
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);

            return buttons;
        }
        protected getColumns(): Slick.Column[] {
            var columns = super.getColumns();

            var fld = Recepcion.ReservasContratosRow.Fields;

            Q.first(columns, x => x.field == fld.ContratoId).format =
                ctx => `<a href="javascript:;" class="contrato-link">${Q.htmlEncode(ctx.value)}</a>`;
            return columns;

        }
        protected onClick(e: JQueryEventObject, row: number, cell: number): void {

            // let base grid handle clicks for its edit links
            super.onClick(e, row, cell);

            // if base grid already handled, we shouldn"t handle it again
            if (e.isDefaultPrevented()) {
                return;
            }

            // get reference to current item
            var item = this.itemAt(row);

            // get reference to clicked element
            var target = $(e.target);
            if (target.hasClass("contrato-link")) {
                e.preventDefault();
                new Contratos.ContratosDialog().loadByIdAndOpenDialog(item.ContratoId);
            }


        }
    }
}