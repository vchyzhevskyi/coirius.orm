using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Coirius.Orm
{
#if DEBUG
    public
#else
    internal
#endif
 class QueryBuilder : AbstractQueryBuilder, IQueryBuilder
    {
        public IQueryBuilder Select(params string[] columnNames)
        {
            if (query.ToString().Contains("SELECT"))
            {
                Match match = Regex.Match(this.query.ToString(), @"^(?<toReplace>SELECT\s+[\w\W]+)\s(FROM|WHERE|ORDER BY)");
                if (match.Success)
                {
                    string toReplace = match.Groups["toReplace"].Value;
                    StringBuilder b = new StringBuilder();
                    b.Append("SELECT ");
                    foreach (string columnName in columnNames)
                    {
                        b.AppendFormat("{0},", columnName);
                    }
                    if (b.Length > 7)
                    {
                        b.Length--;
                    }
                    else if (b.Length == 7)
                    {
                        b.Append("*");
                    }
                    else
                    {
                        throw new Exception();
                    }
                    query.Replace(toReplace, b.ToString());

                    return this;
                }
            }

            if (query.Length > 0)
            {
                query.Length--;
            }

            query.Append("SELECT ");
            foreach (string columnName in columnNames)
            {
                query.AppendFormat("{0},", columnName);
            }

            if (query.Length > 7)
            {
                query.Length--;
            }
            else if (query.Length == 7)
            {
                query.Append("*");
            }
            else
            {
                throw new Exception();
            }
            return this;
        }

        public IQueryBuilder Where(OrmExpression expr)
        {
            if (query.ToString().EndsWith(";"))
            {
                query.Length--;
            }

            query.Append(" WHERE ");
            query.AppendFormat("{0};", expr);
            return this;
        }

        public IQueryBuilder OrderBy(string columnName, OrmOrderBy by)
        {
            if (query.ToString().EndsWith(";"))
            {
                query.Length--;

                if (query.ToString().Contains("ORDER BY"))
                {
                    query.Append(",");
                }
            }

            if (!query.ToString().Contains("ORDER BY"))
            {
                query.Append(" ORDER BY ");
            }
            query.AppendFormat("{0} {1};", columnName, by.ToString().ToUpperInvariant());

            return this;
        }

        public IQueryBuilder Take(int count)
        {
            int index = 7; // query.ToString().IndexOf("SELECT ");
            query.Insert(index, string.Format("TOP {0} ", count));
            return this;
        }

        public IQueryBuilder From(string tableName)
        {
            if (query.Length == 0)
            {
                query.AppendFormat("SELECT * FROM {0};", tableName);
            }
            else
            {
                int index = query.ToString().IndexOf(" WHERE ");
                if (index == -1)
                {
                    query.Length--;
                    query.AppendFormat(" FROM {0};", tableName);
                }
                else
                {
                    query.Insert(index, string.Format(" FROM {0}", tableName));
                }
            }
            return this;
        }

        string IQueryBuilder.ToString()
        {
            return this.query.ToString();
        }
    }
}
