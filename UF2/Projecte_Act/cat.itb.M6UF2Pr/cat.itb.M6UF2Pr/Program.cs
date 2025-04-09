using System;

namespace cat.itb.M6UF2Pr
{
    public static class Program
    {
        public static void Main()
        {
            bool exit = false;
            /*
             * En cas de que la conexio no funcioni per acces de peticions a la base de dades executar el següent codi dins del datagrip:
             * SELECT pg_terminate_backend(pg_stat_activity.pid)
                 FROM pg_stat_activity
                 WHERE datname = 'ckxphvzj'
                  AND pid <> pg_backend_pid();
             * */
            do
            {
                Console.Clear();
                PrintMenu();
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Act1();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Act2();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Act3();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Act4();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Act5();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Act6();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        Act7();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        Act8();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.Clear();
                        Act9();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 10:
                        Console.Clear();
                        Act10();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 11:
                        Console.Clear();
                        Act11();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 12:
                        Console.Clear();
                        Act12();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 13:
                        Console.Clear();
                        Act1Examen_ADO_NET();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 14:
                        Console.Clear();
                        Act2Examen_ADO_NET();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 15:
                        Console.Clear();
                        Act3Examen_ADO_NET();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 16:
                        Console.Clear();
                        Act4Examen_NHibernate();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 17:
                        Console.Clear();
                        Act5Examen_NHibernate();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 18:
                        Console.Clear();
                        Act6Examen_NHibernate();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 19:
                        Console.Clear();
                        RunScriptShop();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 20:
                        Console.Clear();
                        DropTables();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (!exit);
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Act1");
            Console.WriteLine("2. Act2");
            Console.WriteLine("3. Act3");
            Console.WriteLine("4. Act4");
            Console.WriteLine("5. Act5");
            Console.WriteLine("6. Act6");
            Console.WriteLine("7. Act7");
            Console.WriteLine("8. Act8");
            Console.WriteLine("9. Act9");
            Console.WriteLine("10. Act10");
            Console.WriteLine("11. Act11");
            Console.WriteLine("12. Act12");
            Console.WriteLine("13. Act1Examen_ADO.NET");
            Console.WriteLine("14. Act2Examen_ADO.NET");
            Console.WriteLine("15. Act3Examen_ADO.NET");
            Console.WriteLine("16. Act4Examen_NHibernate");
            Console.WriteLine("17. Act5Examen_NHibernate");
            Console.WriteLine("18. Act6Examen_NHibernate");
            Console.WriteLine("19. RunScriptShop");
            Console.WriteLine("20. DropTables");
            Console.WriteLine("0. Exit");
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

        public static void Act1Examen_ADO_NET()
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            List<Employee> employees = employeeCRUD.SelectByJobADO("VENEDOR");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            foreach (Employee employee in employees)
            {
                employee.Salary = 220000;
                employee.Commission = 40000;
            }

            employeeCRUD.UpdateADO(employees);

        }

        public static void Act2Examen_ADO_NET()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            List<Product> products = productCRUD.SelectByEmpADO(5);
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        public static void Act3Examen_ADO_NET()
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            ProductCRUD productCRUD = new ProductCRUD();
            Product product = new Product
            {
                Code = 100890,
                Description = "Description",
                CurrentStock = 10,
                MinStock = 10,
                Price = 10,
                Employee = employeeCRUD.SelectById(2),
            };

            productCRUD.Insert(product);
            
        }

        public static void Act4Examen_NHibernate()
        {
            OrderCRUD orderCRUD = new OrderCRUD();
            SupplierCRUD supplierCRUD = new SupplierCRUD();
            Order order = new Order
            {
                
                OrderDate = new DateTime(2024, 4, 16),
                DeliveryDate = new DateTime(2024, 4, 18),
                Cost = 1000,
                Amount = 1000,
                Supplier = supplierCRUD.SelectByName("JOCKSPORTS")
            };
            
            orderCRUD.Insert(order);
        }

        public static void Act5Examen_NHibernate()
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            List<Employee> employees = employeeCRUD.SelectAll();
            
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
                foreach (Product product in employee.Products)
                {
                    Console.WriteLine($"{product.Id} - {product.Description}");
                }
            }
        }

        public static void Act6Examen_NHibernate()
        {
            SupplierCRUD supplierCRUD = new SupplierCRUD();
            List<object[]> suppliers = supplierCRUD.SelectByStcode("CA");
            foreach (object[] supplier in suppliers)
            {
                Console.WriteLine($"Ciutat: {supplier[0]} - Area: {supplier[1]} - Stcode: {supplier[2]}");
            }
        }
    }
}
