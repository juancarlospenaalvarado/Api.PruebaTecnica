
namespace Application.EmisionesCarbono.Delete;

public record DeleteEmisionCarbonoCommand (int Id) : IRequest<ErrorOr<Unit>>;
