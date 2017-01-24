
namespace Geshotel.Contratos {
    
    @Serenity.Decorators.registerClass()
    export class LineasDeContratoGrid extends Serenity.EntityGrid<LineasDeContratoRow, any> {
        protected getColumnsKey() { return 'Contratos.LineasDeContrato'; }
        protected getDialogType() { return LineasDeContratoDialog; }
        protected getIdProperty() { return LineasDeContratoRow.idProperty; }
        protected getLocalTextPrefix() { return LineasDeContratoRow.localTextPrefix; }
        protected getService() { return LineasDeContratoService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}