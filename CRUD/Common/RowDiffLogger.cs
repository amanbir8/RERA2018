using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace CRUD.Common
{
    public static class RowDiffLogger
    {
        public static string BuildDiff<T>(T before, T after)
        {
            if (before == null && after == null)
                return "        (both before and after rows are null — row not found)";
            if (before == null)
                return "        (no 'before' row found)";
            if (after == null)
                return "        (no 'after' row found — likely no longer pending, i.e. finalized)";

            var sb = new StringBuilder();
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                object beforeVal = prop.GetValue(before);
                object afterVal = prop.GetValue(after);
                string beforeStr = beforeVal?.ToString() ?? "NULL";
                string afterStr = afterVal?.ToString() ?? "NULL";

                if (beforeStr != afterStr)
                    sb.AppendLine($"        {prop.Name}: '{beforeStr}' -> '{afterStr}'");
            }

            return sb.Length == 0 ? "        (no field changes detected)" : sb.ToString();
        }
    }
}