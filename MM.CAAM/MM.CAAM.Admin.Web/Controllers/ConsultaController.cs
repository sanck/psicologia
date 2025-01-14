﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Admin.Web.Models;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Admin.Web.Controllers;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
//using System.Web.Mvc;

namespace MM.CAAM.Admin.Web.Controllers
{
    [Authorize]
    public class ConsultaController : BaseController
    { 
        private readonly ILogger<HomeController> _logger;
        private readonly IConsultaService consultaService;
        private readonly IUsuarioService usuarioService;

        public ConsultaController(ILogger<HomeController> logger, IUsuarioService usuarioService, IConsultaService consultaService)
        {
            _logger = logger;
            this.usuarioService = usuarioService;
            this.consultaService = consultaService;
        }

        public async Task<IActionResult> Index()
        {
            var Consultas = await consultaService.ObtenerConsultas();

            return View(Consultas);
        }
        public async Task<IActionResult> ConsultaDeUsuario(string usuarioId)
        {
            if (string.IsNullOrEmpty(usuarioId))
                throw new ValidationException("Id vacío.");
            int.TryParse(Com.Decryptor(usuarioId), out int id);

            var Consultas = await consultaService.ObtenerConsultasPorUsuario(id);

            var usuario = await usuarioService.ObtenerUsuario(id);

            ViewBag.Usuario = usuario;

            return View(Consultas);
        }

        public async Task<IActionResult> NuevaConsulta(string usuarioId = "", string consultaId = "")
        {
            ConsultaDTO consultaDto = new ConsultaDTO();
            int UsuarioId = 0;
            if (!string.IsNullOrEmpty(usuarioId))
            {
                int.TryParse(Com.Decryptor(usuarioId), out UsuarioId);
            }
            else
            {
                throw new ValidationException("IdUsuario vacío.");
            }
            if (!string.IsNullOrEmpty(consultaId))
            {
                int.TryParse(Com.Decryptor(consultaId), out int ConsultaId);
                consultaDto = await consultaService.ObtenerConsulta(UsuarioId, ConsultaId);
            }

            var usuario = await usuarioService.ObtenerUsuario(UsuarioId);

            ViewBag.Usuario = usuario;

            return View(consultaDto);
        }

        public async Task<IActionResult> VerConsulta(string usuarioId, string consultaId)
        {
            if (string.IsNullOrEmpty(usuarioId))
                throw new ValidationException("Id vacío.");
            if (string.IsNullOrEmpty(consultaId))
                throw new ValidationException("Id vacío.");

            int.TryParse(Com.Decryptor(usuarioId), out int UsuarioId);
            int.TryParse(Com.Decryptor(consultaId), out int ConsultaId);

            var consulta = await consultaService.ObtenerConsultasPorUsuarioYConsultaId(UsuarioId, ConsultaId);

            var usuario = await usuarioService.ObtenerUsuario(UsuarioId);

            ViewBag.Usuario = usuario;
            //var usuario = await usuarioService.ObtenerUsuario(usuarioId);

            //ViewBag.Usuario = usuario;

            return View(consulta);
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearConsulta(ConsultaCreacionDTO consultaCreacionDTO, int usuarioId, int consultaId) //, HttpPostedFileBase PerfilNombreArchivo
        {
            try
            {
                if (consultaId > 0)
                {
                    await consultaService.ModificarConsulta(usuarioId, consultaId, consultaCreacionDTO);
                }
                else
                {
                    await consultaService.CrearConsulta(usuarioId, consultaCreacionDTO);
                }
                return Ok(new Result { Code = StatusCodes.Status200OK });
            }
            catch (ValidationException ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException });
            }
            catch (Exception ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });
            }
        }
    }
}