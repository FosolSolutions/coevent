namespace Coevent.Entities;

using System;

public class Account : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public AccountType AccountType { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public long OwnerId { get; protected set; }

    public User Owner { get; protected set; }

    public ICollection<Calendar> Calendars { get; } = new List<Calendar>();

    public ICollection<Event> Events { get; } = new List<Event>();

    public ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    public ICollection<Trait> Traits { get; } = new List<Trait>();

    public ICollection<Criteria> Criterias { get; } = new List<Criteria>();

    public ICollection<Survey> Surveys { get; } = new List<Survey>();

    public ICollection<UserAccount> UsersManyToMany { get; } = new List<UserAccount>();

    public ICollection<User> Users { get; } = new List<User>();

    public ICollection<Role> Roles { get; } = new List<Role>();

    public ICollection<Claim> Claims { get; } = new List<Claim>();

    public ICollection<UserClaim> UserClaims { get; } = new List<UserClaim>();
    #endregion

    #region Constructors
    public Account(string name, User owner, string createdBy) : base(createdBy)
    {
        this.Name = name;
        this.Description = String.Empty;
        this.Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        this.OwnerId = owner.Id;
    }
    #endregion

    #region Methods
    #endregion
}
