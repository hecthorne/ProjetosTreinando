using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidades;
using Infra.Contexto;

namespace WebApp_mvc.Controllers
{
    public class EnderecoController : Controller
    {
        private MeuContext db = new MeuContext();

        // GET: Endereco
        public async Task<ActionResult> Index()
        {
            var endereco = db.Endereco.Include(e => e.Cliente);
            return View(await endereco.ToListAsync());
        }

        // GET: Endereco/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome");
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EnderecoId,EnderecoCompleto,Bairro,Cep,ClienteId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Endereco.Add(endereco);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", endereco.ClienteId);
            return View(endereco);
        }

        // GET: Endereco/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", endereco.ClienteId);
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EnderecoId,EnderecoCompleto,Bairro,Cep,ClienteId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", endereco.ClienteId);
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Endereco endereco = await db.Endereco.FindAsync(id);
            db.Endereco.Remove(endereco);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
