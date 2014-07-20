using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BGGwrapper.Objects
{
    public class BoardGameHonors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BGH { get; set; }
        public int BGHobjectID { get; set; }
        public string value { get; set; }

        public virtual BoardGame BoardGame { get; set; }
    }
}
