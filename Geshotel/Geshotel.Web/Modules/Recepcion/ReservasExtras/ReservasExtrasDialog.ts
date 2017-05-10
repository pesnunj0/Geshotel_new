
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReservasExtrasDialog extends Serenity.EntityDialog<ReservasServiciosRow, any> {
        protected getFormKey() { return ReservasExtrasForm.formKey; }
        protected getIdProperty() { return ReservasServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasServiciosRow.localTextPrefix; }
        protected getService() { return ReservasExtrasService.baseUrl; }

        protected form = new ReservasExtrasForm(this.idPrefix);

    }
}