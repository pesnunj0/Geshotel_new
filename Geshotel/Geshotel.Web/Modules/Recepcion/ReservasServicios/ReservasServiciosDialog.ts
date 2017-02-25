
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReservasServiciosDialog extends Serenity.EntityDialog<ReservasServiciosRow, any> {
        protected getFormKey() { return ReservasServiciosForm.formKey; }
        protected getIdProperty() { return ReservasServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasServiciosRow.localTextPrefix; }
        protected getService() { return ReservasServiciosService.baseUrl; }

        protected form = new ReservasServiciosForm(this.idPrefix);

    }
}