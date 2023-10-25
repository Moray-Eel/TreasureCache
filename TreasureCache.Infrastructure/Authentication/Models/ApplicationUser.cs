using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TreasureCache.Core.Entities;

namespace TreasureCache.Infrastructure.Authentication.Models;

public class ApplicationUser : IdentityUser
{
    public Guid UserId { get; set; }
    public DomainUser User { get; set; } = null!;
}