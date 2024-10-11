using Domain.EmicionesCarbono;
using Domain.Primitives;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.EmisionesCarbono.Delete;

internal class DeleteEmisionCarbonoCommandHandler : IRequestHandler<DeleteEmisionCarbonoCommand, ErrorOr<Unit>>
{
    private readonly IEmisionCarbonoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteEmisionCarbonoCommandHandler(IEmisionCarbonoRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteEmisionCarbonoCommand command, CancellationToken cancellationToken)
    {
        if (await _repository.GetByIdAsync((command.Id)) is not EmisionCarbono emisionCarbono)
        {
            return Error.NotFound("EmisionCarbono.NotFound", "");
        }

        _repository.Delete(emisionCarbono);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}