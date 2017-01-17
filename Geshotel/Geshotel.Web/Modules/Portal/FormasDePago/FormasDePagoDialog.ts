
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class FormasDePagoDialog extends Serenity.EntityDialog<FormasDePagoRow, any> {
        protected getFormKey() { return FormasDePagoForm.formKey; }
        protected getIdProperty() { return FormasDePagoRow.idProperty; }
        protected getLocalTextPrefix() { return FormasDePagoRow.localTextPrefix; }
        protected getNameProperty() { return FormasDePagoRow.nameProperty; }
        protected getService() { return FormasDePagoService.baseUrl; }

        protected form = new FormasDePagoForm(this.idPrefix);

    }
}