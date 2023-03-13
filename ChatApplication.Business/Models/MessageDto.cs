namespace ChatMVCApplication.Business.Models
{
    public class MessageDto
    {
        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string Text { get; set; }
        public bool IsMineMessage { get; set; }
    }
}
