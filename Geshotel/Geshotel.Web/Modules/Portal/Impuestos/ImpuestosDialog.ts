
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ImpuestosDialog extends Serenity.EntityDialog<ImpuestosRow, any> {
        protected getFormKey() { return ImpuestosForm.formKey; }
        protected getIdProperty() { return ImpuestosRow.idProperty; }
        protected getLocalTextPrefix() { return ImpuestosRow.localTextPrefix; }
        protected getNameProperty() { return ImpuestosRow.nameProperty; }
        protected getService() { return ImpuestosService.baseUrl; }

        protected form = new ImpuestosForm(this.idPrefix);

    }
}