namespace GameLibrary.Migrations
{
    using BGGwrapper.Client;
    using BGGwrapper.Objects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration1 : DbMigrationsConfiguration<GameLibrary.Models.GameLibraryContext>
    {
        public Configuration1()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsNamespace = "GameLibrary.Models.ContextNamespace1";
        }

        protected override void Seed(GameLibrary.Models.GameLibraryContext context)
        {
            IBGGClient kingmakers = new BGGXMLClient();

            List<CollectionItem> collection = new List<CollectionItem>();
            collection = kingmakers.getUserCollection("kingmakers");

            List<CollectionItem> SortedCollection = collection.OrderBy(o => o.ObjectID).ToList();

            foreach (CollectionItem game in SortedCollection)
            {
                if (context.CollectionItems.Find(game.ObjectID) == null)
                {
                    context.CollectionItems.AddOrUpdate(p => p.ObjectID, game);
                    context.SaveChanges();
                }
            }

            var SortedBoardGame = SortedCollection.ToArray();
            List<int> list = new List<int>();



            foreach (CollectionItem x in SortedBoardGame)
            {
                list.Add(x.ObjectID);
            }

            int[] terms = list.ToArray();

            List<BoardGame> boardgames = kingmakers.getBoardGame(terms);

            string br1 = "<br/><br/>";
            string br2 = "<br/>";
            string br3 = "<br/>";


            foreach (var item in boardgames)
            {
                item.description = item.description.Replace(br1, string.Empty);
                item.description = item.description.Replace(br2, string.Empty);
                item.description = item.description.Replace(br3, string.Empty);
            }
            //boardgames.ForEach(b => b.description.Replace(br, ""));

            boardgames.ForEach(s => context.BoardGames.AddOrUpdate(p => p.ObjectID, s));
            context.SaveChanges();
        }
    }

    internal sealed class Configuration2 : DbMigrationsConfiguration<GameLibrary.Models.ApplicationDbContext>
    {
        public Configuration2()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsNamespace = "GameLibrary.Models.ContextNamespace2";
        }

        protected override void Seed(GameLibrary.Models.ApplicationDbContext context)
        {
            
        }
    }
}
