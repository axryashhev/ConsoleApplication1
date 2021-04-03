using System;

namespace ConsoleApplication1.models
{
    public class Session
    {
        public int id { get; set; }
        // public String name_film { get; set; }
        public DateTime dateTime { get; set; } 
        public int price { get; set; }
        public String film_maker { get; set; } // режиссер
        public int countBusyPlaces { get; set; } // количество занятых мест
        public int countFilms{ get; set; } // число снятых фильмов
    }
}