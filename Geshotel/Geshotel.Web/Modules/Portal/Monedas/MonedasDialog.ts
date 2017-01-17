
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class MonedasDialog extends Serenity.EntityDialog<MonedasRow, any> {
        protected getFormKey() { return MonedasForm.formKey; }
        protected getIdProperty() { return MonedasRow.idProperty; }
        protected getLocalTextPrefix() { return MonedasRow.localTextPrefix; }
        protected getNameProperty() { return MonedasRow.nameProperty; }
        protected getService() { return MonedasService.baseUrl; }

        protected form = new MonedasForm(this.idPrefix);

    }
}