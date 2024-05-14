using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Config;
public class AzureCosmos
{
    public string AccountEndpoint { get; set; }
    public string AccountKey { get; set; }
    public string Database { get; set; }
}
