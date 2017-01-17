
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposHotelDialog extends Serenity.EntityDialog<TiposHotelRow, any> {
        protected getFormKey() { return TiposHotelForm.formKey; }
        protected getIdProperty() { return TiposHotelRow.idProperty; }
        protected getLocalTextPrefix() { return TiposHotelRow.localTextPrefix; }
        protected getNameProperty() { return TiposHotelRow.nameProperty; }
        protected getService() { return TiposHotelService.baseUrl; }

        protected form = new TiposHotelForm(this.idPrefix);

    }
}