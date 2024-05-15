using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries;
public class SqlQuery
{
    public static string Email = $"SELECT c.PersonalInformation.Email FROM c WHERE c.PersonalInformation.Email = @email";

    public static string Type = $"SELECT c.Type FROM c WHERE c.Type = @Type";

    public static string Question = $"SELECT * FROM c WHERE c.Id = @Id";

   
}

