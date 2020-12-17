using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class ClaimRepo
    {
        public Queue<ClaimObject> _queueOfClaims = new Queue<ClaimObject>();
        public void EnterNewClaim(ClaimObject newClaim)
        {
            //ClaimObject firstClaim = new ClaimObject(1, "Car", "Car Accident on 464.", "$400.00", new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            _queueOfClaims.Enqueue(newClaim);
        }
        public Queue<ClaimObject> GetQueue()
        {
            return _queueOfClaims;
        }
        public void removeNextClaimFromQueue()
        {
            _queueOfClaims.Dequeue();
        }
        public ClaimObject GetClaimById(int id)
        {
            foreach(ClaimObject claim in _queueOfClaims)
            {
                if (claim.ClaimID == id)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
