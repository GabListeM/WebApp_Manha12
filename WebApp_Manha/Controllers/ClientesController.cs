using Microsoft.AspNetCore.Mvc;
using WebApp_Manha.Models;

namespace WebApp_Manha.Controllers
{
    public class ClientesController : Controller
    {
        public static List<ClienteViewModel> lista = new List<ClienteViewModel>();
        public IActionResult Lista()
        {
            //ClienteViewModel novo = new ClienteViewModel();
            //novo.Nome = "Gabriel Cavalcante";
            //novo.Id = 10;
            //novo.Telefone = "16997007027";

            //ClienteViewModel novo2 = new ClienteViewModel();
            //novo2.Nome = "Gabriela Santos";
            //novo2.Id = 10;
            //novo2.Telefone = "16996007027";

            //ClienteViewModel novo3 = new ClienteViewModel();
            //novo3.Nome = "Gustavo Santos";
            //novo3.Id = 10;
            //novo3.Telefone = "16999007027";





            //lista.Add(novo);
            //lista.Add(novo2);
            //lista.Add(novo3);



            return View(lista);
        }

        public IActionResult Cadastro()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SalvarDados(ClienteViewModel model)
        {
            if(model.Id > 0)
            {

                int indice = lista.FindIndex(a => a.Id == model.Id);
                lista[indice] = model;

            }
            else
            {

                Random random = new Random();
                model.Id = random.Next(1, 99999);
                lista.Add(model);
            }



            return RedirectToAction("Lista");
        }

        [HttpPost]
        public IActionResult Cadastro(string Nome, string Telefone)
        {
            if (string.IsNullOrEmpty(Nome))
            {
                TempData["Erro"] = "O campo nome não pode estar em branco";
            }

            if (string.IsNullOrEmpty(Telefone))
            {
                TempData["Erro"] = "O campo Telefone não pode estar em branco";
            }
            return View();
        }


        public IActionResult Editar(int id)
        {
            ClienteViewModel cliente = lista.Find(a => a.Id == id);
            if (cliente != null)
            {
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Lista");
            }
           
        }
        public IActionResult Excluir(int id)
        {
            ClienteViewModel cliente = lista.Find(a => a.Id == id);
            if (cliente != null)
            {
                lista.Remove(cliente);
            }
            return RedirectToAction("Lista");
        }
    }
   
}
