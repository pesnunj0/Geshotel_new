namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ContratosOfertasGrid extends Serenity.EntityGrid<OfertasGrid, any> {
        protected getDialogType() { return ContratosOfertasDialog; }
        protected getColumnsKey() { return 'Contratos.Ofertas'; }
        protected getIdProperty() { return OfertasRow.idProperty; }
        protected getLocalTextPrefix() { return OfertasRow.localTextPrefix; }
        protected getService() { return OfertasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected initEntityDialog(itemType, dialog) {
            super.initEntityDialog(itemType, dialog);
            Serenity.SubDialogHelper.cascade(dialog, this.element.closest('.ui-dialog'));
        }

        protected addButtonClick() {
            // Javascript is case sensitive, so contratoID didn't work here.
            // To get intellisense, use a TS cast like below <OfertasRow>
            this.editItem(<OfertasRow>{
                ContratoId: this.contratoID
            });
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Contratos/Ofertas/ListExcel',
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

        get contratoID() {
            return this._contratoID;
        }

        set contratoID(value: number) {
            if (this._contratoID !== value) {
                this._contratoID = value;
                this.setEquality(OfertasRow.Fields.ContratoId, value);
                this.refresh();
            }
        }
    }
}




