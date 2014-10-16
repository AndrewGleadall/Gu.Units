﻿
namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity Frequency
    /// </summary>
    [Serializable]
    public partial struct Frequency : IComparable<Frequency>, IEquatable<Frequency>, IFormattable, IXmlSerializable, IQuantity<TimeUnit, INeg1>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Herts"/>.
        /// </summary>
        public readonly double Herts;

        private Frequency(double herts)
        {
            Herts = herts;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Herts"/>.</param>
        public Frequency(double value, FrequencyUnit unit)
        {
            Herts = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Herts
        /// </summary>
        public double SiValue
        {
            get
            {
                return Herts;
            }
        }


        /// <summary>
        /// The quantity in kiloherts
        /// </summary>
        public double Kiloherts
        {
            get
            {
                return FrequencyUnit.Kiloherts.FromSiUnit(Herts);
            }
        }

        /// <summary>
        /// The quantity in megaherts
        /// </summary>
        public double Megaherts
        {
            get
            {
                return FrequencyUnit.Megaherts.FromSiUnit(Herts);
            }
        }

        /// <summary>
        /// The quantity in gigaherts
        /// </summary>
        public double Gigaherts
        {
            get
            {
                return FrequencyUnit.Gigaherts.FromSiUnit(Herts);
            }
        }

        /// <summary>
        /// The quantity in milliherts
        /// </summary>
        public double Milliherts
        {
            get
            {
                return FrequencyUnit.Milliherts.FromSiUnit(Herts);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Frequency"/></param>
        /// <returns></returns>
        public static Frequency Parse(string s)
        {
            return Parser.Parse<FrequencyUnit, Frequency>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Frequency"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Frequency"/></returns>
        public static Frequency ReadFrom(XmlReader reader)
        {
            var v = new Frequency();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="unit"></param>
        public static Frequency From(double value, FrequencyUnit unit)
        {
            return new Frequency(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Frequency FromHerts(double value)
        {
            return new Frequency(value);
        }


        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Frequency FromKiloherts(double value)
        {
            return From(value, FrequencyUnit.Kiloherts);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Frequency FromMegaherts(double value)
        {
            return From(value, FrequencyUnit.Megaherts);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Frequency FromGigaherts(double value)
        {
            return From(value, FrequencyUnit.Gigaherts);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Frequency FromMilliherts(double value)
        {
            return From(value, FrequencyUnit.Milliherts);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Frequency"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator ==(Frequency left, Frequency right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Frequency"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator !=(Frequency left, Frequency right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is less than another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator <(Frequency left, Frequency right)
        {
            return left.Herts < right.Herts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is greater than another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator >(Frequency left, Frequency right)
        {
            return left.Herts > right.Herts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is less than or equal to another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator <=(Frequency left, Frequency right)
        {
            return left.Herts <= right.Herts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is greater than or equal to another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator >=(Frequency left, Frequency right)
        {
            return left.Herts >= right.Herts;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="left"/> and returns the result.</returns>
        public static Frequency operator *(double left, Frequency right)
        {
            return new Frequency(left * right.Herts);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.</returns>
        public static Frequency operator *(Frequency left, double right)
        {
            return new Frequency(left.Herts * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.</returns>
        public static Frequency operator /(Frequency left, double right)
        {
            return new Frequency(left.Herts / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Frequency"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Frequency operator +(Frequency left, Frequency right)
        {
            return new Frequency(left.Herts + right.Herts);
        }

        /// <summary>
        /// Subtracts an Frequency from another Frequency and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Frequency"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Frequency"/> (the subtrahend).</param>
        public static Frequency operator -(Frequency left, Frequency right)
        {
            return new Frequency(left.Herts - right.Herts);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Frequency"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Frequency">A <see cref="T:Gu.Units.Frequency"/></param>
        public static Frequency operator -(Frequency Frequency)
        {
            return new Frequency(-1 * Frequency.Herts);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Frequency"/>.
        /// </returns>
        /// <param name="Frequency">A <see cref="T:Gu.Units.Frequency"/></param>
        public static Frequency operator +(Frequency Frequency)
        {
            return Frequency;
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
            return this.ToString(format, formatProvider, FrequencyUnit.Herts);
        }

        public string ToString(string format, IFormatProvider formatProvider, FrequencyUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Herts);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Frequency"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Frequency"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Frequency"/> object to compare to this instance.</param>
        public int CompareTo(Frequency quantity)
        {
            return this.Herts.CompareTo(quantity.Herts);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Frequency"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Frequency as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Frequency"/> object to compare with this instance.</param>
        public bool Equals(Frequency other)
        {
            return this.Herts.Equals(other.Herts);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Frequency"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Frequency as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Frequency"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Frequency other, double tolerance)
        {
            return Math.Abs(this.Herts - other.Herts) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Frequency && this.Equals((Frequency)obj);
        }

        public override int GetHashCode()
        {
            return this.Herts.GetHashCode();
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
            reader.MoveToContent();
            var e = (XElement)XNode.ReadFrom(reader);

            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, x => x.Herts, XmlConvert.ToDouble(XmlExt.ReadAttributeOrElementOrDefault(e, "Value")));
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Herts);
        }
    }
}