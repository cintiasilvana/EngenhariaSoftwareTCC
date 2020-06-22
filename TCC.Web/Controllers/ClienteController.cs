using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TCC.Application;
using TCC.Domain.Entities;
using TCC.Domain.Objects;
using TCC.Infra.ValueObject;
using TCC.Web.Models;

namespace TCC.Web.Controllers
{
    public class ClienteController : BaseController
    {
        public readonly ClienteObject _clienteObject = new ClienteObject();


        public ActionResult Index()
        {
            var cliente = _clienteObject.GetAllList();
            var clientes = Mapper.Map<List<Aluno>, List<ClienteViewModel>>(cliente);
            return View(clientes);
        }

        [HttpPost]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            var response = new ResponseMessage<Aluno>();
            try
            {
                var cliente = Mapper.Map<ClienteViewModel, Aluno>(clienteViewModel);
                response = _clienteObject.InsertOrUpdate(cliente);
            }
            catch (Exception e)
            {
                LogErro(e, eErrorGravity.Media);
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var response = new ResponseMessage<Aluno>();
            try
            {

                _clienteObject.Delete(Id);
                _clienteObject.Save();

                response.statusCode = HttpStatusCode.OK;
                response.mensagem = CrudMsgFormater.CreateSuccesCrudMessage();
            }
            catch (Exception e)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.mensagem = CrudMsgFormater.CreateErrorCrudMessage();

                LogErro(e, eErrorGravity.Media);
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(int Id)
        {
            var cliente = _clienteObject.GetById(Id);
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        private void InsertCliente(Aluno cliente)
        {
            _clienteObject.Add(cliente);
            _clienteObject.Save();
        }

        [HttpGet]
        public ActionResult Table()
        {
            var clienteList = _clienteObject.GetAllList();
            var clientes = Mapper.Map<List<Aluno>, List<ClienteViewModel>>(clienteList);
            return PartialView("_Table", clientes);
        }
    }
}