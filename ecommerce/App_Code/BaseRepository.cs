using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Services;

/// <summary>
/// Descrição resumida de Repository
/// </summary>
public class BaseRepository<T>
{
    private List<String> entityColumns = new List<String>();
    private String entityName;
    private SqlService sqlService;

    public BaseRepository(String entityName, SqlService sqlService)
    {
        this.entityColumns = Helper.getTypePropertiesNames<T>();
        this.entityName = entityName;
        this.sqlService = sqlService;
    }

    public DataSet listAll()
    {
        String SQL = String.Format("SELECT * FROM {0}", entityName);
        return sqlService.executeQuery(SQL);
    }

    public DataSet findById(int id)
    {
        String SQL = String.Format("SELECT * FROM {0} WHERE id={1}", entityName, id);
        return sqlService.executeQuery(SQL);
    }

    public String create(T entity)
    {
        List<String> valuesList = Helper.getInsertValuesList(entityColumns, entity);

        String columns = String.Join(", ", entityColumns);
        String values = String.Join(", ", valuesList);

        String SQL = String.Format(
            "INSERT INTO {0} ({1}) values ({2})",
            entityName, columns, values
        );

        sqlService.executeNonQuery(SQL);

        return "Registro adicionado com sucesso";
    }

    public String update(int id, T entity)
    {
        List<String> valuesList = Helper.getUpdateValuesList(entityColumns, entity);

        String values = String.Join(", ", valuesList);

        String SQL = String.Format(
            "UPDATE {0} SET {1} WHERE id={2}",
            entityName, values, id
        );

        sqlService.executeNonQuery(SQL);

        return "Registro atualizado com sucesso";
    }

    public String delete(int id)
    {
        String SQL = String.Format(
            "DELETE FROM {0} WHERE id={1}",
            entityName, id
        );

        sqlService.executeNonQuery(SQL);

        return "Registro deletado com sucesso";
    }
}