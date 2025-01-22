using SQLite;
using watercat.Model;

namespace watercat.Services;

public class DailyIntakeDbService : IDailyIntakeDbService
{
    private const string DbName = "daily_intake_db.db3";
    private readonly SQLiteAsyncConnection _connection;

    public DailyIntakeDbService()
    {
        _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DbName));
        _connection.CreateTableAsync<DailyWaterIntake>();
    }

    public async Task<List<DailyWaterIntake>> GetIntakes()
    {
        return await _connection.Table<DailyWaterIntake>().ToListAsync();
    }

    public async Task<DailyWaterIntake> GetByDate(DateTime dateTime)
    {
        return await _connection.Table<DailyWaterIntake>().Where(x => x.Date == dateTime).FirstOrDefaultAsync();
    }

    public async Task Create(DailyWaterIntake intake)
    {
        await _connection.InsertAsync(intake);
    }

    public async Task Update(DailyWaterIntake intake)
    {
        await _connection.UpdateAsync(intake);
    }
    
    public async Task Delete(DailyWaterIntake intake)
    {
        await _connection.DeleteAsync(intake);
    }
}