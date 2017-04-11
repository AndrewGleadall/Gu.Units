﻿namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Reactive;

    [DebuggerDisplay("{Conversion.Symbol}")]
    public class PrefixConversionVm : INotifyPropertyChanged
    {
        private readonly IList<PrefixConversion> conversions;

        private PrefixConversionVm(ObservableCollection<PrefixConversion> conversions, PrefixConversion prefixConversion)
        {
            this.conversions = conversions;
            this.Conversion = prefixConversion;
            conversions.ObservePropertyChangedSlim()
                       .Subscribe(_ => this.OnPropertyChanged(nameof(this.IsUsed))); // no need for IDisposable
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PrefixConversion Conversion { get; }

        public bool IsUsed
        {
            get => this.conversions.Any(this.IsMatch);
            set
            {
                if (value.Equals(this.IsUsed))
                {
                    return;
                }

                if (value)
                {
                    this.conversions.Add(this.Conversion);
                }
                else
                {
                    var match = this.conversions.FirstOrDefault(this.IsMatch);
                    if (match != null)
                    {
                        this.conversions.Remove(match);
                    }
                }

                this.OnPropertyChanged();
            }
        }

        public static PrefixConversionVm Create(Unit unit, Prefix prefix)
        {
            var prefixConversion = PrefixConversion.Create(unit, prefix);
            return new PrefixConversionVm(unit.PrefixConversions, prefixConversion);
        }

        public static PrefixConversionVm Create(FactorConversion factorConversion, Prefix prefix)
        {
            var prefixConversion = PrefixConversion.Create(factorConversion, prefix);
            return new PrefixConversionVm(factorConversion.PrefixConversions, prefixConversion);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsMatch(PrefixConversion x)
        {
            if (this.Conversion.Prefix.Power != x.Prefix.Power)
            {
                return false;
            }

            return true;
        }
    }
}