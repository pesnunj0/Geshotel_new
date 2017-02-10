namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosLineasGrid extends Serenity.EntityGrid<LineasGrid, any> {
        protected getDialogType() { return ContratosLineasDialog; }
        protected getColumnsKey() { return 'Contratos.Lineas'; }
        protected getIdProperty() { return LineasRow.idProperty; }
        protected getLocalTextPrefix() { return LineasRow.localTextPrefix; }
        protected getService() { return LineasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected initEntityDialog(itemType, dialog) {
            super.initEntityDialog(itemType, dialog);
            Serenity.SubDialogHelper.cascade(dialog, this.element.closest('.ui-dialog'));
        }

        protected addButtonClick() {
            // Javascript is case sensitive, so contratoID didn't work here.
            // To get intellisense, use a TS cast like below <LineasRow>
            this.editItem(<LineasRow>{
                ContratoId: this.contratoID
            });
        }

        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
           return this.contratoID != null;
            
        }

        private _contratoID: number;

        get contratoID() {
            return this._contratoID;
        }

        set contratoID(value: number) {
            if (this._contratoID !== value) {
                this._contratoID = value;
                this.setEquality(LineasRow.Fields.ContratoId, value);
                this.refresh();
            }
        }
    }
}




