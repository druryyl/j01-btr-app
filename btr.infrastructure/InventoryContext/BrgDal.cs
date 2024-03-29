﻿using System.Data;
using System.Data.SqlClient;
using btr.application.InventoryContext.BrgAgg.Contracts;
using btr.domain.InventoryContext.BrgAgg;
using btr.infrastructure.Helpers;
using Dapper;
using Microsoft.Extensions.Options;
using Nuna.Lib.DataAccessHelper;

namespace btr.infrastructure.InventoryContext;

public class BrgDal : IBrgDal
{
    private readonly DatabaseOptions _opt;

    public BrgDal(IOptions<DatabaseOptions> opt)
    {
        _opt = opt.Value;
    }

    public void Insert(BrgModel model)
    {
        const string sql = @"
            INSERT INTO BTR_Brg(
                BrgId, BrgName)
            VALUES (
                @BrgId, @BrgName)";

        var dp = new DynamicParameters();
        dp.AddParam("@BrgId", model.BrgId, SqlDbType.VarChar);
        dp.AddParam("@BrgName", model.BrgName, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Update(BrgModel model)
    {
        const string sql = @"
            UPDATE 
                BTR_Brg
            SET
                BrgName = @BrgName
            WHERE
                BrgId = @BrgId ";

        var dp = new DynamicParameters();
        dp.AddParam("@BrgId", model.BrgId, SqlDbType.VarChar);
        dp.AddParam("@BrgName", model.BrgName, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Delete(IBrgKey key)
    {
        const string sql = @"
            DELETE FROM 
                BTR_Brg
            WHERE
                BrgId = @BrgId ";

        var dp = new DynamicParameters();
        dp.AddParam("@BrgId", key.BrgId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public BrgModel GetData(IBrgKey key)
    {
        const string sql = @"
            SELECT
                BrgId, BrgName
            FROM
                BTR_Brg
            WHERE
                BrgId = @BrgId ";

        var dp = new DynamicParameters();
        dp.AddParam("@BrgId", key.BrgId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.ReadSingle<BrgModel>(sql, dp);
    }

    public IEnumerable<BrgModel> ListData()
    {
        const string sql = @"
            SELECT
                BrgId, BrgName
            FROM
                BTR_Brg";

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.Read<BrgModel>(sql);
    }
}