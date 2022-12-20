using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext
  {
    public DbSet<Item> Items { get; set; }  //represents items table in database   

    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
}