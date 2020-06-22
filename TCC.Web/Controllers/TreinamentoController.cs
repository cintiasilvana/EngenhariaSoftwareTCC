using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TCC.Application;
using TCC.Domain.Entities;
using TCC.Domain.Objects;
using TCC.Infra.ValueObject;
using TCC.Web.Models;

namespace TCC.Web.Controllers
{
    public class TreinamentoController : BaseController
    {
        public readonly TreinamentoObject _treinamentoObject = new TreinamentoObject();
        public readonly TreinamentoSemanaObject _treinamentoSemanaObject = new TreinamentoSemanaObject();
        public readonly ColaboradorObject _colaboradorObject = new ColaboradorObject();

        public ActionResult Index()
        {
            var treinamentoList = _treinamentoObject.GetTreinamento();
            var treinamentos = Mapper.Map<List<TreinamentoDto>, List<TreinamentoViewModel>>(treinamentoList);
            return View(treinamentos);
        }

        [HttpPost]
        public ActionResult Create(TreinamentoViewModel treinamentoViewModel)
        {
            var response = new ResponseMessage<Treinamento>();
            try
            {
                var treinamento = Mapper.Map<TreinamentoViewModel, Treinamento>(treinamentoViewModel);

                treinamento.TreinamentoSemana = treinamentoViewModel.DiaSemana
                    .Select(d => new TreinamentoSemana
                    {
                        DiaSemana = EnumHelper.GetEnumObjectByValue<eDiaSemana>(d)
                    }).ToList();

                response = _treinamentoObject.InsertOrUpdate(treinamento);
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
            var response = new ResponseMessage<Treinamento>();
            try
            {
                _treinamentoObject.Delete(Id);
                _treinamentoObject.Save();

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
            var treinamento = _treinamentoObject.GetById(Id);
            var semana = _treinamentoSemanaObject.GetByIdTreinamento(treinamento.Id);

            return Json(new { treinamento, semana }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCombo()
        {
            var colaborador = _colaboradorObject.GetCombo();
            var semana = EnumHelper.GetEnumDescriptionList<eDiaSemana>();

            return Json(new { colaborador, semana }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Table()
        {
            var treinamentoList = _treinamentoObject.GetTreinamento();
            var treinamentos = Mapper.Map<List<TreinamentoDto>, List<TreinamentoViewModel>>(treinamentoList);
            return PartialView("_Table", treinamentos);
        }
    }
}