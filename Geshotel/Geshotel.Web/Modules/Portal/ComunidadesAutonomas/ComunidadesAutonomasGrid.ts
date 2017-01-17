
namespace Geshotel.Portal {
    
    @Serenity.Decorators.registerClass()
        @Serenity.Decorators.filterable()
    export class ComunidadesAutonomasGrid extends Serenity.EntityGrid<ComunidadesAutonomasRow, any> {
        protected getColumnsKey() { return 'Portal.ComunidadesAutonomas'; }
        protected getDialogType() { return ComunidadesAutonomasDialog; }
        protected getIdProperty() { return ComunidadesAutonomasRow.idProperty; }
        protected getLocalTextPrefix() { return ComunidadesAutonomasRow.localTextPrefix; }
        protected getService() { return ComunidadesAutonomasService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getDefaultSortBy() {
            return [ComunidadesAutonomasRow.Fields.ComunidadAutonoma];
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Portal/ComunidadesAutonomas/ListExcel',
                separator: true
            }));

            buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }
    }
}