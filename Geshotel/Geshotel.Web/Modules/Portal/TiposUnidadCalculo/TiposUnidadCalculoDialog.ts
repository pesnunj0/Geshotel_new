
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposUnidadCalculoDialog extends Serenity.EntityDialog<TiposUnidadCalculoRow, any> {
        protected getFormKey() { return TiposUnidadCalculoForm.formKey; }
        protected getIdProperty() { return TiposUnidadCalculoRow.idProperty; }
        protected getLocalTextPrefix() { return TiposUnidadCalculoRow.localTextPrefix; }
        protected getNameProperty() { return TiposUnidadCalculoRow.nameProperty; }
        protected getService() { return TiposUnidadCalculoService.baseUrl; }

        protected form = new TiposUnidadCalculoForm(this.idPrefix);

    }
}