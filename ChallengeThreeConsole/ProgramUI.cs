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
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello security admin! What would you like to do?\n" +
                    "1. Create a new badge\n" +
                    "2. Update existing badge\n" +
                    "3. Delete all doors from existing badge\n" +
                    "4. View all badges\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        createNewBadge();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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
        private void createNewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            Console.WriteLine("Please enter badge ID");
            int badgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please list a door this badge has access to");
            string badgeDoor = Console.ReadLine();
            Console.WriteLine("Would you like to add another another door? (y/n)");
            bool answer = GetYesNoAnswer();
            if (answer == true)
            {
                Console.WriteLine("Please list a door this badge has access to");
                string secondBadgeDoor = Console.ReadLine();
                Console.WriteLine("Would you like to add another another door? (y/n)");
                bool secondAnswer = GetYesNoAnswer();
                if (secondAnswer == true)
                {
                    Console.WriteLine("Please list a door this badge has access to");
                    string thirdBadgeDoor = Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Menu();
                }
            }
            _badgeRepo.addBadgeToDictionary(newBadge);

        }
        private void ViewAllBadges()
        {
            Console.Clear();
          
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
        private void DisplayBadgeDictionary(Badge badge)
        {

            Console.WriteLine($"\tID: {badge.BadgeId}");
            Console.WriteLine($"\tDoor Access: {badge.ListOfDoors}");
            foreach (var badgeInfo in badge.)
            {
                DisplayBadgeDictionary(badge);
            }
        }

    }
}
