namespace Web.Viewmodels.SharedVM
{
    public class DocumentVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DocType { get; set; }
        public string Description { get; set; }
        public int WordCount { get; set; }
        public int CharCount { get; set; }
        public string Author { get; set; }
    }
}
