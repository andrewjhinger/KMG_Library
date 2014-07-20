using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BGGwrapper.Objects;
using BGGwrapper.Settings;

namespace BGGwrapper.Client
{
    public interface IBGGClient
    {
        //Fetch specific boardgame methods
        List<BoardGame> getBoardGame(params int[] gameIDs);
        List<BoardGame> getBoardGame(BoardGameSettings settings, params int[] gameIDs);

        //Retrieve collection methods
        List<CollectionItem> getUserCollection(CollectionSettings settings, string username);
        List<CollectionItem> getUserCollection(string username);
    }
}
