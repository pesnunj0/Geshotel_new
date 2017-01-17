
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ClientesGrid extends Serenity.EntityGrid<ClientesRow, any> {
        protected getColumnsKey() { return 'Contratos.Clientes'; }
        protected getDialogType() { return ClientesDialog; }
        protected getIdProperty() { return ClientesRow.idProperty; }
        protected getLocalTextPrefix() { return ClientesRow.localTextPrefix; }
        protected getService() { return ClientesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Contratos/Clientes/ListExcel',
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