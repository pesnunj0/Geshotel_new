
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ContadoresDialog extends Serenity.EntityDialog<ContadoresRow, any> {
        protected getFormKey() { return ContadoresForm.formKey; }
        protected getIdProperty() { return ContadoresRow.idProperty; }
        protected getLocalTextPrefix() { return ContadoresRow.localTextPrefix; }
        protected getService() { return ContadoresService.baseUrl; }

        protected form = new ContadoresForm(this.idPrefix);

    }
}