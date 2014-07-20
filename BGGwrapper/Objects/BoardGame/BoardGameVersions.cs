﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BGGwrapper.Objects
{
    public class BoardGameVersions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BGV { get; set; }
        public int BGVobjectID { get; set; }
        public string value { get; set; }

        public virtual BoardGame BoardGame { get; set; }
    }
}
