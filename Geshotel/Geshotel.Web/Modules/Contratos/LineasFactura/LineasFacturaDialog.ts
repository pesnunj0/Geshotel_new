
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class LineasFacturaDialog extends Serenity.EntityDialog<LineasFacturaRow, any> {
        protected getFormKey() { return LineasFacturaForm.formKey; }
        protected getIdProperty() { return LineasFacturaRow.idProperty; }
        protected getLocalTextPrefix() { return LineasFacturaRow.localTextPrefix; }
        protected getNameProperty() { return LineasFacturaRow.nameProperty; }
        protected getService() { return LineasFacturaService.baseUrl; }

        protected form = new LineasFacturaForm(this.idPrefix);

    }
}