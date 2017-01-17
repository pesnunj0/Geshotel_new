
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CategoriaHotelesDialog extends Serenity.EntityDialog<CategoriaHotelesRow, any> {
        protected getFormKey() { return CategoriaHotelesForm.formKey; }
        protected getIdProperty() { return CategoriaHotelesRow.idProperty; }
        protected getLocalTextPrefix() { return CategoriaHotelesRow.localTextPrefix; }
        protected getNameProperty() { return CategoriaHotelesRow.nameProperty; }
        protected getService() { return CategoriaHotelesService.baseUrl; }

        protected form = new CategoriaHotelesForm(this.idPrefix);

    }
}