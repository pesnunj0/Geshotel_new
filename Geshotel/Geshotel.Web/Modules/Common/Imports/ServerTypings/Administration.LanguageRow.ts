﻿
namespace Geshotel.Administration {
    export interface LanguageRow {
        Id?: number;
        LanguageId?: string;
        LanguageName?: string;
    }

    export namespace LanguageRow {
        export const idProperty = 'Id';
        export const nameProperty = 'LanguageName';
        export const localTextPrefix = 'Administration.Language';
        export const lookupKey = 'Administration.Languaje';

        export function getLookup(): Q.Lookup<LanguageRow> {
            return Q.getLookup<LanguageRow>('Administration.Languaje');
        }

        export namespace Fields {
            export declare const Id: string;
            export declare const LanguageId: string;
            export declare const LanguageName: string;
        }

        ['Id', 'LanguageId', 'LanguageName'].forEach(x => (<any>Fields)[x] = x);
    }
}

