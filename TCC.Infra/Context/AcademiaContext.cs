using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using TCC.Domain.Entities;
using TCC.Domain.Identity;
using TCC.Infra.Migrations;

namespace TCC.Infra.Context
{

    public class AcademiaContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public AcademiaContext() : base("TCCconnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AcademiaContext, Configuration>());
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public static AcademiaContext Create()
        {
            return new AcademiaContext();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }


        public IDbSet<ApplicationUserClaim> Claim { get; set; }
        public IDbSet<TreinamentoSemana> TreinamentoSemanas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.Configurations.AddFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
              .ToTable("USUARIO", "TCC");

            modelBuilder.Entity<ApplicationRole>()
               .ToTable("USUARIO_TIPO_PERFIL", "TCC");

            modelBuilder.Entity<ApplicationUserRole>()
                .ToTable("USUARIO_PERFIL", "TCC");

            modelBuilder.Entity<ApplicationUserClaim>()
                .ToTable("USUARIO_ACESSO", "TCC");

            modelBuilder.Entity<ApplicationUserLogin>()
                .ToTable("USUARIO_LOGIN", "TCC");

            modelBuilder.Entity<ApplicationUser>().Property(u => u.Id).HasColumnName("ID").HasColumnType("int");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.AccessFailedCount).HasColumnName("FALHA_ACESSO_CONTADOR");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.EmailConfirmed).HasColumnName("CONFIRMA_EMAIL");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.LockoutEnabled).HasColumnName("ATIVA_BLOQUEIO");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.LockoutEndDateUtc).HasColumnName("FIM_BLOQUEIO");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PasswordHash).HasColumnName("SENHA_HASH");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PhoneNumber).HasColumnName("TELEFONE_NUMERO");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PhoneNumberConfirmed).HasColumnName("CONFIRMACAO_TELEFONE");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.SecurityStamp).HasColumnName("SELO_SEGURANCA");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.TwoFactorEnabled).HasColumnName("SEGUNDO_FATOR_HABILITADO");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName).HasColumnName("NOME_USUARIO");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.FirstAccess).HasColumnName("PRIMEIRO_ACESSO").HasColumnAnnotation("Default", 0);
            //modelBuilder.Entity<ApplicationUser>().Property(u => u.Ceo).HasColumnName("CEO").HasColumnAnnotation("Default", 0);
            modelBuilder.Entity<ApplicationRole>().Property(u => u.Name).HasColumnName("NOME");
            modelBuilder.Entity<ApplicationUserRole>().Property(u => u.UserId).HasColumnType("int").HasColumnName("ID_USUARIO");
            modelBuilder.Entity<ApplicationUserRole>().Property(u => u.RoleId).HasColumnType("int").HasColumnName("ID_PERFIL");
            modelBuilder.Entity<ApplicationUserClaim>().Property(u => u.Id).HasColumnType("int").HasColumnName("ID");
            modelBuilder.Entity<ApplicationUserClaim>().Property(u => u.UserId).HasColumnType("int").HasColumnName("ID_USUARIO");
            modelBuilder.Entity<ApplicationUserClaim>().Property(u => u.ClaimType).HasColumnName("TIPO_ACESSO");
            modelBuilder.Entity<ApplicationUserClaim>().Property(u => u.ClaimValue).HasColumnName("VALOR_ACESSO");
            modelBuilder.Entity<ApplicationUserLogin>().Property(u => u.UserId).HasColumnType("int").HasColumnName("ID_USUARIO");
            modelBuilder.Entity<ApplicationUserLogin>().Property(u => u.LoginProvider).HasColumnName("LOGIN_PROVEDOR");
            modelBuilder.Entity<ApplicationUserLogin>().Property(u => u.ProviderKey).HasColumnName("CHAVE_PROVEDOR");
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataRegistro") != null))
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("DataRegistro").CurrentValue = DateTime.Now;

                    if (HttpContext.Current != null)
                    {
                        entry.Property("IdUsuario").CurrentValue = HttpContext.Current.User.Identity.GetUserId<int>();
                    }
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.Property("DataExclusao").CurrentValue = DateTime.Now;

                    if (HttpContext.Current != null)
                    {
                        entry.Property("IdUsuario").CurrentValue = HttpContext.Current.User.Identity.GetUserId<int>();
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}

