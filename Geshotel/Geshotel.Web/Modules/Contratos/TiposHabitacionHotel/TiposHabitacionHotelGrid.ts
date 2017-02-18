﻿
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class TiposHabitacionHotelGrid extends Serenity.EntityGrid<TiposHabitacionHotelRow, any> {
        protected getColumnsKey() { return 'Contratos.TiposHabitacionHotel'; }
        protected getDialogType() { return TiposHabitacionHotelDialog; }
        protected getIdProperty() { return TiposHabitacionHotelRow.idProperty; }
        protected getLocalTextPrefix() { return TiposHabitacionHotelRow.localTextPrefix; }
        protected getService() { return TiposHabitacionHotelService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}