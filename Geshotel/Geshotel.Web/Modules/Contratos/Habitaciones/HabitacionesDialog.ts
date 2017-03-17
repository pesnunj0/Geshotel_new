
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class HabitacionesDialog extends Serenity.EntityDialog<HabitacionesRow, any> {
        protected getFormKey() { return HabitacionesForm.formKey; }
        protected getIdProperty() { return HabitacionesRow.idProperty; }
        protected getLocalTextPrefix() { return HabitacionesRow.localTextPrefix; }
        protected getNameProperty() { return HabitacionesRow.nameProperty; }
        protected getService() { return HabitacionesService.baseUrl; }

        protected form = new HabitacionesForm(this.idPrefix);

    }
}