using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project
{
    public class Menu
    {
        public string message = "Ruslan Gay";
        public void mainMenu()
        {
            Console.WriteLine("1 - Car menu");
            Console.WriteLine("2 - Project menu");
            Console.WriteLine("3 - Component menu");
            Console.WriteLine("4 - Service Station menu");
            int swt = Int32.Parse(Console.ReadLine());
            switch (swt)
            {
                case 1:
                    this.CarMenu();
                    break;
                case 2:
                    this.ProjectMenu();
                    break;
                case 3:
                    this.ComponentMenu();
                    break;
                case 4:
                    this.ServiceStationMenu();
                    break;
            }
        }
        public void CarMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Create car");
            Console.WriteLine("2 - Destroy car");
            Console.WriteLine("3 - Find car by number");
            Console.WriteLine("4 - Find car by model");
            Console.WriteLine("5 - Show cars");
            CarType type = CarType.light;

            int swt = Int32.Parse(Console.ReadLine());
            switch (swt)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Brand: ");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Name: ");
                    string model = Console.ReadLine();

                    Console.WriteLine("Date of issue: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Type: \n1 - Light \n2 - Rover \n3 - Truck");
                    int swtType = Int32.Parse(Console.ReadLine());
                    switch (swtType)
                    {
                        case 1:
                            type = CarType.light;
                            break;
                        case 2:
                            type = CarType.rover;
                            break;
                        case 3:
                            type = CarType.truck;
                            break;
                        default:
                            Console.WriteLine("Incorrect number!");
                            break;
                    }

                    Console.WriteLine("Garage number: ");
                    int garageNum = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Status(Active = 0 | Passive = 1): ");
                    int status = Int32.Parse(Console.ReadLine());

                    this.createCar(brand, date, model, type, garageNum, status, out message);
                    Console.Clear();
                    this.mainMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Input id of the car: ");
                    int id = Int32.Parse(Console.ReadLine());
                    this.deleteCar(id, out message);
                    Console.Clear();
                    this.mainMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Input garage number of the car: ");
                    int findId = Int32.Parse(Console.ReadLine());
                    this.FindByNum(findId, out message);
                    Console.Clear();
                    this.mainMenu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Input model of the car: ");
                    string findModel = Console.ReadLine();
                    this.findByModel(findModel, out message);
                    Console.Clear();
                    this.mainMenu();
                    break;
                case 5:
                    Console.Clear();
                    List<Car> cars = new List<Car>();
                    this.showCars(out message);
                    Console.Clear();
                    this.mainMenu();
                    break;
            }
        }
        public void ProjectMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Create project");
            Console.WriteLine("2 - Show projects");
            int switchProj = Int32.Parse(Console.ReadLine());

            if (switchProj == 1)
            {
                Console.WriteLine("Input name of project");
                string name = Console.ReadLine();
                createProject(name, out message);
                this.mainMenu();
            }
            if (switchProj == 2)
            {
                this.showProjects(out message);
                this.mainMenu();
            }
            else this.mainMenu();

        }
        public void ComponentMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Create component");
            Console.WriteLine("2 - Show components");
            int switchComp = Int32.Parse(Console.ReadLine());

            if (switchComp == 1)
            {
                Console.WriteLine("Input name of component");
                string name = Console.ReadLine();
                Console.WriteLine("Input id");
                int id = Int32.Parse(Console.ReadLine());
                createComponent(name, id, out message);
                this.mainMenu();
            }
            if(switchComp == 2)
            {
                this.showComponents(out message);
                this.mainMenu();
            }
            else this.mainMenu();
        }
        public void ServiceStationMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Create service station");
            int switchSS = Int32.Parse(Console.ReadLine());

            if (switchSS == 1)
            {
                Console.Write("Date: ");
                DateTime createTime = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Description: ");
                string description = Console.ReadLine();
                Console.Write("Recomendation: ");
                string recomendation = Console.ReadLine();
                User inspector = new User();
                createService(createTime, description, recomendation,inspector, out message);
                Console.WriteLine("Created!");
                Console.ReadKey();
                this.mainMenu();
            }
            else this.mainMenu(); 
        }
        

        public User User { get; set; }
        public void RegisterOrLogin()
        {
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - Login");
            while (true)
            {
                try
                {
                    ConsoleKey choice = Console.ReadKey().Key;
                    Console.WriteLine();
                    if (choice == ConsoleKey.D1)
                    {
                        RegisterMenu();
                        return;
                    }
                    else if (choice == ConsoleKey.D2)
                    {
                        LoginMenu();
                        return;                    }
                    else
                        Console.WriteLine("Write correct number!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        void LoginMenu()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.Write("Write name:");
                    string name = Console.ReadLine();
                    Console.Write("Write password:");
                    string password = Console.ReadLine();
                    string message;
                    UserMenu serviceUser = new UserMenu();
                    User user = serviceUser.LogOn(name, password, out message);

                    if (user == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong name or password");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        User = user;
                        Console.WriteLine("Hello {0}", user.Name);
                        this.mainMenu();
                        return;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        void RegisterMenu()
        {

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Password:");
                    string password = Console.ReadLine();

                    Console.WriteLine("Rights:");
                    string rights = Console.ReadLine();

                    User user = new User(name, password, rights);
                    string message;

                    UserMenu serviceUser = new UserMenu();
                    if (serviceUser.Registration(user, out message))
                    {
                        User = user;
                        Console.WriteLine(message);
                        this.RegisterOrLogin();
                        Console.Clear();
                        return;
                    }
                    else
                        Console.WriteLine(message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                this.RegisterOrLogin();
            }
       
        }


        public bool createCar(string brand, DateTime date, string model, CarType type, int garageNum, int status, out string message)
        {
            Console.Clear();
            try
            {
                Car car = new Car(brand, date, model, type, garageNum, status);
                using (var db = new LiteDatabase("Car.db"))
                {
                    var cars = db.GetCollection<Car>("Cars");
                    cars.Insert(car);
                    message = "Added";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        public bool createProject(string name, out string message)
        {
            Console.Clear();
            try
            {
                Project prj = new Project(name);
                using (var db = new LiteDatabase("Project.db"))
                {
                    var proj = db.GetCollection<Project>("Projects");
                    proj.Insert(prj);
                    message = "Added";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

        }
        public bool createComponent(string name, int id, out string message)
        {
            Console.Clear();
            try
            {
                Component cmp = new Component(name, id);
                using (var db = new LiteDatabase("Component.db"))
                {
                    var comp = db.GetCollection<Component>("Components");
                    comp.Insert(cmp);
                    message = "Added";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

        }
        public bool createService(DateTime createTime, string description, string recomendation, User inspector, out string message)
        {
            Console.Clear();
            try
            {
                ServiceStation servS = new ServiceStation(createTime, description, recomendation, inspector);
                using (var db = new LiteDatabase("Component.db"))
                {
                    var serviceS = db.GetCollection<ServiceStation>("Components");
                    serviceS.Insert(servS);
                    message = "Added";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

        }


        public bool deleteCar(int id, out string message)
        {
            try
            {
                using (var db = new LiteDatabase("Car.db"))
                {
                    var carsDel = db.GetCollection<Car>("Cars");
                    carsDel.Delete(id);
                    message = "Deleted";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        public Car FindByNum(int garageNum, out string message)
        {
            try
            {
                using (var db = new LiteDatabase("Car.db"))
                {
                    var cars = db.GetCollection<Car>("Cars");
                    IEnumerable<Car> results =
                    cars.Find(x => x.garageNum.Equals(garageNum) && x.garageNum.Equals(garageNum));
                    message = "Found";
                    return results.LastOrDefault();
                }
            }
            catch (Exception ex)
            {
                Car car = null;
                message = ex.Message;
                return car;
            }
        }
        public Car findByModel(string model, out string message)
        {
            try
            {
                using (var db = new LiteDatabase("Car.db"))
                {
                    var cars = db.GetCollection<Car>("Cars");
                    IEnumerable<Car> results =
                    cars.Find(x => x.garageNum.Equals(model) && x.garageNum.Equals(model));
                    message = "Found";
                    return results.LastOrDefault();
                }
            }
            catch (Exception ex)
            {
                Car car = null;
                message = ex.Message;
                return car;
            }
        }

        public List<Car> showCars(out string message)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase("Car.db"))
                {
                    message = "All cars";
                    var result = db.GetCollection<Car>("Cars").FindAll();
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }
        public List<Project> showProjects(out string message)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase("Project.db"))
                {
                    message = "All Project";
                    var result = db.GetCollection<Project>("Projects").FindAll();
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }
        public List<User> showUsers(out string message)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase("User.db"))
                {
                    message = "All User";
                    var result = db.GetCollection<User>("Users").FindAll();
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }
        public List<Component> showComponents(out string message)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase("Component.db"))
                {
                    message = "All Components";
                    var result = db.GetCollection<Component>("Components").FindAll();
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }
    }
}