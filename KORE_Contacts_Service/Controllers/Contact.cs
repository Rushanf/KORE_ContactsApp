using KORE_Contacts_Service.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KORE_Contacts_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contact : ControllerBase
    {
        ContactService contactService;
        public Contact() { 
                contactService = new ContactService();
            }

        // GET: api/<Contact>
        [HttpGet]
        public List<Models.Contact> Get()
        {
            return contactService.GetAllContacts();
        }

        // GET api/<Contact>/5
        [HttpGet("{id}")]
        public Models.Contact Get(int id)
        {
            return contactService.GetContactById(id);
        }

        // POST api/<Contact>
        [HttpPost]
        public void Post([FromBody] Models.Contact contact)
        {
            contactService.Add(contact);
        }

        // PUT api/<Contact>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Models.Contact contact)
        {
            contactService.Update(contact);
        }

        // DELETE api/<Contact>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            contactService.Delete(id);
        }
    }
}
