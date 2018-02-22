using System;
using Microsoft.Extensions.Localization;

namespace MBODM.AspNetCore.SimpleLocalization
{
    public sealed class Localizer<T> : ILocalizer
    {
        private readonly IStringLocalizer<T> stringLocalizer;

        public Localizer(IStringLocalizer<T> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer ?? throw new ArgumentNullException(nameof(stringLocalizer));
        }

        public string this[string key]
        {
            get { return GetText(key); }
        }

        public string GetText(string key)
        {
            return stringLocalizer[key];
        }
    }
}
