using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourRepo
{
    public class OutingsRepo
    {
        public List<Outings> _outingsDirectory = new List<Outings>();

        //FIX METHOD FOR COST OF EACH AND ALL OUTINGS 

        //public List<double> _allOutingCost = new List<double>();

        public List<double> _costPerPerson = new List<double>();

        //display list of outings
        public List<Outings> GetAllOutings()
        {
            return _outingsDirectory;
        }

        //add outing to list
        public void AddOutingToList(Outings outing)
        {
            _outingsDirectory.Add(outing);
        }

        //calculations
        public void AddOutingCostToList(Outings outingsCost)
        {
            //_allOutingCost.Add(outingsCost.CostOfEvent);
        }

        public double AddAllOutingsMethod(Outings cost)
        {
            List<int> total = new List<int>();
            foreach (Outings outing in _outingsDirectory)
            {

                return outing.CostOfEvent;

            }
        }

        public void AddCostPerPerson(Outings outingCostPerPerson)
        {
            _costPerPerson.Add(outingCostPerPerson.CostPerPerson);
        }

        public double CostPerPersonTotal()
        {
            double total = _costPerPerson.Sum();
            return total;
        }
    }
}
