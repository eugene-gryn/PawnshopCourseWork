using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIWeb.Shared.SharedModels;

namespace UIWeb.Server.Controllers
{
    [ApiController]
    [Route("/customers/")]
    public class CustomersController : ServerControllerBase
    {
        public PawnshopDbContext TestContext { get; }

        public CustomersController(PawnshopDbContext testContext) {
            TestContext = testContext;
        }

        [HttpGet("all")]
        public async Task<List<DataAccessLayer.Models.Customer>> GetAllCustomers() {
            return await TestContext.Customers.ToListAsync();
        }
    }
}
