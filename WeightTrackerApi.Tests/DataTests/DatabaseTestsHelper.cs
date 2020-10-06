using Microsoft.SqlServer.Management.SqlParser.Parser;
using Newtonsoft.Json;
using System.Data;
using System.Linq;

namespace WeightTrackerApi.Tests.DataTests
{
    public static class DatabaseTestsHelper
    {
        public static void ValidateSqlQuery(string sql)
        {
            var result = Parser.Parse(sql);

            if (result.Errors.Any())
            {
                throw new DataException(JsonConvert.SerializeObject(result.Errors));
            }
        }
    }
}
