using System;
using System.IO;
using System.Xml.Serialization;
using Schemas;

namespace GM5_Campaign
{
    public class XMLHandler
    {
        public campaign ParseXML(string path) {
            campaign newCampaign;
            using (StreamReader reader = new StreamReader(path)) {
                XmlSerializer serializer = new XmlSerializer(typeof(campaign));
                newCampaign = (campaign)serializer.Deserialize(reader);
            }
            return newCampaign;
        }

        public void SaveXML(campaign c, string path) {
            using (FileStream writer = new FileStream(path, FileMode.Create)) {
                XmlSerializer serializer = new XmlSerializer(typeof(campaign));
                serializer.Serialize(writer, c);
            }
        }
    }
}
