using Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProgramApplication : AuditableEntity
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    //This would be retrieved by httpcontext using claims if Jwt was used
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public PersonalInformation PersonalInformation { get; set; }

    public List<AdditionalQuestion> AdditionalQuestions { get; set; }
}

