
namespace Geshotel.Recepcion {
    
    @Serenity.Decorators.registerClass()
    export class ReservasHuespedesGrid extends Serenity.EntityGrid<ReservasHuespedesRow, any> {
        protected getColumnsKey() { return 'Recepcion.ReservasHuespedes'; }
        protected getDialogType() { return ReservasHuespedesDialog; }
        protected getIdProperty() { return ReservasHuespedesRow.idProperty; }
        protected getLocalTextPrefix() { return ReservasHuespedesRow.localTextPrefix; }
        protected getService() { return ReservasHuespedesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected initEntityDialog(itemType, dialog) {
            super.initEntityDialog(itemType, dialog);
            Serenity.SubDialogHelper.cascade(dialog, this.element.closest('.ui-dialog'));
        }

        protected addButtonClick() {
            // Javascript is case sensitive, so contratoID didn't work here.
            // To get intellisense, use a TS cast like below <LineasRow>
            this.editItem(<ReservasHuespedesRow>{
                ReservaId: this.reservaID
            });
        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Geshotel.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'Recepcion/ReservasHuespedes/ListExcel',
                separator: true
            }));

            buttons.push(Geshotel.Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }

        protected getInitialTitle() {
            return null;
        }

        protected getGridCanLoad() {
            return this.reservaID != null;

        }

        private _reservaID: number;
 
        get reservaID() {
            return this._reservaID;
        }

        set reservaID(value: number) {
            if (this._reservaID !== value) {
                this._reservaID = value;
                this.setEquality(HabitacionesBloqueosRow.Fields.ReservaId, value);
                this.refresh();
            }
        }
 
    }
    }
}