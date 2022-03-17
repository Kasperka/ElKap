using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ElKap.Infra.Party;
using ElKap.Data.Party;

namespace ElKap.SolutionData;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        InitializeTables(b);
    }

    private static void InitializeTables(ModelBuilder b)
    {
        ElKapDb.InitializeTables(b);
    }
}

