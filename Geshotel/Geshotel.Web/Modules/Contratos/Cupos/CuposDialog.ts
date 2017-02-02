
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CuposDialog extends Serenity.EntityDialog<CuposRow, any> {
        protected getFormKey() { return CuposForm.formKey; }
        protected getIdProperty() { return CuposRow.idProperty; }
        protected getLocalTextPrefix() { return CuposRow.localTextPrefix; }
        protected getService() { return CuposService.baseUrl; }

        protected form = new CuposForm(this.idPrefix);

    }
}