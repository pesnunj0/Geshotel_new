namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
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
                ContratoId: this.contratoID,
                HotelId: this.hotelID
            });
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Contratos/Lineas/ListExcel',
                separator: true
            }));

            buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }

        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
           return this.contratoID != null;
            
        }

        private _contratoID: number;
        private _hotelID: number;

        get contratoID() {
            return this._contratoID;
        }

        get hotelID() {
            return this._hotelID;
        }

        set hotelID(value: number) {
            if (this._hotelID !== value) {
                this._hotelID = value;
                this.setEquality(LineasRow.Fields.HotelId, value);
                this.refresh();
            }
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




