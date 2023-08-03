﻿using FluentValidation;
using MinimalApiPropiedades.Models.DTOS;

namespace MinimalApiPropiedades.Validaciones
{
    public class ValidacionCrearPropiedad : AbstractValidator<CrearPropiedadDto>
    {
        public ValidacionCrearPropiedad()
        {
            RuleFor(modelo => modelo.Nombre).NotEmpty();
            RuleFor(modelo => modelo.Descripcion).NotEmpty();
            RuleFor(modelo => modelo.Ubicacion).NotEmpty();

        }
    }
}
