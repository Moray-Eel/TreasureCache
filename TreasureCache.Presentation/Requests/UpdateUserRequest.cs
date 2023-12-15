using TreasureCache.Application.Files.Dtos;
using TreasureCache.Application.Products.Commands.CreateProductCommand;

namespace TreasureCache.Presentation.Requests;

public record UpdateUserRequest(string Id, List<string> SelectedRoles, bool SignedUpForNewsletter, int PersonalDiscount);