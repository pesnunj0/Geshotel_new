﻿namespace Geshotel.Portal {
    export interface UsuariosEmpresaRow {
        UserId?: number;
        EmpresaId?: number;
        UserUsername?: string;
        UserDisplayName?: string;
        UserEmail?: string;
        UserSource?: string;
        UserPasswordHash?: string;
        UserPasswordSalt?: string;
        UserInsertDate?: string;
        UserInsertUserId?: number;
        UserUpdateDate?: string;
        UserUpdateUserId?: number;
        UserIsActive?: number;
        UserLastDirectoryUpdate?: string;
        UserUserImage?: string;
    }

    export namespace UsuariosEmpresaRow {
        export const idProperty = 'UserId';
        export const localTextPrefix = 'Portal.UsuariosEmpresa';

        export namespace Fields {
            export declare const UserId: string;
            export declare const EmpresaId: string;
            export declare const UserUsername: string;
            export declare const UserDisplayName: string;
            export declare const UserEmail: string;
            export declare const UserSource: string;
            export declare const UserPasswordHash: string;
            export declare const UserPasswordSalt: string;
            export declare const UserInsertDate: string;
            export declare const UserInsertUserId: string;
            export declare const UserUpdateDate: string;
            export declare const UserUpdateUserId: string;
            export declare const UserIsActive: string;
            export declare const UserLastDirectoryUpdate: string;
            export declare const UserUserImage: string;
        }

        ['UserId', 'EmpresaId', 'UserUsername', 'UserDisplayName', 'UserEmail', 'UserSource', 'UserPasswordHash', 'UserPasswordSalt', 'UserInsertDate', 'UserInsertUserId', 'UserUpdateDate', 'UserUpdateUserId', 'UserIsActive', 'UserLastDirectoryUpdate', 'UserUserImage'].forEach(x => (<any>Fields)[x] = x);
    }
}
