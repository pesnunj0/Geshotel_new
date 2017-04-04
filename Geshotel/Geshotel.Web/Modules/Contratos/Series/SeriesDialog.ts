
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class SeriesDialog extends Serenity.EntityDialog<SeriesRow, any> {
        protected getFormKey() { return SeriesForm.formKey; }
        protected getIdProperty() { return SeriesRow.idProperty; }
        protected getLocalTextPrefix() { return SeriesRow.localTextPrefix; }
        protected getNameProperty() { return SeriesRow.nameProperty; }
        protected getService() { return SeriesService.baseUrl; }

        protected form = new SeriesForm(this.idPrefix);

    }
}