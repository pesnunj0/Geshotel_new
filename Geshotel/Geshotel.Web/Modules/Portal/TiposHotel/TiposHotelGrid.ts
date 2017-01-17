
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class TiposHotelGrid extends Serenity.EntityGrid<TiposHotelRow, any> {
        protected getColumnsKey() { return 'Portal.TiposHotel'; }
        protected getDialogType() { return TiposHotelDialog; }
        protected getIdProperty() { return TiposHotelRow.idProperty; }
        protected getLocalTextPrefix() { return TiposHotelRow.localTextPrefix; }
        protected getService() { return TiposHotelService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}