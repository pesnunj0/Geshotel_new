namespace Geshotel.Contratos {
    export class EdadesForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Edades';

    }

    export interface EdadesForm {
        TipoHuespedId: Serenity.IntegerEditor;
        EdadMinima: Serenity.IntegerEditor;
        EdadMaxima: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
    }

    [['TipoHuespedId', () => Serenity.IntegerEditor], ['EdadMinima', () => Serenity.IntegerEditor], ['EdadMaxima', () => Serenity.IntegerEditor], ['UserId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(EdadesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

