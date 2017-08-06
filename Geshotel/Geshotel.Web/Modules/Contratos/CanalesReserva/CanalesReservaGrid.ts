
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class CanalesReservaGrid extends Serenity.EntityGrid<CanalesReservaRow, any> {
        protected getColumnsKey() { return 'Contratos.CanalesReserva'; }
        protected getDialogType() { return CanalesReservaDialog; }
        protected getIdProperty() { return CanalesReservaRow.idProperty; }
        protected getLocalTextPrefix() { return CanalesReservaRow.localTextPrefix; }
        protected getService() { return CanalesReservaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {

            let filters = super.getQuickFilters();
            let fld = Contratos.CanalesReservaRow.Fields;

            var user = Q.Authorization.userDefinition as ScriptUserDefinition;

            Q.first(filters, x => x.field == fld.EmpresaId).init = w => {
                (w as Serenity.LookupEditor).value = user.EmpresaId == null ? "" : user.EmpresaId.toString();
            };

            return filters;
        }
    }
}