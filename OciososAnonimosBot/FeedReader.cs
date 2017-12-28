using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace OciososAnonimosBot {
    public static class FeedReader {
        public static string ReadLast() {
            using (XmlReader reader = XmlReader.Create("https://ociososanonimos.com/feed/")) {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                return feed.Items.First().Links.First().Uri.ToString();
            }
        }
      }
 }