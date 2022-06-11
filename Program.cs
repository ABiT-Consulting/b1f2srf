
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

var xml = System.IO.File.ReadAllText("b1iF.xml");
var docBIF = XDocument.Parse(xml);
//Console.WriteLine(docBIF.ToString());

var appformnumber = "";
appformnumber  = docBIF.Element("form")?.Attribute("FormType")?.Value;
var title = "";
title = docBIF.Element("form")?.Attribute("Title")?.Value;
var visible = "";
// Convert to Byte
visible = docBIF.Element("form")?.Attribute("Visible")?.Value;
var left = "";
left = docBIF.Element("form")?.Attribute("Left")?.Value;
var top = "";
top = docBIF.Element("form")?.Attribute("Top")?.Value;
var width = "";
width = docBIF.Element("form")?.Attribute("Width")?.Value;
var height = "";
height = docBIF.Element("form")?.Attribute("Height")?.Value;
var client_width = "";
client_width = docBIF.Element("form")?.Attribute("Client_Width")?.Value;
var client_height = "";
client_height = docBIF.Element("form")?.Attribute("Client_Height")?.Value;
var SupportedModes = "";
SupportedModes = docBIF.Element("form")?.Attribute("SupportedModes")?.Value;
var AutoManaged = "";
// Convert to Byte
AutoManaged = docBIF.Element("form")?.Attribute("AutoManaged")?.Value;
var mode = "";
mode = docBIF.Element("form")?.Attribute("Mode")?.Value;

//var table = "";
List<string> strs=new List<string>();
var table = docBIF.Descendants("form").Descendants("datasources").Descendants("dbdatasources").Descendants("datasource").SelectMany(x=>x.Attributes()).ToList();
 foreach(var r in table){
     strs.Add(r.Value);
 }
 Console.WriteLine(strs[0]+strs[1]+strs[2]);
  
 
var docSRF = new XDocument();
docSRF.Add(new XElement("Application"
, new XElement("forms", 
new XElement("action"
,new XElement("form"
,new XElement("datasources"
,new XElement("DataTables")
,new XElement("dbdatasources"
,new XElement("action"
,new XElement("datasource")))
,new XElement("userdatasources"
,new XElement("action"
,new XElement("datasource")))

),new XElement("Menus")
,new XElement("items"
,new XElement("action"
,new XElement("item")))))
)
)
);
 
docSRF.XPathSelectElement("/Application/forms/action")?.SetAttributeValue("type","add");
docSRF.XPathSelectElement("/Application/forms/action")?.Add(new XElement("form"));
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("appformnumber", appformnumber);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("FormType", appformnumber);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("type", "0");
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("BorderStyle", "0");
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("uid", appformnumber);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("uid", title);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("visible", visible);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("left", left);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("top", top);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("width", width);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("height", height);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("client_width", client_width);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("client_height", client_height);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("AutoManaged", AutoManaged);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("SupportedModes", SupportedModes);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("ObjectType", appformnumber);
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("mode", mode);
docSRF.XPathSelectElement("/Application/forms/action/form/datasources/dbdatasources/action")?.SetAttributeValue("type","add");
foreach(string i in strs){
   
     docSRF.XPathSelectElement("/Application/forms/action/form/datasources/dbdatasources/action/datasource")?.SetAttributeValue("tablename",strs[i]);//using loop
 }
docSRF.XPathSelectElement("/Application/forms/action/form/datasources/userdatasources/action")?.SetAttributeValue("type","add");
docSRF.XPathSelectElement("/Application/forms/action/form/datasources/userdatasources/action/datasource")?.SetAttributeValue("type","@INWARDGATE");//using loop
docSRF.XPathSelectElement("/Application/forms/action/form/datasources/userdatasources/action/datasource")?.SetAttributeValue("size","@INWARDGATE");//usong loop
docSRF.XPathSelectElement("/Application/forms/action/form/items/action")?.SetAttributeValue("type","add");





 //Console.WriteLine(docSRF.ToString());