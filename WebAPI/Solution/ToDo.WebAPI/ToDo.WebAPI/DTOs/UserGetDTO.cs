﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.WebAPI.DTOs
{
    public class UserGetDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}