
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
        @Serenity.Decorators.filterable()
    export class MonedasGrid extends Serenity.EntityGrid<MonedasRow, any> {
        protected getColumnsKey() { return 'Portal.Monedas'; }
        protected getDialogType() { return MonedasDialog; }
        protected getIdProperty() { return MonedasRow.idProperty; }
        protected getLocalTextPrefix() { return MonedasRow.localTextPrefix; }
        protected getService() { return MonedasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getDefaultSortBy() {
            return [MonedasRow.Fields.MonedaId];
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Portal/Monedas/ListExcel',
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