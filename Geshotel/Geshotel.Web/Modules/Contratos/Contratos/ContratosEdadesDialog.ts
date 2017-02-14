/// <reference path="../Edades/EdadesDialog.ts" />

namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosEdadesDialog extends EdadesDialog {

        constructor() {
            super();
        }

        updateInterface() {
            super.updateInterface();

            Serenity.EditorUtils.setReadOnly(this.form.ClienteId, true);
            Serenity.EditorUtils.setReadOnly(this.form.HotelId, true);
        }
    }
}