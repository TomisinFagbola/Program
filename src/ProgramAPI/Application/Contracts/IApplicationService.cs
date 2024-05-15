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
    /// <summary>
    /// Create application
    /// </summary>
    /// <param name="createApplicationDto"></param>
    /// <returns>ApplicationDto</returns>
    Task<SuccessResponse<ApplicationDto>> Create(CreateApplicationDto createApplicationDto);

    /// <summary>
    /// Update application
    /// </summary>
    /// <param name="updateApplicationDto"></param>
    /// <param name="id"></param>
    /// <returns>ApplicationDto</returns>
    Task<SuccessResponse<ApplicationDto>> Update(UpdateApplicationDto updateApplicationDto, string id);
}

