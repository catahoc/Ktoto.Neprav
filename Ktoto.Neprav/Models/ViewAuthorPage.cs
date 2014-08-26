namespace Ktoto.Neprav.Models
{
    public class ViewAuthorPage
    {
        public ViewAuthorPage()
        {
            
        }

        public ViewAuthorPage(Author author)
        {
            Name = author.Name;
        }

        public string Name { get; set; } 
    }
}