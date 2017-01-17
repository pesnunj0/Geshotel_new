namespace Geshotel.Portal {
    export class TiposHabitacionForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposHabitacion';

    }

    export interface TiposHabitacionForm {
        DescCorta: Serenity.StringEditor;
        Descripcion: Serenity.StringEditor;
        GrupoHabitacionId: Serenity.IntegerEditor;
        NumeroPersonas: Serenity.IntegerEditor;
        Desvios: Serenity.IntegerEditor;
        NoShow: Serenity.IntegerEditor;
    }

    [['DescCorta', () => Serenity.StringEditor], ['Descripcion', () => Serenity.StringEditor], ['GrupoHabitacionId', () => Serenity.IntegerEditor], ['NumeroPersonas', () => Serenity.IntegerEditor], ['Desvios', () => Serenity.IntegerEditor], ['NoShow', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(TiposHabitacionForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

