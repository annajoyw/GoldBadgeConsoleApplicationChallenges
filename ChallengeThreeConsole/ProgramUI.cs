using ChallengeThreeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        
        public void Run()
        {
            SeedData();
            Menu();
        }
        private void SeedData()
        {
            var badge1 = new Badge(12345, new List<string> {"A7"});
            var badge2 = new Badge(22345, new List<string> { "A1","A4","B1","B2" });
            var badge3 = new Badge(32345, new List<string> { "A4", "A5" });
            _badgeRepo.AddBadgeToDictionary(badge1);
            _badgeRepo.AddBadgeToDictionary(badge2);
            _badgeRepo.AddBadgeToDictionary(badge3);
            
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello security admin! What would you like to do?\n" +
                    "1. View all badges\n" +
                    "2. Create new badge\n" +
                    "3. Update doors of existing badge\n" +
                    "4. Delete badge\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllBadges();
                        break;
                    case "2":
                        CreateNewBadge();
                        break;
                    case "3":
                        UpdateExistingBadgeDoors();
                        break;
                    case "4":
                        DeleteBadge();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye. Have a spectacular day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            Console.WriteLine("Please enter badge ID");
            int badgeID = int.Parse(Console.ReadLine());
            newBadge.BadgeId = badgeID;
            Console.WriteLine("Please list a door this badge has access to");
            string newDoor = Console.ReadLine();
            newBadge.ListOfDoors.Add(newDoor);
            Console.WriteLine("Would you like to add another another door? (y/n)");
            bool answer = GetYesNoAnswer();
            if (answer == true)
            {
                Console.WriteLine("Please list a door this badge has access to");
                string secondBadgeDoor = Console.ReadLine();
                newBadge.ListOfDoors.Add(secondBadgeDoor);
                Console.WriteLine("Would you like to add another another door? (y/n)");
                bool secondAnswer = GetYesNoAnswer();
                if (secondAnswer == true)
                {
                    Console.WriteLine("Please list a door this badge has access to");
                    string thirdBadgeDoor = Console.ReadLine();
                    newBadge.ListOfDoors.Add(thirdBadgeDoor);
                }
                else
                {
                    Console.WriteLine($"Magnificent! Badge number {badgeID} has been added to the list of badges.");
                }
            }
            _badgeRepo.AddBadgeToDictionary(newBadge);

        }
        private void ViewAllBadges()
        {
            Console.Clear();
            var allBadges = _badgeRepo.SeeAllBadges();
            foreach(var badge in allBadges)
            {
                DisplayBadge(badge.Value);
            }
          
        }
        private void DeleteBadge()
        {
            ViewAllBadges();
            Console.WriteLine("Please enter ID of badge you'd like to delete");
            int badgeToDelete = int.Parse(Console.ReadLine());
            bool wasDeleted = _badgeRepo.DeleteBadge(badgeToDelete);
            if (wasDeleted)
            {
                Console.WriteLine("Badge was successfully deleted");
            }
            else
            {
                Console.WriteLine("Badge could not be deleted");
            }
        }      
        private void UpdateExistingBadgeDoors()
        {
            Console.Clear();
            ViewAllBadges();
            Console.WriteLine("Please enter the ID of the badge you would like to update");
            int badgeId = int.Parse(Console.ReadLine());
            Badge badgeToUpdate = _badgeRepo.GetBadgeByID(badgeId);
            DisplayBadge(badgeToUpdate);
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            switch (Console.ReadLine())
            {
                case "1":
                    DisplayAllDoors(badgeToUpdate);
                    RemoveDoorFromBadge(badgeToUpdate);
                    break;
                case "2":
                    DisplayAllDoors(badgeToUpdate);
                    AddDoorToBadge(badgeToUpdate);
                    break;
            }


        }
        private void RemoveDoorFromBadge(Badge badgeDoors)
        {
            //DisplayAllDoors(badgeDoors);
            Console.WriteLine("Please enter the name of the door you would like to remove");
            string doorName = Console.ReadLine();
            int initialCount = badgeDoors.ListOfDoors.Count;
            badgeDoors.ListOfDoors.Remove(doorName);
            if (initialCount > badgeDoors.ListOfDoors.Count)
            {
                Console.WriteLine("Door was successfully removed");
            }
            else
            {
                Console.WriteLine("Door was unable to be removed");
            }
            
               
        }
        private void AddDoorToBadge(Badge badgeDoors)
        {
            Console.WriteLine("Please enter the name of the door you would like to add");
            string doorName = Console.ReadLine();
            int initialCount = badgeDoors.ListOfDoors.Count;
            badgeDoors.ListOfDoors.Add(doorName);
            if(initialCount < badgeDoors.ListOfDoors.Count)
            {
                Console.WriteLine("Door was successfully added to badge");
            }
            else
            {
                Console.WriteLine("Door was unable to be added to badge");
            }

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
        private void DisplayBadge(Badge displayBadge)
        {
            Console.WriteLine($"\tBadge ID: {displayBadge.BadgeId}");
            //Console.WriteLine($"\tAccessible Doors:{displayBadge.ListOfDoors}");

            foreach(var door in displayBadge.ListOfDoors)
            {
                Console.WriteLine($"\t\tAccessible Door:{door}");
            }
        }
        private void DisplayAllDoors(Badge listOfDoors)
        {
            foreach(var door in listOfDoors.ListOfDoors)
            Console.WriteLine($"Door Name:{door}");
        }
    }
}
