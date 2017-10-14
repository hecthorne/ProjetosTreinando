using Dominio.Entidades;
using Infra.Contexto;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp_mvc.Controllers
{
    public class PedidoController : Controller
    {
        private MeuContext db = new MeuContext();

        // GET: Pedido
        public async Task<ActionResult> Index()
        {
            var pedido = db.Pedido.Include(p => p.Cliente).Include(p => p.Produto);
            return View(await pedido.ToListAsync());
        }

        // GET: Pedido/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = await db.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Descricao");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PedidoId,Quantidade,ValorTotal,ProdutoId,ClienteId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", pedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Descricao", pedido.ProdutoId);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = await db.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", pedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Descricao", pedido.ProdutoId);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PedidoId,Quantidade,ValorTotal,ProdutoId,ClienteId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", pedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Descricao", pedido.ProdutoId);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = await db.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pedido pedido = await db.Pedido.FindAsync(id);
            db.Pedido.Remove(pedido);
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
