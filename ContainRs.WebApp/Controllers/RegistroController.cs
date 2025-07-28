using ContainRs.WebApp.Data;
using ContainRs.WebApp.Models;
using ContaineRs.Domain.Models;
using ContainRs.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ContainRs.WebApp.Controllers;

public class RegistroController : Controller
{
    private readonly AppDbContext context;

    public RegistroController(AppDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Sucesso() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(RegistroViewModel form)
    {
        if (!ModelState.IsValid) return View("Index", form);

        var idade = DateTime.Now.Year - form.DataNascimento.Year;
        if (idade < 18)
        {
            ModelState.AddModelError("DataNascimento", "Você deve ser maior de 18 anos para se registrar.");
            return View("Index", form);
        }

        var useCase = new RegistrarCliente(
            form.Nome,
            new Email(form.Email),
            form.CPF,
            form.Celular,
            form.CEP,
            form.Rua,
            form.Numero,
            form.Complemento,
            form.Bairro,
            form.Municipio,
            form.Estado,
            context
        );

        await useCase.ExecutarAsync();

        return RedirectToAction("Sucesso");
    }
}
