using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace OciososAnonimosBot {
    public class FeedReader {

        private string _uri;

        public FeedReader(string uri) {
            _uri = uri;
        }
        public string Read() {
            using (XmlReader reader = XmlReader.Create(_uri)) {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                return feed.Links[0].Uri.ToString();                
            }
        }

    }
}
