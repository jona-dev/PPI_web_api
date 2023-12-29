using DB;
using DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using DB.Entities.DTO;
using PPI_web_Api.Service;

namespace PPI_web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private OrdenService ordenService;
        public OrderController(OrdenService _ordenService)
        {
            ordenService = _ordenService;
        }


        [HttpGet]
        public IEnumerable<OrdenDTO> GetOrdenes()
        {
            var result = ordenService.GetAllOrdenes();
            return result;
        }

        [HttpPost]
        public Task AddOrden(OrdenDTO_Add orden) {
            try
            {
                ordenService.PutOrden(orden);
            } catch (Exception ex)
            {
                return Task.FromException<Orden>(ex);
            }
            return Task.CompletedTask;
        }
        [HttpPut]
        public Task UpdateOrden(OrdenDTO_Update orden) {
            try
            {
                ordenService.UpdateOrden(orden);
            }
            catch (Exception ex)
            {
                return Task.FromException<Orden>(ex);
            }
            return Task.CompletedTask;
        }

        [HttpDelete]
        public Task RemoveOrden(OrdenDTO_Remove orden) 
        {
            try
            {
                ordenService.RemoveOrden(orden);
            }
            catch (Exception ex)
            {
                return Task.FromException<Orden>(ex);
            }
            return Task.CompletedTask;

        }
    }
}
