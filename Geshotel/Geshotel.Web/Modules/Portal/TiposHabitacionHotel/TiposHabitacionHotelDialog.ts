
namespace Geshotel.Portal {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TiposHabitacionHotelDialog extends Serenity.EntityDialog<TiposHabitacionHotelRow, any> {
        protected getFormKey() { return TiposHabitacionHotelForm.formKey; }
        protected getIdProperty() { return TiposHabitacionHotelRow.idProperty; }
        protected getLocalTextPrefix() { return TiposHabitacionHotelRow.localTextPrefix; }
        protected getService() { return TiposHabitacionHotelService.baseUrl; }

        protected form = new TiposHabitacionHotelForm(this.idPrefix);

    }
}