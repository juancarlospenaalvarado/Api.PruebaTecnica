using Domain.EmicionesCarbono;
using Domain.Primitives;

namespace Application.EmisionesCarbono.Create;

internal class CreateEmisionCarbonoCommandHandler : IRequestHandler<CreateEmisionCarbonoCommand, ErrorOr<int>>
{
    private readonly IEmisionCarbonoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateEmisionCarbonoCommandHandler(IEmisionCarbonoRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<int>> Handle(CreateEmisionCarbonoCommand command, CancellationToken cancellationToken)
    {

        var emisionCarbono = new EmisionCarbono(
            command.EmpresaId,
            command.Descripcion,
            command.Cantidad,
            DateTime.UtcNow,
            command.TipoEmision
            
        );

        _repository.Add(emisionCarbono);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return emisionCarbono.Id;
    }
}

