using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace DbUtility
{
    /// <summary>
    /// 对应实体与数据库中的表
    /// 关联SQL和实体属性
    /// </summary>
    public sealed class EntityReader
    {
        private const BindingFlags BindingFlag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        //将类型与该类型所有的可写且未被忽略属性之间建立映射
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> propertyMappings = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        /// <summary>
        /// 将DataTable中的所有数据转换成List>T<集合，包含复杂、简单等类型
        /// </summary>
        /// <typeparam name="T">DataTable中每条数据可以转换的数据类型</typeparam>
        /// <param name="dataTable">包含有可以转换成数据类型T的数据集合</param>
        /// <returns></returns>
        public static List<T> GetEntities<T>(DataTable dataTable) where T : new()
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable");
            }
            //如果T的类型满足以下条件：字符串、ValueType或者是Nullable<ValueType>
            if (typeof(T) == typeof(string) || typeof(T) == typeof(byte[]) || typeof(T).IsValueType)
            {
                return GetSimpleEntities<T>(dataTable);
            }
            else
            {
                return GetComplexEntities<T>(dataTable);
            }
        }
        /// <summary>
        /// 将指定的 Object 的值转换为指定类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <param name="targetType">要转换的目标数据类型</param>
        /// <returns></returns>
        public static object GetValueFromObject(object value, Type targetType)
        {
            if (targetType == typeof(string))//如果要将value转换成string类型
            {
                return GetString(value);
            }
            else if (targetType == typeof(byte[]))//如果要将value转换成byte[]类型
            {
                return GetBinary(value);
            }
            else if (targetType.IsGenericType)//如果目标类型是泛型
            {
                return GetGenericValueFromObject(value, targetType);
            }
            else//如果是基本数据类型（包括数值类型、枚举和Guid）
            {
                return GetNonGenericValueFromObject(value, targetType);
            }
        }
        /// <summary>
        /// 从DataTable中读取复杂数据类型集合
        /// </summary>
        /// <typeparam name="T">要转换的目标数据类型</typeparam>
        /// <param name="dataTable">包含有可以转换成数据类型T的数据集合</param>
        /// <returns></returns>
        private static List<T> GetComplexEntities<T>(DataTable dataTable) where T : new()
        {
            if (!propertyMappings.ContainsKey(typeof(T)))
            {
                GenerateTypePropertyMapping(typeof(T));
            }
            List<T> list = new List<T>();
            Dictionary<string, PropertyInfo> properties = propertyMappings[typeof(T)];

            T t;
            foreach (DataRow row in dataTable.Rows)
            {
                t = new T();
                foreach (KeyValuePair<string, PropertyInfo> item in properties)
                {
                    //如果对应的属性名出现在数据源的列中则获取值并设置给对应的属性
                    if (row[item.Key] != null)
                    {
                        item.Value.SetValue(t, GetValueFromObject(row[item.Key], item.Value.PropertyType), null);
                    }
                }
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// 将DataTable中的所有数据转换成List>T<集合,仅针对复杂类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> GetEntitiesForList<T>(DataTable dt) where T : new()
        {
            // 定义集合
            List<T> ts = new List<T>();

            // 获得此模型的类型
            Type type = typeof(T);
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量
                    //检查DataTable是否包含此列（列名==对象的属性名）  
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出
                        //取值
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }
            return ts;
        }

        /// <summary>
        /// 从DataTable中将每一行的第一列转换成T类型的数据
        /// </summary>
        /// <typeparam name="T">要转换的目标数据类型</typeparam>
        /// <param name="dataTable">包含有可以转换成数据类型T的数据集合</param>
        /// <returns></returns>
        private static List<T> GetSimpleEntities<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add((T)GetValueFromObject(row[0], typeof(T)));
            }
            return list;
        }
        /// <summary>
        /// 从DbDataReader的实例中读取简单数据类型（String,ValueType)
        /// </summary>
        /// <typeparam name="T">目标数据类型</typeparam>
        /// <param name="reader">DbDataReader的实例</param>
        /// <returns></returns>
        private static List<T> GetSimpleEntities<T>(DbDataReader reader)
        {
            List<T> list = new List<T>();

            while (reader.Read())
            {
                list.Add((T)GetValueFromObject(reader[0], typeof(T)));
            }
            return list;
        }
        /// <summary>
        /// 将Object转换成字符串类型
        /// </summary>
        /// <param name="value">object类型的实例</param>
        /// <returns></returns>
        private static object GetString(object value)
        {
            if (value != null)
            {
                return value.ToString() as string;
            }
            return null;
        }
        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private static object GetEnum(object value, Type targetType)
        {
            return System.Enum.Parse(targetType, Convert.ToString(value));
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetBoolean(object value)
        {
            if (value is Boolean)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetByte(object value)
        {
            if (value is Byte)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetSByte(object value)
        {
            if (value is SByte)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetChar(object value)
        {
            if (value is Char)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetGuid(object value)
        {
            if (value is Guid)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetInt16(object value)
        {
            if (value is Int16)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetUInt16(object value)
        {
            if (value is UInt16)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetInt32(object value)
        {

            if (value is Int32)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetUInt32(object value)
        {
            if (value is UInt32)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetInt64(object value)
        {
            if (value is Int64)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetUInt64(object value)
        {
            if (value is UInt64)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetSingle(object value)
        {
            if (value is Single)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetDouble(object value)
        {
            if (value is Double)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetDecimal(object value)
        {
            if (value is Decimal)
            {
                return value;
            }
            else if (value is Double)
            {
                return Convert.ToDecimal(value);
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetDateTime(object value)
        {
            if (value is DateTime) return value;

            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static object GetTimeSpan(object value)
        {
            if (value is TimeSpan)
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <returns></returns>
        private static byte[] GetBinary(object value)
        {
            //如果该字段为NULL则返回null
            if (value == DBNull.Value)
            {
                return null;
            }
            else if (value is Byte[])
            {
                return (byte[])(value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将Object类型数据转换成对应的可空数值类型表示
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <param name="targetType">可空数值类型</param>
        /// <returns></returns>
        private static object GetGenericValueFromObject(object value, Type targetType)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                //获取可空数值类型对应的基本数值类型，如int?->int,long?->long
                //Type nonGenericType = genericTypeMappings[targetType];
                Type nonGenericType = targetType.GetGenericArguments()[0];
                return GetNonGenericValueFromObject(value, nonGenericType);
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定类型的值。
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null</param>
        /// <param name="targetType">目标对象的类型</param>
        /// <returns></returns>
        private static object GetNonGenericValueFromObject(object value, Type targetType)
        {
            if (targetType.IsEnum)//因为
            {
                return GetEnum(value, targetType);
            }
            else
            {
                switch (targetType.Name.ToLower())
                {
                    case "byte": return GetByte(value);
                    case "sbyte": return GetSByte(value);
                    case "char": return GetChar(value);
                    case "boolean": return GetBoolean(value);
                    case "guid": return GetGuid(value);
                    case "int16": return GetInt16(value);
                    case "uint16": return GetUInt16(value);
                    case "int32": return GetInt32(value);
                    case "uint32": return GetUInt32(value);
                    case "int64": return GetInt64(value);
                    case "uint64": return GetUInt64(value);
                    case "single": return GetSingle(value);
                    case "double": return GetDouble(value);
                    case "decimal": return GetDecimal(value);
                    case "datetime": return GetDateTime(value);
                    case "timespan": return GetTimeSpan(value);
                    default: return null;
                }
            }
        }

        /// <summary>
        /// 获取该类型中属性与数据库字段的对应关系映射
        /// </summary>
        /// <param name="type"></param>
        private static void GenerateTypePropertyMapping(Type type)
        {
            if (type != null)
            {
                PropertyInfo[] properties = type.GetProperties(BindingFlag);
                Dictionary<string, PropertyInfo> propertyColumnMapping = new Dictionary<string, PropertyInfo>(properties.Length);
                string description = string.Empty;
                Attribute[] attibutes = null;
                string columnName = string.Empty;
                foreach (PropertyInfo p in properties)
                {
                    //默认情况下为过滤字段属性
                    var myAttr = new ColumnAttribute("", true, false, true);
                    columnName = string.Empty;
                    attibutes = Attribute.GetCustomAttributes(p);
                    foreach (Attribute attribute in attibutes)
                    {
                        //检查是否设置了ColumnName属性
                        if (attribute.GetType() == typeof(ColumnAttribute))
                        {
                            myAttr = (ColumnAttribute)attribute;
                            columnName = myAttr.ColumnName;
                            break;
                        }
                    }
                    //如果该属性是可读并且未被忽略的，则有可能在实例化该属性对应的类时用得上
                    if (myAttr.IsFilter == false)
                    {
                        //如果没有设置ColumnName属性，则直接将该属性名作为数据库字段的映射
                        if (string.IsNullOrEmpty(columnName))
                        {
                            columnName = p.Name;
                        }
                        propertyColumnMapping.Add(columnName, p);
                    }
                }
                propertyMappings.Add(type, propertyColumnMapping);
            }
        }


    }
}
