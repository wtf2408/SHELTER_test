using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace SHELTER_test_task_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private const string bearerToken = "shelter_test_task_2408";

        [HttpPost("create")]
        public IActionResult Create(ShelterContext dbcontext, Company company)
        {
            if (!IsValidToken())
                return Unauthorized();

            if (!dbcontext.Companies.ToList().Contains(company))
            {
                dbcontext.Companies.Add(company);
                dbcontext.SaveChanges();
            }
            return Ok(company);
        }

        [HttpPost("read")]
        public IActionResult GetAll(ShelterContext dbcontext)
        {
            if (!IsValidToken())
                return Unauthorized();

            var companies = new List<Company>(dbcontext.Companies);
            return Ok(companies);
        }

        [HttpPost("update")]
        public IActionResult Update(ShelterContext dbcontext, Company company)
        {
            if (!IsValidToken())
                return Unauthorized();

            var companyToUpdate = dbcontext.Companies.ToList().First(c => c.Equals(company));
            if (companyToUpdate is not null)
            {
                foreach (var prop in typeof(Company).GetProperties())
                {
                    if (prop.Name != "ID")
                        prop.SetValue(companyToUpdate, prop.GetValue(company));
                }
                dbcontext.SaveChanges();
            }
            return Ok(companyToUpdate);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ShelterContext dbcontext, Company company)
        {
            if (!IsValidToken())
                return Unauthorized();
            if (dbcontext.Companies.ToList().Contains(company))
            {
                var companyToRemove = dbcontext.Companies.ToList().First(c => c.Equals(company));
                dbcontext.Companies.Remove(companyToRemove);
                dbcontext.SaveChanges();
            }
            return Ok();
        }

        private bool IsValidToken()
        {
            var token = Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(token))
            {
                return token.Replace("Bearer ", "") == bearerToken;
            }
            return false;
        }
    }
}
