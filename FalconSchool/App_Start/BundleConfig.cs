using System.Web;
using System.Web.Optimization;

namespace FalconSchool
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css/Admin_Layout_Css").Include(
                "~/Content/libs/css/style.css",
                "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/vendor/fonts/circular-std/style.css",
                "~/Content/vendor/fonts/fontawesome/css/fontawesome-all.css",
                "~/Content/vendor/fonts/material-design-iconic-font/css/materialdesignicons.min.css"));



            bundles.Add(new StyleBundle("~/Content/css/ProspectList_Css").Include(
                 "~/Content/vendor/datatables/css/buttons.bootstrap4.css",
                 "~/Content/vendor/datatables/css/dataTables.bootstrap4.css",
                 "~/Content/vendor/datatables/css/fixedHeader.bootstrap4.css",
                 "~/Content/vendor/datatables/css/select.bootstrap4.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ProspectList_JS").Include(
                "~/Content/vendor/jquery/jquery-3.5.1.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.js",
                "~/Content/vendor/slimscroll/jquery.slimscroll.js",
                "~/Content/vendor/datatables/js/buttons.bootstrap4.min.js",
                "~/Content/vendor/datatables/js/data-table.js",
                "~/Content/vendor/datatables/js/dataTables.bootstrap4.min.js",
                "~/Content/vendor/datatables/js/jquery.dataTables.min.js",
                "~/Content/vendor/datatables/js/dataTables.buttons.min.js",
                "~/Content/vendor/datatables/js/jszip.min.js",
                "~/Content/vendor/datatables/js/pdfmake.min.js",
                "~/Content/vendor/datatables/js/vfs_fonts.js",
                "~/Content/vendor/datatables/js/buttons.html5.min.js",
                "~/Content/vendor/datatables/js/buttons.print.min.js",
                "~/Content/vendor/datatables/js/buttons.colVis.min.js",
                "~/Content/vendor/datatables/js/dataTables.rowGroup.min.js",
                "~/Content/vendor/datatables/js/dataTables.select.min.js",
                "~/Content/vendor/datatables/js/dataTables.fixedHeader.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Dashboard_JS").Include(
               "~/Content/vendor/jquery/jquery-3.5.1.js",
               "~/Content/vendor/bootstrap/js/bootstrap.bundle.js",
               "~/Content/vendor/slimscroll/jquery.slimscroll.js",
               "~/Content/vendor/charts/chartist-bundle/chartist.min.js",
               "~/Content/vendor/charts/sparkline/jquery.sparkline.js",
               "~/Content/vendor/charts/morris-bundle/raphael.min.js",
               "~/Content/vendor/charts/morris-bundle/morris.js",
               "~/Content/vendor/charts/c3charts/c3.min.js",
               "~/Content/vendor/charts/c3charts/d3-5.4.0.min.js",
               "~/Content/vendor/charts/c3charts/c3chartjs.js",
               "~/Content/libs/js/main-js.js",
               "~/Content/libs/js/dashboard-ecommerce.js"
               ));

            bundles.Add(new StyleBundle("~/Content/css/Dashboard_CSS").Include(
                 "~/Content/vendor/datatables/css/buttons.bootstrap4.css",
                 "~/Content/vendor/datatables/css/dataTables.bootstrap4.css",
                 "~/Content/vendor/datatables/css/fixedHeader.bootstrap4.css",
                 "~/Content/vendor/datatables/css/select.bootstrap4.css"
                ));
        }
    }
}

/* JS Files Locations
                        "~/Content/vendor/jquery/jquery-3.5.1.js"
                        "~/Content/libs/js/main-js.js"
                        "~/Content/libs/js/create-prospect.js"
                        "~/Content/libs/js/dashboard-ecommerce.js"
                        "~/Content/libs/js/dashboard-finance.js"
                        "~/Content/libs/js/dashboard-influencer.js"
                        "~/Content/libs/js/dashboard-sales.js"
                        "~/Content/libs/js/gmaps.min.js"
                        "~/Content/libs/js/google_map.js"
                        "~/Content/libs/js/jvectormap.custom.js"
                        "~/Content/vendor/bootstrap/js/bootstrap.bundle.js"
                        "~/Content/vendor/bootstrap-colorpicker/@claviska/jquery-minicolors/jquery.minicolors.min.js"
                        "~/Content/vendor/bootstrap-colorpicker/jquery-asColor/dist/jquery-asColor.min.js"
                        "~/Content/vendor/bootstrap-colorpicker/jquery-asColorPicker/dist/jquery-asColorPicker.min.js"
                        "~/Content/vendor/bootstrap-colorpicker/jquery-asGradient/dist/jquery-asGradient.js"
                        "~/Content/vendor/bootstrap-select/js/bootstrap-select.js"
                        "~/Content/vendor/charts/c3charts/c3.min.js"
                        "~/Content/vendor/charts/c3charts/C3chartjs.js"
                        "~/Content/vendor/charts/c3charts/d3-5.4.0.min.js"
                        "~/Content/vendor/charts/chartist-bundle/chartist-plugin-threshold.js"
                        "~/Content/vendor/charts/chartist-bundle/chartist.min.js"
                        "~/Content/vendor/charts/chartist-bundle/Chartistjs.js"
                        "~/Content/vendor/charts/charts-bundle/Chart.bundle.js"
                        "~/Content/vendor/charts/charts-bundle/chartjs.js"
                        "~/Content/vendor/charts/morris-bundle/morris.js"
                        "~/Content/vendor/charts/morris-bundle/Morrisjs.js"
                        "~/Content/vendor/charts/morris-bundle/raphael.min.js"
                        "~/Content/vendor/charts/sparkline/jquery.sparkline.js"
                        "~/Content/vendor/charts/sparkline/spark-js.js"
                        "~/Content/vendor/cropper/dist/cropper-int.js"
                        "~/Content/vendor/cropper/dist/cropper.min.js"
                        "~/Content/vendor/datatables/js/buttons.bootstrap4.min.js"
                        "~/Content/vendor/datatables/js/data-table.js"
                        "~/Content/vendor/datatables/js/dataTables.bootstrap4.min.js"
                        "~/Content/vendor/datepicker/datepicker.js"
                        "~/Content/vendor/datepicker/moment.js"
                        "~/Content/vendor/datepicker/tempusdominus-bootstrap-4.js"
                        "~/Content/vendor/dropzone/dropzone.js"
                        "~/Content/vendor/full-calendar/js/calendar.js"
                        "~/Content/vendor/full-calendar/js/fullcalendar.js"
                        "~/Content/vendor/full-calendar/js/jquery-ui.min.js"
                        "~/Content/vendor/full-calendar/js/moment.min.js"
                        "~/Content/vendor/gauge/gauge.js"
                        "~/Content/vendor/gauge/gauge.min.js"
                        "~/Content/vendor/inputmask/js/jquery.inputmask.bundle.js"
                        "~/Content/vendor/jquery/jquery-3.3.1.min.js"
                        "~/Content/vendor/jquery/jquery-3.5.1.intellisense.js"

                        "~/Content/vendor/jquery/jquery-3.5.1.min.js"
                        "~/Content/vendor/jquery/jquery-3.5.1.slim.js"
                        "~/Content/vendor/jquery/jquery-3.5.1.slim.min.js"
                        "~/Content/vendor/jvectormap/jquery-jvectormap-2.0.2.min.js"
                        "~/Content/vendor/jvectormap/jquery-jvectormap-au-mill.js"
                        "~/Content/vendor/jvectormap/jquery-jvectormap-in-mill.js"
                        "~/Content/vendor/jvectormap/jquery-jvectormap-uk-mill-en.js"
                        "~/Content/vendor/jvectormap/jquery-jvectormap-us-aea-en.js"
                        "~/Content/vendor/jvectormap/jquery-jvectormap-world-mill-en.js"
                        "~/Content/vendor/multi-select/js/jquery.multi-select.js"
                        "~/Content/vendor/parsley/parsley.js"
                        "~/Content/vendor/select2/js/select2.min.js"
                        "~/Content/vendor/shortable-nestable/jquery.nestable.js"
                        "~/Content/vendor/shortable-nestable/sort-nest.js"
                        "~/Content/vendor/shortable-nestable/Sortable.min.js"
                        "~/Content/vendor/slimscroll/jquery.slimscroll.js"
                        "~/Content/vendor/summernote/js/summernote-bs4.js"
                        "~/Content/vendor/timeline/js/main.js"
*/

/* CSS Files Locations
                        "~/Content/vendor/bootstrap/css/bootstrap.min.css"
                        "~/Content/libs/css/style.css"
                        "~/Content/vendor/bootstrap/css/bootstrap-select.css"
                        "~/Content/vendor/charts/c3charts/c3.css"
                        "~/Content/vendor/cropper/dist/cropper.min.css"
                        "~/Content/vendor/datatables/css/buttons.bootstrap4.css"
                        "~/Content/vendor/datatables/css/dataTables.bootstrap4.css"
                        "~/Content/vendor/datatables/css/fixedHeader.bootstrap4.css"
                        "~/Content/vendor/datatables/css/select.bootstrap4.css"
                        "~/Content/vendor/datepicker/tempusdominus-bootstrap-4.css"
                        "~/Content/vendor/daterangepicker/daterangepicker.css"
                        "~/Content/vendor/bootstrap/css/bootstrap.min.css"
                        "~/Content/vendor/bootstrap-colorpicker/@claviska/jquery-minicolors/jquery.minicolors.css"
                        "~/Content/vendor/bootstrap-select/css/bootstrap-select.css"
                        "~/Content/vendor/charts/c3charts/c3.css"
                        "~/Content/vendor/charts/chartist-bundle/chartist.css"
                        "~/Content/vendor/charts/morris-bundle/morris.css"
                        "~/Content/vendor/cropper/dist/cropper.min.css"
                        "~/Content/vendor/datatables/css/buttons.bootstrap4.css"
                        "~/Content/vendor/datatables/css/dataTables.bootstrap4.css"
                        "~/Content/vendor/datatables/css/fixedHeader.bootstrap4.css"
                        "~/Content/vendor/datatables/css/select.bootstrap4.css"
                        "~/Content/vendor/datepicker/tempusdominus-bootstrap-4.css"
                        "~/Content/vendor/daterangepicker/daterangepicker.css"
                        "~/Content/vendor/fonts/circular-std/style.css"
                        "~/Content/vendor/fonts/flag-icon-css/flag-icon.min.css"
                        "~/Content/vendor/fonts/fontawesome/css/fontawesome-all.css"
                        "~/Content/vendor/fonts/material-design-iconic-font/css/materialdesignicons.min.css"
                        "~/Content/vendor/fonts/simple-line-icons/css/simple-line-icons.css"
                        "~/Content/vendor/fonts/themify-icons/themify-icons.css"
                        "~/Content/vendor/fonts/weather-icons/css/weather-icons.min.css"
                        "~/Content/vendor/full-calendar/css/fullcalendar.css"
                        "~/Content/vendor/full-calendar/css/fullcalendar.print.css"
                        "~/Content/vendor/inputmask/css/inputmask.css"
                        "~/Content/vendor/jvectormap/jquery-jvectormap-2.0.2.css"
                        "~/Content/vendor/multi-select/css/multi-select.css"
                        "~/Content/vendor/select2/css/select2.css"
                        "~/Content/vendor/summernote/css/summernote-bs4.css"
                        "~/Content/vendor/vector-map/jqvmap.css"
*/
