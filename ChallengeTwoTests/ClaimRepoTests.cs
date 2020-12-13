using System;
using ChallengeTwoRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwoTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepo _repo;
        private ClaimObject _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _claim = new ClaimObject(1, "car", "car accident on 365", "$400.00", new DateTime(10, 10, 2020), new DateTime(10, 15, 2020), true);
            _repo.EnterNewClaim(_claim);
        }
        [TestMethod]
        public void EnterNewClaim_ShouldGetNotNull()
        {
            ClaimObject claim = new ClaimObject();
            claim.ClaimID = 1;
            ClaimRepo repo = new ClaimRepo();

            repo.EnterNewClaim(claim);
            ClaimObject claimFromDirectory = repo.GetClaimById(1);

            Assert.IsNotNull(claimFromDirectory);
        }
    }
}
