using System.Configuration.Assemblies;
using Microsoft.Data.SqlClient;
using QuantityMeasurementAppModelLayer.Models;
using QuantityMeasurementAppRepositoryLayer.Data;
using QuantityMeasurementAppRepositoryLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Utils;

namespace QuantityMeasurementAppRepositoryLayer.Database;

public class QuantityMeasurementRepository : IQuantityMeasurementRepository
{
    private readonly UserDbContext _context;
    public QuantityMeasurementRepository(UserDbContext context)
    {
        _context = context;
    }

    public void Register(UserEntity user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public UserEntity? GetUserbyName(string name)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserName == name);
        return user;

    }

    public void SaveToDatabase(QuantityMeasurementEntity quantity)
    {
        _context.Quantity.Add(quantity);
        _context.SaveChanges();
    }

    public IEnumerable<QuantityMeasurementEntity> GetMyDatabase(int userId)
    {
        var result = _context.Quantity.Where(u => u.UserId == userId).ToList();
        return result;
    }

}