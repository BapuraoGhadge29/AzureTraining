namespace CustomerKYCManagement.Constants
{
    public enum AccountStatus
    {
        Open = 1,
        Closed = 2,
        Suspended = 3,
        Switched = 4
    }
     public enum CustomerStatus
    {
        PendingKYC = 1,
        Active = 2,
        Suspended = 3,
        Closed = 4
    }
      public enum AddressType
    {
        Residential = 1,
        Office = 2,
        Communication = 3
    }
    public enum CustomerCategory
    {
        Individual = 1,
        Business = 2,
        Corporate = 3
    }
     public enum VerificationStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}