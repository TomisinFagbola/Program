using Application.Dtos.ApplicationDtos;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts;
public interface IApplicationService
{
    Task<SuccessResponse<ApplicationDto>> Create(CreateApplicationDto createApplicationDto);
    Task<SuccessResponse<ApplicationDto>> Update(UpdateApplicationDto updateApplication, string id);
}

