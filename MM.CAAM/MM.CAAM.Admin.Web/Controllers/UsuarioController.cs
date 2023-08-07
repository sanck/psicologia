﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Admin.Services.Servicios.Test;
using MM.CAAM.Admin.Web.Models;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using System.Diagnostics;

namespace MM.CAAM.Admin.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService usuarioService;

        public UsuarioController(ILogger<HomeController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            this.usuarioService = usuarioService;
        }


        public async Task<IActionResult> Index()
        {
            // OBTIENE DEL SERVICIO
            var Usuarios = await usuarioService.ObtenerListaUsuarios();

            return View(Usuarios);
        }

        public IActionResult AgregarUsuario()
        {
            List<GeneroRequest> Generos = new List<GeneroRequest>()
            {
                new GeneroRequest() { Id = 1, Genero = "M" },
                new GeneroRequest() { Id = 2, Genero = "F" }
            };
            var GenerosSelect = new SelectList(
                                        items: Generos,
                                        dataValueField: nameof(GeneroRequest.Genero),
                                        dataTextField: nameof(GeneroRequest.Genero));
            ViewBag.Generos = GenerosSelect;

            List<RolDTO> Roles = new List<RolDTO>()
            {
                new RolDTO() { Id = 1, Rol = "1" },
                new RolDTO() { Id = 2, Rol = "2" }
            };

            var RolesSelect = new SelectList(
                                        items: Roles,
                                        dataValueField: nameof(RolDTO.Rol),
                                        dataTextField: nameof(RolDTO.Rol));


            ViewBag.Roles = RolesSelect;
            return View();
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearUsuario(UsuarioCreacionDTO usuarioCreacionDto) //, HttpPostedFileBase PerfilNombreArchivo
        {
            try
            {

                //if (PerfilNombreArchivo != null && PerfilNombreArchivo.ContentLength > 0)
                //{
                //    var fullPath = Path.Combine(usuarioDto.PathFotosActuarios, PerfilNombreArchivo.FileName);
                //    var fileName = Com.RenombrarSiExisteArchivo(fullPath);
                //    PerfilNombreArchivo.SaveAs(Path.Combine(usuarioDto.PathFotosActuarios, fileName));

                //    usuarioDto.PerfilNombreArchivo = fileName;
                //}
                //else
                //    usuarioDto.PerfilNombreArchivo = null;

                var a = await usuarioService.InsertUsuario(usuarioCreacionDto);

                //JResult.Data = new Result { Code = (int)HttpStatusCode.OK };
            }
            catch (ValidationException ex)
            {
                var error = new ExceptionMessage(ex);
                //JResult.Data = new Result { Code = (int)HttpStatusCode.BadRequest, Message = ex.Message };
            }
            catch (Exception ex)
            {
                //var error = new ExceptionMessage(ex);
                //return new JsonHttpStatusResult(error.MessageException, HttpStatusCode.InternalServerError);
            }

            //return JResult;

            //return null;

            return RedirectToAction("Index");
            // View("Index");
        }
    }
}