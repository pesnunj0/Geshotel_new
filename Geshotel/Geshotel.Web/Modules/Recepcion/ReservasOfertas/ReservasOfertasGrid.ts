﻿
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasOfertasGrid extends Serenity.EntityGrid<ReservasOfertasRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasOfertas'; }
        protected getDialogType() { return ReservasOfertasDialog; }
        protected getIdProperty() { return ReservasOfertasRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasOfertasRow.localTextPrefix; }
        protected getService() { return ReservasOfertasService.baseUrl; }

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
                this.setEquality(ReservasOfertasRow.Fields.ReservaId, value);
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
    }
}