using BlazorApp2.Server.Data;
using BlazorApp2.Shared.Models;
using BlazorApp2.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerOrdersController : Controller
    {
        private readonly Context _context;

        public ComputerOrdersController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        [Produces("application/json")]
        public List<ComputerOrderViewModel> Index() => GetOrders(_context.ComputerOrders).ToList();

        [HttpGet("customers")]
        [Produces("application/json")]
        public IEnumerable<Customer> GetCustomers() => _context.Customers.ToList();

        [HttpGet("employees")]
        [Produces("application/json")]
        public IEnumerable<Employee> GetEmployees() => _context.Employees.ToList();

        [HttpPost]
        public IActionResult Post([FromBody] ComputerOrder computerOrder)
        {
            if (computerOrder == null)
            {
                return BadRequest();
            }
            _context.ComputerOrders.Add(computerOrder);
            _context.SaveChanges();
            return Ok(computerOrder);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ComputerOrder computerOrder)
        {
            _context.ComputerOrders.Update(computerOrder);
            _context.SaveChanges();

            return Ok(computerOrder);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var computerOrder = _context.ComputerOrders.FirstOrDefault(i => i.ComputerOrderId == id);
            _context.ComputerOrders.Remove(computerOrder);
            _context.SaveChanges();
            return Ok(computerOrder);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ComputerOrder computerOrder = _context.ComputerOrders.FirstOrDefault(x => x.ComputerOrderId == id);
            return new ObjectResult(computerOrder);
        }

        public IEnumerable<ComputerOrderViewModel> GetOrders(IEnumerable<ComputerOrder> computerOrders)
        {
            IEnumerable<ComputerOrderViewModel> computerOrdersViews = from c in computerOrders
                                join cust in _context.Customers
                                on c.CustomerId equals cust.CustomerId
                                join emp in _context.Employees
                                on c.EmployeeId equals emp.EmployeeId
                                select new ComputerOrderViewModel
                                {
                                    ComputerOrderId = c.ComputerOrderId,
                                    OrderDate = c.OrderDate,
                                    ExecutionDate = c.ExecutionDate,
                                    CustomerName = cust.Name,
                                    Prepayment = c.Prepayment,
                                    WorkMark = c.WorkMark,
                                    AllCost = c.AllCost,
                                    GuaranteePeriod = c.GuaranteePeriod,
                                    EmployeeName = emp.Name,
                                    EmployeeId = emp.EmployeeId,
                                    CustomerId = cust.CustomerId
                                };
            return computerOrdersViews;
        }
    }
}
