using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Emergency.BE;
namespace Emergency.BL.MapQuestAPI
{
    public static class geocodingApi
    {
        public static Coordinates ConvertToCoordinates(Address address)
        {
            string key = @"aNt5BLAa2aK3uAMZoR87F25z2VlhlE3u";
            string adress=address.Street+" "+address.NumOfHome+" st. "+address.City+ " Israel";
            string url = @"http://www.mapquestapi.com/geocoding/v1/address?key=" + key + @"&location=" + adress + @"&outFormat=xml";
            //Console.WriteLine("{0}, {1}", response.Results[0].Geometry.Location.Lat, response.Results[0].Geometry.Location.Lng);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList displayLatLng = xmldoc.GetElementsByTagName("displayLatLng");
                double lat,Long;
                if (!Double.TryParse(displayLatLng[0].FirstChild.FirstChild.InnerText, out lat) || !Double.TryParse(displayLatLng[0].FirstChild.LastChild.InnerText, out Long))
                    throw new Exception("error");
               return new Coordinates(lat, Long);
            }
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                throw new Exception("the addres does not find");
            }
            else //busy network or other error...
            {
                throw new Exception("Network problems");
            }
        }
    }
}
