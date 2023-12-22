﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain.Contracts
{
    public interface IEntity : IStorable
    {
        void SetEnable(bool enable);
    }
}
