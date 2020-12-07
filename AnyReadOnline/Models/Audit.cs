﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyReadOnline.Models
{
    public class Audit : IAudit
    {
        public int InsBy { get; set; }
        public DateTime InsDate { get; set; }
        public int UpdBy { get; set; }
        public DateTime UpdDate { get; set; }
        public int UpdNo { get; set; }
    }
}