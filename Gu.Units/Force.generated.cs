﻿namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Force"/>.
    /// </summary>
    [Serializable]
    public partial struct Force : IComparable<Force>, IEquatable<Force>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1, LengthUnit, I1, TimeUnit, INeg2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Newtons"/>.
        /// </summary>
        public readonly double Newtons;

        private Force(double newtons)
        {
            Newtons = newtons;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Newtons"/>.</param>
        public Force(double value, ForceUnit unit)
        {
            Newtons = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Newtons
        /// </summary>
        public double SiValue
        {
            get
            {
                return Newtons;
            }
        }

        /// <summary>
        /// The quantity in nanonewtons
        /// </summary>
        public double Nanonewtons
        {
            get
            {
                return ForceUnit.Nanonewtons.FromSiUnit(Newtons);
            }
        }

        /// <summary>
        /// The quantity in micronewtons
        /// </summary>
        public double Micronewtons
        {
            get
            {
                return ForceUnit.Micronewtons.FromSiUnit(Newtons);
            }
        }

        /// <summary>
        /// The quantity in millinewtons
        /// </summary>
        public double Millinewtons
        {
            get
            {
                return ForceUnit.Millinewtons.FromSiUnit(Newtons);
            }
        }

        /// <summary>
        /// The quantity in kilonewtons
        /// </summary>
        public double Kilonewtons
        {
            get
            {
                return ForceUnit.Kilonewtons.FromSiUnit(Newtons);
            }
        }

        /// <summary>
        /// The quantity in meganewtons
        /// </summary>
        public double Meganewtons
        {
            get
            {
                return ForceUnit.Meganewtons.FromSiUnit(Newtons);
            }
        }

        /// <summary>
        /// The quantity in giganewtons
        /// </summary>
        public double Giganewtons
        {
            get
            {
                return ForceUnit.Giganewtons.FromSiUnit(Newtons);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Force"/></param>
        /// <returns></returns>
        public static Force Parse(string s)
        {
            return Parser.Parse<ForceUnit, Force>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Force"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Force"/></returns>
        public static Force ReadFrom(XmlReader reader)
        {
            var v = new Force();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Force From(double value, ForceUnit unit)
        {
            return new Force(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="newtons">The value in <see cref="T:Gu.Units.Newtons"/></param>
        public static Force FromNewtons(double newtons)
        {
            return new Force(newtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="nanonewtons">The value in nN</param>
        public static Force FromNanonewtons(double nanonewtons)
        {
            return From(nanonewtons, ForceUnit.Nanonewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="micronewtons">The value in µN</param>
        public static Force FromMicronewtons(double micronewtons)
        {
            return From(micronewtons, ForceUnit.Micronewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="millinewtons">The value in mN</param>
        public static Force FromMillinewtons(double millinewtons)
        {
            return From(millinewtons, ForceUnit.Millinewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="kilonewtons">The value in kN</param>
        public static Force FromKilonewtons(double kilonewtons)
        {
            return From(kilonewtons, ForceUnit.Kilonewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="meganewtons">The value in MN</param>
        public static Force FromMeganewtons(double meganewtons)
        {
            return From(meganewtons, ForceUnit.Meganewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <param name="giganewtons">The value in GN</param>
        public static Force FromGiganewtons(double giganewtons)
        {
            return From(giganewtons, ForceUnit.Giganewtons);
        }

        public static Mass operator /(Force left, Acceleration right)
        {
            return Mass.FromKilograms(left.Newtons / right.MetresPerSecondSquared);
        }

        public static Pressure operator /(Force left, Area right)
        {
            return Pressure.FromPascals(left.Newtons / right.SquareMetres);
        }

        public static Energy operator *(Force left, Length right)
        {
            return Energy.FromJoules(left.Newtons * right.Metres);
        }

        public static Power operator *(Force left, Speed right)
        {
            return Power.FromWatts(left.Newtons * right.MetresPerSecond);
        }

        public static Acceleration operator /(Force left, Mass right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.Newtons / right.Kilograms);
        }

        public static Stiffness operator /(Force left, Length right)
        {
            return Stiffness.FromNewtonsPerMetre(left.Newtons / right.Metres);
        }


        public static double operator /(Force left, Force right)
        {
            return left.Newtons / right.Newtons;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Force"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Force"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Force"/>.</param>
        public static bool operator ==(Force left, Force right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Force"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Force"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Force"/>.</param>
        public static bool operator !=(Force left, Force right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Force"/> is less than another specified <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Force"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Force"/>.</param>
        public static bool operator <(Force left, Force right)
        {
            return left.Newtons < right.Newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Force"/> is greater than another specified <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Force"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Force"/>.</param>
        public static bool operator >(Force left, Force right)
        {
            return left.Newtons > right.Newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Force"/> is less than or equal to another specified <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Force"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Force"/>.</param>
        public static bool operator <=(Force left, Force right)
        {
            return left.Newtons <= right.Newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Force"/> is greater than or equal to another specified <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Force"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Force"/>.</param>
        public static bool operator >=(Force left, Force right)
        {
            return left.Newtons >= right.Newtons;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Force"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Force"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Force"/> with <paramref name="left"/> and returns the result.</returns>
        public static Force operator *(double left, Force right)
        {
            return new Force(left * right.Newtons);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Force"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Force"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Force"/> with <paramref name="right"/> and returns the result.</returns>
        public static Force operator *(Force left, double right)
        {
            return new Force(left.Newtons * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Force"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Force"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Force"/> with <paramref name="right"/> and returns the result.</returns>
        public static Force operator /(Force left, double right)
        {
            return new Force(left.Newtons / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Force"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Force"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Force"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Force operator +(Force left, Force right)
        {
            return new Force(left.Newtons + right.Newtons);
        }

        /// <summary>
        /// Subtracts an Force from another Force and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Force"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Force"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Force"/> (the subtrahend).</param>
        public static Force operator -(Force left, Force right)
        {
            return new Force(left.Newtons - right.Newtons);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Force"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Force"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Force">A <see cref="T:Gu.Units.Force"/></param>
        public static Force operator -(Force Force)
        {
            return new Force(-1 * Force.Newtons);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Force"/>.
        /// </returns>
        /// <param name="Force">A <see cref="T:Gu.Units.Force"/></param>
        public static Force operator +(Force Force)
        {
            return Force;
        }

        public override string ToString()
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo);
        }

        public string ToString(string format)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo);
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.GetInstance(provider));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.ToString(format, formatProvider, ForceUnit.Newtons);
        }

        public string ToString(string format, IFormatProvider formatProvider, ForceUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Newtons);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Force"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Force"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// 
        ///                     Value
        /// 
        ///                     Description
        /// 
        ///                     A negative integer
        /// 
        ///                     This instance is smaller than <paramref name="quantity"/>.
        /// 
        ///                     Zero
        /// 
        ///                     This instance is equal to <paramref name="quantity"/>.
        /// 
        ///                     A positive integer
        /// 
        ///                     This instance is larger than <paramref name="quantity"/>.
        /// 
        /// </returns>
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Force"/> object to compare to this instance.</param>
        public int CompareTo(Force quantity)
        {
            return this.Newtons.CompareTo(quantity.Newtons);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Force"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Force as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Force"/> object to compare with this instance.</param>
        public bool Equals(Force other)
        {
            return this.Newtons.Equals(other.Newtons);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Force"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Force as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Force"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Force other, double tolerance)
        {
            return Math.Abs(this.Newtons - other.Newtons) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Force && this.Equals((Force)obj);
        }

        public override int GetHashCode()
        {
            return this.Newtons.GetHashCode();
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, 
        /// you should return null (Nothing in Visual Basic) from this method, and instead, 
        /// if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
        ///  <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> 
        /// method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "Newtons", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Newtons);
        }
    }
}
