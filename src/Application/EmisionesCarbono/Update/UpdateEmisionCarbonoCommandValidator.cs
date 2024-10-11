using Application.EmisionesCarbono.Create;

namespace Application.EmisionesCarbono.Update;

public class UpdateEmisionCarbonoCommandValidator : AbstractValidator<UpdateEmisionCarbonoCommand>
{
    public UpdateEmisionCarbonoCommandValidator()
    {
        RuleFor(r => r.Descripcion)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(r => r.EmpresaId)
               .NotEqual(0)
               .GreaterThan(0);

        RuleFor(r => r.Cantidad)
                .NotEqual(0)
               .GreaterThan(0);

        RuleFor(r => r.TipoEmision)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
    }

}