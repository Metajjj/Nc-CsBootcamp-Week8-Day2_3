namespace ConferenceManager.Data
{
    public class Event
    {
        private int id;
        public int Id { get { return id; } set { id = value < 1 ? 1 : value; } }
                            //Custom range limitation

        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public string Category {  get; set; }
    }
}
