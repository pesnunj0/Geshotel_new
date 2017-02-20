
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class HabitacionesSituacionDialog extends Serenity.EntityDialog<HabitacionesSituacionRow, any> {
        protected getFormKey() { return HabitacionesSituacionForm.formKey; }
        protected getIdProperty() { return HabitacionesSituacionRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesSituacionRow.localTextPrefix; }
        protected getNameProperty() { return HabitacionesSituacionRow.nameProperty; }
        protected getService() { return HabitacionesSituacionService.baseUrl; }

        protected form = new HabitacionesSituacionForm(this.idPrefix);

    }
}