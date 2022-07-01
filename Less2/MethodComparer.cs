using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Less2
{
    public class MethodComparer : IComparer<Datas>
    {
        /// <summary>
        /// Критерий сортировки
        /// </summary>
        public enum CompareField : byte
        {
            /// <summary>
            /// По имени метода.
            /// </summary>
            byNameMethod = 0,
            /// <summary>
            /// По длине имени.
            /// </summary>
            byLenghtOfNameMethod,
            /// <summary>
            /// По числу аргументов.
            /// </summary>
            byCountArguments
        }
        public CompareField Field { get; set; }
        

        public int Compare(DataMethods x, DataMethods y)
        {
            switch (Field)
            {
                case CompareField.byNameMethod:
                    return x.NumberOverloadsMethod.CompareTo(y.NumberOverloadsMethod);
                case CompareField.byLenghtOfNameMethod:
                    return x.MinCountParam.CompareTo(y.MinCountParam);
                case CompareField.byCountArguments:
                    return x.MaxCountParam.CompareTo(y.MaxCountParam); ;
                default:
                    return 0;
            }
        }

        public int Compare(Datas x, Datas y)
        {
            switch (Field)
            {
                case CompareField.byNameMethod:
                    return x.Name.CompareTo(y.Name);
                case CompareField.byLenghtOfNameMethod:
                    return x.Name.Length.CompareTo(y.Name.Length);
                case CompareField.byCountArguments:
                    return x.DataMethod.MaxCountParam.CompareTo(y.DataMethod.MaxCountParam); ;
                default:
                    return 0;
            }
        }
    }
}
