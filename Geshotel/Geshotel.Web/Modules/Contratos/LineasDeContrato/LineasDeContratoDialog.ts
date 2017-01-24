
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class LineasDeContratoDialog extends Serenity.EntityDialog<LineasDeContratoRow, any> {
        protected getFormKey() { return LineasDeContratoForm.formKey; }
        protected getIdProperty() { return LineasDeContratoRow.idProperty; }
        protected getLocalTextPrefix() { return LineasDeContratoRow.localTextPrefix; }
        protected getService() { return LineasDeContratoService.baseUrl; }

        protected form = new LineasDeContratoForm(this.idPrefix);

    }
}