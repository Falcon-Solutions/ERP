using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Utility
{
    public static class Extentions
    {
        public static List<Variance> DetailedCompare<T>(this T val1, T val2)
        {
            List<Variance> variances = new List<Variance>();
            var allProperties = val1.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo f in allProperties)
            {
                Variance v = new Variance();
                v._Prop = f.Name;
                v._FirstVal = f.GetValue(val1);
                v._SecondVal = f.GetValue(val2);
                if (!Equals(v._FirstVal, v._SecondVal))
                    variances.Add(v);

            }
            return variances;
        }


    }

    public class Variance
    {
        public string _Prop { get; set; }
        public object _FirstVal { get; set; }
        public object _SecondVal { get; set; }
    }
}
