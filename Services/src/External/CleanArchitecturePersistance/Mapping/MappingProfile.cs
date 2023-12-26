using AutoMapper;
using CleanArchitecture.App.Features.AuthFeatres.Commands.Register;
using CleanArchitecture.App.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecturePersistance.Mapping
{
    public sealed class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>();
            CreateMap<RegisterCommand,User>();
        }
    }
}
