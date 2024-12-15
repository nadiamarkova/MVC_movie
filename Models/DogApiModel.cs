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