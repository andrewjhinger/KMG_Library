﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BGGwrapper.Objects
{
    public class BoardGameStats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime? statDate { get; set; }
        public int usersRated { get; set; }
        public float average { get; set; }
        public float bayesAverage { get; set; }
        public float standardDeviation { get; set; }
        public float median { get; set; }
        public int owned { get; set; }
        public int trading { get; set; }
        public int wanting { get; set; }
        public int wishing { get; set; }
        public int numComments { get; set; }
        public int numWeights { get; set; }
        public float averageWeight { get; set; }
        public List<BoardGameRank> ranks { get; set; }
    }

    public class BoardGameRank
    {
        public string type { get; set; }
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string friendlyName { get; set; }
        public int value { get; set; }
        public float bayesAverage { get; set; }
    }
}
