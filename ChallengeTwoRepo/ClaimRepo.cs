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
        public DataTable ClaimTable()
        {
            if (_queueOfClaims.Count == 1000)
            {
                DataTable claimTable = new DataTable();
                claimTable.Columns.Add("Claim ID");
                foreach (var ClaimObject in _queueOfClaims)
                {
                    DataRow dataRow = claimTable.NewRow();
                    dataRow["Claim ID"] = ClaimObject.ClaimID;
                    claimTable.Rows.Add(dataRow);
                }
                claimTable.Columns.Add("Accident Type");
                foreach (var ClaimObject in _queueOfClaims)
                {
                    DataRow dataRow = claimTable.NewRow();
                    dataRow["Type of Claim"] = ClaimObject.ClaimType;
                    claimTable.Rows.Add(dataRow);
                }
                claimTable.Columns.Add("Description");
                foreach (var ClaimObject in _queueOfClaims)
                {
                    DataRow dataRow = claimTable.NewRow();
                    dataRow["DesCription"] = ClaimObject.Desctription;
                    claimTable.Rows.Add(dataRow);
                }
                claimTable.Columns.Add("Amount");
                foreach (var ClaimObject in _queueOfClaims)
                {
                    DataRow dataRow = claimTable.NewRow();
                    dataRow["Amount"] = ClaimObject.ClaimAmount;
                    claimTable.Rows.Add(dataRow);
                }
                claimTable.Columns.Add("Date of Accident");
                foreach (var ClaimObject in _queueOfClaims)
                {
                    DataRow dataRow = claimTable.NewRow();
                    dataRow["Date of Accident"] = ClaimObject.DateOfIncident;
                    claimTable.Rows.Add(dataRow);
                }
                claimTable.Columns.Add("Date of Claim");
                foreach (var ClaimObject in _queueOfClaims)
                {
                    DataRow dataRow = claimTable.NewRow();
                    dataRow["Date of Claim"] = ClaimObject.DateOfClaim;
                    claimTable.Rows.Add(dataRow);
                }
                claimTable.Columns.Add("Is Claim Valid");
                foreach (var ClaimObject in _queueOfClaims)
                {
                    DataRow dataRow = claimTable.NewRow();
                    dataRow["Is Claim Valid"] = ClaimObject.IsValid;
                    claimTable.Rows.Add(dataRow);
                }
                return claimTable;
            }
            else
            {
                return null;
            }

        }
        public Queue<ClaimObject> HandleNextClaim()
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
