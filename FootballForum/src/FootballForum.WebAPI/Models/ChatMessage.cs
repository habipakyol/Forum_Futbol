﻿namespace FootballForum.WebAPI.Models
{
    // Models/ChatMessage.cs
    public class ChatMessage
    {
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}