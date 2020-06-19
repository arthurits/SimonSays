using System;
using System.Drawing;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace System
{
    // https://dzone.com/articles/how-to-serializedeserialize-a-dictionary-object-in-1
    [XmlRoot("Program_SimonSays")]
    public class ProgramSettings<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>, IXmlSerializable
    {
        public XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement) { return; }

            reader.Read();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                object key = reader.GetAttribute("Property");
                object value = reader.GetAttribute("Value");
                this.Add((TKey)key, (TValue)value);
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var pair in this)
            {
                writer.WriteStartElement("Settings");
                writer.WriteAttributeString("Property", pair.Key.ToString());
                writer.WriteAttributeString("Value", pair.Value.ToString());
                writer.WriteEndElement();
            }
        }
    }

    // https://stackoverflow.com/questions/453161/how-can-i-save-application-settings-in-a-windows-forms-application
    // https://github.com/Nucs/JsonSettings
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            //System.IO.File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            //System.IO.File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }
        /*
        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (System.IO.File.Exists(fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(System.IO.File.ReadAllText(fileName));
            return t;
        }
        */
    }
}
