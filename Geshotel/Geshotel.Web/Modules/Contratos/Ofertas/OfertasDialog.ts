
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class OfertasDialog extends Serenity.EntityDialog<OfertasRow, any> {
        protected getFormKey() { return OfertasForm.formKey; }
        protected getIdProperty() { return OfertasRow.idProperty; }
        protected getLocalTextPrefix() { return OfertasRow.localTextPrefix; }
        protected getNameProperty() { return OfertasRow.nameProperty; }
        protected getService() { return OfertasService.baseUrl; }

        protected form = new OfertasForm(this.idPrefix);

    }
}