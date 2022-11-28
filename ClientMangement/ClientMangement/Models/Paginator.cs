namespace ClientMangement.Models
{
    public class Paginator
    {
        internal static int perpage;

        public int PerPage { get; set; }
        public int CurrentPage { get; set; }
        public Paginator()
        {
            this.PerPage = 2;
            this.CurrentPage = 1;
        }
        public Paginator(int PerPage,int CurrentPage)
        {
            this.PerPage = PerPage > 5 ? 5 : PerPage;
            this.CurrentPage = CurrentPage < 1 ? 1 : CurrentPage;
        }
    }
}
