
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

var xml = System.IO.File.ReadAllText("b1iF.xml");
var docBIF = XDocument.Parse(xml);
//Console.WriteLine(docBIF.ToString());

var appformnumber = "";
appformnumber  = docBIF.Element("form")?.Attribute("FormType")?.Value;
var docSRF = new XDocument();
docSRF.Add(new XElement("Application"
, new XElement("forms", 
new XElement("action")
)
));
docSRF.XPathSelectElement("/Application/forms/action")?.SetAttributeValue("type","add");
docSRF.XPathSelectElement("/Application/forms/action")?.Add(new XElement("form"));
docSRF.XPathSelectElement("/Application/forms/action/form")?.SetAttributeValue("appformnumber", appformnumber);

Console.WriteLine(docSRF.ToString());