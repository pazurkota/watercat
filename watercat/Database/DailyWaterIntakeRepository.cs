using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using watercat.Model;

namespace watercat.Database;

public class DailyWaterIntakeRepository(AppDbContext context) : IDailyWaterIntakeRepository
{
    public async Task<IEnumerable<DailyWaterIntake>> GetAllAsync()
    {
        return await context.DailyWaterIntakes.ToListAsync();
    }

    public async Task<DailyWaterIntake> GetByIdAsync(int id)
    {
        return await context.DailyWaterIntakes.FindAsync(id);
    }

    public async Task AddAsync(DailyWaterIntake dailyWaterIntake)
    {
        await context.DailyWaterIntakes.AddAsync(dailyWaterIntake);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DailyWaterIntake dailyWaterIntake)
    {
        context.DailyWaterIntakes.Update(dailyWaterIntake);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dailyWaterIntake = await context.DailyWaterIntakes.FindAsync(id);
        if (dailyWaterIntake != null)
        {
            context.DailyWaterIntakes.Remove(dailyWaterIntake);
            await context.SaveChangesAsync();
        }
    }
}