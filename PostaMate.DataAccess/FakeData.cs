using System;
using System.Collections.Generic;
using PostaMate.Core.Domain;
using PostaMate.Core.Types;

namespace PostaMate.DataAccess
{
    public class FakeData
    {
        public static List<Postamat> GetPostamats()
        {
            return new List<Postamat>()
            {
                new Postamat()
                {
                    Number = "111",
                    Address = "Адрес 1",
                    Status = true,
                },
                new Postamat()
                {
                    Number = "112",
                    Address = "Адрес 2",
                    Status = true,
                },
                new Postamat()
                {
                    Number = "113",
                    Address = "Адрес 3",
                    Status = false,
                },
            };
        }

        public static List<Order> Orders = new List<Order>()
        {
            new Order()
            {
                Blocks = new List<string>()
                {
                    "Товар 1",
                    "Товар 2",
                    "Товар 3",
                },
                Cost = 100_500,
                Number = 1,
                Recipient = "Получатель 1",
                PhoneNumber = "+7111-111-11-11",
                PostamatNumber = 111,
                StatusOrder = StatusOrder.Registered,
            },
            new Order()
            {
                Blocks = new List<string>()
                {
                    "Товар 1",
                    "Товар 2",
                    "Товар 3",
                },
                Cost = 100,
                Number = 2,
                Recipient = "Получатель 2",
                PhoneNumber = "+7222-222-22-22",
                PostamatNumber = 113,
                StatusOrder = StatusOrder.Registered,
            },
        };
    }
}