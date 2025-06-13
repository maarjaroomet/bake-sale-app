using BakeSale.Data;
using BakeSale.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

public class ItemsModel : PageModel
{
    private readonly BakeSaleDbContext _context;

    public ItemsModel(BakeSaleDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public List<Item> Items { get; set; } = new();
    public List<Item> FixedItems { get; set; } = new();
    public List<Item> VariableItems { get; set; } = new();

    public async Task OnGetAsync()
    {
        var allItems = await _context.Items.ToListAsync();
        FixedItems = allItems
            .Where(i => i.IsFixedStock)
            .OrderBy(i => i.Id)
            .ToList();

        VariableItems = allItems
            .Where(i => !i.IsFixedStock)
            .OrderBy(i => i.Id)
            .ToList();
        Items = VariableItems;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        foreach (var updatedItem in Items)
        {
            var item = await _context.Items.FindAsync(updatedItem.Id);
            if (item != null && !item.IsFixedStock)
            {
                item.Quantity = updatedItem.Quantity;
            }
        }

        await _context.SaveChangesAsync();
        return RedirectToPage();
    }
}