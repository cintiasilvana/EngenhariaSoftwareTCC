using AutoMapper;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using TCC.Application;
using TCC.Domain.Entities;
using TCC.Domain.Objects;
using TCC.Infra.ValueObject;
using TCC.Web.Models;
using TCC.Web.Reports.Treinamento;

namespace TCC.Web.Controllers
{
    public class TreinamentoRptController : BaseController
    {
        public readonly TreinamentoObject _treinamentoObject = new TreinamentoObject();


        public ActionResult Index()
        {
            return View();
        }

        private TreinamentoRpt RptTreinamento()
        {
            var treinamentoReport = new TreinamentoRpt();
            return treinamentoReport;
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }
            return table;

        }

        public static HttpResponseMessage GetResponseRelatorio(byte[] bytes, string fileName)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.AcceptRanges.Add("bytes");
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = bytes.Length;

            return response;
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public ActionResult VisualizarTreinamentoPDF()
        {
            var relatorio = RptTreinamento();

            //Busca os dados do relatório
            var treinamento = _treinamentoObject.GetTreinamentoRptDto();

            //Converte para dataTable
            var dtTreinamento = ConvertToDataTable(treinamento);

            //Nome do dataTable deve ser o mesmo utilizado nas tables do dataset criado para o relatório
            dtTreinamento.TableName = "Treinamento";

            DataSet ds = new DataSet();
            ds.Tables.Add(dtTreinamento);
            relatorio.SetDataSource(ds);

            Stream streamReport = relatorio.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            var bytes = ReadFully(streamReport);

            var base64 = Convert.ToBase64String(bytes);
            var pdfUrl = "data:application/pdf;base64," + base64;

            return Json(pdfUrl, JsonRequestBehavior.AllowGet);
        }
    }
}