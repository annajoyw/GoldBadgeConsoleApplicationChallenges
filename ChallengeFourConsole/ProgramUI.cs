using ChallengeFourRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourConsole
{
    class ProgramUI
    {
        private OutingsRepo _repo = new OutingsRepo();
        public void Run()
        {
            SeedData();
            while (Menu())
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Goodbye!\n" +
                "Press an key to exit...");
            Console.ReadKey();
        }
        public void SeedData()
        {
            var golfOuting = new Outings("Golf", 100, new DateTime(2021, 1, 15), 20.99, 2099);
            var bowlingOuting = new Outings("Bowling", 70, new DateTime(2020, 1, 13), 8, 560);
            var amusementParkOuting = new Outings("Amusement Park", 150, new DateTime(2020, 5, 1), 49.99, 7498);
            var concertOuting = new Outings("Concert", 90, new DateTime(2019, 1, 1), 20, 1800);

            _repo.AddOutingToList(golfOuting);
            _repo.AddOutingToList(bowlingOuting);
            _repo.AddOutingToList(amusementParkOuting);
            _repo.AddOutingToList(concertOuting);
        }
        private bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome! What would you like to do?\n" +
                "1. Display all outings\n" +
                "2. Add outing to list\n" +
                "3. View company outing costs\n" +
                "4. Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    //display outings
                    ViewAllOutingsMenuMethod();
                    break;
                case "2":
                    //add outing to list
                    AddNewOuting();
                    break;
                case "3":
                    //view costs
                    ViewOutingCostMenuMethod();
                    break;
                case "4":
                    return false;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
            return true;
        }
        private void ViewAllOutingsMenuMethod()
        {
            Console.Clear();
            //var allOutings = _repo.GetAllOutings();
            List<Outings> outings = _repo.GetAllOutings();

            foreach (Outings outing in outings)
            {
                DisplayOutings(outing);
            }
           
        }
        private void AddNewOuting()
        {
            Console.Clear();
            Outings newOuting = new Outings();
            Console.WriteLine("Please enter event type (ex. Golf, Zoo, Museum etc)");
            newOuting.EventType = Console.ReadLine();
            Console.WriteLine("Please enter the number of people that attended (if applicable, it event has not taken place yet, please type N/A");
            
            int attendees=int.Parse(Console.ReadLine());
            newOuting.NumOfAttendees = attendees;

            _repo.AddOutingToList(newOuting);
        }
        private void DisplayOutings(Outings outing)
        {
            Console.WriteLine($"Event Type: {outing.EventType}");
            Console.WriteLine($"Number of attendees: {outing.NumOfAttendees}");
            Console.WriteLine($"Date: {outing.OutingDate}");
            Console.WriteLine($"Cost per person: {outing.CostPerPerson}");
            Console.WriteLine($"Cost of event: {outing.CostOfEvent}");
        }

        private void ViewOutingCostMenuMethod()
        {
            Console.Clear();
            Console.WriteLine("Welcome! What would you like to do?\n" +
                "1. View combined cost of all outings\n" +
                "2. View cost by outing"); 

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayCombinedCost();
                    break;

                case "2":
                    break;

              
            }
        }
        private void DisplayCombinedCost()
        {
            var cost = _repo.AddAllOutingsMethod();
            Console.WriteLine($"Combined cost of all events: {cost}");
        }

        private void DisplayCostByType()
        {

        }

    }
}
