using Domain.Dtos;
using Domain.Entities;
using Domain.Repo;
using Domain.Services;
using Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// مدیریت کارها
    /// </summary>

    public class ToDoInfoController : BaseController
    {
        private readonly IToDoInfoRepo _todoServices;
        public ToDoInfoController(
            IToDoInfoRepo personnalServices,
            ICacheService cacheServices, 
            IConfiguration configuration):base(configuration,cacheServices)
        {
            _todoServices = personnalServices;
        }
        /// <summary>
        /// افزودن کار جدید
        /// </summary>
        /// <param name="dto">مقدار</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddToDoDto dto)
        {
            try
            {
                await _todoServices.InsertAsync(new ToDoInfo
                {
                    CreateDateTime = DateTime.Now,
                    Description = dto.Description,
                    Priority = dto.Priority,
                    Title = dto.Title
                }, Request.HttpContext.RequestAborted);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Something went wrong inside Add ToDo action:" +
                    $"Parameters : " + JsonConvert.SerializeObject(dto) +
                    $" ErrorMessage : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// بروزرسانی کار
        /// </summary>
        /// <param name="dto">مقدار</param>
        /// <returns></returns>
    [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateToDoDto dto)
        {
            try
            {
                await _todoServices.UpdateAsync(new List<System.Linq.Expressions.Expression<Func<ToDoInfo, object>>> {
                x=>x.Priority,
                x=>x.Description,
                x=>x.Title
            }, new ToDoInfo
            {
                Description = dto.Description,
                Priority = dto.Priority,
                Title = dto.Title
            }, dto.Id, Request.HttpContext.RequestAborted);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                Log.Logger.Error($"Something went wrong inside Update ToDo action:" +
                    $"Parameters : " + JsonConvert.SerializeObject(dto) +
                    $" ErrorMessage : {ex.Message}");
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Something went wrong inside Update ToDo action:" +
                    $"Parameters : " + JsonConvert.SerializeObject(dto) +
                    $" ErrorMessage : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        /// <summary>
        /// حذف کار
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteReqDto dto)
        {
            try
            {
                await _todoServices.DeleteAsync(dto.Id, Request.HttpContext.RequestAborted);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                Log.Logger.Error($"Something went wrong inside Update ToDo action:" +
                    $"Parameters : " + JsonConvert.SerializeObject(dto) +
                    $" ErrorMessage : {ex.Message}");
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Something went wrong inside Delete ToDo action:" +
                    $"Parameters : " + JsonConvert.SerializeObject(dto) +
                    $" ErrorMessage : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// گرفتن اطلاعات
        /// </summary>
        /// <param name="dto">مقدار</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var res = await _todoServices.GetOneAsync(id, Request.HttpContext.RequestAborted);
                if(res == null)
                    return StatusCode(404, "Item not found");

                return Ok(res);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Something went wrong inside Get ToDo action:" +
                    $"Parameters : " + id +
                    $" ErrorMessage : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// گرفتن اطلاعات
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PaginationReqDto paginationReqDto)
        {
            try
            {
                return Ok(await _todoServices.GetAllWithFilterAsync(paginationReqDto.PageSize,paginationReqDto.PageNumber,
                    paginationReqDto.AscSort,paginationReqDto.SrtField,null, Request.HttpContext.RequestAborted));
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Something went wrong inside Get ToDo action:" +
                    $"Parameters : " + JsonConvert.SerializeObject(paginationReqDto) +
                    $" - ErrorMessage : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
