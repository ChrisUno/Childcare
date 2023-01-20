using System.ComponentModel.DataAnnotations.Schema;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Childcare.Dal.Contexts;

public class ChildcareContext : BaseContext, IDatabase
{
    public ChildcareContext(DbContextOptions option) : base(option)
    {
    }

    public ChildcareContext(string connectionString) : base(connectionString)
    {
    }

    public virtual DbSet<Family> Families { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserEvent> UserEvents { get; set; }
    public virtual DbSet<UserRelationshipType> UserRelationshipTypes { get; set; }
}
