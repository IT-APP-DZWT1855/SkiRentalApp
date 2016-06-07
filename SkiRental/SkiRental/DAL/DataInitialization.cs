using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Models;
using System.Data.Entity;

namespace SkiRental.DAL
{
    class DataInitialization : DropCreateDatabaseIfModelChanges<SkiRentalContext>
    {
        protected override void Seed(SkiRentalContext context)
        {
            var incidentTypes = new List<IncidentType>
            {
                new IncidentType
                {
                    Name = "Serwis"
                },

                new IncidentType
                {
                    Name = "Uszkodzenie"
                },

                new IncidentType
                {
                    Name = "Przegląd"
                }
            };


            incidentTypes.ForEach(c => context.IncidentTypes.Add(c));

            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Radomiła",
                    LastName = "Adamczuk",
                    Phone = "53 484 00 74",
                    Email = "RadomilaAdamczyk@inbound.plus",
                    ZipCode = "00-910",
                    City = "Warszawa",
                    Street = "Topograficzna 142",
                    IsVip = false,
                    IdentityCard = "Dowód osobisty",
                    NumberOfIdentityCard = "ABW275513",
                    Pesel = "43110104408",
                    CreateDate = DateTime.Now
                },

                new Customer
                {
                    FirstName = "Rafał",
                    LastName = "Dąbrowski",
                    Phone = "53 484 00 74",
                    Email = "RafalDabrowski@inbound.plus",
                    ZipCode = "04-406",
                    City = "Warszawa",
                    Street = "Cyrulików 27",
                    IsVip = false,
                    IdentityCard = "Dowód osobisty",
                    NumberOfIdentityCard = "ABW286383",
                    Pesel = "81062252196",
                    CreateDate = DateTime.Now
                },

                new Customer
                {
                    FirstName = "Eustachy",
                    LastName = "Pawłowski",
                    Phone = "51 337 62 16",
                    Email = "RafalDabrowski@inbound.plus",
                    ZipCode = "65-423",
                    City = "Zielona Góra",
                    Street = "Ceglana 72",
                    IsVip = true,
                    IdentityCard = "Dowód osobisty",
                    NumberOfIdentityCard = "ABW28300",
                    Pesel = "44071864534",
                    CreateDate = DateTime.Now
                },

                new Customer
                {
                    FirstName = "Gustaw",
                    LastName = "Kowalski",
                    Phone = "67 476 41 09",
                    Email = "gustaw@inbound.plus",
                    ZipCode = "25-116",
                    City = "Kielce",
                    Street = "Łotewska 102",
                    IsVip = true,
                    IdentityCard = "Dowód osobisty",
                    NumberOfIdentityCard = "ABW23343",
                    Pesel = "55030547076",
                    CreateDate = DateTime.Now
                },

                new Customer
                {
                    FirstName = "Apolonia",
                    LastName = "Woźniak",
                    Phone = "66 633 60 49",
                    Email = "ApoloniaWozniak@inbound.plus",
                    ZipCode = "54-046",
                    City = "Wrocław",
                    Street = "Beżowa 94",
                    IsVip = true,
                    IdentityCard = "Dowód osobisty",
                    NumberOfIdentityCard = "ABW23343",
                    Pesel = "43031260087",
                    CreateDate = DateTime.Now
                },

                new Customer
                {
                    FirstName = "Tytus",
                    LastName = "Kowalczyk",
                    Phone = "72 855 97 03",
                    Email = "TytusKowalczyk@inbound.plus",
                    ZipCode = "50-259",
                    City = "Warszawa",
                    Street = "Jedności Narodowej 59",
                    IsVip = false,
                    IdentityCard = "Dowód osobisty",
                    NumberOfIdentityCard = "ADX227511",
                    Pesel = "84032691896",
                    CreateDate = DateTime.Now
                }
            };

            //var orders = new List<Order>
            //{
            //    new Order
            //    {
            //        CustomerId = 3,
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now
            //    }
            //};

            //orders.ForEach(o => context.Orders.Add(o));

            customers.ForEach(c => context.Customers.Add(c));

            var itemCategories = new List<ItemCategory>
            {
                new ItemCategory
                {
                    Name = "Buty biegowe",
                    Cost = 10m
                },

                new ItemCategory
                {
                    Name = "Buty narciarskie",
                    Cost = 10m
                },

                new ItemCategory
                {
                    Name = "Buty snowboardowe",
                    Cost = 10m
                },

                new ItemCategory
                {
                    Name = "Kask",
                    Cost = 10m
                },

                // 4
                new ItemCategory
                {
                    Name = "Kijki biegowe",
                    Cost = 10m
                },

                // 5
                new ItemCategory
                {
                    Name = "Kijki zjazdowe",
                    Cost = 10m
                },


                // 6
                new ItemCategory
                {
                    Name = "Narty biegowe",
                    Cost = 10m
                },

                // 7
                new ItemCategory
                {
                    Name = "Narty skiturowe",
                    Cost = 10m
                },

                // 8
                new ItemCategory
                {
                    Name = "Narty zjazdowe",
                    Cost = 10m
                },


                // 9
                new ItemCategory
                {
                    Name = "Sanki",
                    Cost = 10m
                },

                // 10
                new ItemCategory
                {
                    Name = "Snowboard",
                    Cost = 10m
                }
            };

            var items = new List<Item>
            {
                // Buty biegowe
                new Item
                {
                    Producer = "Fischer",
                    Model = "XJ Sprint",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[0]
                },

                new Item
                {
                    Producer = "Comfort",
                    Model = "My Style 37",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[0]
                },

                new Item
                {
                    Producer = "Fischer",
                    Model = " XC Offtrack 37",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[0]
                },

                new Item
                {
                    Producer = "Fischer",
                    Model = "RC 5 Classic",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[0]
                },

                // Buty narciarskie

                new Item
                {
                    Producer = "Rossignol",
                    Model = "Radical J3 Solar",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[1]
                },

                new Item
                {
                    Producer = "Head",
                    Model = "Adapt Edge 100",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[1]
                },

                new Item
                {
                    Producer = "Head",
                    Model = "Raptor 130 Rs",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[1]
                },

                new Item
                {
                    Producer = "Rossignol",
                    Model = "Alias Sensor 70",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[1]
                },

                // Buty snowboardowe

                new Item
                {
                    Producer = "Worker",
                    Model = "Yetti",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[2]
                },

                new Item
                {
                    Producer = "Morrow",
                    Model = "Slick",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[2]
                },

                new Item
                {
                    Producer = "Razor",
                    Model = "Rc 55",
                    Size = 45,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[2]
                },

                // Kask

                new Item
                {
                    Producer = "Mivida",
                    Model = "Mat Visor Deluxe",
                    Size = 60,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[3]
                },

                new Item
                {
                    Producer = "Uvex",
                    Model = "Bandi",
                    Size = 60,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[3]
                },

                new Item
                {
                    Producer = "Julbo",
                    Model = "Sumbios Connect",
                    Size = 60,
                    Description = "",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[3]
                },

                // Narty biegowe
                new Item
                {
                    Producer = "Rossignol",
                    Model = "Snow Flake",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[6]
                },

                new Item
                {
                    Producer = "Blizzard",
                    Model = "Race WSC 2",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[6]
                },

                new Item
                {
                    Producer = "Rossignol",
                    Model = "Xt Intense",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[6]
                },

                // Narty skiturowe
                new Item
                {
                    Producer = "Blizzard",
                    Model = "Race WSC 2",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[7]
                },

                new Item
                {
                    Producer = "Dynafit",
                    Model = "Nanga Parbat",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[7]
                },

                new Item
                {
                    Producer = "Atomic",
                    Model = "Alfa 1000",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[7]
                },

                // Narty zjazdowe
                new Item
                {
                    Producer = "Dynastar",
                    Model = "Course 64 TEAM",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[8]
                },

                new Item
                {
                    Producer = "Fischer",
                    Model = "RC4 RC",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[8]
                },

                new Item
                {
                    Producer = "Elan",
                    Model = "Radial 6X",
                    Size = 170,
                    Description = "Profesionalne narty World Cup z systemem IQ",
                    isAvailable = true,
                    PhotoUrl = "",
                    ItemCategory = itemCategories[8]
                },

                // Sanki

                // Snowboard


            };

            items.ForEach(i => context.Items.Add(i));
            itemCategories.ForEach(i => context.ItemCategories.Add(i));

            context.SaveChanges();
        }
    }
}
