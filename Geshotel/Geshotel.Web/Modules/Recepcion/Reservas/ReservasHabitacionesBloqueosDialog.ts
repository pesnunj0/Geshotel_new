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

            // Serenity.EditorUtils.setReadonly(this.form.TipoBloqueoId, true);

            // -------------------------------------------------------------------
            // Here if I uncomment the line above I get the following error
            // Argument of type LookupEditor is not assignable to parameter jQuery 
            // Property ajaxComplete is missing in type LookupEditor ???
            // --------------------------------------------------------------------
        }
    }
}