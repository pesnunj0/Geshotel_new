
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class GruposHabitacionGrid extends Serenity.EntityGrid<GruposHabitacionRow, any> {
        protected getColumnsKey() { return 'Portal.GruposHabitacion'; }
        protected getDialogType() { return GruposHabitacionDialog; }
        protected getIdProperty() { return GruposHabitacionRow.idProperty; }
        protected getLocalTextPrefix() { return GruposHabitacionRow.localTextPrefix; }
        protected getService() { return GruposHabitacionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}