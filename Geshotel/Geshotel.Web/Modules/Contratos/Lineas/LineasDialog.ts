
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class LineasDialog extends Serenity.EntityDialog<LineasRow, any> {
        protected getFormKey() { return LineasForm.formKey; }
        protected getIdProperty() { return LineasRow.idProperty; }
        protected getLocalTextPrefix() { return LineasRow.localTextPrefix; }
        protected getService() { return LineasService.baseUrl; }

        protected form = new LineasForm(this.idPrefix);

    }
}