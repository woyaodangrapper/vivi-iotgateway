﻿namespace Vivi.Infrastructure.IRepositories;

public interface IAdoRepository : IRepository
{
    void ChangeOrSetDbConnection(IDbConnection dbConnection);

    void ChangeOrSetDbConnection(string connectionString, DbTypes dbType);

    bool HasDbConnection();
}