
namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ServiciosHotelDialog extends Serenity.EntityDialog<ServiciosHotelRow, any> {
        protected getFormKey() { return ServiciosHotelForm.formKey; }
        protected getIdProperty() { return ServiciosHotelRow.idProperty; }
        protected getLocalTextPrefix() { return ServiciosHotelRow.localTextPrefix; }
        protected getNameProperty() { return ServiciosHotelRow.nameProperty; }
        protected getService() { return ServiciosHotelService.baseUrl; }

        protected form = new ServiciosHotelForm(this.idPrefix);

    }
}