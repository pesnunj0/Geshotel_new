
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class FrecuenciaFacturacionDialog extends Serenity.EntityDialog<FrecuenciaFacturacionRow, any> {
        protected getFormKey() { return FrecuenciaFacturacionForm.formKey; }
        protected getIdProperty() { return FrecuenciaFacturacionRow.idProperty; }
        protected getLocalTextPrefix() { return FrecuenciaFacturacionRow.localTextPrefix; }
        protected getNameProperty() { return FrecuenciaFacturacionRow.nameProperty; }
        protected getService() { return FrecuenciaFacturacionService.baseUrl; }

        protected form = new FrecuenciaFacturacionForm(this.idPrefix);

    }
}