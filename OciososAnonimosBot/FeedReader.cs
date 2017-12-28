using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace OciososAnonimosBot {
    public static class FeedReader {
        private const string _url = "https://ociososanonimos.com/feed/";

        public static string ReadLast() {
            using (var reader = XmlReader.Create(_url)) {
                var feed = SyndicationFeed.Load(reader);

                return feed.Items.First().Links.First().Uri.ToString();
            }
        }
    }
 }