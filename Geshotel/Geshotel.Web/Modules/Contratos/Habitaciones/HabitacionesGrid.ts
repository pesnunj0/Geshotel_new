
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class HabitacionesGrid extends Serenity.EntityGrid<HabitacionesRow, any> {
        protected getColumnsKey() { return 'Contratos.Habitaciones'; }
        protected getDialogType() { return HabitacionesDialog; }
        protected getIdProperty() { return HabitacionesRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesRow.localTextPrefix; }
        protected getService() { return HabitacionesService.baseUrl; }

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
            let fld = Contratos.HabitacionesRow.Fields;

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