using Chat.ChatServer;
using System;
using System.Collections.Generic;

namespace Chat
{
    public interface IClient
    {
        event EventHandler<Message> NewMessage;
        void SendMessage(string text);
    }
}
