using Application.Dtos.ApplicationDtos;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks.Application;
    public record ApplicationMock
    {
        public static CreateApplicationDto CreateApplicationDtoMock = new()
        {

            PersonalInformation = new()
            {
                Email = "tomifagbola97@gmail.com",
                FirstName = "Tomisin",
                LastName = "Fagbola",
                Gender = "Male",
                Nationality = "Canadian",
                Phone = "+18886873745"

            },
            AdditionalQuestions = new()
            {
                new()
                {
                    Id = "f746b062-62d8-4b2c-a464-8bf67a8db2fe",
                    isAnswered = true,

                },
              
            }


        };

        public static ApplicationDto ResponseCreateApplicationMock = new()
        {
            UserId = Guid.NewGuid().ToString(),
            PersonalInformation = new()
            {
                Email = "tomifagbola97@gmail.com",
                FirstName = "Tomisin",
                LastName = "Fagbola",
                Gender = "Male",
                Nationality = "Canadian",
                Phone = "+18886873745"

            },
            AdditionalQuestions = new()
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    isAnswered = true,

                },
                new()
                 {
                    Id = Guid.NewGuid().ToString(),
                    Options = new()
                    {
                        "Outgoing",
                        "Introverted"
                    }
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = "24/05/2024",
                }
            }

        };

        public static UpdateApplicationDto UpdateApplicationDtoMock = new()
        {

            PersonalInformation = new()
            {
                Email = "tomifagbola97@gmail.com",
                FirstName = "Tomisin",
                LastName = "Fagbola",
                Gender = "Male",
                Nationality = "Canadian",
                Phone = "+18886873745"

            },
            AdditionalQuestions = new()
            {
                new()
                {
                    Id = "f746b062-62d8-4b2c-a464-8bf67a8db2fe",
                    Value = "it works well",
                }
            }


        };

        public static ApplicationDto ResponseUpdateApplicationMock = new()
        {
            UserId = Guid.NewGuid().ToString(),
            PersonalInformation = new()
            {
                Email = "tomifagbola97@gmail.com",
                FirstName = "Tomisin",
                LastName = "Fagbola",
                Gender = "Male",
                Nationality = "Canadian",
                Phone = "+18886873745"

            },
            AdditionalQuestions = new()
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    isAnswered = true,

                },
                new()
                 {
                    Id = Guid.NewGuid().ToString(),
                    Options = new()
                    {
                        "Outgoing",
                        "Introverted"
                    }
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = "24/05/2024",
                }
            }

        };

        public static SuccessResponse<ApplicationDto> SuccessResponseDTOMock = new()
        {
            Message = "Application Created successfully created",
            Data = ResponseCreateApplicationMock,
            Success = true
        };

        public static SuccessResponse<ApplicationDto> UpdateSuccessResponseDTOMock = new()
        {
            Message = "Application Updated successfully",
            Data = ResponseCreateApplicationMock,
            Success = true

        };
    }
