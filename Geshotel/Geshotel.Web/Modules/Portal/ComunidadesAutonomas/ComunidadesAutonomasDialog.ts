
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ComunidadesAutonomasDialog extends Serenity.EntityDialog<ComunidadesAutonomasRow, any> {
        protected getFormKey() { return ComunidadesAutonomasForm.formKey; }
        protected getIdProperty() { return ComunidadesAutonomasRow.idProperty; }
        protected getLocalTextPrefix() { return ComunidadesAutonomasRow.localTextPrefix; }
        protected getNameProperty() { return ComunidadesAutonomasRow.nameProperty; }
        protected getService() { return ComunidadesAutonomasService.baseUrl; }

        protected form = new ComunidadesAutonomasForm(this.idPrefix);

    }
}