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
        private void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("Claim ID \t Claim Type \t Description \t\t Claim Amount \t\t Date of Incident \t\t Date of Claim \t\t Valid claim?");
            var allClaims = _claimRepo.GetQueue();
            foreach(var claim in allClaims)
            {
                DisplayQueue(claim);
            }

        }
        private void EnterNewClaim()
        {
            Console.Clear();
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

            Console.WriteLine("Enter the date of the incident YYYY-MM-DD:");
            DateTime incidentDate = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfIncident = incidentDate;

            Console.WriteLine("Enter the date the claim was made YYYY-MM-DD:");
            DateTime claimDate = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfClaim = claimDate;

            Console.WriteLine("Company policy states the claim must be made within 30 days of the accident to remain valid. Please press 'y' if this claim is valid, or 'n' if claim is not valid.");
            bool answer = GetYesNoAnswer();
            if (answer)
            {
                Console.WriteLine("This claim has been documented as valid.");
                newClaim.IsValid = true;
            }
            else
            {
                Console.WriteLine("This claim has been documented as not valid.");
                newClaim.IsValid = false;
            }
            _claimRepo.EnterNewClaim(newClaim);
            /*int ans = dateOfIncident.Day - dateOfClaim.Day;
            if (ans <= timeBeforeClaimLapse)
            {
                Console.WriteLine("This claim is valid");
            }
            else
            {
                Console.WriteLine("this claim is not valid");
            }*/
        }
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<ClaimObject> claimQueue = _claimRepo.GetQueue();
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
                Console.WriteLine("Great! Claim has been removed from queue.");
                _claimRepo.removeNextClaimFromQueue();
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
        private bool GetYesNoAnswer()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                }
                Console.WriteLine("Please enter valid input");
            }
        }
        private void DisplayQueue(ClaimObject displayClaim)
        {
            Console.WriteLine($"{displayClaim.ClaimID} \t\t {displayClaim.ClaimType} \t\t {displayClaim.Desctription} \t {displayClaim.ClaimAmount} \t\t {displayClaim.DateOfIncident.Date.ToShortDateString()} \t\t\t {displayClaim.DateOfClaim.Date.ToShortDateString()} \t\t {displayClaim.IsValid}");

        }
    }
}
