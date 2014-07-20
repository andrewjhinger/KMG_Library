using BGGwrapper.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameLibrary.Models
{
    public class GameLibraryContext : DbContext
    {

        public GameLibraryContext()
            : base("GameLibraryContext")
        {
        }

        public System.Data.Entity.DbSet<BGGwrapper.Objects.CollectionItem> CollectionItems { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGame> BoardGames { get; set; }

        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGameCategories> BoardGameCategories { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGameDesigner> BoardGameDesigner { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGameExpansions> BoardGameExpansions { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGameHonors> BoardGameHonors { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGameMechanics> BoardGameMechanics { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGameName> BoardGameName { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGamePublisher> BoardGamePublisher { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGameSubdomains> BoardGameSubdomains { get; set; }
        public System.Data.Entity.DbSet<BGGwrapper.Objects.BoardGameVersions> BoardGameVersions { get; set; }


    
    }
}
