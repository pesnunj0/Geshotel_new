
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ServiciosGrid extends Serenity.EntityGrid<ServiciosRow, any> {
        protected getColumnsKey() { return 'Portal.Servicios'; }
        protected getDialogType() { return ServiciosDialog; }
        protected getIdProperty() { return ServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return ServiciosRow.localTextPrefix; }
        protected getService() { return ServiciosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Portal/Servicios/ListExcel',
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