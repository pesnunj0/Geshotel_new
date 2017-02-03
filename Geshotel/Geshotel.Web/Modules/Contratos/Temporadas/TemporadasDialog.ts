
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TemporadasDialog extends Serenity.EntityDialog<TemporadasRow, any> {
        protected getFormKey() { return TemporadasForm.formKey; }
        protected getIdProperty() { return TemporadasRow.idProperty; }
        protected getLocalTextPrefix() { return TemporadasRow.localTextPrefix; }
        protected getNameProperty() { return TemporadasRow.nameProperty; }
        protected getService() { return TemporadasService.baseUrl; }

        protected form = new TemporadasForm(this.idPrefix);

    }
}