using Domain.EmicionesCarbono;
using Domain.Primitives;

namespace Application.EmisionesCarbono.Update;

internal class UpdateEmisionCarbonoCommandHandler : IRequestHandler<UpdateEmisionCarbonoCommand, ErrorOr<Unit>>
{
    private readonly IEmisionCarbonoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmisionCarbonoCommandHandler(IEmisionCarbonoRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateEmisionCarbonoCommand command, CancellationToken cancellationToken)
    {
        if (!await _repository.ExistsAsync((command.Id)))
        {
            return Error.NotFound("emisioncarbono.notfound", "");
        }

        var emisionCarbono = new EmisionCarbono(
          command.Id,
          command.EmpresaId,
          command.Descripcion,
          command.Cantidad,
          DateTime.UtcNow,
          command.TipoEmision,
          1

        );

        _repository.Update(emisionCarbono);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}


