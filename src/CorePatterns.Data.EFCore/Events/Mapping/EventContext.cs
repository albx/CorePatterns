using Microsoft.EntityFrameworkCore;

namespace CorePatterns.Data.EFCore.Events.Mapping
{
    public class EventContext : DbContext
    {
        public DbSet<EventWrapper> Events { get; set; }
    }
}
