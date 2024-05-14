﻿using Domain.Entities;
using Infrastructure.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class CustomQuestionRepository : CosmosDbRepository<CustomQuestion>, ICustomQuestionRepository
{
    public CustomQuestionRepository(IConfiguration configuration) : base(nameof(CustomQuestion), configuration)
    {
    }


}
