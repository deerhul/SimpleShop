﻿using SimpleShop.Context;
using SimpleShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace SimpleShop.Controllers
{
    public class ProductsController : Controller
    {
        public SimpleShopDbContext db = new SimpleShopDbContext();

        // GET: Products
        public ActionResult Index(string search, string quantity)
        {
            //public List<PPinfoCase> itemList;
            ICollection<PPinfoCase> viewModel = new List<PPinfoCase>();
            PPinfoCase temp;

            //get products and ProdInfo
            var products = from Product in db.Products
                select Product;
            var prodinfo = from ProdInfo in db.ProductInfo
                select ProdInfo;
            foreach (Product prod in products)
            {
                temp = new PPinfoCase();
                temp.getItems(prod, prodinfo.ToList());
                viewModel.Add(temp);
            }

            if (!string.IsNullOrEmpty(search))
            {
                return View(viewModel.Where(d => (d.Product.ProductName.ToLower().Contains(search.ToLower()))
                                                 || (d.Product.Description.ToLower().Contains(search.ToLower())))
                    .ToList());
            }

            return View(viewModel.ToList());

            //return View(db.Products.ToList());
        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult AddToCart(string ProductId, string quantity)
        //{
        //    ICollection<PPinfoCase> viewModel = new List<PPinfoCase>();
        //    PPinfoCase temp;
        //    int tempId = 0;
        //    int amount = 0;

        //    AlertMessage("Product Id: " + ProductId + " Quantity: " + quantity);



        //    //get products and ProdInfo
        //    var products = from Product in db.Products
        //                   select Product;
        //    var prodinfo = from ProdInfo in db.ProductInfo
        //                   select ProdInfo;
        //    foreach (Product prod in products)
        //    {
        //        temp = new PPinfoCase();
        //        temp.getItems(prod, prodinfo.ToList());
        //        viewModel.Add(temp);
        //    }

        //    if (!Int32.TryParse(ProductId, out tempId) || !Int32.TryParse(quantity, out amount))
        //    {
        //        //send alert
        //        AlertMessage("An error has occurred");
        //    }

        //    foreach (PPinfoCase item in viewModel)
        //    {
        //        if (item.Product.ProductId == tempId)
        //        {
        //            //check if amount wanted exceeds amount available
        //            if (item.ProdInfo.Quantity < amount)
        //            {
        //                //send alert
        //                AlertMessage("Amount requested has exceed the available.");
        //                return View("Index",viewModel.ToList());
        //            }
        //            else
        //            {
        //                item.ProdInfo.Quantity -= amount;
        //            }
        //        }
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        ModelState.Clear();
        //    }

        //    return View("Index", viewModel.ToList());
        //}

        public ActionResult AddToCart(List<string> quantity, List<string> ProdId)
        {
            ICollection<PPinfoCase> viewModel;
            int temp = 0, itemsChanged = 0;
            bool SuccessChange = false;

            viewModel = GetProducts();

            for (int i = 0; i < ProdId.Count; i++)
            {
                Int32.TryParse(quantity[i], out temp);
                if (temp > 0)
                {
                    if (!EditQuantity(ProdId[i], quantity[i], viewModel))
                    {
                        itemsChanged++;
                    }
                    SuccessChange = true;
                    /*add some checks in EditQuantity:
                    * - change return value to boolean
                    * - check if entered amount is a positive integer (non-negative and an integer).
                    */
                }
            }
            if (itemsChanged > 0)
            {
                AlertMessage(string.Format("Request for {0} item(s) exceeded the available amount.",itemsChanged));
            }
            viewModel = GetProducts();
            return View("Index", viewModel.ToList());
        }

        public void AlertMessage(string message) //display a message window with the given string
        {
            ViewData["Alertmsg"] = message;
        }

        public ICollection<PPinfoCase> GetProducts()
        {
            ICollection<PPinfoCase> viewModel = new List<PPinfoCase>();
            PPinfoCase temp;

            //get products and ProdInfo
            var products = from Product in db.Products
                select Product;
            var prodinfo = from ProdInfo in db.ProductInfo
                select ProdInfo;
            foreach (Product p in products)
            {
                temp = new PPinfoCase();
                temp.getItems(p, prodinfo.ToList());
                viewModel.Add(temp);
            }

            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }

            return viewModel;
        }

        public bool EditQuantity(string id, string amount, ICollection<PPinfoCase> ItemList)
        {
            int Quantity = 0, NewQuantity = 0, id2int = 0;
            int[,] tempArray = (int[,])Session["Cart"];
            int i = 0;
            int maxCart = 0;

            Int32.TryParse(amount, out Quantity);
            Int32.TryParse(id, out id2int);
            Int32.TryParse(Session["MaxCart"].ToString(), out maxCart);

            //initialize second array


            foreach (PPinfoCase item in ItemList) //find item in the database and edit properties
            {
                if (item.ProdInfo.ProductId == id2int)
                {
                    if (Quantity > item.ProdInfo.Quantity)
                    {
                        return false;
                    }
                    else
                    {
                        NewQuantity = item.ProdInfo.Quantity - Quantity;
                        item.ProdInfo.Quantity = NewQuantity;
                        db.ProductInfo.Find(item.ProdInfo.ProdInfoId).Quantity = NewQuantity;

                        //add information to session
                        if (InsertIntoCart(tempArray, maxCart, item.ProdInfo.ProdInfoId, Quantity))
                        {
                            AlertMessage("Add to cart Successs!");
                        }
                        else
                        {
                            AlertMessage("Add to cart Failure!");
                        }
                    }
                }
            }


            
            //for (int n = 0 ; n < 3; n++)
            //{
            //    tempArray[n, 0] = n+1;
            //    tempArray[n, 1] = (n+1)*10;
            //}
            //AlertMessage(string.Format("{0}_{1}, {2}_{3}, {4}_{5}",
            //    tempArray[0, 0], tempArray[0, 1],
            //    tempArray[1, 0], tempArray[1, 1],
            //    tempArray[2, 0], tempArray[2, 1]));

            @Session["test"] = tempArray;

            db.SaveChanges();
            return true;

            /*NOTE:
             * SaveChanges vs SaveChangesAsync
             * 
             * SaveChangesAsyc can perform it's task in the background, not holding up the whole application while it does the task assigned.
             * PS: 'await SaveChangesAsync' is better than creating a new thread and have the 'SaveChanges' run on the separate thread because it doesnt
             * create any overhead.
             */
        }

        public bool InsertIntoCart(int[,] tempArray, int maxCart, int Id, int Amount)
        {  
            //traverse through the array, insert into the right slot (duplicate or empty), return true
            for (int i = 0 ; i < maxCart; i++)
            {
                if ( (tempArray[i,0] == 0 || tempArray[i,0] == Id) ) //if slot is either empty or occupied by same item
                {
                    tempArray[i, 1] += Amount; //add amount to amount stored in array
                    Session["Cart"] = tempArray; //write over array in session["cart"] with updated array
                    return true;
                }
            }

            return false;
        }

        public void printArray(int[,] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0 ; i < array.Length; i++)
            {
                if (array[i, 0] != 0)
                {
                    sb.AppendLine(string.Format("ID: {0}, Quantity: {1}.", array[i, 0], array[i, 1]));
                }
                else
                {
                    break;
                }
                
            }
            AlertMessage(sb.ToString());
        }
    }
}
