using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using BGGwrapper.Client;
using BGGwrapper.Objects;
using BGGwrapper.Settings;

namespace BGGwrapper.Client
{
    public class BGGXMLClient : IBGGClient
    {
        private IUrlBuilder builder = new UrlBuilder();
        private IXMLParser parser = new XMLParser();

        public List<BoardGame> getBoardGame(params int[] gameIDs)
        {
            return getBoardGame(null, gameIDs);
        }

        public List<BoardGame> getBoardGame(BoardGameSettings settings, params int[] gameIDs)
        {
            string requestUrl = builder.buildBoardGameUrl(settings, gameIDs);

            XDocument result = XDocument.Load(requestUrl);

            return parser.parseBoardGameXML(result);
        }

       
        public List<CollectionItem> getUserCollection(string username)
        {
            return getUserCollection(null, username);
        }

        public List<CollectionItem> getUserCollection(CollectionSettings settings, string username)
        {
            string requestUrl = builder.buildUserCollectionUrl(settings, username);

            XDocument result = XDocument.Load(requestUrl);

            return parser.parseCollectionXML(result);
        }
    }
}
