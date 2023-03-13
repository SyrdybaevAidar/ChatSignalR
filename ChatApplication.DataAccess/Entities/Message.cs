﻿namespace ChatMVCApplication.DataAccess.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? ToUserId { get; set; }
        public User? ToUser { get; set; }
        public Message(string text, bool isRead, int userId)
        {
            CreateDate = DateTimeOffset.UtcNow;
            Text = text;
            IsRead = isRead;
            UserId = userId;
        }
    }
}
