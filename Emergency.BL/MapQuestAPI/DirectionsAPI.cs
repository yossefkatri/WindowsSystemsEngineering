using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Emergency.BL.MapQuestAPI
{
    class DirectionsAPI
    {  
            //string origin = "pisga 45 st. jerusalem"; //or "תקווה פתח 100 העם אחד "etc.
            //string destination = "gilgal 78 st. ramat-gan";//or "גן רמת 10 בוטינסקי'ז "etc.
        public double DistanceBetweenAdress(string origin, string destination)
        {
            string KEY = @"aNt5BLAa2aK3uAMZoR87F25z2VlhlE3u";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
             @"?key=" + KEY +
             @"&from=" + origin +
             @"&to=" + destination +
             @"&outFormat=xml" +
             @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
             @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                return distInMiles * 1.609344;

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
