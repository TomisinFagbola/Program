using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts;

public interface IRepositoryManager
{
    public IApplicationRepository Application { get; }

    public ICustomQuestionRepository CustomQuestion { get; }
}



