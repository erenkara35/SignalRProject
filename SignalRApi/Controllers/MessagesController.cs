﻿using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessagesController(IMessageService messageService)
		{
			_messageService = messageService;
		}
		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			Message message = new Message()
			{
				Mail=createMessageDto.Mail,
				MessageContent=createMessageDto.MessageContent,
				MessageSendDate=DateTime.Now,
				NameSurname=createMessageDto.NameSurname,
				Phone = createMessageDto.Phone,
				Status = false,
				Subject = createMessageDto.Subject,
			};
			_messageService.TAdd(message);
			return Ok("Mesaj başarılı bir şekilde gönderildi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("Mesaj başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message message = new Message()
			{
				Mail = updateMessageDto.Mail,
				MessageContent = updateMessageDto.MessageContent,
				MessageSendDate = updateMessageDto.MessageSendDate,
				NameSurname = updateMessageDto.NameSurname,
				Phone = updateMessageDto.Phone,
				Status = updateMessageDto.Status,
				Subject = updateMessageDto.Subject,
				MessageId=updateMessageDto.MessageId
			};
			_messageService.TUpdate(message);
			return Ok("Mesaj güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetById(id);
			return Ok(value);
		}
	}
}
