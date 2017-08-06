
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
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {

            let filters = super.getQuickFilters();
            let fld = Contratos.ClientesRow.Fields;

            var user = Q.Authorization.userDefinition as ScriptUserDefinition;

            Q.first(filters, x => x.field == fld.EmpresaId).init = w => {
                (w as Serenity.LookupEditor).value = user.EmpresaId == null ? "" : user.EmpresaId.toString();
            };

            return filters;
        }
    }
}