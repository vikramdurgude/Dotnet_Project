using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPISimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase    //hardcore fruit list
    {
        public List<string> fruits = new List<string>()
        {
        "Apple",
        "Banana",
        "Mango",
        "Cherry",
        "Grapes"
        };

        [HttpGet]
        public List<string> GetFruits()
        {
            return fruits;
        }

        [HttpGet("{id}")]   //  samaja, id pass kela tr yethun data pass honar.
        public string GetFruitsByIndex(int id)
        {
            return fruits.ElementAt(id);
        }
    }

}
