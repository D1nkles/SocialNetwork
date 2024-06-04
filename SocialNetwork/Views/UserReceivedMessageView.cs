﻿using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class UserReceivedMessageView
    {
        MessageService _messageService;

        public UserReceivedMessageView(MessageService messageService) 
        {
            _messageService = messageService;
        }

        public void Show(User user) 
        {
            var receivedMessages = _messageService.GetReceivedMessages(user);
            foreach (var receivedMessage in receivedMessages)
            {
                Console.WriteLine($"Id отправителя: {receivedMessage.sender_id}\n" +
                    $"Сообщение: {receivedMessage.content}\n");
            }
        }
    }
}
