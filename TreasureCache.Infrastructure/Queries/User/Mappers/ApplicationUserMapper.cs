using TreasureCache.Infrastructure.Authentication.Models;
using TreasureCache.Infrastructure.Queries.User.Dtos;

namespace TreasureCache.Infrastructure.Queries.User.Mappers;

public static class ApplicationUserMapper
{
    public static IQueryable<ApplicationUserDto> ProjectToDto(
        this IQueryable<ApplicationUser> users)
        => users.Select(u => new ApplicationUserDto(
            u.Id,
            u.UserName,
            u.Email,
            u.EmailConfirmed,
            u.PhoneNumber,
            new DomainUserDto(
                u.User.Id,
                u.User.FirstName,
                u.User.LastName,
                u.User.PersonalDiscount,
                u.User.SignedForNewsletter
                )
        ));
    
    public static ApplicationUserDto ProjectToDto(
        this ApplicationUser user)
        => new ApplicationUserDto(
            user.Id,
            user.UserName,
            user.Email,
            user.EmailConfirmed,
            user.PhoneNumber,
            new DomainUserDto(
                user.User.Id,
                user.User.FirstName,
                user.User.LastName,
                user.User.PersonalDiscount,
                user.User.SignedForNewsletter
            )
        );
}