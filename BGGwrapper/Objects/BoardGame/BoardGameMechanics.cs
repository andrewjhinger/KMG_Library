using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BGGwrapper.Objects
{
    public class BoardGameMechanics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BGM { get; set; }
        public int BGMobjectID { get; set; }
        public string value { get; set; }

        public virtual BoardGame BoardGame { get; set; }
    }
}
