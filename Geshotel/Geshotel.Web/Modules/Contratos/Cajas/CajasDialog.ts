
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CajasDialog extends Serenity.EntityDialog<CajasRow, any> {
        protected getFormKey() { return CajasForm.formKey; }
        protected getIdProperty() { return CajasRow.idProperty; }
        protected getLocalTextPrefix() { return CajasRow.localTextPrefix; }
        protected getNameProperty() { return CajasRow.nameProperty; }
        protected getService() { return CajasService.baseUrl; }

        protected form = new CajasForm(this.idPrefix);

    }
}