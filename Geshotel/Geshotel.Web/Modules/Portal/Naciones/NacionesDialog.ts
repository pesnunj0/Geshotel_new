
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class NacionesDialog extends Serenity.EntityDialog<NacionesRow, any> {
        protected getFormKey() { return NacionesForm.formKey; }
        protected getIdProperty() { return NacionesRow.idProperty; }
        protected getLocalTextPrefix() { return NacionesRow.localTextPrefix; }
        protected getNameProperty() { return NacionesRow.nameProperty; }
        protected getService() { return NacionesService.baseUrl; }

        protected form = new NacionesForm(this.idPrefix);

    }
}