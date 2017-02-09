
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposCondicionDialog extends Serenity.EntityDialog<TiposCondicionRow, any> {
        protected getFormKey() { return TiposCondicionForm.formKey; }
        protected getIdProperty() { return TiposCondicionRow.idProperty; }
        protected getLocalTextPrefix() { return TiposCondicionRow.localTextPrefix; }
        protected getNameProperty() { return TiposCondicionRow.nameProperty; }
        protected getService() { return TiposCondicionService.baseUrl; }

        protected form = new TiposCondicionForm(this.idPrefix);

    }
}