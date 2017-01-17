
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ClientesDialog extends Serenity.EntityDialog<ClientesRow, any> {
        protected getFormKey() { return ClientesForm.formKey; }
        protected getIdProperty() { return ClientesRow.idProperty; }
        protected getLocalTextPrefix() { return ClientesRow.localTextPrefix; }
        protected getNameProperty() { return ClientesRow.nameProperty; }
        protected getService() { return ClientesService.baseUrl; }

        protected form = new ClientesForm(this.idPrefix);

    }
}