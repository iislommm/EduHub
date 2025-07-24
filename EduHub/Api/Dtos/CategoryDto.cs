﻿using Domain.Entities;

namespace Application.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconUrl { get; set; }
    public DateTime CreatedAt { get; set; }
}
