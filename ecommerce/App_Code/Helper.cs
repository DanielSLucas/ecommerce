using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

public class Helper
{
    public Helper()
    {        
    }

    public static List<String> getTypePropertiesNames<T>()
    {
        return typeof(T).GetProperties().Select(x => x.Name).ToList();
    }

    public static List<String> getInsertValuesList<T>(List<String> columns, T entity)
    {
        return columns.Select(
            column => formatValue(
                typeof(T).GetProperty(column).GetValue(entity)
            )
        ).ToList();
    }

    public static List<String> getUpdateValuesList<T>(List<String> columns, T entity)
    {   
        return columns.Select(
            column => String.Format(
                "{0}={1}",
                column, formatValue(typeof(T).GetProperty(column).GetValue(entity))
            )
        ).ToList();
    }

    private static String formatValue(object value)
    {
        String valueType = value.GetType().ToString();

        if (valueType == "System.String")
        {
            return "'" + value + "'";
        }

        if (valueType == "System.DateTime")
        {
            return ((DateTime)value).ToString("yyyy-MM-dd");
        }

        return value.ToString();
    }
}