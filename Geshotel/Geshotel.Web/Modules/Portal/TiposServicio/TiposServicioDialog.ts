
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposServicioDialog extends Serenity.EntityDialog<TiposServicioRow, any> {
        protected getFormKey() { return TiposServicioForm.formKey; }
        protected getIdProperty() { return TiposServicioRow.idProperty; }
        protected getLocalTextPrefix() { return TiposServicioRow.localTextPrefix; }
        protected getNameProperty() { return TiposServicioRow.nameProperty; }
        protected getService() { return TiposServicioService.baseUrl; }

        protected form = new TiposServicioForm(this.idPrefix);

    }
}