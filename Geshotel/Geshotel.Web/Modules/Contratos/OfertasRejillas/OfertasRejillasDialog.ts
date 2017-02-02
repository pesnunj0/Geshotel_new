
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class OfertasRejillasDialog extends Serenity.EntityDialog<OfertasRejillasRow, any> {
        protected getFormKey() { return OfertasRejillasForm.formKey; }
        protected getIdProperty() { return OfertasRejillasRow.idProperty; }
        protected getLocalTextPrefix() { return OfertasRejillasRow.localTextPrefix; }
        protected getService() { return OfertasRejillasService.baseUrl; }

        protected form = new OfertasRejillasForm(this.idPrefix);

    }
}