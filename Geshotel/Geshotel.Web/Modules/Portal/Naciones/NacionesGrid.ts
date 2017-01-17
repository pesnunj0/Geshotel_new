
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class NacionesGrid extends Serenity.EntityGrid<NacionesRow, any> {
        protected getColumnsKey() { return 'Portal.Naciones'; }
        protected getDialogType() { return NacionesDialog; }
        protected getIdProperty() { return NacionesRow.idProperty; }
        protected getLocalTextPrefix() { return NacionesRow.localTextPrefix; }
        protected getService() { return NacionesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getDefaultSortBy() {
            return [NacionesRow.Fields.Nacion];
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Portal/Naciones/ListExcel',
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