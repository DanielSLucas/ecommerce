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
public class GenericRepository<T>
{
    private List<String> entityColumns = new List<String>();
    private String entityName;
    private SqlService sqlService;

    public GenericRepository(String entityName, SqlService sqlService)
    {
        mapEntityColumns();
        this.entityName = entityName;
        this.sqlService = sqlService;
    }

    private void mapEntityColumns()
    {
        foreach (var prop in typeof(T).GetProperties())
        {
            entityColumns.Add(prop.Name);
        }
    }

    public DataSet listAll()
    {
        String SQL = String.Format("SELECT * FROM {0}", entityName);
        return sqlService.query(SQL);
    }

    public DataSet findById(int id)
    {
        String SQL = String.Format("SELECT * FROM {0} WHERE id={1}", entityName, id);
        return sqlService.query(SQL);
    }

    public String create(T entity)
    {
        String columns = String.Join(", ", entityColumns);
        List<object> valuesList = new List<object>();

        foreach (var column in entityColumns)
        {
            object columnValue = typeof(T).GetProperty(column).GetValue(entity);
            String columntype = columnValue.GetType().ToString();

            if (columntype == "System.String" || columntype == "System.DateTime")
            {
                valuesList.Add("'" + columnValue + "'");
            }
            else
            {
                valuesList.Add(columnValue);
            }
        }

        String values = String.Join(", ", valuesList);

        String SQL = String.Format(
            "INSERT INTO {0} ({1}) values ({2})",
            entityName, columns, values
        );

        sqlService.nonQuery(SQL);

        return "Registro adicionado com sucesso";
    }

    public String update(int id, T entity)
    {
        List<String> valuesList = new List<String>();

        foreach (var column in entityColumns)
        {
            object columnValue = typeof(T).GetProperty(column).GetValue(entity);
            String columntype = columnValue.GetType().ToString();

            if (columntype == "System.String" || columntype == "System.DateTime")
            {
                valuesList.Add(
                    String.Format("{0}={1}", column, "'" + columnValue + "'")
                );
            }
            else
            {
                valuesList.Add(
                    String.Format("{0}={1}", column, columnValue)
                );
            }
        }

        String values = String.Join(", ", valuesList);

        String SQL = String.Format(
            "UPDATE {0} SET {1} WHERE id={2}",
            entityName, values, id
        );

        sqlService.nonQuery(SQL);

        return "Registro atualizado com sucesso";
    }

    public String delete(int id)
    {
        String SQL = String.Format(
            "DELETE FROM {0} WHERE id={1}",
            entityName, id
        );

        sqlService.nonQuery(SQL);

        return "Registro deletado com sucesso";
    }
}