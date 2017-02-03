
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class MercadosDialog extends Serenity.EntityDialog<MercadosRow, any> {
        protected getFormKey() { return MercadosForm.formKey; }
        protected getIdProperty() { return MercadosRow.idProperty; }
        protected getLocalTextPrefix() { return MercadosRow.localTextPrefix; }
        protected getNameProperty() { return MercadosRow.nameProperty; }
        protected getService() { return MercadosService.baseUrl; }

        protected form = new MercadosForm(this.idPrefix);

    }
}