using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UIWeb.Server.Controllers; 

[ApiController]
[Route("/[Controller]")]
public class CustomersController : ServerControllerBase {
    public CustomersController(PawnshopDbContext testContext) {
        TestContext = testContext;
    }

    public PawnshopDbContext TestContext { get; }

    [HttpGet("/all")]
    public async Task<List<Customer>> GetAllCustomers() {
        return await TestContext.Customers.ToListAsync();
    }
}