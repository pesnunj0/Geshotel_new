
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
        @Serenity.Decorators.filterable()
    export class EmpresasGrid extends Serenity.EntityGrid<EmpresasRow, any> {
        protected getColumnsKey() { return 'Portal.Empresas'; }
        protected getDialogType() { return EmpresasDialog; }
        protected getIdProperty() { return EmpresasRow.idProperty; }
        protected getLocalTextPrefix() { return EmpresasRow.localTextPrefix; }
        protected getService() { return EmpresasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getDefaultSortBy() {
            return [EmpresasRow.Fields.Empresa];
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Portal/Empresas/ListExcel',
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