
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ImpuestosGrid extends Serenity.EntityGrid<ImpuestosRow, any> {
        protected getColumnsKey() { return 'Portal.Impuestos'; }
        protected getDialogType() { return ImpuestosDialog; }
        protected getIdProperty() { return ImpuestosRow.idProperty; }
        protected getLocalTextPrefix() { return ImpuestosRow.localTextPrefix; }
        protected getService() { return ImpuestosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Recepcion/Reservas/ListExcel',
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
            let fld = ImpuestosRow.Fields;

            var user = Q.Authorization.userDefinition as ScriptUserDefinition;

            Q.first(filters, x => x.field == fld.EmpresaId).init = w => {
                (w as Serenity.LookupEditor).value = user.EmpresaId == null ? "" : user.EmpresaId.toString();
            };
            return filters;
        }
    }
}