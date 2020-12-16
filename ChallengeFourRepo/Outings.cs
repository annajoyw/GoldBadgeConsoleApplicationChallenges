using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourRepo
{
    public class Outings
    {
        public string EventType { get; set; }
        public int NumOfAttendees { get; set; }
        public DateTime OutingDate { get; set; }
        public double CostPerPerson { get; set; }
        public double CostOfEvent { get; set; }
        public List<Outings> OutingsList { get; set; }

        public Outings(string eventType, int numOfAttendees, DateTime outingDate, double costPerPerson, double costOfEvent, List<Outings> outingsList)
        {
            EventType = eventType;
            NumOfAttendees = numOfAttendees;
            OutingDate = outingDate;
            CostPerPerson = costPerPerson;
            CostOfEvent = costOfEvent;
            OutingsList = outingsList;
        }
        public void AddOutingToList(List<Outings> outingsToAdd)
        {
            OutingsList.AddRange(outingsToAdd);
        }


    }
}
