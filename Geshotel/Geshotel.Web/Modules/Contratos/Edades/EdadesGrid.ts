
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class EdadesGrid extends Serenity.EntityGrid<EdadesRow, any> {
        protected getColumnsKey() { return 'Contratos.Edades'; }
        protected getDialogType() { return EdadesDialog; }
        protected getIdProperty() { return EdadesRow.idProperty; }
        protected getLocalTextPrefix() { return EdadesRow.localTextPrefix; }
        protected getService() { return EdadesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {

            let filters = super.getQuickFilters();
            let fld = Recepcion.ReservasRow.Fields;

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