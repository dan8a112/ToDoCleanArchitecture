﻿using Application.Interfaces.Activities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService service)
        {
            _activityService = service;
        }

        [HttpGet("user/{idUser}/")]
        public async Task<IActionResult> GetAllAsyncByUser(int idUser)
        {
            var activities = await _activityService.GetAllAsyncByUser(idUser);
            return activities is null ? NotFound($"No existe el usuario con id {idUser} por la que se desea filtrar") : Ok(activities);
        }

        [HttpGet("user/{idUser}/date/{date}")]
        public async Task<IActionResult> GetAllAsyncByUserAndDate(int idUser, DateTime date)
        {
            var activities = await _activityService.GetAllAsyncByUserAndDate(idUser, date);
            return activities is null ? NotFound($"No existe el usuario con id {idUser} por la que se desea filtrar") : Ok(activities);
        }
    }
}
