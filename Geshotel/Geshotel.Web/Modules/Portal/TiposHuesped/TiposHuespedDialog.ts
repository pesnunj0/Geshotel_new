
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposHuespedDialog extends Serenity.EntityDialog<TiposHuespedRow, any> {
        protected getFormKey() { return TiposHuespedForm.formKey; }
        protected getIdProperty() { return TiposHuespedRow.idProperty; }
        protected getLocalTextPrefix() { return TiposHuespedRow.localTextPrefix; }
        protected getNameProperty() { return TiposHuespedRow.nameProperty; }
        protected getService() { return TiposHuespedService.baseUrl; }

        protected form = new TiposHuespedForm(this.idPrefix);

    }
}