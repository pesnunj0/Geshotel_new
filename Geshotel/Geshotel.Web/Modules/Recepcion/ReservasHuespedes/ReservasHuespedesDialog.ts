
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReservasHuespedesDialog extends Serenity.EntityDialog<ReservasHuespedesRow, any> {
        protected getFormKey() { return ReservasHuespedesForm.formKey; }
        protected getIdProperty() { return ReservasHuespedesRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasHuespedesRow.localTextPrefix; }
        protected getService() { return ReservasHuespedesService.baseUrl; }

        protected form = new ReservasHuespedesForm(this.idPrefix);

    }
}