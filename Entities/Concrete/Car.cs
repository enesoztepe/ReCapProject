using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        private string name;
        public string Name
        { 
            get { return name; }
            set
            {
                if (value.Length >= 2)
                    name = value;
                else
                {
                    Console.WriteLine("İsim minimum 2 karakter olmak zorundadır.");
                    throw new NotImplementedException();
                }  
            }
        }
        public int ModelYear { get; set; }
        private double dailyPrice;
        public double DailyPrice
        {
            get{ return dailyPrice; }
            set
            {
                if (value >= 0)
                    dailyPrice = value;
                else
                {
                    Console.WriteLine("Günlük Fiyat 0 dan büyük olmak zorundadır.");
                    throw new NotImplementedException();
                }
            }
        }
        public string Description { get; set; }
    }
}