using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BGGwrapper.Objects
{
    public class BoardGameName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BGN { get; set; }
        public int sortIndex { get; set; }
        public string name { get; set; }
        public bool isPrimary { get; set; }

        public virtual BoardGame BoardGame { get; set; }
    }
}
