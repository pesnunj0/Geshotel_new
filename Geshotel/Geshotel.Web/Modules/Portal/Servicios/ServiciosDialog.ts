
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ServiciosDialog extends Serenity.EntityDialog<ServiciosRow, any> {
        protected getFormKey() { return ServiciosForm.formKey; }
        protected getIdProperty() { return ServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return ServiciosRow.localTextPrefix; }
        protected getNameProperty() { return ServiciosRow.nameProperty; }
        protected getService() { return ServiciosService.baseUrl; }

        protected form = new ServiciosForm(this.idPrefix);

    }
}