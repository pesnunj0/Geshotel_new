
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class FacturasDialog extends Serenity.EntityDialog<FacturasRow, any> {
        protected getFormKey() { return FacturasForm.formKey; }
        protected getIdProperty() { return FacturasRow.idProperty; }
        protected getLocalTextPrefix() { return FacturasRow.localTextPrefix; }
        protected getNameProperty() { return FacturasRow.nameProperty; }
        protected getService() { return FacturasService.baseUrl; }

        protected form = new FacturasForm(this.idPrefix);

    }
}