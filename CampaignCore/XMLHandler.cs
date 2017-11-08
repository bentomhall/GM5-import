using System;
using System.IO;
using System.Xml.Serialization;
using Schemas;

namespace CampaignCore
{
    public class XMLHandler
    {
        public Campaign ParseXML(string path) {
            campaign newCampaign;
            using (StreamReader reader = new StreamReader(path)) {
                XmlSerializer serializer = new XmlSerializer(typeof(campaign));
                newCampaign = (campaign)serializer.Deserialize(reader);
            }
            return new Campaign(newCampaign);
        }

        public void SaveXML(campaign c, string path) {
            using (FileStream writer = new FileStream(path, FileMode.Create)) {
                XmlSerializer serializer = new XmlSerializer(typeof(campaign));
                serializer.Serialize(writer, c);
            }
        }

        public void GetXMLString(Campaign c, StreamWriter writer)
        {
            var serializer = new XmlSerializer(typeof(campaign));
            serializer.Serialize(writer, c.BuildForPersistance());  
        }
    }
}
