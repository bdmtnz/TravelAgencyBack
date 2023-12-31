﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;

namespace TravelAgencyBack.Application.HotelHandler.Switch
{
    public class SwitchHotelRequest : IRequest<ApiResponse<object>>
    {
        public string Id { get; set; }
        public bool Enabled { get; set; }
    }
}
