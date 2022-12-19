using Microsoft.AspNetCore.Mvc;
using Sale.Application.Interfaces;
using Sale.Domain.Models;

namespace Sale.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    //Crie uma API que permita consultar o estoque de um produto pelo ID do produto;;
    [HttpGet]
    [Route("{product_id}")]
    public async Task<ActionResult<Estoque>> Get(int product_id)
    {
        var sale = await _inventoryService.GetByProductNameAsync(product_id);

        if (sale is null)
            return NotFound();

        return sale;
    }
}
