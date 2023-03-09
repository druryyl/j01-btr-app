using System.Data;
using System.Data.SqlClient;
using btr.application.PurchaseContext.SupplierAgg.Contracts;
using btr.domain.PurchaseContext.SupplierAgg;
using btr.infrastructure.Helpers;
using Dapper;
using Microsoft.Extensions.Options;
using Nuna.Lib.DataAccessHelper;

namespace btr.infrastructure.PurchasingContext.SupplierAgg;

public class SupplierDal : ISupplierDal
{
    private readonly DatabaseOptions _opt;

    public SupplierDal(IOptions<DatabaseOptions> opt)
    {
        _opt = opt.Value;
    }

    public void Insert(SupplierModel model)
    {
        const string sql = @"
            INSERT INTO BTRPC_Supplier (
                SupplierId, SupplierName)
            VALUES (
                @SupplierId, @SupplierName)";

        var dp = new DynamicParameters();
        dp.AddParam("@SupplierId", model.SupplierId, SqlDbType.VarChar);
        dp.AddParam("@SupplierName", model.SupplierName, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Update(SupplierModel model)
    {
        const string sql = @"
            UPDATE 
                BTRPC_Supplier
            SET 
                SupplierName = @SupplierName
            WHERE
                SupplierId = @SupplierId";

        var dp = new DynamicParameters();
        dp.AddParam("@SupplierId", model.SupplierId, SqlDbType.VarChar);
        dp.AddParam("@SupplierName", model.SupplierName, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Delete(ISupplierKey key)
    {
        const string sql = @"
            DELETE FROM 
                BTRPC_Supplier
            WHERE
                SupplierId = @SupplierId";

        var dp = new DynamicParameters();
        dp.AddParam("@SupplierId", key.SupplierId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public SupplierModel GetData(ISupplierKey key)
    {
        const string sql = @"
            SELECT 
                SupplierId, SupplierName
            FROM
                BTRPC_Supplier
            WHERE
                SupplierId = @SupplierId";

        var dp = new DynamicParameters();
        dp.AddParam("@SupplierId", key.SupplierId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.ReadSingle<SupplierModel>(sql, dp);
    }

    public IEnumerable<SupplierModel> ListData()
    {
        const string sql = @"
            SELECT 
                SupplierId, SupplierName
            FROM
                BTRPC_Supplier";

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.Read<SupplierModel>(sql);
    }
}