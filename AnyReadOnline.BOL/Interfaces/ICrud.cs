﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface ICrud<T> : ICreate<T>, IRead<T>, IUpdate<T>, IDelete
    {
    }
}
