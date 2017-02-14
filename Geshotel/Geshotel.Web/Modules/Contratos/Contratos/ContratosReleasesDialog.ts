/// <reference path="../Releases/ReleasesDialog.ts" />

namespace Geshotel.Contratos {

    @Serenity.Decorators.registerClass()
    export class ContratosReleasesDialog extends ReleasesDialog {

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