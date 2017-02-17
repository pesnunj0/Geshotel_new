
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class ServiciosHotelGrid extends Serenity.EntityGrid<ServiciosHotelRow, any> {
        protected getColumnsKey() { return 'Contratos.ServiciosHotel'; }
        protected getDialogType() { return ServiciosHotelDialog; }
        protected getIdProperty() { return ServiciosHotelRow.idProperty; }
        protected getLocalTextPrefix() { return ServiciosHotelRow.localTextPrefix; }
        protected getService() { return ServiciosHotelService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}