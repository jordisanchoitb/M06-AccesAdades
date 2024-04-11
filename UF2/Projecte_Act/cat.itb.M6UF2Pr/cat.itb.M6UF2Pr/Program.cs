using Antlr.Runtime;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cat.itb.M6UF2Pr
{
    public static class Program
    {
        public static void Main()
        {
            // Exercicis amb ADO.NET
            Act1();
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
            /* Exercici 6 (1 punt)
A la botiga es volen vendre dos productes nous i per tant s’han d’insertar aquests dos productes a la taula PRODUCT
i els seus corresponents proveïdors nous a la taula SUPPLIER. Inventat les dades dels dos nous productes i també
dels nous proveïdors. Utiliza els mètodes Insert de les classes ProductCRUD i SupplierCRUD que has implementat
per treballar amb NHibernate. */

            /* Supplier
             * public virtual int? Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Address { get; set; }
        public virtual string? City { get; set; }
        public virtual string? StCode { get; set; }
        public virtual string? ZipCode { get; set; }
        public virtual double? Area { get; set; }
        public virtual string? Phone { get; set; }
        public virtual int? ProductNo { get; set; }
        public virtual double? Amount { get; set; }
        public virtual double? Credit { get; set; }
        public virtual string? Remark { get; set; }
        public virtual Product? Product { get; set; }
        public virtual IList<Order>? Orders { get; set; } */

            /* Product
             * public virtual int? Id { get; set; }
        public virtual int? Code { get; set; }
        public virtual string? Description { get; set; }
        public virtual int? CurrentStock { get; set; }
        public virtual int? MinStock { get; set; }
        public virtual double? Price { get; set; }
        public virtual int? EmpNo { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Supplier? Supplier { get; set; }
             */
            /*
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier()
                {
                    Name = "Supplier1",
                    Address = "Address1",
                    City = "City1",
                    StCode = "StCode1",
                    ZipCode = "ZipCode1",
                    Area = 1.1,
                    Phone = "Phone1",
                    ProductNo = 1,
                    Amount = 1.1,
                    Credit = 1.1,
                    Remark = "Remark1"
                },
                new Supplier()
                {
                    Name = "Supplier2",
                    Address = "Address2",
                    City = "City2",
                    StCode = "StCode2",
                    ZipCode = "ZipCode2",
                    Area = 2.2,
                    Phone = "Phone2",
                    ProductNo = 2,
                    Amount = 2.2,
                    Credit = 2.2,
                    Remark = "Remark2"
                }
            };

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Code = 1001,
                    Description = "Description1",
                    CurrentStock = 1,
                    MinStock = 1,
                    Price = 1.1,
                    EmpNo = 1,
                    Employee = null,
                    Supplier = suppliers[0]
                },
                new Product()
                {
                    Code = 1002,
                    Description = "Description2",
                    CurrentStock = 2,
                    MinStock = 2,
                    Price = 2.2,
                    EmpNo = 2,
                    Employee = null,
                    Supplier = suppliers[1]
                }
            };*/

            ProductCRUD productCRUD = new ProductCRUD();
            //productCRUD.Insert(products);
            List<Product> products = productCRUD.SelectAll();
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
