namespace firstASP.Models
{
    // The shape of one post from the outside website (JSONPlaceholder).
    // The names match the JSON it sends back: { "userId", "id", "title", "body" }
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
    }
}
