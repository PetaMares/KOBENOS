using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    /// <summary>
    /// Tato třída umožňuje serializovat objekt do XML a zpět.
    /// Zdroj: stackoverflow.com
    /// </summary>
    class SerializationHelper
    {
        public static T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Načte XML soubor a vrátí deserializovaný objekt.
        /// </summary>
        /// <param name="path">Cesta k souboru s XML.</param>
        public static T DeserializeFile<T>(string path) where T : class
        { 
            string xmlString = File.ReadAllText(path);
            return Deserialize<T>(xmlString);
        }
    }
}
