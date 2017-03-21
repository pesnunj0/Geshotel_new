/// <reference path="../HabitacionesBloqueos/HabitacionesBloqueosDialog.ts" />

namespace Geshotel.Recepcion {

    @Serenity.Decorators.registerClass()
    export class ReservasHabitacionesBloqueosDialog extends HabitacionesBloqueosDialog {

        constructor() {
            super();
        }

        updateInterface() {
            super.updateInterface();

            Serenity.EditorUtils.setReadOnly(this.form.ReservaId, true);
            //Serenity.EditorUtils.setReadonly(this.form.TipoBloqueoId, true);
        }
    }
}