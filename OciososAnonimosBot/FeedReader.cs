using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace OciososAnonimosBot {
    public static class FeedReader {
        public static string Read() {
            using (XmlReader reader = XmlReader.Create("https://ociososanonimos.com/feed/")) {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                return feed.Links[0].Uri.ToString();
            }
        }
 
     }
 }