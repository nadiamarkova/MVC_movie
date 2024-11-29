namespace MvcMovie.Models
{
    public class DogApiModel
    {
        public string? Message { get; set; }
        public string Status { get; set; }
        public DogApiModel()
        {
            Status = "unknown";
        }   
        public override string ToString() 
        {
            return "DogApiModel Message:" + Message + " Status:" + Status;
        }
    }
}

//TODO remove constructor on line 7-10 and bring back Status and Message to Upper case and see if it works
//We are trying to understand why when we made everything lower case, it worked