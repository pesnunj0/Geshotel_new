
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CanalesReservaDialog extends Serenity.EntityDialog<CanalesReservaRow, any> {
        protected getFormKey() { return CanalesReservaForm.formKey; }
        protected getIdProperty() { return CanalesReservaRow.idProperty; }
        protected getLocalTextPrefix() { return CanalesReservaRow.localTextPrefix; }
        protected getNameProperty() { return CanalesReservaRow.nameProperty; }
        protected getService() { return CanalesReservaService.baseUrl; }

        protected form = new CanalesReservaForm(this.idPrefix);

    }
}