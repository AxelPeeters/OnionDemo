﻿using Application.Persistence.Generic;

namespace Persistence.Generic;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}