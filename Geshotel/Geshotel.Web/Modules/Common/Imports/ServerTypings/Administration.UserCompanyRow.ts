
namespace Geshotel.Administration {
    export interface UserCompanyRow {
        UsuarioId?: number;
        EmpresaId?: number;
    }

    export namespace UserCompanyRow {
        export const idProperty = 'UsuarioId';
        export const localTextPrefix = 'Administration.UserCompany';

        export namespace Fields {
            export declare const UsuarioId;
            export declare const EmpresaId;
        }

        ['UsuarioId', 'EmpresaId'].forEach(x => (<any>Fields)[x] = x);
    }
}

