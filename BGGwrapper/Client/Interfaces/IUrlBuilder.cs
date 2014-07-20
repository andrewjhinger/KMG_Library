using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BGGwrapper.Client;
using BGGwrapper.Objects;
using BGGwrapper.Settings;

namespace BGGwrapper.Client
{
    public interface IUrlBuilder
    {
        string buildBoardGameUrl(BoardGameSettings settings, params int[] gameIDs);
        string buildUserCollectionUrl(CollectionSettings settings, string username);
    }
}
