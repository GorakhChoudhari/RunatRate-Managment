﻿using RunAtRate.Application.Interfaces.Services;
using RunAtRate.Appllication.DTOs;
using RunAtRate.Appllication.Interfaces.Repositories;


public class InspectionService(AppDbContext _context, IInspectionRepostory _inspectionRepostory) : IInspectionService
{
public  Task<InspectionDto> GetInspectionByIdAsync(int id)
    {
        return  _inspectionRepostory.GetInspectionByIdAsync(id);
    }
}

