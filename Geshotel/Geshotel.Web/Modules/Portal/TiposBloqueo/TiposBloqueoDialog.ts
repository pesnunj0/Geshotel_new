
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposBloqueoDialog extends Serenity.EntityDialog<TiposBloqueoRow, any> {
        protected getFormKey() { return TiposBloqueoForm.formKey; }
        protected getIdProperty() { return TiposBloqueoRow.idProperty; }
        protected getLocalTextPrefix() { return TiposBloqueoRow.localTextPrefix; }
        protected getNameProperty() { return TiposBloqueoRow.nameProperty; }
        protected getService() { return TiposBloqueoService.baseUrl; }

        protected form = new TiposBloqueoForm(this.idPrefix);

    }
}