using System;
using System.Collections.Generic;
using ConsoleApplication1.controllers;
using ConsoleApplication1.models;

namespace ConsoleApplication1
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      int price = 233;
      int countBusyPlaces = 33;
      String film_maker = "film_maker2";
      var listSession = new List<Session>();

      listSession.Add(new Session {id = 0, 
         price = 250, film_maker = "film_maker1", countBusyPlaces = 34,
        dateTime = new DateTime(2021, 03, 21, 13, 30,00),
        countFilms = 312,
      });
      
      listSession.Add(new Session {id = 1, 
         price = 200, film_maker = "film_maker2", countBusyPlaces = 25,
        dateTime = new DateTime(2021, 03, 21, 14, 30,00),
        countFilms = 432,
      });
      
      listSession.Add(new Session {id = 2, 
         price = 210, film_maker = "film_maker3", countBusyPlaces = 12,
        dateTime = new DateTime(2021, 03, 21, 15, 30,00),
        countFilms = 134,
      });
      
      listSession.Add(new Session {id = 3, 
         price = 220, film_maker = "film_maker4", countBusyPlaces = 35,
        dateTime = new DateTime(2021, 03, 21, 16, 30,00),
        countFilms = 232,
      });
      
      listSession.Add(new Session {id = 5, 
         price = 230, film_maker = "film_maker1", countBusyPlaces = 21,
        dateTime = new DateTime(2021, 03, 21, 17, 30,00),
        countFilms = 123,
      });
      
      listSession.Add(new Session {id = 4, 
         price = 240, film_maker = "film_maker6", countBusyPlaces = 12,
        dateTime = new DateTime(2021, 03, 21, 18, 30,00),
        countFilms = 321,
      });

      List<Film> listFilms = new List<Film>();
      
      listFilms.Add(new Film { id = 0, film_maker = "film_maker6", name = "film_name1"});
      listFilms.Add(new Film { id = 1, film_maker = "film_maker5", name = "film_name2"});
      listFilms.Add(new Film { id = 2, film_maker = "film_maker1", name = "film_name3"});
      listFilms.Add(new Film { id = 3, film_maker = "film_maker3", name = "film_name4"});
      listFilms.Add(new Film { id = 4, film_maker = "film_maker2", name = "film_name5"});
      listFilms.Add(new Film { id = 5, film_maker = "film_maker1", name = "film_name6"});
      

      var cinema = new Cinema(listSession, listFilms);
      cinema.convertToXML();
      
      cinema.get1Method(price);
      Console.WriteLine();
      
      cinema.get2Method(film_maker);
      Console.WriteLine();
      
      cinema.get3Method();
      Console.WriteLine();
      
      cinema.get4Method();
      Console.WriteLine();
      
      cinema.get5Method(countBusyPlaces);
      Console.WriteLine();

      // Console.ReadKey();
      // Console.ReadLine();
    }
  }
}