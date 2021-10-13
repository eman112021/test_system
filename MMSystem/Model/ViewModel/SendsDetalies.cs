﻿using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class SendsDetalies
    {
        public int Department_id { get; set; }

        public string Department_name { get; set; }
        public string MesureName { get; set; }
        public string State { get; set; }
        public int flag { get; set; }


        public List<ReplayDto> Replies { get; set; } = new List<ReplayDto>();
    }
}