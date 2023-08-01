using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Db;
using ProjectTracker.Models;

namespace ProjectTracker.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly Context _context;

        public EmployeeController(Context context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Employee>> SearchEmployees(string query, int pageSize = 10, int pageIndex = 1)
        {
            // Convert the search query into individual keywords
            string[] keywords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Perform the search and apply pagination
            var queryable = _context.Employees.AsQueryable();

            // Added conditon to get all the records
            if (!query.ToLower().Equals("all"))
            {
                foreach (var keyword in keywords)
                {
                    queryable = queryable.Where(e =>
                        e.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        e.Company.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        e.Project.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        e.Role.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    );
                }
            }

            var totalCount = queryable.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var employees = queryable
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new JsonResult(new
            {
                Total = totalCount,
                PageSize = pageSize,
                CurrentPage = pageIndex,
                Pages = totalPages,
                Employees = employees
            });
        }
    }
}
