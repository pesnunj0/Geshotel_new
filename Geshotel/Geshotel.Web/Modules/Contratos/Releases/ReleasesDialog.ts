
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ReleasesDialog extends Serenity.EntityDialog<ReleasesRow, any> {
        protected getFormKey() { return ReleasesForm.formKey; }
        protected getIdProperty() { return ReleasesRow.idProperty; }
        protected getLocalTextPrefix() { return ReleasesRow.localTextPrefix; }
        protected getNameProperty() { return ReleasesRow.nameProperty; }
        protected getService() { return ReleasesService.baseUrl; }

        protected form = new ReleasesForm(this.idPrefix);

    }
}