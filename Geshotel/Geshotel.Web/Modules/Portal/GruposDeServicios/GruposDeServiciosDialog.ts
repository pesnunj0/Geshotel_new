
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class GruposDeServiciosDialog extends Serenity.EntityDialog<GruposDeServiciosRow, any> {
        protected getFormKey() { return GruposDeServiciosForm.formKey; }
        protected getIdProperty() { return GruposDeServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return GruposDeServiciosRow.localTextPrefix; }
        protected getNameProperty() { return GruposDeServiciosRow.nameProperty; }
        protected getService() { return GruposDeServiciosService.baseUrl; }

        protected form = new GruposDeServiciosForm(this.idPrefix);

    }
}