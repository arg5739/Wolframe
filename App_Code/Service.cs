using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Net;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    // variable declaration
    string key = null;

    //constructor
    public Service()
    {
        key = "X8R4WX-7K976AWP82";
    }

    /**
 * Get the outfrom Wolframe Alpha in json format.
 *
 * @param       input    (string) it is input string 
 * 
 * @return              json object 
 */
    public string getWolframe(string input)
    {
        string output;
        using (WebClient client = new WebClient())
        {
            string input_xml = "http://api.wolframalpha.com/v2/query?input=" + input + "&appid=" + key ;
            output = client.DownloadString(input_xml);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(output);
            
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(json);
            return (jss.Serialize(dict));
        }
    }

}
