﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carly.Models;

namespace Carly.ViewModels
{
    public class CarFormViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
    }
}