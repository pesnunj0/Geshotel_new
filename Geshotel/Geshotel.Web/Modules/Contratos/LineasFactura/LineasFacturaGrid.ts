
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class LineasFacturaGrid extends Serenity.EntityGrid<LineasFacturaRow, any> {
        protected getColumnsKey() { return 'Contratos.LineasFactura'; }
        protected getDialogType() { return LineasFacturaDialog; }
        protected getIdProperty() { return LineasFacturaRow.idProperty; }
        protected getLocalTextPrefix() { return LineasFacturaRow.localTextPrefix; }
        protected getService() { return LineasFacturaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Contratos/LineasFactura/ListExcel',
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
            let fld = LineasFacturaRow.Fields;

            var user = Q.Authorization.userDefinition as ScriptUserDefinition;

            Q.first(filters, x => x.field == fld.EmpresaId).init = w => {
                (w as Serenity.LookupEditor).value = user.EmpresaId == null ? "" : user.EmpresaId.toString();
            };

            Q.first(filters, x => x.field == fld.HotelId).init = w => {
                (w as Serenity.LookupEditor).value = user.HotelId == null ? "" : user.HotelId.toString();
            };

            return filters;
        }
    }
}