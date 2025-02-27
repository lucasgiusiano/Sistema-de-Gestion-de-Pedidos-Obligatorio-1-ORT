﻿using Microsoft.AspNetCore.Mvc;
using SistemaGestionAplicacion.CasosUso.CUCliente;
using SistemaGestionAplicacion.InterfacesCU.ICUCliente;
using SistemaGestionDatos.Repositorios;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using SistemaGestionPedidos.Models;
using System.Linq;

namespace SistemaGestionPedidos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ICUBuscarClientePorRazonSocial _buscarClientePorRazonSocial;
        private readonly ICUObtenerTodosLosClientes _obtenerTodosLosClientes;
        private readonly ICUBuscarClientesPorMonto _buscarClientesPorMonto;
        private readonly ICUObtenerTodosLosClientesConDireccion _obtenerClientesPorDirec;

        public ClienteController(ICUBuscarClientePorRazonSocial buscarClientePorRazonSocial, ICUObtenerTodosLosClientes obtenerTodosLosClientes, ICUBuscarClientesPorMonto buscarClientesPorMonto, ICUObtenerTodosLosClientesConDireccion obtenerTodosLosClientesConDireccion)
        {
            _buscarClientePorRazonSocial = buscarClientePorRazonSocial;
            _obtenerTodosLosClientes = obtenerTodosLosClientes;
            _buscarClientesPorMonto = buscarClientesPorMonto;
            _obtenerClientesPorDirec = obtenerTodosLosClientesConDireccion;
        }

        public ActionResult Buscar(string textoBusqueda)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                var cliente = _buscarClientePorRazonSocial.BuscarClientePorRazonSocial(textoBusqueda);

                if (cliente != null)
                {

                    var clientesConDireccion = _obtenerClientesPorDirec.ObtenerTodosLosClientesConDireccion();


                    var clienteConDireccion = clientesConDireccion.FirstOrDefault(c => c.Id == cliente.Id);

                    if (clienteConDireccion != null)
                    {
                        ClienteViewModel clienteViewModel = new ClienteViewModel
                        {
                            Id = clienteConDireccion.Id,
                            RazonSocial = clienteConDireccion.RazonSocial ?? "",
                            Rut = clienteConDireccion.Rut ?? "",
                            DistanciaDeposito = clienteConDireccion.DistanciaDeposito
                        };

                        if (clienteConDireccion.Direccion != null)
                        {
                            clienteViewModel.Calle = clienteConDireccion.Direccion.Calle ?? "";
                            clienteViewModel.Numero = clienteConDireccion.Direccion.Numero;
                            clienteViewModel.Ciudad = clienteConDireccion.Direccion.Ciudad ?? "";
                        }
                        else
                        {

                            clienteViewModel.Calle = "";
                            clienteViewModel.Numero = 0;
                            clienteViewModel.Ciudad = "";
                        }

                        return View("ListadoClientes", new List<ClienteViewModel> { clienteViewModel });
                    }
                }


                ViewData["Mensaje"] = "No se encontró ningún cliente con la razón social proporcionada.";
                return View("ListadoClientes");
            }
        }


        public ActionResult BuscarPorMonto(double monto)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                var clientesQueSuperanMonto = _buscarClientesPorMonto.BuscarClientes(monto);
                if (!clientesQueSuperanMonto.Any())
                {
                    ViewData["Mensaje"] = "No se encontraron clientes cuyos pedidos superen el monto especificado.";
                }
                var clientesViewModel = new List<ClienteViewModel>();
                foreach (var cliente in clientesQueSuperanMonto)
                {

                    var clienteConDireccion = _obtenerClientesPorDirec.ObtenerTodosLosClientesConDireccion()
                                                    .FirstOrDefault(c => c.Id == cliente.Id);

                    if (clienteConDireccion != null)
                    {
                        ClienteViewModel clienteViewModel = MapClienteToViewModel(clienteConDireccion);
                        clientesViewModel.Add(clienteViewModel);
                    }
                }
                return View("ListadoClientes", clientesViewModel);
            }
        }


        private ClienteViewModel MapClienteToViewModel(Cliente cliente)
        {
            ClienteViewModel clienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                RazonSocial = cliente.RazonSocial ?? "",
                Rut = cliente.Rut ?? "",
                DistanciaDeposito = cliente.DistanciaDeposito
            };

            if (cliente.Direccion != null)
            {
                clienteViewModel.Calle = cliente.Direccion.Calle ?? "";
                clienteViewModel.Numero = cliente.Direccion.Numero;
                clienteViewModel.Ciudad = cliente.Direccion.Ciudad ?? "";
            }
            else
            {
                clienteViewModel.Calle = "";
                clienteViewModel.Numero = 0;
                clienteViewModel.Ciudad = "";
            }

            return clienteViewModel;
        }


        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                var clientes = _obtenerClientesPorDirec.ObtenerTodosLosClientesConDireccion();

                var clientesViewModel = clientes.Select(c => new ClienteViewModel
                {
                    Id = c.Id,
                    RazonSocial = c.RazonSocial ?? "",
                    Rut = c.Rut ?? "",
                    Calle = c.Direccion.Calle,
                    Numero = c.Direccion.Numero,
                    Ciudad = c.Direccion.Ciudad,
                    DistanciaDeposito = c.DistanciaDeposito
                }).ToList();

                return View("ListadoClientes", clientesViewModel);
            }
        }


        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // GET: ClienteController/Create
        public ActionResult Create()
		{
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }
    }
}
