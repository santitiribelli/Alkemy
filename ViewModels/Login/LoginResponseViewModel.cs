﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.ViewModels.Login
{
    public class LoginResponseViewModel
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
