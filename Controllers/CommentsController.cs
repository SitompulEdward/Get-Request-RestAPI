using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        [HttpGet]
        [Route("GetData")]
        public async Task<IActionResult> GetData()
        {
            List<Comment> comment = new List<Comment>();
            using (var httpClient = new HttpClient())
            {
                using(var respon = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments"))
                {
                    string apiResponse = await respon.Content.ReadAsStringAsync();
                    comment = JsonConvert.DeserializeObject<List<Comment>>(apiResponse);
                }
            }
            return Ok(comment);
        }
    }
}
