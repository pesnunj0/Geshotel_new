
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class HabitacionesSituacionGrid extends Serenity.EntityGrid<Ha, any> {
        protected getColumnsKey() { return 'Portal.HabitacionesSituacion'; }
        protected getDialogType() { return HabitacionesSituacionDialog; }
        protected getIdProperty() { return HabitacionesSituacionRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesSituacionRow.localTextPrefix; }
        protected getService() { return HabitacionesSituacionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}