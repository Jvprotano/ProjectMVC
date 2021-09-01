using System;
using System.Collections.Generic;
using SalesWebMvc.Models;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int id { get; set; }
        public String name { get; set; }
        public DateTime birthDate { get; set; }
        public double baseSalary { get; set; }

        public Department department { get; set; }

        public ICollection<SalesRecord> sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, DateTime birthDate, double baseSalary, Department department)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.baseSalary = baseSalary;
            this.department = department;
        }

        public void addSeller(SalesRecord sr)
        {
            sales.Add(sr);
        }

        public void removeSale(SalesRecord sr)
        {
            sales.Remove(sr);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            return sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.amount);
        }
    }
}
