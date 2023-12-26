﻿using CleanArchitecture.Domain.Abstrations;

namespace CleanArchitecture.Domain.Entites
{
    public sealed class Car: Entity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int EnginePower { get; set; }
    }
}
