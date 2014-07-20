using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using BGGwrapper.Objects;

namespace BGGwrapper.Client
{
    public interface IXMLParser
    {
        List<BoardGame> parseBoardGameXML(XDocument input);
        List<CollectionItem> parseCollectionXML(XDocument input);
    }
}
