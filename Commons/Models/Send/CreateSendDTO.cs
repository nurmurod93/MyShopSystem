﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.Send
{
    public class CreateSendDTO
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}
