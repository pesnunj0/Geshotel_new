
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class GruposHabitacionDialog extends Serenity.EntityDialog<GruposHabitacionRow, any> {
        protected getFormKey() { return GruposHabitacionForm.formKey; }
        protected getIdProperty() { return GruposHabitacionRow.idProperty; }
        protected getLocalTextPrefix() { return GruposHabitacionRow.localTextPrefix; }
        protected getNameProperty() { return GruposHabitacionRow.nameProperty; }
        protected getService() { return GruposHabitacionService.baseUrl; }

        protected form = new GruposHabitacionForm(this.idPrefix);

    }
}