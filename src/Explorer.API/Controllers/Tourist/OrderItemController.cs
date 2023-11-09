﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Explorer.API.Controllers.Tourist;


[Route("api/tourist/orderItem")]
public class OrderItemController : BaseApiController
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet("shoppingCart/{shoppingCartId}")]
    public ActionResult GetOrderItems(int shoppingCartId)
    {
        var result = _orderItemService.GetAllByShoppingCartId(shoppingCartId);
        return CreateResponse(result);     
    }

    
}
