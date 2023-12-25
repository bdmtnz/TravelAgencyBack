﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;

namespace TravelagencyBack.Application.RoomHandler.Switch
{
    public class SwitchRoomRequest : IRequest<ApiResponse<object>>
    {
        public string Id { get; set; }
        public bool Enabled { get; set; }
    }
}