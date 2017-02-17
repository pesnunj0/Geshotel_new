namespace Geshotel.Administration.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;
    using Geshotel.Portal.Entities;

    [FormScript("Administration.User")]
    [BasedOnRow(typeof(Entities.UserRow))]
    public class UserForm
    {
        public String Username { get; set; }
        public String DisplayName { get; set; }
        [LookupEditor("Portal.Empresas")]
        public Int16 EmpresaId { get; set; }

        [LookupEditor(("Portal.Hoteles"),CascadeFrom ="EmpresaId",CascadeField ="EmpresaId")]
        public Int16 HotelId { get; set; }
        [EmailEditor]
        public String Email { get; set; }
        public String UserImage { get; set; }
        [PasswordEditor, Required(true)]
        public String Password { get; set; }
        [PasswordEditor, OneWay, Required(true)]
        public String PasswordConfirm { get; set; }
        [OneWay]
        public string Source { get; set; }
    }
}