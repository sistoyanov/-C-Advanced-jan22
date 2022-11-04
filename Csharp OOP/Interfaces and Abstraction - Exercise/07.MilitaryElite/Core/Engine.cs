namespace MilitaryElite.Core
{
    using System;
    using Interfaces;
    using MilitaryElite.IO.Interfaces;
    using MilitaryElite.Models;
    using MilitaryElite.Models.Enums;
    using MilitaryElite.Models.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        ICollection<ISoldier> soldiers;
        ISoldier soldier;

        public Engine()
        {
            this.soldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

            this.CreateSoldiers();
            this.PrintSoldiers();
            
            
        }

        private void CreateSoldiers()
        {
            string input = string.Empty;


            while ((input = this.reader.ReadLine()) != "End")
            {
                string[] inputDetails = input.Split(" ");
                string soldierType = inputDetails[0];
                int solderId = int.Parse(inputDetails[1]);
                string soldierFirstName = inputDetails[2];
                string soldierLastName = inputDetails[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(inputDetails[4]);
                    soldier = new Private(solderId, soldierFirstName, soldierLastName, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputDetails[4]);
                    ICollection<IPrivate> privates = AddPrivats(inputDetails);
                    soldier = new LieutenantGeneral(solderId, soldierFirstName, soldierLastName, salary, privates);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(inputDetails[4]);
                    string corpsText = inputDetails[5];
                    bool isCorpValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);

                    if (!isCorpValid)
                    {
                        continue;
                    }

                    ICollection<IRepair> repairs = AddRepairs(inputDetails);
                    soldier = new Engineer(solderId, soldierFirstName, soldierLastName, salary, corps, repairs);
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(inputDetails[4]);
                    string corpsText = inputDetails[5];
                    bool isCorpValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);

                    if (!isCorpValid)
                    {
                        continue;
                    }

                    ICollection<IMission> missions = AddMission(inputDetails);
                    soldier = new Commando(solderId, soldierFirstName, soldierLastName, salary, corps, missions);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(inputDetails[4]);
                    soldier = new Spy(solderId, soldierFirstName, soldierLastName, codeNumber);

                }

                this.soldiers.Add(soldier);
            }
        }

        private ICollection<IMission> AddMission(string[] inputDetails)
        {
            ICollection<IMission> missions = new HashSet<IMission>();
            string[] missionDetails = inputDetails.Skip(6).ToArray();

            for (int i = 0; i < missionDetails.Length; i += 2)
            {
                string codeName = missionDetails[i];
                string stateText = missionDetails[i + 1];

                bool isStateValid = Enum.TryParse<State>(stateText, false, out State state);
                if (!isStateValid)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }

            return missions;
        }

        private ICollection<IRepair> AddRepairs(string[] inputDetails)
        {
            ICollection<IRepair> repairs = new HashSet<IRepair>();
            string[] reparirDetails = inputDetails.Skip(6).ToArray();

            for (int i = 0; i < reparirDetails.Length; i+= 2)
            {
                string partName = reparirDetails[i];
                int horsWorked = int.Parse(reparirDetails[i + 1]);
                IRepair repair = new Repair(partName, horsWorked);
                repairs.Add(repair);
            }

            return repairs;
        }

        private ICollection<IPrivate> AddPrivats(string[] inputDetails)
        {
            ICollection<IPrivate> privates = new HashSet<IPrivate>();
            int[] privatesIds = inputDetails.Skip(5).Select(int.Parse).ToArray();

            foreach (var id in privatesIds)
            {
                IPrivate currentPrivate = (IPrivate)this.soldiers.FirstOrDefault(p => p.Id == id);

                if (currentPrivate != null)
                {
                    privates.Add(currentPrivate);
                }
            }

            return privates;
        }

        private void PrintSoldiers()
        {
            foreach (var solder in this.soldiers)
            {
                this.writer.WriteLine(solder.ToString());
            }
        }
    }
}
