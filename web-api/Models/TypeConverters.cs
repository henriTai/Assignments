using System;
using System.ComponentModel;

namespace web_api.Models
{
    public class PlayerTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                string result = "Name: " + ((Player)value).Name;
                result += " Level: ";
                result += ((Player)value).level;
                result += " Score: ";
                result += ((Player)value).Score;
                result += " ID: ";
                result += ((Player)value).Id;
                if (((Player)value).IsBanned) result += " (Banned) ";
                else result += " () ";
                result += ((Player)value).CreationTime;
                return result;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    public class NewPlayerTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom (ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                NewPlayer n = new NewPlayer((string)value);
                return n;
            }
            else return null;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string)) return ((NewPlayer)value).Name;
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class ModifiedPlayerTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom (ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            int score = Int32.Parse((string) value);
                ModifiedPlayer n = new ModifiedPlayer();
                n.Score = score;
                return n;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                string s = ""+((ModifiedPlayer)value).Score;
                return s;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class ItemTypeConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                string s = ((Item)value)._type.ToString() + 
                ", lvl. " + ((Item)value)._level + " (created: " + ((Item)value)._creationDate + ") " +
                ((Item)value)._itemId;
                return s;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}