
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReservasDescuentosDialog extends Serenity.EntityDialog<ReservasDescuentosRow, any> {
        protected getFormKey() { return ReservasDescuentosForm.formKey; }
        protected getIdProperty() { return ReservasDescuentosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasDescuentosRow.localTextPrefix; }
        protected getNameProperty() { return ReservasDescuentosRow.nameProperty; }
        protected getService() { return ReservasDescuentosService.baseUrl; }

        protected form = new ReservasDescuentosForm(this.idPrefix);

    }
}