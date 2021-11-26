﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMWebCore.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Height { get; set; }
        public string Photo { get; set; }
        public virtual Team TeamId { get; set; }
    }
}