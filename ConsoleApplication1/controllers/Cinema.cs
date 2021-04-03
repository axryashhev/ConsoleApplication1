using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ConsoleApplication1.models;

namespace ConsoleApplication1.controllers
{
    public class Cinema
    {
        public List<Session> sessionsList;
        public List<Film> listFilms;
        private XDocument xDocument;

        public Cinema(List<Session> sessionsList, List<Film> listFilms)
        {
            this.sessionsList = sessionsList;
            this.listFilms = listFilms;
        }

        public void convertToXML()
        {
            // XDocument xmlDocument = new XDocument();
            var xmlDocument = new XElement("Sessions",
                from session in sessionsList
                select new XElement("session",
                    new XElement("ID_сеанса", session.id),
                    new XElement("Дата_и_время", session.dateTime.ToString()),
                    new XElement("Цена", session.price),
                    new XElement("Режиссер", session.film_maker),
                    new XElement("Количество_занятых_мест", session.countBusyPlaces),
                    new XElement("Число_снятых_фильмов", session.countFilms)
                )
            );

            // Console.WriteLine(xmlDocument);

            xmlDocument.Save("labJob.xml");
            
            xDocument = XDocument.Load("labJob.xml");
        }

        public void get1Method(int price)
        {
            Console.WriteLine($"1. Дата и время начала сеансов с ценой билета более «{price}».");
            var result = from f in xDocument.Elements("Sessions").Elements("session") 
                where Int32.Parse(f.Element("Цена").Value) > price select f;
            foreach (var r in result)
            {
                Console.WriteLine("id сеанса: " + r.Element("ID_сеанса").Value);
                Console.WriteLine("Дата и время: " + r.Element("Дата_и_время").Value);
                Console.WriteLine("Цена: " + r.Element("Цена").Value);
            }
        }

        public void get2Method(String film_maker)
        {
            Console.WriteLine($"2. Число показанных фильмов, снятых режиссером «{film_maker}».");
            var result = from f in xDocument.Elements("Sessions").Elements("session") 
                where f.Element("Режиссер").Value == film_maker select f;
            foreach (var r in result)
            {
                Console.WriteLine("Число снятых фильмов: " + r.Element("Число_снятых_фильмов").Value);
            }
        }
        
        public void get3Method()
        {
            Console.WriteLine($"3. Данные о занятых местах, сгруппированные по сеансам.");
            var result = from f in xDocument.Elements("Sessions").Elements("session")
                group f by (int) f.Element("ID_сеанса")
                into groupData
                from g in groupData
                select g;
            foreach (var r in result)
            {
                Console.WriteLine("ID сеанса: " + r.Element("ID_сеанса").Value);
                Console.WriteLine("Количество занятых мест: " + r.Element("Количество_занятых_мест").Value);
            }
        }

        public void get4Method()
        {
            Console.WriteLine($"4. Список сеансов с указанием названия фильма (join).");
            var result = from f in xDocument.Elements("Sessions").Elements("session")
                join r in listFilms on f.Element("Режиссер").Value equals r.film_maker
                select new { id=f.Element("ID_сеанса").Value, nameFilm = r.name };
            foreach (var r in result)
            {
                Console.WriteLine("ID сеанса: " + r.id);
                Console.WriteLine("Наименование фильма: " + r.nameFilm);
            }
        }
        
        public void get5Method(int countBusyPlaces)
        {
            Console.WriteLine($"5. Сеансы, на которые число занятых мест было более «{countBusyPlaces}» (XPath).");
            var list = xDocument.XPathSelectElements(".//session");
            foreach (var r in list)
            {
                if (countBusyPlaces < Int32.Parse(r.Element("Количество_занятых_мест").Value))
                {
                    Console.WriteLine("ID сеанса: " + r.Element("ID_сеанса").Value);
                    Console.WriteLine("Количество_занятых_мест: " + r.Element("Количество_занятых_мест").Value);
                }
            }
        }
    }
}