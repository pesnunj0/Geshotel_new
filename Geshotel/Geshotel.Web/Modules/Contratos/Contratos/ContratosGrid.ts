
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ContratosGrid extends Serenity.EntityGrid<ContratosRow, any> {
        protected getColumnsKey() { return 'Contratos.Contratos'; }
        protected getDialogType() { return ContratosDialog; }
        protected getIdProperty() { return ContratosRow.idProperty; }
        protected getLocalTextPrefix() { return ContratosRow.localTextPrefix; }
        protected getService() { return ContratosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Contratos/Contratos/ListExcel',
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