﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface IConvertToObject<T>
    {
        T ConvertToObject(SqlDataReader sqlDataReader);
    }
}
