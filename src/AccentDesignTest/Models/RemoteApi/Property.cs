namespace AccentDesignTest.Models.RemoteApi
{
    public class Property
    {
        public string id { get; set; }
        public Address address { get; set; }
        public DateTime erectedAt { get; set; }
        public Erectedboardtype erectedBoardType { get; set; }
        public float totalFeeCharged { get; set; }
        public float totalFeeChargedCalculated { get; set; }
    }
}