using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Quotations;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ApplicationInformationController : BaseController
    {
        

        [HttpGet]
        public async Task<IActionResult> GetApplicationInformationDetails([FromQuery] PagingParams param)
        {
            return HandlePagedResult(await Mediator.Send(new ListApplicationInformation.Query{Params = param}));
        }

         [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationInformation(Guid id)
        {
            return HandleResult(await Mediator.Send(new DetailsApplicationInformation.Query{Id = id}));
        }
        [HttpPost]
        public async Task<IActionResult> CreateApplicationInformation(AppInformation AppInfo)
        {
            return HandleResult(await Mediator.Send(new CreateApplicationInformation.Command {AppInformation = AppInfo}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditQuotation(Guid id, AppInformation appInfo)
        {
            appInfo.Id = id;
            return HandleResult(await Mediator.Send(new EditApplicationInformation.Command{AppInformation = appInfo}));
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAppInformation(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteApplicationInformationDetails.Command{Id = id}));
        }
    }
}