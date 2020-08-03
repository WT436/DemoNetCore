using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B1_CreateApiSimple.Controllers
{
    [Route("api/[controller]")]// đường dẫn của trang api
    [ApiController]
    public class Test1Controller : ControllerBase
    {
        // GET: api/<Test1Controller>
        [HttpGet]//phương thức truyền
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Test1Controller>/5
        [HttpGet("{id}")] // trả về giá trị theo id tương ứng
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Test1Controller>
        [HttpPost]
        public void Post([FromBody] string value) // nó sẽ đóng thành form để gửi dữ liệu vào đây
        {
        }

        // PUT api/<Test1Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Test1Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
