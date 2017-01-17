
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposHabitacionGrid extends Serenity.EntityGrid<TiposHabitacionRow, any> {
        protected getColumnsKey() { return 'Portal.TiposHabitacion'; }
        protected getDialogType() { return TiposHabitacionDialog; }
        protected getIdProperty() { return TiposHabitacionRow.idProperty; }
        protected getLocalTextPrefix() { return TiposHabitacionRow.localTextPrefix; }
        protected getService() { return TiposHabitacionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}