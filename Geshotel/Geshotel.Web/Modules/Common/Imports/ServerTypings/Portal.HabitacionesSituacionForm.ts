
namespace Geshotel.Portal {
    export class HabitacionesSituacionForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.HabitacionesSituacion';

    }

    export interface HabitacionesSituacionForm {
        Descriptivo: Serenity.StringEditor;
        Editable: Serenity.BooleanEditor;
    }

    [['Descriptivo', () => Serenity.StringEditor], ['Editable', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(HabitacionesSituacionForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

