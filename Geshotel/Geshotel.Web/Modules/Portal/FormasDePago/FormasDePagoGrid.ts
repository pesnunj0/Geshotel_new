
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class FormasDePagoGrid extends Serenity.EntityGrid<FormasDePagoRow, any> {
        protected getColumnsKey() { return 'Portal.FormasDePago'; }
        protected getDialogType() { return FormasDePagoDialog; }
        protected getIdProperty() { return FormasDePagoRow.idProperty; }
        protected getLocalTextPrefix() { return FormasDePagoRow.localTextPrefix; }
        protected getService() { return FormasDePagoService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Portal/FormasDePago/ListExcel',
                separator: true
            }));

            buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }

    }
}