﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Data.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
