using Antlr.Runtime;
using System;
using System.Drawing.Printing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cat.itb.M6UF2Pr
{
    public static class Program
    {
        public static void Main()
        {
            // Exercicis amb ADO.NET
            //Act1();
            //Act2();
            //Act3();
            //Act4();
            //Act5();

            // Exercicis amb NHibernate
            //Act6();
            //Act7();
            //Act8();
            //Act9();
            //Act10();
            //Act11();
            //Act12();

            //RunScriptShop();
            //DropTables();
        }

        public static void RunScriptShop()
        {
            GeneralCRUD crud = new GeneralCRUD();
            crud.RunScriptShop();
        }

        public static void DropTables()
        {
            GeneralCRUD crud = new GeneralCRUD();
            List<string> tables = ["ORDERP", "SUPPLIER", "PRODUCT", "EMPLOYEE"];
            crud.DropTables(tables);
        }

        public static void Act1()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Surname = "SMITH",
                    Job = "DIRECTOR",
                    ManagerNo = 9,
                    StartDate = new DateTime(1988, 12, 12),
                    Salary = 118000,
                    Commission = 52000,
                    DeptNo = 10
                },
                new Employee()
                {
                    Surname = "JOHNSON",
                    Job = "VENEDOR",
                    ManagerNo = 4,
                    StartDate = new DateTime(1992, 2, 25),
                    Salary = 125000,
                    Commission = 30000,
                    DeptNo = 30
                },
                new Employee()
                {
                    Surname = "HAMILTON",
                    Job = "ANALISTA",
                    ManagerNo = 7,
                    StartDate = new DateTime(1989, 3, 18),
                    Salary = 172000,
                    Commission = null,
                    DeptNo = 10
                },
                new Employee()
                {
                    Surname = "JACKSON",
                    Job = "ANALISTA",
                    ManagerNo = 7,
                    StartDate = new DateTime(2001, 10, 25),
                    Salary = 192000,
                    Commission = null,
                    DeptNo = 10
                }
            };

            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            employeeCRUD.InsertADO(employees);
        }

        public static void Act2()
        {
            ProductCRUD productCRUD = new ProductCRUD();

            Product product1 = productCRUD.SelectByCodeADO(100890);
            Product product2 = productCRUD.SelectByCodeADO(200376);
            Product product3 = productCRUD.SelectByCodeADO(200380);
            Product product4 = productCRUD.SelectByCodeADO(100861);
            product1.CurrentStock = 8;
            product2.CurrentStock = 7;
            product3.CurrentStock = 9;
            product4.CurrentStock = 12;

            productCRUD.UpdateADO(new List<Product>() { product1, product2, product3, product4 });

        }

        public static void Act3()
        {
            OrderCRUD orderCRUD = new OrderCRUD();
            List<Order> orders = orderCRUD.SelectOrdersSupplierADO(6);

            double totalAmount = 0;
            double totalQuantity = 0;
            foreach (Order order in orders)
            {
                totalAmount += order.Amount;
                totalQuantity += order.Cost;
            }
            Console.WriteLine($"El proveïdor amb id 6 ha facturat un total de {totalAmount} per una quantitat igual a {totalQuantity}");

        }

        public static void Act4()
        {
            SupplierCRUD supplierCRUD = new SupplierCRUD();
            List<Supplier> suppliers = supplierCRUD.SelectCreditHigherThanADO(8000);
            foreach (Supplier supplier in suppliers)
            {
                Console.WriteLine(supplier);
            }
            
        }

        public static void Act5()
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            Employee employee = employeeCRUD.SelectByNameADO("SMITH");
            
            employeeCRUD.DeleteADO(employee);

        }

        public static void Act6()
        {
            SupplierCRUD supplierCRUD = new SupplierCRUD();
            ProductCRUD productCRUD = new ProductCRUD();

            Product product1 = new Product();
            product1.Code = 1003;
            product1.Description = "Description3";
            product1.CurrentStock = 3;
            product1.MinStock = 3;
            product1.Price = 3;

            Product product2 = new Product();
            product2.Code = 1004;
            product2.Description = "Description4";
            product2.CurrentStock = 4;
            product2.MinStock = 4;
            product2.Price = 4;

            productCRUD.Insert(product1);
            productCRUD.Insert(product2);


            Supplier supplier1 = new Supplier();
            supplier1.Name = "Supplier1";
            supplier1.Address = "Address1";
            supplier1.City = "Sevilla";
            supplier1.StCode = "SV";
            supplier1.ZipCode = "04057";
            supplier1.Area = 2000;
            supplier1.Phone = "654821485";
            supplier1.Amount = 20000;
            supplier1.Credit = 10000;
            supplier1.Remark = "muy buen servicio";
            supplier1.Product = product1;

            Supplier supplier2 = new Supplier();
            supplier2.Name = "Supplier2";
            supplier2.Address = "Address2";
            supplier2.City = "Barcelona";
            supplier2.StCode = "BC";
            supplier2.ZipCode = "08001";
            supplier2.Area = 1000;
            supplier2.Phone = "654821485";
            supplier2.Amount = 10000;
            supplier2.Credit = 5000;
            supplier2.Remark = "muy buen servicio";
            supplier2.Product = product2;

            supplierCRUD.Insert(supplier1);
            supplierCRUD.Insert(supplier2);
            
        }

        public static void Act7()
        {
            SupplierCRUD supplierCRUD = new SupplierCRUD();
            List<Supplier> suppliers = supplierCRUD.SelectByCity("BURLINGAME");
            foreach (Supplier supplier in suppliers)
            {
                supplier.Credit = 10000;
            }
            supplierCRUD.Update(suppliers);

        }

        public static void Act8()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            List<Product> products = productCRUD.SelectAll();
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        public static void Act9()
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            Employee employee = employeeCRUD.SelectBySurname("ARROYO");
            foreach (var product in employee.Products)
            {
                Console.WriteLine($"Product code: {product.Code} - Nom proveidor: {product.Supplier.Name}");
            }
        }

        public static void Act10()
        {
            OrderCRUD orderCRUD = new OrderCRUD();
            List<Order> orders = orderCRUD.SelectByCostHigherThan(10000, 100);
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order} - {order.Supplier.Name}, {order.Supplier.Phone}");
            }
        }

        public static void Act11()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            List<object[]> objects = productCRUD.SelectByPriceLowThan(30);
            foreach (object[] obj in objects)
            {
                Console.WriteLine($"Product code: {obj[0]} - Product description: {obj[1]}");
            }

        }

        public static void Act12()
        {
            SupplierCRUD supplierCRUD = new SupplierCRUD();
            Supplier supplier = supplierCRUD.SelectLowestAmount();
            Console.WriteLine($"Nom: {supplier.Name}");
            Console.WriteLine($"Quantitat: {supplier.Amount}");
            Console.WriteLine($"Stock Producte: {supplier.Product.CurrentStock}");

        }
    }
}
