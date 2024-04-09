// Controllers/CSharpCornerArticlesController.cs

using Athena.Data;
using Athena.Models;
using Athena.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CustomerController: ControllerBase
{
    private readonly PostgressDbContext _context;
    private readonly CustomerService _customerService;

    public CustomerController(
        PostgressDbContext context,
        CustomerService customerService
    ){
        _context = context;
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return Ok(await _customerService.GetAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _customerService.GetAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    {
        // Treinar Try Catch
        try
        {
            await _customerService.CreateAsync(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }
        catch (Exception)
        {
            //Logar Erro
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest();
        }

        try
        {
            await _customerService.UpdateAsync(customer);
            return NoContent();
        }
        catch (Exception)
        {
            if (!_customerService.CustomerExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        await _customerService.RemoveAsync(customer);

        return NoContent();
    }
}