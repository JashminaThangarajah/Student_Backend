using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegisterFormAPI.Models;

namespace StudentRegisterFormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student objStudent)
        {
            _studentDbContext.Students.Add(objStudent);
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }

        //[HttpPatch]
        //[Route("UpdateStudent/{id}")]
        //public async Task<Student> UpdateStudent(Student objStudent)
        //{
        //    _studentDbContext.Entry(objStudent).State = EntityState.Modified;
        //    await _studentDbContext.SaveChangesAsync();
        //    return objStudent;
        //}

        //[HttpGet]
        //[Route("{id:int}")]
        //public async Task<Student> GetStudent([FromBody ] int id)
        //{
        //    var students =
        //        await _studentDbContext.Students.FirstOrDefaultAsync(x => x.id==id);
        //    if (students == null) {
        //        return NotFoundResult();
        //    }
        //    else
        //    {
        //        return students;
        //    }
        //}

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentDbContext.Students.FirstOrDefaultAsync(x => x.id == id);
            if (student == null)
            {
                return NotFound(); // Return 404 if student with the given id is not found
            }
            else
            {
                return student; // Return the found student
            }
        }

        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(Student updateStudentRequest)
        {
            var student = await _studentDbContext.Students.FindAsync(updateStudentRequest.id);
            if(student == null)
            {
                return NotFound();
            }
            student.firstname = updateStudentRequest.firstname;
            student.lastname = updateStudentRequest.lastname;

            student.address = updateStudentRequest.address;

            student.dob = updateStudentRequest.dob;

            student.gender = updateStudentRequest.gender;   
            student.profileimage = updateStudentRequest.profileimage;

            await _studentDbContext.SaveChangesAsync();
            return Ok(student);
        }



        private Student NotFoundResult()
        {
            throw new NotImplementedException();
        }

               //[HttpDelete]
               // [Route("DeleteStudent/{id}")]
               // public bool DeleteStudent(int id)
               // {
               //     bool a = false;
               //     var student = _studentDbContext.Students.Find(id);
               //    if (student != null)
               //     {
               //         a = true;
               //        _studentDbContext.Entry(student).State = EntityState.Deleted;
               //        _studentDbContext.SaveChanges();
               //     }
               //     else
               //     {
               //        a = false;
               //     }
               //     return a;
               // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentDbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentDbContext.Students.Remove(student);
            await _studentDbContext.SaveChangesAsync();

            return Ok(student);
        }

        //[HttpDelete]
        //[Route("{id:any")]
        //public async Task<ActionResult<Student>> DeleteStudent(int id)
        //{
        //    var student = await _studentDbContext.Students.FindAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    _studentDbContext.Students.Remove(student);
        //    await _studentDbContext.SaveChangesAsync();
        //    return Ok(student);
        //}
    }


}
