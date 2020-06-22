using System.Web.Optimization;

namespace TCC.Web
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/jquery/jquery-2.1.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/assets/js/plugins/jquery-validation/js/jquery.validate.js*",
                       "~/assets/js/plugins/jquery-validation/js/localization/messages_pt_BR.js"
                      ));

            //// Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            //// pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                       "~/assets/js/plugins/modernizr/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/assets/js/bootstrap/bootstrap.min.js"
                    ));


            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                "~/assets/js/plugins/datatable/jquery.dataTables.min.js",
                "~/assets/js/plugins/datatable/dataTables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugin").Include(
                "~/assets/js/plugins/bootstrap-datepicker/bootstrap-datepicker.js",
                "~/assets/js/plugins/bootstrap-timepicker/bootstrap-timepicker.min.js",
                "~/assets/js/plugins/moment/moment.min.js",
                "~/assets/js/plugins/bootstrap-tour/bootstrap-tour.custom.js",
                "~/assets/js/plugins/bootstrap-multiselect/bootstrap-multiselect.js",
                "~/assets/js/plugins/select2/select2.min.js",
                "~/assets/js/plugins/jquery-maskedinput/jquery.masked-input.min.js",
                "~/assets/js/plugins/jquery-gritter/js/jquery.gritter.js",
                "~/assets/js/king-common.js",
                "~/demo-style-switcher/assets/js/deliswitch.js"));


            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
