

namespace Geshotel.Administration {
    export class UserCompanyForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.UserCompany';
    }

    export interface UserCompanyForm {
        EmpresaId: Serenity.IntegerEditor;
    }

    [['UsuarioId', () => Serenity.IntegerEditor], ['EmpresaId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(UserCompanyForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}