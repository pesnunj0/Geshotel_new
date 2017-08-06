
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class AgenciasGrid extends Serenity.EntityGrid<AgenciasRow, any> {
        protected getColumnsKey() { return 'Contratos.Agencias'; }
        protected getDialogType() { return AgenciasDialog; }
        protected getIdProperty() { return AgenciasRow.idProperty; }
        protected getLocalTextPrefix() { return AgenciasRow.localTextPrefix; }
        protected getService() { return AgenciasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Contratos/Agencias/ListExcel',
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
            let fld = Contratos.AgenciasRow.Fields;

            var user = Q.Authorization.userDefinition as ScriptUserDefinition;

            Q.first(filters, x => x.field == fld.EmpresaId).init = w => {
                (w as Serenity.LookupEditor).value = user.EmpresaId == null ? "" : user.EmpresaId.toString();
            };

            return filters;
        }
    }
}