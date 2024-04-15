using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;
using ProjectTracker.Models.ViewModels;
using System.Diagnostics;

namespace ProjectTracker.Controllers
{
    public class AtividadesController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly IEmpresaService _empresaService;
        private readonly IProcessoService _processoService;
        private readonly ILogProcessoService _logProcessoService;
        private readonly ILogAreaService _logAreaService;
        private readonly ILogEmpresaService _logEmpresaService;
        private readonly IProcessoUsuarioService _processoUsuarioService;
        private readonly IUsuarioService _usuarioService;



        public AtividadesController(IAreaService areaService, IEmpresaService empresaService,
            IProcessoService processoService, ILogProcessoService logProcessoService, IProcessoUsuarioService processoUsuarioService,
            ILogAreaService logAreaService, ILogEmpresaService logEmpresaService, IUsuarioService usuarioService)
        {
            _areaService = areaService;
            _empresaService = empresaService;
            _processoService = processoService;
            _logProcessoService = logProcessoService;
            _processoUsuarioService = processoUsuarioService;
            _logAreaService = logAreaService;
            _logEmpresaService = logEmpresaService;
            _usuarioService = usuarioService;
        }

        [Authorize]
        public IActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
                var userId = Int32.Parse(User.Claims.First().Value);
                ViewLogProcesso viewLogProcesso = new();
                viewLogProcesso.Usuario = _usuarioService.GetUsuarioById(userId).Result;
                viewLogProcesso.Areas = _areaService.GetListAreas();
                viewLogProcesso.Empresas = _empresaService.GetListEmpresas();
                viewLogProcesso.Processos = _processoService.GetListProcessos();
                viewLogProcesso.ProcessosUsuariosHistorico = _processoUsuarioService.GetListProcessosUsuarioFinalizados(userId);
                viewLogProcesso.ProcessosUsuarios = _processoUsuarioService.GetListProcessosUsuario(userId);
                return View(viewLogProcesso);
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            
        }

        public IActionResult LoadSelectProcessos(int idArea)
        {
            var processos = _processoService.GetProcessoByIdArea(idArea);
            return Json(processos);
        }

        public IActionResult LoadTableProcessos(int Usuario)
        {
            var processos = _processoUsuarioService.GetListProcessosUsuario(Usuario);
            return Json(processos);
        }

        [HttpPost]
        public IActionResult AddProcessoUsuario(ProcessoUsuario processoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = true });
            }
            else
            {
                var ProcessoAdicionado = _processoUsuarioService.AddProcessoUsuario(processoUsuario);
                return Json(new { success = true, error = false, processo = ProcessoAdicionado });
            }
        }

        [HttpGet]
        public IActionResult GetProcessoUsuario(int id)
        {
            var idproc = id;
            var processo = _processoUsuarioService.GetProcessoUsuario(id);
            return Json(processo);
        }

        [HttpGet]
        public IActionResult GetProcessoUsuarioFinalizado(int id)
        {
            var idproc = id;
            var processo = _processoUsuarioService.GetProcessoUsuarioFinalizados(id);
            return Json(processo);
        }
        [HttpGet]
        public DateTime GetDataServidor()
        {
            DateTime Data = DateTime.Now;
            return new DateTime(Data.Year, Data.Month, Data.Day, Data.Hour, Data.Minute, Data.Second);

        }

        [HttpGet]
        public async Task<IActionResult> GetLastLogProcesso(int id)
        {
            var logprocesso = await _logProcessoService.GetLastLogProcessoByIdProcesso(id);
            return Json(logprocesso);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProcessoUsuario(ProcessoUsuario ProcessoUsuario)
        {
            
            var logProcesso = new LogProcesso();
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = true });
            }
            else
            {
                
                if (ProcessoUsuario.Status.Equals("INICIO"))
                {
                    await _processoUsuarioService.UpdateProcessoUsuario(ProcessoUsuario);
                    await _logProcessoService.AddLogProcessoInicio(ProcessoUsuario);
                    await _logAreaService.AddLogAreaInicio(ProcessoUsuario);
                    await _logEmpresaService.AddLogEmpresaInicio(ProcessoUsuario);                    
                }
                else if (ProcessoUsuario.Status.Equals("PAUSA"))
                {
                    await _processoUsuarioService.UpdateProcessoUsuario(ProcessoUsuario);
                    await _logProcessoService.AddLogProcessoPausa(ProcessoUsuario);
                    await _logAreaService.AddLogAreaPausa(ProcessoUsuario);
                    await _logEmpresaService.AddLogEmpresaPausa(ProcessoUsuario);
                } 
                else if (ProcessoUsuario.Status.Equals("FIM"))
                {
                    await _processoUsuarioService.UpdateProcessoUsuario(ProcessoUsuario);
                    await _logProcessoService.AddLogProcessoFim(ProcessoUsuario);
                    await _logAreaService.AddLogAreaPausa(ProcessoUsuario);
                    await _logEmpresaService.AddLogEmpresaPausa(ProcessoUsuario);
                }
                else if(ProcessoUsuario.Status.Equals("REINICIAR"))
                {
                    ProcessoUsuario.Status = "PAUSA";
                    await _processoUsuarioService.UpdateProcessoUsuario(ProcessoUsuario);
                }               
                
                return Json(new { success = true, error = false });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLogProcesso(LogProcesso logProcesso)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = true });
            }
            else
            {
                await _logProcessoService.UpdateLogProcesso(logProcesso);
                return Json(new { success = true, error = false });
            }
        }

        [HttpDelete]
        public IActionResult DeleteProcessoUsuario(ProcessoUsuario ProcessoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = true, error = false });
            }
            else
            {
                _processoUsuarioService.DeleteProcessoUsuario(ProcessoUsuario);
                return Json(new {success = true, error = false});
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddLogProcesso(ProcessoUsuario ProcessoUsuario)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = true });
            }
            else
            {
                if (ProcessoUsuario.Status.Equals("INICIO"))
                {
                    await _logProcessoService.AddLogProcessoInicio(ProcessoUsuario);
                }
                else if (ProcessoUsuario.Status.Equals("PAUSA"))
                {
                    await _logProcessoService.AddLogProcessoPausa(ProcessoUsuario);
                }
                else if (ProcessoUsuario.Status.Equals("FIM"))
                {
                    await _logProcessoService.AddLogProcessoFim(ProcessoUsuario);
                }
                return Json(new { success = true, error = false });
            }
           
        }

        //[HttpPost]
        //public IActionResult AddLogProcesso(LogProcesso logProcesso)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return Json(new { success = false, error = true });
        //    }
        //    else
        //    {
        //        _logProcessoService.AddLogProcessoInicio(logProcesso);
        //        return Json(new { success = true, error = false });
        //    }


        //}


    }
}
