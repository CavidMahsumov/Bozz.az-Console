using ProjectFinal.Exception1;
using ProjectFinal.JsonHelper;
using ProjectFinal.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Classes
{
    public class Run
    {
        static public void Runn()
        {
            DataBase database = new DataBase();
            string speciality;
            string school;
            string getlink;
            string linkedin;
            string sn;
            string cn;
            string ln;
            string ll;
            string username;
            string password;
            int score = 0;
            bool diplom;
            bool isTrue;
            bool isTrue1;
            bool isTrue2;
            bool isChoose;
            bool isChoose1;
            bool isChoose2;
            int sc = 0;
            int cc = 0;
            int wp = 0;
            int lc = 0;
            int choose1 = 0;
            int choose2 = 0;
            int choose = 0;
            int result = 0;
            int result1 = 0;
            int result2 = 0;
            int select1 = 0;
            int id = 0;
            int id1 = 0;
            int id2 = 0;
            int id3 = 0;
            int id4 = 0;
            int cin = 0;
            int cin1 = 0;
            int cin2 = 0;
            int select = 0;
            int select2 = 0;
            int select3 = 0;
            int select4 = 0;
            int select5 = 0;
            int select6 = 0;
            int select7 = 0;
            int select8 = 0;
            int sendc = 0;
            void ShowVacancyChoose()
            {
                Console.Clear();
                Console.WriteLine("1)Show all vanacies");
                Console.WriteLine("2)Show vanacies with filter");
                Console.WriteLine("3)Back");
                Console.WriteLine("\nEnter your choche : ");
                isChoose = int.TryParse(Console.ReadLine(), out choose1);
            }
            void ShowVacancyWithFilterChoose()
            {
                Console.Clear();
                Console.WriteLine("1)Front-end Developer");
                Console.WriteLine("2)Designer");
                Console.WriteLine("3)Programmer");
                Console.WriteLine("\nEnter your choche : ");
                select1 = int.Parse(Console.ReadLine());
            }
            void ShowWithFilter()
            {
                try
                {
                    foreach (var item in database.ShowVacancyWithFilter(select1))
                    {
                        Console.WriteLine(item);
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(1000);
                    Console.ResetColor();
                    MainMenu();

                }
            }
            void ShowVacancySelection()
            {
                if (isChoose)
                {
                    if (choose1 == 1)
                    {
                        Console.Clear();
                        database.ShowAllVacancies();
                        SendCV();
                    }
                    else if (choose1 == 2)
                    {
                        ShowVacancyWithFilterChoose();
                        ShowWithFilter();
                        SendCV();
                    }
                    else if (choose1 == 3)
                    {
                        WorkerSide();
                    }
                }
                else
                {
                    try
                    {
                        throw new TryParseException("Invalid format");
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                        MainMenu();
                    }
                }
            }
            void ShowVacancies()
            {
                ShowVacancyChoose();
                ShowVacancySelection();
            }
            void ShowWorkerCvs()
            {
                Console.Clear();
                foreach (var item in database.Worker.Cvs)
                {
                    item.Show();
                }
            }
            void UpdateCvMenuSelection()
            {
                Console.WriteLine("Enter ID : ");
                id1 = int.Parse(Console.ReadLine());
                database.UpdateCv(id1);
            }
            void UpdateCvMenu()
            {
                ShowWorkerCvs();
                UpdateCvMenuSelection();
                ShowWorkerCvs();
            }
            void UpdateCvSelection()
            {
                Console.WriteLine("CV updated!");
                Console.WriteLine("1)Back");
                select2 = int.Parse(Console.ReadLine());
                if (select2 == 1)
                {
                    JsonFileHelper.JSONSerialization(database);
                    WorkerSide();
                }
            }
            void UpdateCv()
            {
                UpdateCvMenu();
                UpdateCvSelection();
            }
            void DeleteMenuSelection()
            {
                Console.WriteLine("Enter ID :");
                id = int.Parse(Console.ReadLine());
                var list = database.Worker.Cvs.Where(c => c.Id != id).ToList();
                database.Worker.Cvs = list;
                Console.WriteLine("---------------------");
            }
            void DeleteCvMenu()
            {
                ShowWorkerCvs();
                DeleteMenuSelection();
                ShowWorkerCvs();
            }
            void DeleteCvSelection()
            {
                Console.WriteLine("CV deleted!");
                Console.WriteLine("1)Back");
                select = int.Parse(Console.ReadLine());
                if (select == 1)
                {
                    JsonFileHelper.JSONSerialization(database);
                    WorkerSide();
                }
            }
            void DeleteCv()
            {
                DeleteCvMenu();
                DeleteCvSelection();
            }
            void AddCvMenuObj()
            {
                List<Companie> companies = new List<Companie>
                     {
                         new Companie {
                             Count = cc,
                             Name = cn,
                             Practice = wp,
                             End = new DateTime(2021, 11, 09),
                             Start = new DateTime(2020, 10, 05)
                         }
                     };
                List<Language> languages = new List<Language>
                     {
                         new Language
                         {
                              Count=lc,
                               Level=ll,
                                Name=ln
                         }
                     };
                List<Skill> skills = new List<Skill>
                     {
                         new Skill
                         {
                              Count=sc,
                               Name=sn
                         }
                     };
                Cv cv = new Cv
                {
                    Speciality = speciality,
                    GetLink = getlink,
                    Linkedin = linkedin,
                    FirstSchool = school,
                    IsDiplom = diplom,
                    Score = score,
                    Companies = companies,
                    Languages = languages,
                    Skills = skills,
                    Id = database.Worker.Id++
                };
                database.Worker.Cvs.Add(cv);
            }
            void AddCvMenu()
            {
                Console.Clear();
                Console.WriteLine("Enter your speciality : ");
                speciality = Console.ReadLine();
                Console.WriteLine("Enter your school : ");
                school = Console.ReadLine();
                Console.WriteLine("Enter your score : ");
                score = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your differentition(True/False) : ");
                diplom = bool.Parse(Console.ReadLine());
                Console.WriteLine("Enter your link : ");
                getlink = Console.ReadLine();
                Console.WriteLine("Enter your linkedin adress : ");
                linkedin = Console.ReadLine();
                Console.WriteLine("Enter your skill name : ");
                sn = Console.ReadLine();
                Console.WriteLine("Enter your skill count : ");
                sc = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your companie name : ");
                cn = Console.ReadLine();
                Console.WriteLine("Enter your companie count : ");
                cc = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your work practise : ");
                wp = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your language name : ");
                ln = Console.ReadLine();
                Console.WriteLine("Enter your language count : ");
                lc = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your language level : ");
                ll = Console.ReadLine();
            }
            void AddCvSelection()
            {
                Console.WriteLine("CV added!");
                Console.WriteLine("1)Back");
                select3 = int.Parse(Console.ReadLine());
                if (select3 == 1)
                {
                    JsonFileHelper.JSONSerialization(database);
                    WorkerSide();
                }
            }
            void AddCv()
            {
                AddCvMenu();
                AddCvMenuObj();
                AddCvSelection();
            }
            void SendCvSelection()
            {
                Console.WriteLine("1)Send CV");
                Console.WriteLine("2)Back");
                sendc = int.Parse(Console.ReadLine());
            }
            void SendCvEnterId()
            {
                Console.WriteLine("Enter Vacancy ID : ");
                id2 = int.Parse(Console.ReadLine());
                database.SendCv(id2);
                Console.WriteLine("1)Back");
                select8 = int.Parse(Console.ReadLine());
                if (select8 == 1)
                {
                    ShowVacancySelection();
                }
            }
            void WorkerSideSelect()
            {
                if (isTrue1)
                {
                    if (result1 == 1)
                    {
                        WorkerSideCvOperationSelection();
                        WorkerSideCvOperationsSelect();
                    }
                    else if (result1 == 2)
                    {
                        ShowVacancies();
                    }
                    else if (result1 == 3)
                    {
                        if (database.Worker.notifications != null)
                        {
                            foreach (var item in database.Worker.notifications)
                            {
                                Console.WriteLine(item);
                            }
                            System.Threading.Thread.Sleep(2500);

                            BackRequest();
                        }
                        else
                        {
                            Console.WriteLine("Notificatin not found!");
                            System.Threading.Thread.Sleep(2500);
                            MainMenu();
                        }
                    }
                    else if (result1 == 4)
                    {
                        MainMenu();
                    }
                }
                else
                {
                    try
                    {
                        throw new TryParseException("Invalid format");
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                        MainMenu();
                    }
                }
            }
            void SendCV()
            {
                SendCvSelection();
                if (sendc == 1)
                {
                    SendCvEnterId();
                }
                else if (sendc == 2)
                {
                    ShowVacancies();
                }
                else
                {
                    try
                    {
                        throw new WrongSelectionException("Wrong selection");
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                }
            }

            Employeer employeer = new Employeer
            {
                Age = 48,
                City = "Baki",
                Id = 1,
                Name = "Cavid",
                Surname = "Mahsunov",
                Password = "1",
                Username = "1",
                PhoneNumber = "+994552000000",
                Vacancies = new List<Vacancy> {
                    new Vacancy {
                     Id=1,
                     AgeRequeriment=18,
                     EmployerName="Cavid",
                     PracticeRequeriment=5,
                     Type="Designer",
                     WorkPlace="Shirvan"
                    }
                }
            };
            Employeer employeer1 = new Employeer
            {
                Age = 30,
                City = "Shirvan",
                Id = 2,
                Name = "Tural",
                Surname = "Tahirli",
                Password = "1",
                Username = "1",
                PhoneNumber = "+994553000000",
                Vacancies = new List<Vacancy> {
                    new Vacancy
                    {
                        Id=2,
                        AgeRequeriment=18,
                        EmployerName="Tural",
                        PracticeRequeriment=10,
                        Type="Programmer",
                        WorkPlace="Baki"
                    }
                }
            };
            Employeer employeer2 = new Employeer
            {
                Age = 20,
                City = "Baki",
                Id = 3,
                Name = "Murad",
                Surname = "Sadixov",
                Password = "1",
                Username = "1",
                PhoneNumber = "+994552000000",
                Vacancies = new List<Vacancy>
                {
                    new Vacancy
                    {
                        Id=3,
                        AgeRequeriment=25,
                        EmployerName="Murad",
                        PracticeRequeriment=3,
                        Type="Front-end Developer",
                        WorkPlace="Baki"
                    }
                }
            };
            Worker worker = new Worker
            {
                Age = 18,
                City = "Baki",
                Id = 1,
                Name = "Elxan",
                Surname = "Atayev",
                PhoneNumber = "+994555555555",
                Password = "1",
                Username = "1",
                Cvs = new List<Cv>
                {
                    new Cv
                    {
                        Score = 100,
                        IsDiplom = false,
                        FirstSchool = "School number 21",
                        Speciality = "Engineer",
                        GetLink = "Link",
                        Linkedin = "Linkedin",
                        Companies = new List<Companie>
                        {
                             new Companie
                             {
                                  Count=1,
                                  End=DateTime.Now,
                                  Start=DateTime.Now,
                                  Name="Shlumberger",
                                  Practice=3
                             }
                        },
                        Languages = new List<Language>
                        {
                            new Language
                            {
                                 Count=1,
                                 Level="Good",
                                 Name="English"
                            }
                        },
                        Skills = new List<Skill>
                        {
                            new Skill
                            {
                                 Count=1,
                                 Name="Pragramming leaner"
                            }
                        }
                    }
                }
            };
            Worker worker1 = new Worker
            {
                Age = 20,
                City = "Sheki",
                Id = 2,
                Name = "Eli",
                Surname = "Ibadzade",
                PhoneNumber = "+994556666666",
                Password = "1",
                Username = "1",
                Cvs = new List<Cv>
                {
                    new Cv
                    {
                        Score = 70,
                        IsDiplom = true,
                        FirstSchool = "School number 53",
                        Speciality = "Teacher",
                        GetLink = "Link",
                        Linkedin = "Linkedin",
                        Companies = new List<Companie>
                        {
                             new Companie
                             {
                                  Count=1,
                                  End=DateTime.Now,
                                  Start=DateTime.Now,
                                  Name="Step IT",
                                  Practice=5
                             }
                        },
                        Languages = new List<Language>
                        {
                            new Language
                            {
                                 Count=1,
                                 Level="Good",
                                 Name="Russian"
                            }
                        },
                        Skills = new List<Skill>
                        {
                            new Skill
                            {
                                 Count=1,
                                 Name="Reading"
                            }
                        }
                    }
                }
            };
            List<Worker> workers = new List<Worker> { worker, worker1 };
            database.Workers = workers;
            List<Employeer> employeers = new List<Employeer> { employeer, employeer1, employeer2 };
            database.Employeers = employeers;


            void WorkerSideSelection()
            {
                Console.Clear();
                Console.WriteLine("1)CV ");
                Console.WriteLine("2)Show vacancies");
                Console.WriteLine("3)Show notification");
                Console.WriteLine("4)Back");
                Console.Write("\nEnter your choiche : ");
                isTrue1 = int.TryParse(Console.ReadLine(), out result1);
            }
            void BackRequest()
            {
                Console.WriteLine("1)Back");
                int a = int.Parse(Console.ReadLine());
                if (a == 1)
                {
                    Console.Clear();
                    WorkerSideSelection();
                }
            }
            void WorkerSideCvOperationSelection()
            {
                Console.Clear();
                Console.WriteLine("1)Add  CV");
                Console.WriteLine("2)Delete  CV");
                Console.WriteLine("3)Update  CV");
                Console.WriteLine("4)Back");
                Console.WriteLine("\nEnter your choiche : ");
                isTrue2 = int.TryParse(Console.ReadLine(), out result2);
            }
            void ShowEmployeersVacancies()
            {
                Console.Clear();
                ShowVacancyE();
                Console.WriteLine("1)Back");
                Console.WriteLine("\nEnter your choiche");
                select4 = int.Parse(Console.ReadLine());
                if (select4 == 1)
                {
                    JsonFileHelper.JSONSerialization(database);
                    VacancyMenu();
                }
            }
            void WorkerSideCvOperationsSelect()
            {
                if (isTrue2)
                {
                    if (result2 == 1)
                    {
                        AddCv();
                    }
                    else if (result2 == 2)
                    {
                        DeleteCv();
                    }
                    else if (result2 == 3)
                    {
                        UpdateCv();
                    }
                    else if (result2 == 4)
                    {
                        WorkerSide();
                    }
                }
                else
                {
                    try
                    {
                        throw new TryParseException("Invalid format");
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                        WorkerSide();
                    }
                }
            }
            void WorkerSide()
            {
                WorkerSideSelection();
                WorkerSideSelect();
            }
            void MainMenuSelection()
            {
                Console.Clear();
                Console.WriteLine("1)Worker");
                Console.WriteLine("2)Employeer");
                Console.WriteLine("\nEnter your choiche : ");
                isTrue = int.TryParse(Console.ReadLine(), out result);
            }
            void EnterUsernamePassword()
            {
                Console.Clear();
                Console.WriteLine("Enter username");
                username = Console.ReadLine();
                Console.WriteLine("Enter password");
                password = Console.ReadLine();
            }

            void AddVacancy()
            {
                Console.Clear();
                Console.WriteLine("Enter vacancy type : ");
                string type = Console.ReadLine();
                Console.WriteLine("Enter practice requierment : ");
                int pr = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter age requierment : ");
                int ar = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter work place : ");
                string city = Console.ReadLine();
                Vacancy vacancy = new Vacancy
                {
                    Id = database.Employeer.Vacancies[0].Id++,
                    Type = type,
                    PracticeRequeriment = pr,
                    AgeRequeriment = ar,
                    WorkPlace = city,
                    EmployerName = database.Employeer.Name
                };
                database.Employeer.Vacancies.Add(vacancy);
                Console.WriteLine("1)Back");
                select5 = int.Parse(Console.ReadLine());
                if (select5 == 1)
                {
                JsonFileHelper.JSONSerialization(database);
                    VacancyMenu();
                }
            }
            void ShowVacancyE()
            {
                Console.Clear();
                foreach (var item in database.Employeer.Vacancies)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            void DeleteVacancy()
            {
                Console.WriteLine("Id : ");
                id3 = int.Parse(Console.ReadLine());
                var List = database.Employeer.Vacancies.Where(v => v.Id != id3).ToList();
                database.Employeer.Vacancies = List;
                Console.WriteLine("Vacancies Is Deleted!");
                Console.WriteLine("1)Back");
                select6 = int.Parse(Console.ReadLine());
                if (select6 == 1)
                {
                    JsonFileHelper.JSONSerialization(database);
                    VacancyMenu();
                }
            };
            void UpdateVacancy()
            {
                Console.WriteLine("Enter the ID");
                id4 = int.Parse(Console.ReadLine());
                database.UpdateVac(id4);
                Console.WriteLine("Vacancy updated!");
                Console.WriteLine("1)Back");
                select7 = int.Parse(Console.ReadLine());
                if (select7 == 1)
                {
                    JsonFileHelper.JSONSerialization(database);
                    VacancyMenu();
                }
            }
            void VacancyMenu()
            {
                Console.Clear();
                Console.WriteLine("1)See your vacancies");
                Console.WriteLine("2)Add vacancy");
                Console.WriteLine("3)Delete vacancy");
                Console.WriteLine("4)Update vacancy");
                Console.WriteLine("5)Back");
                Console.WriteLine("\nEnter your choiche");
                isChoose1 = int.TryParse(Console.ReadLine(), out choose2);
                if (choose2 == 1)
                {
                    ShowEmployeersVacancies();
                }
                else if (choose2 == 2)
                {
                    AddVacancy();
                    ShowEmployeersVacancies();
                }
                else if (choose2 == 3)
                {
                    ShowVacancyE();
                    DeleteVacancy();
                }
                else if (choose2 == 4)
                {
                    ShowVacancyE();
                    UpdateVacancy();
                }
                else if (choose2 == 5)
                {
                    EmployeerSide();
                }
            }
            void EmployeerSide()
            {
                Console.Clear();
                Console.WriteLine("1)Vacancy");
                Console.WriteLine("2)Show notifications");
                Console.WriteLine("3)Back");
                Console.WriteLine("\nEnter your choiche");
                isChoose2 = int.TryParse(Console.ReadLine(), out choose);
                if (isChoose2)
                {
                    if (choose == 1)
                    {
                        VacancyMenu();
                    }
                    else if (choose == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("1)Show CV");
                        Console.WriteLine("2)Back");
                        Console.WriteLine("\nEnter your choiche");
                        cin = int.Parse(Console.ReadLine());
                        if (cin == 1)
                        {
                            Console.Clear();
                            if (database.Employeer.Cvs != null)
                            {
                                foreach (var item in database.Employeer.Cvs)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine("1)Accept");
                                Console.WriteLine("2)Cancel");
                                cin1 = int.Parse(Console.ReadLine());
                                if (cin1 == 1)
                                {
                                    Console.WriteLine("Input ID : ");
                                    cin2 = int.Parse(Console.ReadLine());
                                    database.AcceptCv(cin2);
                                    SendMail.SendMail1();
                                    EmployeerSide();
                                }
                                else if (cin1 == 2)
                                {
                                    Console.WriteLine("Input ID : ");
                                    cin2 = int.Parse(Console.ReadLine());
                                    database.CancelCv(cin2);
                                    SendMail.SendMail1();
                                    EmployeerSide();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("CV not found!");
                                System.Threading.Thread.Sleep(2000);
                                Console.ResetColor();
                                EmployeerSide();
                            }
                        }
                        else if (cin == 2)
                        {
                            Console.Clear();
                            EmployeerSide();
                        }
                        else
                        {
                            try
                            {
                                throw new WrongSelectionException("Wrong selection");
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                System.Threading.Thread.Sleep(1000);
                                Console.ResetColor();
                                MainMenu();
                            }
                        }
                    }
                    else if (choose == 3)
                    {
                        MainMenu();
                    }
                }
                else
                {
                    try
                    {
                        throw new TryParseException("Invalid format");
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                        MainMenu();
                    }
                }
            }
            void MainMenu()
            {
                MainMenuSelection();
                if (isTrue)
                {
                    if (result == 1)
                    {
                        EnterUsernamePassword();
                        if (database.CheckUsernameAndPasswordWorker(username, password))
                        {
                            WorkerSide();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong password or username");
                            System.Threading.Thread.Sleep(1000);
                            Console.ResetColor();
                            MainMenu();
                        }
                    }
                    else if (result == 2)
                    {
                        EnterUsernamePassword();
                        if (database.CheckUsernameAndPasswordEmployeer(username, password))
                        {
                            EmployeerSide();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong password or username");
                            System.Threading.Thread.Sleep(1000);
                            Console.ResetColor();
                            MainMenu();
                        }
                    }
                    else
                    {
                        try
                        {
                            throw new WrongSelectionException("Wrong selection");
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine(ex.Message);
                        }
                        System.Threading.Thread.Sleep(2000);
                        MainMenu();
                    }
                }
                else
                {
                    try
                    {
                        throw new TryParseException("Invalid format");
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                        MainMenu();
                    }
                }
            }
            if (File.Exists(JsonFileHelper.fileName))
            {
                JsonFileHelper.JSONDeSerialization(ref database);
            }
            MainMenu();
        }
    }
}
