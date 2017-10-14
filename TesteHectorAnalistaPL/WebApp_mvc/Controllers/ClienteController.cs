using Dominio.Entidades;
using Infra.Contexto;
using Servico;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp_mvc.Controllers
{
    public class ClienteController : Controller
    {
        private static ClienteServico _servico = new ClienteServico();

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            var lista = _servico.ObterListaClientes();

            return View(lista);
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _servico.ObterCliente(id);

            ClienteNaoEncontrado(cliente);

            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClienteId,Nome")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _servico.Inserir(cliente);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _servico.ObterCliente(id);

            ClienteNaoEncontrado(cliente);

            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClienteId,Nome")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _servico.Atualizar(cliente);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _servico.ObterCliente(id);

            ClienteNaoEncontrado(cliente);

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var cliente = _servico.ObterCliente(id);
            _servico.Excluir(cliente);

            return RedirectToAction("Index");
        }

        public ActionResult ClienteNaoEncontrado(Cliente cliente)
        {
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return null;
        }
    }
}
