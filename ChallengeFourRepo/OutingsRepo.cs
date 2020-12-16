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
        public double CostForAllOutings()
        {
            foreach (Outings outingCost in _outingsDirectory)
            {
                return outingCost.CostOfEvent;
            }
            return new double();
        }
    }
}
