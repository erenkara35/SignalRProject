using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _ContactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_ContactService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _ContactService.TAdd(new Contact()
            {
                FooterDescription=createContactDto.FooterDescription,
                Location=createContactDto.Location,
                Mail=createContactDto.Mail,
                Phone=createContactDto.Phone,
                FooterTitle=createContactDto.FooterTitle,
                OpenDays=createContactDto.OpenDays,
                OpenDaysDescription = createContactDto.OpenDaysDescription,
                OpenHours=createContactDto.OpenHours
            });
            return Ok("İletişim eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _ContactService.TGetById(id);
            _ContactService.TDelete(value);
            return Ok("İletişim silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _ContactService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _ContactService.TUpdate(new Contact()
            {
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                Phone = updateContactDto.Phone,
                ContactId = updateContactDto.ContactId,
                OpenHours = updateContactDto.OpenHours,
                OpenDays = updateContactDto.OpenDays,
                OpenDaysDescription= updateContactDto.OpenDaysDescription,
                FooterTitle=updateContactDto.FooterTitle
            });
            return Ok("İletişim güncellendi.");
        }

    }
}