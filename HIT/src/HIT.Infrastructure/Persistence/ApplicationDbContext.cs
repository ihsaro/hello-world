using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HIT.Domain.Entities;
using System.Reflection;
using HIT.Domain.Attributes;
using System.Security.Cryptography;
using System.Text;

namespace HIT.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<CandidateCertification> CandidateCertifications => Set<CandidateCertification>();
    public DbSet<CandidateSkill> CandidateSkills => Set<CandidateSkill>();
    public DbSet<JobPosting> JobPostings => Set<JobPosting>();
    public DbSet<JobPostingApplication> JobPostingApplications => Set<JobPostingApplication>();
    public DbSet<JobSkill> JobSkills => Set<JobSkill>();
    public DbSet<JobPostingSkill> JobPostingSkills => Set<JobPostingSkill>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<ApplicationUser>()
            .HasIndex(a => a.Username)
            .IsUnique();
        
        builder
            .Entity<ApplicationUser>()
            .HasIndex(a => a.EmailAddress)
            .IsUnique();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            ((BaseEntity)entry.Entity).LastUpdatedTimestamp = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                ((BaseEntity)entry.Entity).CreatedTimestamp = DateTime.UtcNow;
            }

            PropertyInfo[] props = entry.Entity.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    AnonymizeAttribute attribute = attr as AnonymizeAttribute;
                    if (attribute != null)
                    {
                        string propName = prop.Name;
                        // string auth = attribute.GetType().Name;

                        prop.SetValue(entry.Entity, EncryptString(prop.GetValue(entry.Entity).ToString()));
                    }
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }



    public static string EncryptString(string text, string keyString = "E546C8DF278CD5931069B522E695D4F2")
    {
        var key = Encoding.UTF8.GetBytes(keyString);

        using (var aesAlg = System.Security.Cryptography.Aes.Create())
        {
            using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
            {
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }

                    var iv = aesAlg.IV;

                    var decryptedContent = msEncrypt.ToArray();

                    var result = new byte[iv.Length + decryptedContent.Length];

                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }
    }

    public static string DecryptString(string cipherText, string keyString = "E546C8DF278CD5931069B522E695D4F2")
    {
        var fullCipher = Convert.FromBase64String(cipherText);

        var iv = new byte[16];
        var cipher = new byte[16];

        Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
        Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
        var key = Encoding.UTF8.GetBytes(keyString);

        using (var aesAlg = System.Security.Cryptography.Aes.Create())
        {
            using (var decryptor = aesAlg.CreateDecryptor(key, iv))
            {
                string result;
                using (var msDecrypt = new MemoryStream(cipher))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            result = srDecrypt.ReadToEnd();
                        }
                    }
                }

                return result;
            }
        }
    }
}