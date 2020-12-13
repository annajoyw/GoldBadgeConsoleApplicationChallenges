using ChallengeTwoRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsole
{
    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            SeedClaimList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome! Please select a menu option:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye and have a great day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //research .date
        private void SeeAllClaims()
        {
            Console.Clear();
            DataTable dataTable =_claimRepo.ClaimTable();

            // DataTable claimInfo = _claimRepo.ClaimTable();
            /*foreach(ClaimObject info in claimInfo)
            {
                Console.WriteLine($"Claim ID:{info.ClaimID}, Claim Type:{info.ClaimType}, Description:{info.Desctription}, Amount: {info.ClaimAmount}, Date of Incident:{info.DateOfIncident.Date}, Date of Claim:{info.DateOfClaim.Date}, Is Valid:{info.IsValid}" );
            }*/
        }
        private void EnterNewClaim()
        {
            Console.Clear();
            int timeBeforeClaimLapse=30;
            ClaimObject newClaim = new ClaimObject();

            Console.WriteLine("Enter the claim ID:");
            string ClaimIdAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(ClaimIdAsString);

            Console.WriteLine("Enter the claim type (car, home, or theft):");
            newClaim.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter claim description:");
            newClaim.Desctription = Console.ReadLine();

            Console.WriteLine("Enter amount of damage:");
            newClaim.ClaimAmount = Console.ReadLine();

           // Console.WriteLine("how much time before claim lapse");
           // timeBeforeCaimLapse = int.Parse(Console.ReadLine());

          DateTime dateOfIncident = IncidentClaimCreationHelperMethod();
          DateTime dateOfClaim= ClaimCreationHelperMethod();


            int ans = dateOfIncident.Day - dateOfClaim.Day;
            if (ans <= timeBeforeClaimLapse)
            {
                Console.WriteLine("This claim is valid");
            }
            else
            {
                Console.WriteLine("this claim is not valid");
            }

        }

        private DateTime IncidentClaimCreationHelperMethod()
        {

            Console.WriteLine("Please input the year of incident.");
            int inputYearOfAccident = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the month of incident.");
            int inputMonthOfAccident = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the day of incident.");
            int inputDayofAccident = int.Parse(Console.ReadLine());


             DateTime dateOfIncident = new DateTime(inputYearOfAccident, inputMonthOfAccident, inputDayofAccident);
            return dateOfIncident;
        }

        private DateTime ClaimCreationHelperMethod()
        {

            Console.WriteLine("Please input the year claim was made.");
            int inputYearOfAccident = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the Month claim was made.");
            int inputMonthOfAccident = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the Day claim was made.");
            int inputDayofAccident = int.Parse(Console.ReadLine());


            DateTime dateOfIncident = new DateTime(inputYearOfAccident, inputMonthOfAccident, inputDayofAccident);
            return dateOfIncident;
        }

        //get rid of time in dateTime?
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<ClaimObject> claimQueue = _claimRepo.HandleNextClaim();
            ClaimObject firstClaim = new ClaimObject(1, "Car", "Car Accident on 464.", "$400.00", new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            claimQueue.Peek();

            Console.WriteLine($"Current number of claims to be handled:{claimQueue.Count}");
            if (claimQueue.Count > 0)
            {
                Console.WriteLine($"Claim ID:{firstClaim.ClaimID}, Claim Type:{firstClaim.ClaimType}, Description:{firstClaim.Desctription}, Amount: {firstClaim.ClaimAmount}, Date of Incident:{firstClaim.DateOfIncident}, Date of Claim:{firstClaim.DateOfClaim}, Is Valid:{firstClaim.IsValid}");
            }
           
            Console.WriteLine("Would you like to handle this claim now? (y/n)");
            
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                claimQueue.Dequeue();
            }
            else
            {
                Console.Clear();
                Menu();
            }
        }

        private void SeedClaimList()
        {
            ClaimObject claimOne = new ClaimObject(1, "Car", "Car Accident on 464.", "$400.00", new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            _claimRepo.EnterNewClaim(claimOne);
            
        }
        
    }
}
