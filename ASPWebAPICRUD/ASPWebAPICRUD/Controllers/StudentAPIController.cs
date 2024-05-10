using ASPWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPWebAPICRUD.Controllers
{
    [Route("api/[controller]")] // is url ko get request ke sath hit karenge to httpget ka action ,ethod call hoga.
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MyDbContext context; //mydbcontext ka object here
                                               //is object ka use krke hum mydbcontext me jo dbset hai isme data insert and data fetch kr sakta hu.
        public StudentAPIController(MyDbContext context) //class ka constructor
        {
            this.context = context;
        }


        //get() hme student table se data fetch krke dega. {data read krenge.}
        [HttpGet] //API ko call krte hai tb http protocols ko use krte hai so httpget.
        public async Task<ActionResult<List<Student>>> GetStudents()   //.Netcore me Action() asynchronously krna hota hai.
        {
            var data = await context.Students.ToListAsync(); //asyn hai so await use karenge.
            return Ok(data); //ye status code Status200ok response generate krta hai.
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Student>> GetStudentById(int id)   
        {
            var student = await context.Students.FindAsync(id); 
            if(student == null) 
            {
                return NotFound();  //ye hme status404notfound response generate krke dega.
            }
            return student; 
        }

        [HttpPost]   //data insert or create krte hai to hm httppost use krte hai.
        public async Task<ActionResult<Student>> CreateStudent(Student std)//ye student class ka object accept krega so use Student std instead of id.
        {
            await context.Students.AddAsync(std);// data add hoga.
            await context.SaveChangesAsync();// add data, yethe save honar.
            return Ok(std);
        }

        [HttpPut("{id}")] //data update and always remember data update/delete sathi "id" use karavi lagte.
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)//std me updated data store hoga and id me id store hogi.
        {
            if(id != std.Id) //means stduent se jo Id ayegi vo id se match nhi hogi to bad request.
            {
                return BadRequest(); // 400bad request generate.
            }
            context.Entry(std).State = EntityState.Modified; //here 'std' updated data hai usko modify/update krna hai usi 'id' ke upar jaha pe ye request generate ho rhi hai.
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")] //data delete and always remember data update/delete sathi "id" use karavi lagte.
        public async Task<ActionResult<Student>> DeleteStudent(int id) // yaha pe 'id' ke through only data delete krna hai.
        {
            var std = await context.Students.FindAsync(id); //iis 'id' ki row std me store kro.
            if(std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std); //data remove hoga.
            await context.SaveChangesAsync();// yaha pe database se 100% data remove.
            return Ok();
        }



    }
}
