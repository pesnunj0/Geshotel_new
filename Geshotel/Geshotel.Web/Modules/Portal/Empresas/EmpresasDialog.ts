
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class EmpresasDialog extends Serenity.EntityDialog<EmpresasRow, any> {
        protected getFormKey() { return EmpresasForm.formKey; }
        protected getIdProperty() { return EmpresasRow.idProperty; }
        protected getLocalTextPrefix() { return EmpresasRow.localTextPrefix; }
        protected getNameProperty() { return EmpresasRow.nameProperty; }
        protected getService() { return EmpresasService.baseUrl; }

        protected form = new EmpresasForm(this.idPrefix);

    }
}