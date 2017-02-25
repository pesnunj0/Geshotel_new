
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReservasOfertasDialog extends Serenity.EntityDialog<ReservasOfertasRow, any> {
        protected getFormKey() { return ReservasOfertasForm.formKey; }
        protected getIdProperty() { return ReservasOfertasRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasOfertasRow.localTextPrefix; }
        protected getNameProperty() { return ReservasOfertasRow.nameProperty; }
        protected getService() { return ReservasOfertasService.baseUrl; }

        protected form = new ReservasOfertasForm(this.idPrefix);

    }
}