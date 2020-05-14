﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Shared
{
    public class Item
    {
        public string Name { get; set; }     // Name of product
        public uint Id { get; set; }
        public string Barcode { get; set; }
        public uint Available { get; set; }
        public uint NumSold { get; set; }
        public decimal Price { get; set; }   // Price in dollars
        public bool NonTaxable { get; set; }
        public string ItemType { get; set; }
        public uint NumBottles { get; set; }
        public decimal Discount { get; set; }
        public decimal Coupon { get; set; }
        


        public Item(string Name,
                    uint Id,
                    string Barcode,
                    uint Available,
                    uint NumSold,
                    decimal Price,
                    bool NonTaxable,
                    string ItemType,
                    uint NumBottles,
                    decimal Discount,
                    decimal Coupon)
        {
            this.Available  = Available;
            this.NumSold    = NumSold;
            this.Barcode    = Barcode;
            this.Id         = Id;
            this.Name       = Name;
            this.Price      = Price;
            this.NonTaxable  = NonTaxable;
            this.ItemType   = ItemType;
            this.NumBottles = NumBottles;
            this.Discount = Discount;
            this.Coupon = Coupon;
        }
    }


    [Serializable()]
    public class Transaction : ISerializable
    {
        // Define properties. The way I set them up, we can add accessors later.
        public uint InvoiceID { get; set; }
        public uint RegisterID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string Location { get; set; }
        public List<Item> Items { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public bool TaxExempt { get; set; }
        public string PayMethod { get; set; }
        public string PayNum { get; set; }  // Credit card digits, check num, or nothing for cash
        public decimal Discount { get; set; } 
        public decimal LocalTax { get; set; }
        public uint EmployeeID { get; set; }
        public uint CustomerID { get; set; }
       

        // Default constructor
        public Transaction()
        {
            TransactionDateTime = DateTime.Now;
            InvoiceID  = 0;
            RegisterID = 1;
            Location   = "";
            Items      = new List<Item>();
            Subtotal   = 0.0M;
            Tax        = 0.0M;
            Total      = 0.0M;
            TaxExempt  = false;
            PayMethod  = "";
            PayNum     = "";
            Discount = 0.0M;
            LocalTax = 0.0M;
            EmployeeID = 0;
            CustomerID = 0;
        }

        // Parameterized constructor
        public Transaction(uint InvoiceID,
                           uint RegisterID,
                           DateTime TransactionDateTime,
                           string Location,
                           List<Item> Items,
                           decimal Discount,
                           decimal Subtotal,
                           decimal Tax,
                           decimal Total,
                           bool TaxExempt,
                           string PayMethod,
                           string PayNum,
                           decimal LocalTax,
                           uint EmployeeID,
                           uint CustomerID)
        {
            this.InvoiceID  = InvoiceID;
            this.RegisterID = RegisterID;
            this.TransactionDateTime = TransactionDateTime;
            this.Location   = Location;
            this.Items      = Items;
            this.Discount   = Discount; // Will this be applied before or after subtotal is calculated?
            this.Subtotal   = Subtotal;
            this.Tax        = Tax;
            this.Total      = Total;
            this.TaxExempt  = TaxExempt;
            this.PayMethod  = PayMethod;
            this.PayNum     = PayNum;
            this.LocalTax   = LocalTax;
            this.EmployeeID = EmployeeID;
            this.CustomerID = CustomerID;
        }

        // Deserialization constructor
        public Transaction(SerializationInfo info, StreamingContext ctxt)
        {
            InvoiceID = (uint)info.GetValue("InvoiceID", typeof(uint));
            RegisterID = (uint)info.GetValue("RegisterID", typeof(uint));
            TransactionDateTime = (DateTime)info.GetValue("TransactionDateTime", typeof(DateTime));
            Location = (string)info.GetValue("Location", typeof(string));
            Items = (List<Item>)info.GetValue("Items", typeof(List<Item>));
            Discount = (decimal)info.GetValue("Discount", typeof(decimal));
            Subtotal = (decimal)info.GetValue("Subtotal", typeof(decimal));
            Tax = (decimal)info.GetValue("Tax", typeof(decimal));
            Total = (decimal)info.GetValue("Total", typeof(decimal));
            TaxExempt = (bool)info.GetValue("TaxExempt", typeof(bool));
            PayMethod = (string)info.GetValue("PayMethod", typeof(string));
            PayNum = (string)info.GetValue("PayNum", typeof(string));
            LocalTax = (decimal)info.GetValue("LocalTax", typeof(decimal));
            EmployeeID = (uint)info.GetValue("EmployeeID", typeof(uint));
            CustomerID = (uint)info.GetValue("CustomerID", typeof(uint));
        }
        
        // Serialization method
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("InvoiceID", InvoiceID);
            info.AddValue("RegisterID", RegisterID);
            info.AddValue("TransactionDateTime", TransactionDateTime);
            info.AddValue("Location", Location);
            info.AddValue("Items", Items);
            info.AddValue("Discount", Discount);
            info.AddValue("Subtotal", Subtotal);
            info.AddValue("Tax", Tax);
            info.AddValue("Total", Total);
            info.AddValue("TaxExempt", TaxExempt);
            info.AddValue("PayMethod", PayMethod);
            info.AddValue("PayNum", PayNum);
            info.AddValue("LocalTax", LocalTax);
            info.AddValue("EmployeeID", EmployeeID);
            info.AddValue("CustomerID", CustomerID);
        }
    }
}
