
namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReservasContratosDialog extends Serenity.EntityDialog<ReservasContratosRow, any> {
        protected getFormKey() { return ReservasContratosForm.formKey; }
        protected getIdProperty() { return ReservasContratosRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasContratosRow.localTextPrefix; }
        protected getService() { return ReservasContratosService.baseUrl; }

        protected form = new ReservasContratosForm(this.idPrefix);

        updateInterface() {
            super.updateInterface();

            Serenity.EditorUtils.setReadOnly(this.form.ReservaId, true);
        }
    }
}