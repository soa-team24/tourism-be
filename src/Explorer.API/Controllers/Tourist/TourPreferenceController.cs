﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization
=======
>>>>>>> 7bf2ecd (Tour Preference CRUD and get by user)
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Explorer.API.Controllers.Tourist;


[Authorize(Policy = "touristPolicy")]
[Route("api/tourists/preference")]
public class TourPreferenceController: BaseApiController
{
    private readonly ITourPreferenceService _tourPreferenceService;
<<<<<<< HEAD
    [Route("api/tourist/preference")]
    public class TourPreferenceController: BaseApiController
    {
        private readonly ITourPreferenceService _tourPreferenceService;
=======
>>>>>>> 7bf2ecd (Tour Preference CRUD and get by user)

    public TourPreferenceController(ITourPreferenceService tourPreferenceService, IHttpContextAccessor httpContextAccessor)
    {
        _tourPreferenceService = tourPreferenceService;
    }

    [HttpGet("byTourist")]
    public ActionResult GetMyPreference()
<<<<<<< HEAD
    {
        var userIdClaim = HttpContext.User.Claims.First(x=> x.Type == "id");
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int touristId))
        {

            var result = _tourPreferenceService.GetByTouristId(touristId);
            return CreateResponse(result);
        }
        else
        {
            return BadRequest("User ID not found or invalid.");
        }

    }

    [HttpPost]
    public ActionResult<TourPreferenceDto> Create([FromBody] TourPreferenceDto tourPreference)
    {
        var result = _tourPreferenceService.Create(tourPreference);
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<TourPreferenceDto> Update([FromBody] TourPreferenceDto tourPreference)
    {
        var result = _tourPreferenceService.Update(tourPreference);
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _tourPreferenceService.Delete(id);
    }

    [HttpGet]
    public ActionResult<PagedResult<TourPreferenceDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
=======
>>>>>>> 7bf2ecd (Tour Preference CRUD and get by user)
    {
        var userIdClaim = HttpContext.User.Claims.First(x=> x.Type == "id");
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int touristId))
        {

            var result = _tourPreferenceService.GetByTouristId(touristId);
            return CreateResponse(result);
        }
        else
        {
            return BadRequest("User ID not found or invalid.");
        }

    }

    [HttpPost]
    public ActionResult<TourPreferenceDto> Create([FromBody] TourPreferenceDto tourPreference)
    {
        var result = _tourPreferenceService.Create(tourPreference);
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<TourPreferenceDto> Update([FromBody] TourPreferenceDto tourPreference)
    {
        var result = _tourPreferenceService.Update(tourPreference);
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _tourPreferenceService.Delete(id);
        return CreateResponse(result);
    }
}
