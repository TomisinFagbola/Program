using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries;
public class SqlQuery
{
    public static string Email = $"SELECT * FROM c WHERE c.PersonalInformation.Email = @email";

    public static string Type = $"SELECT * FROM c WHERE c.Type = @Type";
}

