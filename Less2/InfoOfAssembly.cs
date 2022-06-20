using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2
{
    /// <summary>
    /// Данные для общей информации
    /// </summary>
    public struct InfoOfAssembly
    {
        /// <summary>
        /// Количество значимых типов
        /// </summary>
        public int countValueType;
        /// <summary>
        /// Количество интерфейсов
        /// </summary>
        public int countInterface;
        /// <summary>
        /// Макс длина имени метода
        /// </summary>
        public int maxLenghtNameOfMethod;
        /// <summary>
        /// Тип с макс числом методов
        /// </summary>
        public int maxNumberMethodsOfType;
        /// <summary>
        /// Макс число параметров в методе
        /// </summary>
        public int maxCountArgumentsInMethod;
        /// <summary>
        /// Тип с макс числом методов
        /// </summary>
        public string nameType;
        /// <summary>
        /// Метод с макс числом параметров
        /// </summary>
        public string nameMethodMaxParam;
        /// <summary>
        /// Метод с макс длиной имени
        /// </summary>
        public string maxLenghtName;
        public InfoOfAssembly(int defaultIntValue = -1, string defaultStringValue = "")
        {
            countValueType = defaultIntValue;
            countInterface = defaultIntValue;
            maxLenghtNameOfMethod = defaultIntValue;
            maxNumberMethodsOfType = defaultIntValue;
            maxCountArgumentsInMethod = defaultIntValue;
            nameType = defaultStringValue;
            nameMethodMaxParam = defaultStringValue;
            maxLenghtName = defaultStringValue;
        }
    }
}
