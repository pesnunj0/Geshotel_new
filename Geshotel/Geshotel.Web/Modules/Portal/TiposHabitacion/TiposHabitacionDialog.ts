
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposHabitacionDialog extends Serenity.EntityDialog<TiposHabitacionRow, any> {
        protected getFormKey() { return TiposHabitacionForm.formKey; }
        protected getIdProperty() { return TiposHabitacionRow.idProperty; }
        protected getLocalTextPrefix() { return TiposHabitacionRow.localTextPrefix; }
        protected getNameProperty() { return TiposHabitacionRow.nameProperty; }
        protected getService() { return TiposHabitacionService.baseUrl; }

        protected form = new TiposHabitacionForm(this.idPrefix);

    }
}