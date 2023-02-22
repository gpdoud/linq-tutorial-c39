﻿
using SalesLibrary;

var custCtrl = new CustomersController("localhost", "sqlexpress");

var customers = custCtrl.GetAll();

// customers from Cin if sales LT 50k and from Col if sales LT 40k and Cle if sales > 50 or sales < 20k;;

var customerByCityAndSales = from c in customers
                             where (c.City == "Cincinnati" && c.Sales < 50000)
                                   || (c.City == "Cleveland" && c.Sales > 50000 || c.Sales < 20000)
                                   || (c.City == "Columbus" && c.Sales < 40000)
                             orderby c.City, c.Sales
                             select c;
//var customersByName = customers
//                        .Where(x => (x.City == "Cincinnati" && x.Sales < 50000) 
//                                    || (x.City == "Columbus" && x.Sales <= 40000)
//                                    || (x.City == "Cleveland" && x.Sales > 50000 || x.Sales < 20000) )
//                        .OrderBy(x => x.City)
//                        .ThenBy(x => x.Sales);

foreach(var cust in customerByCityAndSales) {
    Console.WriteLine($"{cust.Id,2} | {cust.Name,-25} | {cust.City,-25}, {cust.State} | {cust.Sales,11:C} | {cust.Active}");
}










//int[] nbrs = {

//   754, 233, 509, 792, 700, 596, 833, 658, 998, 742,
//   187, 754, 308, 914, 489, 867, 717, 586, 929, 467,
//   460, 241, 770, 324, 599, 259, 120, 800, 336, 609,
//   690, 134, 598, 249, 282, 574, 334, 956, 659, 214,
//   435, 643, 809, 874, 906, 620, 328, 369, 426, 561

//};

// query syntax (nbrs divisible by 3)

//var divBy3 = from i in nbrs
//             where i % 3 == 0 || i % 5 == 0
//             orderby i
//             select i;

// method syntax (nbrs divisible by 3 or 5 and sorted)

//var divBy3Or5 = nbrs.Where(i => i % 3 == 0 || i % 5 == 0).OrderBy(i => i).ToList();

//foreach(var i in divBy3Or5) {
//    Console.Write($"{i} ");
//}