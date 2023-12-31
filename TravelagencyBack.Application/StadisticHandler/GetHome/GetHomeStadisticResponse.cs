using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyBack.Application.StadisticHandler.GetHome
{
    public class GetHomeStadisticResponse
    {
        public GetHomeStadisticHotel Hoteles { get; set; }
        public GetHomeStadisticRoom Room { get; set; }
        public GetHomeStadisticBooking Reservaciones { get; set; }
    }

    public class GetHomeStadisticHotel
    {
        public int N_creados { get; set; }
        public int Habilitados { get; set; }
        public int Deshabilitados => N_creados - Habilitados;
    }

    public class GetHomeStadisticRoom
    {
        public int N_creados { get; set; }
        public int Disponibles { get; set; }
        public int Reservadas => N_creados - Disponibles;
    }

    public class GetHomeStadisticBooking
    {
        public int N_creados { get; set; }
        public int Habilitados { get; set; }
    }
}
/*
hoteles
{
N_creados
habilitados
deshabilitados
}

room {
N_creados
disponibles
reservadas
}


reservaciones {
N_creados
habillitadas

}
*/