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
    public class EmpresaController : BaseController
    {
        public readonly EmpresaObject _empresaObject = new EmpresaObject();


        public ActionResult Index()
        {
            var empresa = _empresaObject.GetAllList();
            var empresas = Mapper.Map<List<Empresa>, List<EmpresaViewModel>>(empresa);
            return View(empresas);
        }

        [HttpPost]
        public ActionResult Create(EmpresaViewModel empresaViewModel)
        {
            var response = new ResponseMessage<Empresa>();
            try
            {
                var empresa = Mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel);
                response = _empresaObject.InsertOrUpdate(empresa);
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
            var response = new ResponseMessage<Empresa>();
            try
            {

                _empresaObject.Delete(Id);
                _empresaObject.Save();

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
        public ActionResult Form()
        {
            return PartialView("_Form");
        }

        [HttpGet]
        public JsonResult Get(int Id)
        {
            var empresa = _empresaObject.GetById(Id);
            return Json(empresa, JsonRequestBehavior.AllowGet);
        }

        private void InsertEmpresa(Empresa empresa)
        {
            _empresaObject.Add(empresa);
            _empresaObject.Save();
        }

        [HttpGet]
        public ActionResult Table()
        {
            var empresaList = _empresaObject.GetAllList();
            var empresas = Mapper.Map<List<Empresa>, List<EmpresaViewModel>>(empresaList);
            return PartialView("_Table", empresas);
        }
    }
}