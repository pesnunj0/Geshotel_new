
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReservasExtrasDialog extends Serenity.EntityDialog<ReservasExtrasRow, any> {
        protected getFormKey() { return ReservasExtrasForm.formKey; }
        protected getIdProperty() { return ReservasExtrasRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasExtrasRow.localTextPrefix; }
        protected getService() { return ReservasExtrasService.baseUrl; }

        protected form = new ReservasExtrasForm(this.idPrefix);

    }
}