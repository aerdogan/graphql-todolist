using graphql_todolist.Models;
using Microsoft.EntityFrameworkCore;

namespace graphql_todolist.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                .WithMany(p => p.ItemDatas)
                .HasForeignKey(d => d.ListId)
                .HasConstraintName("FK_ItemData_ItemList");
            });
        }





        public virtual DbSet<ItemData> Items { get; set; }
        public virtual DbSet<ItemList> Lists { get; set; }
    }
}