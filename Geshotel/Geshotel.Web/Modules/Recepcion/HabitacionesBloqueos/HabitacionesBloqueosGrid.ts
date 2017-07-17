
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class HabitacionesBloqueosGrid extends Serenity.EntityGrid<HabitacionesBloqueosRow, any> {
        protected getColumnsKey() { return 'Recepcion.HabitacionesBloqueos'; }
        protected getDialogType() { return HabitacionesBloqueosDialog; }
        protected getIdProperty() { return HabitacionesBloqueosRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesBloqueosRow.localTextPrefix; }
        protected getService() { return HabitacionesBloqueosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected onViewSubmit() {
            // only continue if base class returns true (didn't cancel request)
            if (!super.onViewSubmit()) {
                return false;
            }

            // view object is the data source for grid (SlickRemoteView)
            // this is an EntityGrid so its Params object is a ListRequest
            var request = this.view.params as Serenity.ListRequest;

            // list request has a Criteria parameter
            // we AND criteria here to existing one because 
            // otherwise we might clear filter set by 
            // an edit filter dialog if any.

            request.Criteria = Serenity.Criteria.and(request.Criteria,
                [['Editable'], '=', 1]);

            // TypeScript doesn't support operator overloading
            // so we had to use array syntax above to build criteria.

            // Make sure you write
            // [['Field'], '>', 10] (which means field A is greater than 10)
            // not 
            // ['A', '>', 10] (which means string 'A' is greater than 10

            return true;
        }
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {

            let filters = super.getQuickFilters();
            let fld = Recepcion.HabitacionesBloqueosRow.Fields;

            var user = Q.Authorization.userDefinition as ScriptUserDefinition;

            Q.first(filters, x => x.field == fld.EmpresaId).init = w => {
                (w as Serenity.LookupEditor).value = user.EmpresaId == null ? "" : user.EmpresaId.toString();
            };

            Q.first(filters, x => x.field == fld.HotelId).init = w => {
                (w as Serenity.LookupEditor).value = user.HotelId == null ? "" : user.HotelId.toString();
            };

            //Q.first(filters, x => x.field == fld.Editable).init = w => {
            //    (w as Serenity.BooleanEditor).value = true;
            //};

            return filters;
        }
        protected createQuickFilters(): void {

            // let base class to create quick filters first
            super.createQuickFilters();

            // get a reference to HabitacionesBloqueos row field names
            let fld = Recepcion.HabitacionesBloqueosRow.Fields;

            // find a quick filter widget by its field name
            //this.findQuickFilter(Serenity.IntegerEditor, fld.Editable).value = 1;
        }
    }
}