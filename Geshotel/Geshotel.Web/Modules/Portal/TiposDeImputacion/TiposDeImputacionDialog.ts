
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposDeImputacionDialog extends Serenity.EntityDialog<TiposDeImputacionRow, any> {
        protected getFormKey() { return TiposDeImputacionForm.formKey; }
        protected getIdProperty() { return TiposDeImputacionRow.idProperty; }
        protected getLocalTextPrefix() { return TiposDeImputacionRow.localTextPrefix; }
        protected getNameProperty() { return TiposDeImputacionRow.nameProperty; }
        protected getService() { return TiposDeImputacionService.baseUrl; }

        protected form = new TiposDeImputacionForm(this.idPrefix);

    }
}