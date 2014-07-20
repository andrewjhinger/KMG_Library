using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGGwrapper.Objects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BGGwrapper.Objects
{
    /// <summary>
    /// This class is used to store the boardgame object that maps to ther XML returned by the API
    /// </summary>
    public class BoardGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectID { get; set; }
        public int yearPublished { get; set; }
        public int minPlayers { get; set; }
        public int maxPlayers { get; set; }
        public int playingTime { get; set; }
        public int age { get; set; }

        public string description { get; set; }
        public string imageThumnailURL { get; set; }
        public string imageURL { get; set; }
        public virtual List<BoardGameCategories> BoardGameCategories { get; set; }
        public virtual List<BoardGameName> BoardGameName { get; set; }
        public virtual List<BoardGameHonors> BoardGameHonors { get; set; }
        public virtual List<BoardGameExpansions> BoardGameExpansions { get; set; }
        public virtual List<BoardGamePublisher> BoardGamePublisher { get; set; }
        public virtual List<BoardGameDesigner> BoardGameDesigner { get; set; }
        public virtual List<BoardGameMechanics> BoardGameMechanics { get; set; }
        public virtual List<BoardGameSubdomains> BoardGameSubdomains { get; set; }
        public virtual List<BoardGameVersions> BoardGameVersions { get; set; }

        public string getPrimaryName()
        {
            return this.BoardGameName.First(x => x.isPrimary == true).name;
        }

        public string getCategories(int Objectid)
        {
            var s = string.Join(",", this.BoardGameCategories.Where(p => p.BGCobjectID == ObjectID)
                                     .Select(p => p.value.ToString()));

            return s;
        }
    }
}
