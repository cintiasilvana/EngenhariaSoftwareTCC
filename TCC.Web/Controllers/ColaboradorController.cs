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
    public class ColaboradorController : BaseController
    {
        public readonly ColaboradorObject _colaboradorObject = new ColaboradorObject();

        public ActionResult Index()
        {
            var colaborador = _colaboradorObject.GetAllList();
            var colaboradores = Mapper.Map<List<Instrutor>, List<ColaboradorViewModel>>(colaborador);
            return View(colaboradores);
        }

        [HttpPost]
        public ActionResult Create(ColaboradorViewModel colaboradorViewModel)
        {
            var response = new ResponseMessage<Instrutor>();
            try
            {
                var colaborador = Mapper.Map<ColaboradorViewModel, Instrutor>(colaboradorViewModel);
                response = _colaboradorObject.InsertOrUpdate(colaborador);
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
            var response = new ResponseMessage<Instrutor>();
            try
            {

                _colaboradorObject.Delete(Id);
                _colaboradorObject.Save();

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
            var colaborador = _colaboradorObject.GetById(Id);
            return Json(colaborador, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetCombo()
        {
            var atividade = EnumHelper.GetEnumDescriptionList<eTipoAtividade>();
            var perfil = EnumHelper.GetEnumDescriptionList<eTipoPerfil>();

            return Json(new { atividade, perfil }, JsonRequestBehavior.AllowGet);
        }

        private void InsertColaborador(Instrutor colaborador)
        {
            _colaboradorObject.Add(colaborador);
            _colaboradorObject.Save();
        }

        [HttpGet]
        public ActionResult Table()
        {
            var colaboradorList = _colaboradorObject.GetAllList();
            var colaboradors = Mapper.Map<List<Instrutor>, List<ColaboradorViewModel>>(colaboradorList);
            return PartialView("_Table", colaboradors);
        }
    }
}