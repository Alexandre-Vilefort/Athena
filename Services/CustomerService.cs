using Athena.Data;
using Athena.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athena.Services;

public class CustomerService(PostgressDbContext context)
{
    private readonly PostgressDbContext _context = context;

    public async Task<IEnumerable<Customer>> GetAsync() =>
        await _context.Customers.ToListAsync();

    public async Task<Customer?> GetAsync(int id) =>
        await _context.Customers.FindAsync(id);

    public async Task CreateAsync(Customer newCustomer)
    {
        newCustomer.CreatedAt = DateTime.Now;
        newCustomer.UpdatedAt = newCustomer.CreatedAt;
        _context.Customers.Add(newCustomer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer updatedCustomer)
    {
        updatedCustomer.UpdatedAt = DateTime.Now;
        _context.Entry(updatedCustomer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Customer customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.Id == id);
    }
}