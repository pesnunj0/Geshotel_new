
using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Geshotel.Administration
{
    public partial class EmpresasListFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "Geshotel.Administration.EmpresasListFormatter";

        public EmpresasListFormatterAttribute()
            : base(Key)
        {
        }
    }
}

