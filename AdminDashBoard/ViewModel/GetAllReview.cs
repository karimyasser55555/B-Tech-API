namespace AdminDashBoard.ViewModel
{
    public class GetAllReview
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }
        public string Productname { get; set; }

        public GetAllReview() { } 
    
    }

}
