﻿using FluentValidation;
using MinimalApiPropiedades.Models.DTOS;

namespace MinimalApiPropiedades.Validaciones
{
    public class ValidacionActualizarPropiedad : AbstractValidator<ActualizarPropiedadDto>
    {
        public ValidacionActualizarPropiedad()
        {
            RuleFor(modelo => modelo.IdPropiedad).NotEmpty().GreaterThan(0);
            RuleFor(modelo => modelo.Nombre).NotEmpty();
            RuleFor(modelo => modelo.Descripcion).NotEmpty();
            RuleFor(modelo => modelo.Ubicacion).NotEmpty();

        }
    }
}
