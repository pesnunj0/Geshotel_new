
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class HotelesGrid extends Serenity.EntityGrid<HotelesRow, any> {
        protected getColumnsKey() { return 'Portal.Hoteles'; }
        protected getDialogType() { return HotelesDialog; }
        protected getIdProperty() { return HotelesRow.idProperty; }
        protected getLocalTextPrefix() { return HotelesRow.localTextPrefix; }
        protected getService() { return HotelesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getDefaultSortBy() {
            return [HotelesRow.Fields.HotelId];
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Portal/Hoteles/ListExcel',
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