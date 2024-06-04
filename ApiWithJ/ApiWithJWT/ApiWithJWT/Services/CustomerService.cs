using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithJWT.Data;
using ApiWithJWT.Dtos.Users;
using ApiWithJWT.Models;
using ApiWithJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace ApiWithJWT.Services;

public class CustomerService : ICustomerService
{
	private readonly ApplicationDbContext _dbContext;

	public CustomerService(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}



	//Read(Get)Users
	public async Task<List<CustomerDto>> GetAllCustomersAsync()
	{
		return await _dbContext
			.Customers.Select(customer => new CustomerDto
			{
				CustomerId = customer.Id,
				UserName = customer.UserName ?? "",
				Email = customer.Email ??""
			})
			.ToListAsync();
	}

	// Read (Get) User by ID
	public async Task<CustomerDto> GetCustomerByIdAsync(Guid cusomerId)
	{
		var cusomer = await _dbContext.Customers.FindAsync(cusomerId);
		if (cusomer == null)
		{
			throw new Exception("User not found.");
		}

		return new CustomerDto
		{
			CustomerId = cusomer.Id,
			UserName = cusomer.UserName ?? "",
			Email = cusomer.Email ?? ""
		};
	}



	// Delete User
	public async Task<bool> DeleteCustomerAsync(Guid cusomerId)
	{
		var cusomer = await _dbContext.Customers.FindAsync(cusomerId);
		if (cusomer == null)
			return false;

		_dbContext.Customers.Remove(cusomer);
		await _dbContext.SaveChangesAsync();
		return true;
	}
}
