
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class HabitacionesGrid extends Serenity.EntityGrid<HabitacionesRow, any> {
        protected getColumnsKey() { return 'Contratos.Habitaciones'; }
        protected getDialogType() { return HabitacionesDialog; }
        protected getIdProperty() { return HabitacionesRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesRow.localTextPrefix; }
        protected getService() { return HabitacionesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}