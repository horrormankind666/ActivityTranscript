using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Data;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
	public Utility()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string StringEncryption(string text)
    {
        byte[] encodeByte = Encoding.BigEndianUnicode.GetBytes(text);

        return Convert.ToBase64String(encodeByte);
    }
    public static string StringDecryption(string text)
    {
        byte[] encodeByte = Convert.FromBase64String(text);

        return Encoding.BigEndianUnicode.GetString(encodeByte);
    }
}

public class DataTableColumnStringConverter : JsonConverter {
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (objectType == typeof(DataTable))
        {
            return reader.Value;
        }

        return reader.Value;
    }

    public override bool CanConvert(Type objectType)
    {
        return true;// objectType == typeof(DataTable);
    }
}