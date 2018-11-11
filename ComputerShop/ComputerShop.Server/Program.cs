using ComputerShop.Core;
using ComputerShop.Core.Models;
using ComputerShop.Server.Access;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            
            Init();

            ConnectionService _connectionService = new ConnectionService();
            _connectionService.StartConnection();
            Console.ReadKey(true);
            _connectionService.EndConnection();
        }

        private static void Init()
        {
            UserService service = new UserService();
            if (service.AddNewUser(new User { Username = "admin", Name = "admin", Password = "admin", Surname = "admin" }))
            {
                Console.WriteLine("Admin dodat!");
            }
            else
            {
                Console.WriteLine("Admin je vec u bazi.");
            }

            var components = ComputerPartsRepository.Instance.GetComponents();
            if (components.Count() >= 12)
            {
                Console.WriteLine("Komponente su vec dodate u bazu.");
                return;
            }
            else
            {
                ImportComponents();
            }
        }

        private static void ImportComponents()
        {
            string path = @"..\..\..\..\import.txt";
            string readPath = @"..\..\..\import.txt";

            if (!File.Exists(path))
            {
                var text = File.ReadAllText(readPath);

                var dataH = text.Replace("\r\n", String.Empty);
                var data = dataH.Replace("\t", string.Empty).Split('|');
                decimal help = 443;

                decimal.TryParse(data[3], out help);

                Case caseOne = new Case
                {
                    Model = data[0],
                    Name = data[1],
                    CaseType = data[2],
                    Price = help
                };

                decimal.TryParse(data[7], out help);

                Case caseTwo = new Case
                {
                    Model = data[4],
                    Name = data[5],
                    CaseType = data[6],
                    Price = help
                };

                decimal.TryParse(data[12], out help);

                Memory memOne = new Memory
                {
                    Model = data[8],
                    Name = data[9],
                    Size = data[10],
                    MemoryType = data[11],
                    Price = help
                };

                decimal.TryParse(data[17], out help);

                Memory memTwo = new Memory
                {
                    Model = data[13],
                    Name = data[14],
                    Size = data[15],
                    MemoryType = data[16],
                    Price = help
                };

                decimal.TryParse(data[22], out help);

                RAM ramOne = new RAM
                {
                    Model = data[18],
                    Name = data[19],
                    Size = data[20],
                    RamType = data[21],
                    Price = help
                };

                decimal.TryParse(data[27], out help);

                RAM ramTwo = new RAM
                {
                    Model = data[23],
                    Name = data[24],
                    Size = data[25],
                    RamType = data[26],
                    Price = help
                };

                decimal.TryParse(data[32], out help);

                CPU cpuOne = new CPU
                {
                    Model = data[28],
                    Name = data[29],
                    Cores = Int32.Parse(data[30]),
                    Speed = data[31],
                    Price = help
                };

                decimal.TryParse(data[37], out help);

                CPU cpuTwo = new CPU
                {
                    Model = data[33],
                    Name = data[34],
                    Cores = Int32.Parse(data[35]),
                    Speed = data[36],
                    Price = help
                };

                decimal.TryParse(data[42], out help);

                GPU gpuOne = new GPU
                {
                    Model = data[38],
                    Name = data[39],
                    Memory = data[40],
                    Speed = data[41],
                    Price = help
                };

                decimal.TryParse(data[47], out help);

                GPU gpuTwo = new GPU
                {
                    Model = data[43],
                    Name = data[44],
                    Memory = data[45],
                    Speed = data[46],
                    Price = help
                };

                decimal.TryParse(data[51], out help);

                MotherBoard mbOne = new MotherBoard
                {
                    Model = data[48],
                    Name = data[49],
                    Socket = data[50],
                    Price = help
                };

                decimal.TryParse(data[55], out help);

                MotherBoard mbTwo = new MotherBoard
                {
                    Model = data[52],
                    Name = data[53],
                    Socket = data[54],
                    Price = help
                };

                if(ComputerPartsRepository.Instance.AddComponent(caseOne) && ComputerPartsRepository.Instance.AddComponent(caseTwo) && ComputerPartsRepository.Instance.AddComponent(memOne) &&
                    ComputerPartsRepository.Instance.AddComponent(memTwo) && ComputerPartsRepository.Instance.AddComponent(ramOne) && ComputerPartsRepository.Instance.AddComponent(ramTwo) &&
                        ComputerPartsRepository.Instance.AddComponent(cpuOne) && ComputerPartsRepository.Instance.AddComponent(cpuTwo) && ComputerPartsRepository.Instance.AddComponent(gpuOne) &&
                            ComputerPartsRepository.Instance.AddComponent(gpuTwo) && ComputerPartsRepository.Instance.AddComponent(mbOne) && ComputerPartsRepository.Instance.AddComponent(mbTwo))
                {
                    Console.WriteLine("Components added to db.");
                }
                else
                {
                    Console.WriteLine("Error while adding components to db.");
                }
            }
            else
            {
                Console.WriteLine("Wrong path to data file!");
            }
        }
    }
}
