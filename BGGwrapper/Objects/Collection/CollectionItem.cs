using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BGGwrapper.Objects
{
    public class CollectionItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectID { get; set; }
    }
}
