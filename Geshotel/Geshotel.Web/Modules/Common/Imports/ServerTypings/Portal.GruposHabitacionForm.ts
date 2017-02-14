
namespace Geshotel.Portal {
    export class GruposHabitacionForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.GruposHabitacion';

    }

    export interface GruposHabitacionForm {
        Habitacion: Serenity.StringEditor;
    }

    [['Habitacion', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(GruposHabitacionForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

