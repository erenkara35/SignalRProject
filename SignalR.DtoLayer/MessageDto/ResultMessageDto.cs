﻿namespace SignalR.DtoLayer.MessageDto
{
	public class ResultMessageDto
	{
		public int MessageId { get; set; }
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; } = DateTime.Now;
		public bool Status { get; set; }
	}
}
