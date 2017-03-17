namespace Geshotel.Portal {
    export class CategoriaHotelesForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.CategoriaHoteles';

    }

    export interface CategoriaHotelesForm {
        Abreviatura: Serenity.StringEditor;
        Categoria: Serenity.StringEditor;
    }

    [['Abreviatura', () => Serenity.StringEditor], ['Categoria', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(CategoriaHotelesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

