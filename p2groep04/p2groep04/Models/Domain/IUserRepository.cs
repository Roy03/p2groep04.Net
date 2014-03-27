﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2groep04.Models.Domain
{
    interface IUserRepository
    {
        User FindBy(string username);
        void SaveChanges();
        void Add(User user);
    }
}
