
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
    export class GruposDeServiciosGrid extends Serenity.EntityGrid<GruposDeServiciosRow, any> {
        protected getColumnsKey() { return 'Portal.GruposDeServicios'; }
        protected getDialogType() { return GruposDeServiciosDialog; }
        protected getIdProperty() { return GruposDeServiciosRow.idProperty; }
        protected getLocalTextPrefix() { return GruposDeServiciosRow.localTextPrefix; }
        protected getService() { return GruposDeServiciosService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}