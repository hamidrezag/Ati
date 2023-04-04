using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public static class Extention
    {
        public static PropertyInfo ToPropertyInfo<TSource, TProperty>(this Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);
            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
            {
                var ubody = (UnaryExpression)propertyLambda.Body;
                member = ubody.Operand as MemberExpression;
                if (member == null)
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        propertyLambda.ToString()));
            }
            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            return propInfo;
        }
        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int pageSize, int pageNumber, Expression<Func<T, dynamic>> orderField = null, bool ascSorted = true)
            where T : class, IBaseModel
        {

            if (orderField == null)
                return Paginate(query, pageSize, pageNumber, x => x.Id, ascSorted);
            else
                return Paginate(query, pageSize, pageNumber, orderField, ascSorted);
        }
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageSize, int pageNumber, Expression<Func<T, dynamic>> orderField, bool ascSorted = true)
        {
            query = ascSorted ? query.OrderBy(orderField) : query.OrderByDescending(orderField);
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public static DateTime ToSystemDate(this string persianDate)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = int.Parse(persianDate.Substring(0, 4));
            int month = int.Parse(persianDate.Substring(4, 2));
            int day = int.Parse(persianDate.Substring(6, 2));
            return pc.ToDateTime(year,month,day,0,0,0,0);
        }
    }
}
