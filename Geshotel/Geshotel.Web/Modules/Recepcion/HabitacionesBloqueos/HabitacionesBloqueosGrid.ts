
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class HabitacionesBloqueosGrid extends Serenity.EntityGrid<HabitacionesBloqueosRow, any> {
        protected getColumnsKey() { return 'Recepcion.HabitacionesBloqueos'; }
        protected getDialogType() { return HabitacionesBloqueosDialog; }
        protected getIdProperty() { return HabitacionesBloqueosRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesBloqueosRow.localTextPrefix; }
        protected getService() { return HabitacionesBloqueosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}