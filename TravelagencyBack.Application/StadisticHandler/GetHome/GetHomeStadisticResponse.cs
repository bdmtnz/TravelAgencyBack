using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyBack.Application.StadisticHandler.GetHome
{
    public class GetHomeStadisticResponse
    {
        public string Title { get; set; }
        public List<GetHomeStadisticItem> Items { get; set; }
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

    public class GetHomeStadisticItem
    {
        public string Label { get; set; }
        public string Icon { get; set; }
        public int Value { get; set; }
    }
}