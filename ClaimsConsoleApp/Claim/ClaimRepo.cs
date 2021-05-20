using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClassLibrary
{
    public class ClaimRepo
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        public bool AddNewClaim(Claim newClaim)
        {
            int startingCount = _claimQueue.Count;

            _claimQueue.Enqueue(newClaim);

            bool addedSuccessfully = (_claimQueue.Count > startingCount) ? true : false;
            return addedSuccessfully;
        }

        public Queue<Claim> SeeAllClaims()
        {
            return _claimQueue;
        }

        public Claim PeekAtNextClaim()
        {
            if (_claimQueue.Count == 0)
            {
                return null;
            }
            else
            {
                return _claimQueue.Peek();
            }
        }

        public bool DeleteNextClaimInQueue()
        {
            int startingCount = _claimQueue.Count;

            _claimQueue.Dequeue();

            bool removedSuccessfully = (_claimQueue.Count < startingCount) ? true : false; ;
            return removedSuccessfully;
        }

    }
}
