using Microsoft.AspNetCore.Mvc;
using Sale.Application.Interfaces;
using Sale.Domain.Models;
using System.Net;

namespace Sale.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : Controller
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    //Crie uma API que permita cadastrar uma venda.
    [HttpPost]
    public async Task<IActionResult> Post(Vendas_Produto venda)
    {
        if (ModelState.IsValid)
        {
            await _saleService.AddAsync(venda);

            return StatusCode(HttpStatusCode.Created.GetHashCode(), venda);

        }
        return BadRequest(ModelState);
    }


    //Crie uma API que permita consultar uma venda pelo nome do produto;
    [HttpGet]
    [Route("getsale/{product_name}")]
    public async Task<IActionResult> Get(string product_name)
    {
        var sale = await _saleService.GetByProductNameAsync(product_name);

        if (sale is null)
            return NotFound();

        return Ok(sale);
    }


    //Crie uma API que liste os produtos vendidos a partir de um ID de uma venda.;
    [HttpGet]
    [Route("{sale_id}")]
    public async Task<IActionResult> GetListProductsSold(int sale_id)
    {
        var sale = await _saleService.GetBySaleIdAsync(sale_id);

        if (sale is null)
            return NotFound();

        return Ok(sale);
    }
}
