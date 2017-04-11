﻿namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class PrefixConversionsVm : INotifyPropertyChanged
    {
        private readonly Settings settings;
        private readonly ObservableCollection<PrefixConversionVm[]> prefixes = new ObservableCollection<PrefixConversionVm[]>();
        private Unit unit;

        public PrefixConversionsVm(Settings settings)
        {
            this.settings = settings;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PrefixConversionVm[]> Prefixes => this.prefixes;

        public Unit Unit
        {
            get => this.unit;
            set
            {
                if (Equals(value, this.unit))
                {
                    return;
                }

                this.unit = value;
                this.OnPropertyChanged();
            }
        }

        public bool HasItems => this.Prefixes.Any();

        public void SetBaseUnit(Unit value)
        {
            this.Unit = value;
            this.prefixes.Clear();
            if (this.unit != null)
            {
                if (this.IsValidPrefixUnit(this.unit))
                {
                    this.prefixes.Add(this.settings.Prefixes.Select(x => PrefixConversionVm.Create(this.unit, x)).ToArray());
                }

                foreach (var conversion in this.unit.FactorConversions)
                {
                    var prefixConversionVms = this.settings.Prefixes.Select(x => PrefixConversionVm.Create(conversion, x))
                                                                    .Where(x => !string.Equals(x.Conversion.Name, this.unit.Name, StringComparison.OrdinalIgnoreCase)) // filter out kilograms
                                                                    .ToArray();
                    this.prefixes.Add(prefixConversionVms);
                }
            }

            this.OnPropertyChanged(nameof(this.HasItems));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsValidPrefixUnit(INameAndSymbol item)
        {
            if (this.settings.Prefixes.Any(p => item.Name.StartsWith(p.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            if (item is BaseUnit)
            {
                return true;
            }

            if (item is DerivedUnit derivedUnit)
            {
                if (SymbolAndPowerReader.TryRead(derivedUnit.Symbol, out IReadOnlyList<SymbolAndPower> symbolAndPowers))
                {
                    return symbolAndPowers.Count == 1 && symbolAndPowers[0].Power == 1;
                }

                return false;
            }

            return item is FactorConversion;
        }
    }
}
