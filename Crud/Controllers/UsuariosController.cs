﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Models.Contexto;
using Crud.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crud.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto _contexto;
        public UsuariosController(Contexto contexto)
        {
            _contexto = contexto;

        }

        public IActionResult Index()
        {
           var lista =  _contexto.Usuario.ToList();
            CarregaTipoUsuario();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var usuario = new Usuario();
            CarregaTipoUsuario();
            return View(usuario);
        }


        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var usuario = _contexto.Usuario.Find(Id);
            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
           if(ModelState.IsValid)
            {
                _contexto.Usuario.Update(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("index");
            }
           else
            {
                CarregaTipoUsuario();
                return View(usuario);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var usuario = _contexto.Usuario.Find(Id);
            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(Usuario _usuario)
        {
            var usuario = _contexto.Usuario.Find(_usuario.Id);
            if (usuario != null)
            {
                _contexto.Usuario.Remove(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var usuario = _contexto.Usuario.Find(Id);
            CarregaTipoUsuario();
            return View(usuario);
        }

        public void CarregaTipoUsuario()
        {
            var ItensTipoUsuario = new List<SelectListItem>
            {
                new SelectListItem{ Value = "1", Text = "Administrador"},
                new SelectListItem{ Value = "2", Text = "Técnico"},
                new SelectListItem{ Value = "3", Text = "Usuário Normal"}
            };

            ViewBag.TipoUsuario = ItensTipoUsuario;
        }

    }
   
}