
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class HotelesDialog extends Serenity.EntityDialog<HotelesRow, any> {
        protected getFormKey() { return HotelesForm.formKey; }
        protected getIdProperty() { return HotelesRow.idProperty; }
        protected getLocalTextPrefix() { return HotelesRow.localTextPrefix; }
        protected getNameProperty() { return HotelesRow.nameProperty; }
        protected getService() { return HotelesService.baseUrl; }

        protected form = new HotelesForm(this.idPrefix);

    }
}