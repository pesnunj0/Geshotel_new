
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
        @Serenity.Decorators.filterable()
    export class ProvinciasGrid extends Serenity.EntityGrid<ProvinciasRow, any> {
        protected getColumnsKey() { return 'Portal.Provincias'; }
        protected getDialogType() { return ProvinciasDialog; }
        protected getIdProperty() { return ProvinciasRow.idProperty; }
        protected getLocalTextPrefix() { return ProvinciasRow.localTextPrefix; }
        protected getService() { return ProvinciasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getDefaultSortBy() {
            return [ProvinciasRow.Fields.Provincia];
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Portal/Provincias/ListExcel',
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