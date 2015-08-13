namespace Buttons
{
    using System.Collections.Generic;
    using System.Xml;

    public class ButtonsConfig
    {
        public List<ApplicationButton> Buttons { get; set; } = new List<ApplicationButton>();
        public string ApplicationMessage { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public string BackgroundColor { get; set; }
        public string Title { get; set; }

        public static ButtonsConfig LoadFile(string s)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(s);
            
            if (xmlDoc.DocumentElement == null) return null;

            var config = new ButtonsConfig();
            var appNodes = xmlDoc.DocumentElement.SelectNodes("//application");
            if (appNodes != null)
            {
                foreach (XmlNode selectNode in appNodes)
                {
                    if (selectNode.Attributes == null) continue;
                
                    var appButton = new ApplicationButton();
                    var titleNode = selectNode.Attributes.GetNamedItem("title");
                    if (titleNode != null)
                    {
                        appButton.Title = titleNode.Value;
                    }
                    var appPathNode = selectNode.Attributes.GetNamedItem("path");
                    if (appPathNode != null)
                    {
                        appButton.ApplicationPath = appPathNode.Value;
                    }
                    var paramsNode = selectNode.Attributes.GetNamedItem("params");
                    if (paramsNode != null)
                    {
                        appButton.Parameters = paramsNode.Value;
                    }
                    config.Buttons.Add(appButton);
                }
            }
            var windowNode = xmlDoc.DocumentElement.SelectSingleNode("//window");
            if (windowNode != null && windowNode.Attributes != null)
            {
                var messageNode = windowNode.Attributes.GetNamedItem("message");
                if (messageNode != null)
                {
                    config.ApplicationMessage = messageNode.Value;
                }
                var titleNode = windowNode.Attributes.GetNamedItem("title");
                if (titleNode != null)
                {
                    config.Title = titleNode.Value;
                }
                var windowWidthAttr = windowNode.Attributes.GetNamedItem("width");
                if (windowWidthAttr != null)
                {
                    var windowWidth = config.WindowWidth;
                    int.TryParse(windowWidthAttr.Value, out windowWidth);
                }
                var windowHeightAttr = windowNode.Attributes.GetNamedItem("height");
                if (windowHeightAttr != null)
                {
                    var windowHeight = config.WindowHeight;
                    int.TryParse(windowHeightAttr.Value, out windowHeight);
                }

                var backgroundColorAttr = windowNode.Attributes.GetNamedItem("backgroundColor");
                if (backgroundColorAttr != null)
                {
                    config.BackgroundColor = backgroundColorAttr.Value;
                }
                //backgroundColor
            }

            return config;

        }

        
    }
}