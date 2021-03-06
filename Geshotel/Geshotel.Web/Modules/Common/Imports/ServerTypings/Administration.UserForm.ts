﻿
namespace Geshotel.Administration {
    export class UserForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.User';

    }

    export interface UserForm {
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        EmpresaId: Serenity.LookupEditor;
        HotelId: Serenity.LookupEditor;
        Email: Serenity.EmailEditor;
        UserImage: Serenity.ImageUploadEditor;
        Password: Serenity.PasswordEditor;
        PasswordConfirm: Serenity.PasswordEditor;
        Source: Serenity.StringEditor;
    }

    [['Username', () => Serenity.StringEditor], ['DisplayName', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.LookupEditor], ['HotelId', () => Serenity.LookupEditor], ['Email', () => Serenity.EmailEditor], ['UserImage', () => Serenity.ImageUploadEditor], ['Password', () => Serenity.PasswordEditor], ['PasswordConfirm', () => Serenity.PasswordEditor], ['Source', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(UserForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

