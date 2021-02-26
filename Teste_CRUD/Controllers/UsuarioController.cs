using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Teste_CRUD.Models;
using NHibernate.Linq;

namespace Teste_CRUD.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ISession _session;

        public UsuarioController(ISession session)
        {
            _session = session;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _session.Query<Usuario>().ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                using(ITransaction transaction = _session.BeginTransaction()) 
                {
                    await _session.SaveAsync(usuario);
                    await transaction.CommitAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            return View(await _session.GetAsync<Usuario>(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            if(id != usuario.id)
                return NotFound();

            if (ModelState.IsValid)
            {
                using(ITransaction transaction = _session.BeginTransaction())
                {
                    await _session.SaveOrUpdateAsync(usuario);
                    await transaction.CommitAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(usuario);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _session.GetAsync<Usuario>(id);

            using(ITransaction transaction = _session.BeginTransaction())
            {
                await _session.DeleteAsync(usuario);
                await transaction.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }

}
