﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Explorer.API.Controllers.Administrator
{

    [Route("api/administrator/tour")]
    public class TourAdminController : BaseApiController
    {
        private readonly ITourService _tourService;

        public TourAdminController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<TourDto> Get(int id)
        {
            var result = _tourService.Get(id);
            return CreateResponse(result);
        }

        [HttpGet]
        [Authorize(Roles = "administrator")]
        public ActionResult<PagedResult<TourDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<TourDto> Create([FromBody] TourDto tour)
        {
            var result = _tourService.Create(tour);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourDto> Update([FromBody] TourDto tour)
        {
            var result = _tourService.Update(tour);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _tourService.Delete(id);
            return CreateResponse(result);
        }

        [HttpPost("tourEquipment/{tourId:int}/{equipmentId:int}")]
        public ActionResult<TourDto> AddEquipmentToTour([FromBody] TourDto tour, int equipmentId)
        {

            var result = _tourService.AddEquipmentToTour(tour, equipmentId);
            return CreateResponse(result);
        }

        [HttpPut("remove/{tourId:int}/{equipmentId:int}")]
        public ActionResult<TourDto> RemoveEquipmentFromTour([FromBody] TourDto tour, int equipmentId)
        {
            var result = _tourService.RemoveEquipmentFromTour(tour, equipmentId);
            return CreateResponse(result);
        }

        [HttpPut("{tourId:int}/{checkPointId:int}")]
        public ActionResult<TourDto> AddCheckPoint([FromBody] TourDto tour, int checkPointId)
        {
            var result = _tourService.AddCheckPoint(tour, checkPointId);
            return CreateResponse(result);
        }

        [HttpPut("delete/{tourId:int}/{checkPointId:int}")]
        public ActionResult<TourDto> DeleteCheckPoint([FromBody] TourDto tour, int checkPointId)
        {
            var result = _tourService.DeleteCheckPoint(tour, checkPointId);
            return CreateResponse(result);
        }

    }
}

