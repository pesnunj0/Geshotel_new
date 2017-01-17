
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ProvinciasDialog extends Serenity.EntityDialog<ProvinciasRow, any> {
        protected getFormKey() { return ProvinciasForm.formKey; }
        protected getIdProperty() { return ProvinciasRow.idProperty; }
        protected getLocalTextPrefix() { return ProvinciasRow.localTextPrefix; }
        protected getNameProperty() { return ProvinciasRow.nameProperty; }
        protected getService() { return ProvinciasService.baseUrl; }

        protected form = new ProvinciasForm(this.idPrefix);

    }
}