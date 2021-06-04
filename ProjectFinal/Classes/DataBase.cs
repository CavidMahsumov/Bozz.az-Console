using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Classes
{
    public class DataBase
    {
        public Worker Worker { get; set; }
        public List<Employeer> Employeers { get; set; }
        public List<Worker> Workers { get; set; }
        public Employeer Employeer { get; set; }
        public bool CheckUsernameAndPasswordWorker(string username, string password)
        {
            foreach (var item in Workers)
            {
                if (item.Username == username && item.Password == password)
                {
                    Worker = item;
                    return true;
                }
            }
            return false;
        }
        public bool CheckUsernameAndPasswordEmployeer(string username, string password)
        {
            foreach (var item in Employeers)
            {
                if (item.Username == username && item.Password == password)
                {
                    Employeer = item;
                    return true;
                }
            }
            return false;
        }
        string speciality;
        string school;
        int score;
        bool diplom;
        string getlink;
        string linkedin;
        int sc;
        string cn;
        int cc;
        int wp;
        int lc;
        string ll;
        string ln;
        string sn;
        public Cv Update()
        {
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
            Worker.Cvs = new List<Cv>
            {
                new Cv{
                Speciality = speciality,
                GetLink = getlink,
                Linkedin = linkedin,
                FirstSchool = school,
                IsDiplom = diplom,
                Score = score,
                Companies = new List<Companie>
                        {
                            new Companie {
                                Count = cc,
                                Name = cn,
                                Practice = wp,
                                End = new DateTime(2021, 11, 09),
                                Start = new DateTime(2020, 10, 05)
                            }
                        },
                Languages = new List<Language>
                         {
                             new Language
                             {
                                  Count=lc,
                                   Level=ll,
                                    Name=ln
                             }
                         },
                Skills = new List<Skill>
                         {
                             new Skill
                             {
                                  Count=sc,
                                   Name=sn
                             }
                         }
                }
            };
            return Worker.Cvs[0];
        }
        public void UpdateCv(int id)
        {
            for (int i = 0; i < Worker.Cvs.Count(); i++)
            {
                if (Worker.Cvs[i].Id == id)
                {
                    Worker.Cvs[i] = Update();
                }
            }
        }
        int ageRequeriment;
        int workPractice;
        string type;
        string city;
        public Vacancy UpdateVacancy()
        {
            Console.WriteLine("Enter vacancy type : ");
            type = Console.ReadLine();
            Console.WriteLine("Enter work requeriment : ");
            workPractice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter age requeriment : ");
            ageRequeriment = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter work place : ");
            city = Console.ReadLine();
            Vacancy vacancy = new Vacancy
            {
                AgeRequeriment = ageRequeriment,
                EmployerName = Employeer.Name,
                PracticeRequeriment = workPractice,
                Id = Employeer.Vacancies[Employeer.Vacancies.Count - 1].Id++,
                WorkPlace = city,
                Type = type
            };
            return vacancy;
        }
        public void UpdateVac(int id)
        {
            for (int i = 0; i < Employeer.Vacancies.Count(); i++)
            {
                if (Employeer.Vacancies[i].Id == id)
                {
                    Employeer.Vacancies[i] = UpdateVacancy();
                }
            }
        }
        public List<Vacancy> ShowVacancyWithFilter(int select)
        {
            List<Vacancy> vacancies = new List<Vacancy>();
            foreach (var item in Employeers)
            {
                if (select == 1)
                {
                    var request = item.Vacancies
                        .Where(v => v.Type == "Front-end Developer")
                        .ToList();
                    vacancies = request;
                    break;
                }
                else if (select == 2)
                {
                    var request = item.Vacancies
                        .Where(v => v.Type == "Designer")
                        .ToList();
                    vacancies = request;
                    break;
                }
                else if (select == 3)
                {
                    var request = item.Vacancies
                        .Where(v => v.Type == "Programmer")
                        .ToList();
                    vacancies = request;
                    break;
                }
            }
            return vacancies;
        }
        public void ShowAllVacancies()
        {
            foreach (var item in Employeers)
            {
                Console.WriteLine("==================");
                for (int i = 0; i < item.Vacancies.Count(); i++)
                {
                    Console.WriteLine(item.Vacancies[i]);
                }
            }
        }
        public void SendCv(int id)
        {
            foreach (var item in Employeers)
            {
                foreach (var cv in item.Vacancies)
                {
                    if (cv.Id == id)
                    {
                        Employeer = item;
                        Employeer.Cvs = Worker.Cvs;
                        Console.WriteLine("Cv is Send");
                        break;
                    }
                }
            }
        }
        public void AcceptCv(int id)
        {
            foreach (var item in Employeer.Cvs)
            {
                List<Notification> notifications = new List<Notification> {
                new Notification{
                 From=Employeer.Name,
                 Time=DateTime.Now,
                 Description="CV Accepted"
                }
                };
                Worker.notifications = notifications;
                Console.WriteLine("CV Accepted!");
            }
        }
        public void CancelCv(int id)
        {
            foreach (var item in Employeer.Cvs)
            {
                List<Notification> notifications = new List<Notification> {
                new Notification{
                 From=Employeer.Name,
                 Time=DateTime.Now,
                 Description="CV Canceled"
                }
                };
                Worker.notifications = notifications;
                Console.WriteLine("CV Canceled!");
            }
        }

    }
}
