using BakeSale.Data;
using BakeSale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class SaleModel : PageModel
{
    private readonly BakeSaleDbContext _context;

    public SaleModel(BakeSaleDbContext context)
    {
        _context = context;
    }

    public List<Item> Items { get; set; } = new();

    public async Task OnGetAsync()
    {
        Items = await _context.Items
            .OrderBy(i => i.Id)
            .ToListAsync();
    }
}
