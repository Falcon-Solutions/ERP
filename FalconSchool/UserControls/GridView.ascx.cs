using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalconSchool.User_Controls
{
    public partial class GridView : System.Web.Mvc.ViewUserControl<IEnumerable>
    {
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsDetails { get; set; }

        public GridView()
        {

        }

        protected PropertyInfo[] Columns
        {
            get
            {
                var e = ViewData.Model.GetEnumerator();
                e.MoveNext();
                object firstRow = e.Current;
                if (firstRow == null)
                {
                    throw new Exception("No data passed to GridView User Control.");
                }

                return firstRow.GetType().GetProperties();
            }
        }

        protected IEnumerable Rows
        {
            get { return ViewData.Model; }
        }


        protected object GetColumnValue(object row, string columnName)
        {
            return DataBinder.Eval(row, columnName);
        }

        protected object GetColumnValue(object row, string columnName, string format)
        {
            return DataBinder.Eval(row, columnName, format);
        }


        bool flip = false;
        protected string FlipCssClass(string className, string alternativeClassName)
        {
            flip = !flip;
            return flip ? className : alternativeClassName;
        }

    }
}