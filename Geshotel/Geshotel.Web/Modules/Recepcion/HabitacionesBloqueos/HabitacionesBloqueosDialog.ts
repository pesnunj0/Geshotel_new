
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class HabitacionesBloqueosDialog extends Serenity.EntityDialog<HabitacionesBloqueosRow, any> {
        protected getFormKey() { return HabitacionesBloqueosForm.formKey; }
        protected getIdProperty() { return HabitacionesBloqueosRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesBloqueosRow.localTextPrefix; }
        protected getNameProperty() { return HabitacionesBloqueosRow.nameProperty; }
        protected getService() { return HabitacionesBloqueosService.baseUrl; }

        protected form = new HabitacionesBloqueosForm(this.idPrefix);

    }
}