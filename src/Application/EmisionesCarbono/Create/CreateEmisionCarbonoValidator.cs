namespace Application.EmisionesCarbono.Create;

public class CreateEmisionCarbonoValidator : AbstractValidator<CreateEmisionCarbonoCommand>
{
    public CreateEmisionCarbonoValidator()
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
