
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class HuespedesDialog extends Serenity.EntityDialog<HuespedesRow, any> {
        protected getFormKey() { return HuespedesForm.formKey; }
        protected getIdProperty() { return HuespedesRow.idProperty; }
        protected getLocalTextPrefix() { return HuespedesRow.localTextPrefix; }
        protected getNameProperty() { return HuespedesRow.nameProperty; }
        protected getService() { return HuespedesService.baseUrl; }

        protected form = new HuespedesForm(this.idPrefix);

    }
}