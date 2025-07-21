using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/configuraciones")]
    [Authorize]
    public class ConfiguracionesController:ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IConfigurationSection seccion_1;
        private readonly IConfigurationSection seccion_2;

        public ConfiguracionesController(IConfiguration configuration)
        {
            this.configuration = configuration;
            seccion_1 = configuration.GetSection("seccion_1");
            seccion_2  =configuration.GetSection("seccion_2");
        }

        [HttpGet("obtenertodos")]
        public ActionResult GetObtenerTodos()
        {
            var hijos = configuration.GetChildren().Select(x => $"{x.Key}: {x.Value}");
            return Ok(new { hijos });
        }

        [HttpGet("seccion_1")]
        public ActionResult GetSeccion1()
        {
            var nopmbre = seccion_1.GetValue<string>("nombre")!;
            var edad = seccion_1.GetValue<int>("edad");

            return Ok(new { nopmbre, edad });
 
        }

        [HttpGet("seccion_2")]
        public ActionResult GetSeccion2()
        {
            var nopmbre = seccion_2.GetValue<string>("nombre")!;
            var edad = seccion_2.GetValue<int>("edad");

            return Ok(new { nopmbre, edad });

        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            var opcion1= configuration["ConnectionStrings"];

            var opcion2 = configuration.GetValue<string>("DefaultConnection")!;

            return opcion2;
        }

        [HttpGet("secciones")]  
        public ActionResult<string> GetSecciones()
        {
            var secciones = configuration["ConnectionStrings:DefaultConnection"]!;
            return secciones;
        }
    }
}
