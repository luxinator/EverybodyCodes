using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CameraController : Controller
    {
        private readonly CameraContext context;

        public CameraController(CameraContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IQueryable<CameraDto>> GetAll()
        {
            var cams = context.Cameras.Select(c => c.MapToDto());
            return Ok(cams);
        }
    }
}