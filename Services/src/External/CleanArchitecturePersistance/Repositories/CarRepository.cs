using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecturePersistance.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecturePersistance.Repositories
{
    public sealed class CarRepository:Repository<Car,AppDbContext>,ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context) { }
    }
}
