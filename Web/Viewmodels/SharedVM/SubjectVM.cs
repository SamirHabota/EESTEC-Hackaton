namespace Web.Viewmodels.SharedVM
{
    public class SubjectVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Professor { get; set; }
        public string Description { get; set; }
        public int ETCS { get; set; }
        public int LecturesCount{ get; set; }
        public int DocumentCount{ get; set; }
        public int CardCount{ get; set; }
    }
}
