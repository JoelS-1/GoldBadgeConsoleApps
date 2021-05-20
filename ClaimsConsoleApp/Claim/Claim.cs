using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClassLibrary
{
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if((DateOfClaim - DateOfIncident).Days > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Claim() { }
        
        public Claim(int claimId, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;


        }
    }
}
