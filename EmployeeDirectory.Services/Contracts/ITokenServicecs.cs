﻿using EmployeeDirectory.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contracts
{
    public interface ITokenServicecs
    {
        string CreateToken(User user);
    }
}
