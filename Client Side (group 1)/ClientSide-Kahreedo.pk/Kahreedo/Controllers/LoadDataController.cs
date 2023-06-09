﻿using Khareedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Khareedo.Controllers
{
    // This static class is used to get the default data for the controller base.
    // It is used to store the items in the "TempShpData" list, retrieve the data from the database, and store them in the "ViewBag" to be used by the controller.
    // It also calculates the discounts, subtotal and total amount for the items in the list.
    public static class LoadDataController
    {
        static KhareedoEntities db = new KhareedoEntities();
        public static List<OrderDetail> GetDefaultData(this ControllerBase controller)
        {
            if (TempShpData.items == null)
            {
                TempShpData.items = new List<OrderDetail>();
            }
            var data = TempShpData.items.ToList();

            controller.ViewBag.cartBox = data.Count == 0 ? null : data;
            controller.ViewBag.NoOfItem = data.Count();
            int? SubTotal = Convert.ToInt32(data.Sum(x => x.TotalAmount));
            controller.ViewBag.Total = SubTotal;

            int Discount = 0;
            controller.ViewBag.SubTotal = SubTotal;
            controller.ViewBag.Discount = Discount;
            controller.ViewBag.TotalAmount = SubTotal - Discount;

            controller.ViewBag.WlItemsNo = db.Wishlists.Where(x => x.CustomerID == TempShpData.UserID).ToList().Count();
            return data;
        }
    }
}