using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourRepo
{
    class OutingsRepo
    {
        private List<Outings> _outingsDirectory = new List<Outings>();
        public List<double> _allOutingCost = new List<double>();
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
            _allOutingCost.Add(outingsCost.CostOfEvent);
        }
        public double Add()
        {
            double total = _allOutingCost.Sum();
            return total;
        }
        
    }
}
