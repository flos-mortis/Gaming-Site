﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models;

namespace TestStore.ViewModels
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? Year { get; set; }
        public Game FavGame { get; set; }
        public string About { get; set; }
    }
}
