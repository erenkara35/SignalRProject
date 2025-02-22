﻿namespace SignalRWebUI.Dtos.MessageDtos
{
	public class CreateMessageDto
	{
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; } = DateTime.Now;
		public bool Status { get; set; }
	}
}
