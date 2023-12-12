namespace WorldCupManagementSystem.Models
{
    public abstract class Human : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Nationality { get; set; }
    }
}