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
        /// Количество подключенных сборок.
        /// </summary>
        public int countConnectingAssemblies;
        /// <summary>
        /// Число уникальных типов в текущей сборке.
        /// </summary>
        public int countUniqueTepesInCurrentAssembly;
        /// <summary>
        /// Количество значимых типов
        /// </summary>
        public int countValueType;
        /// <summary>
        /// Количество ссылочных типов
        /// </summary>
        public int countRefTypes;
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
        public InfoOfAssembly(int defaultIntValue = 0, string defaultStringValue = "")
        {
            countConnectingAssemblies = defaultIntValue;
            countUniqueTepesInCurrentAssembly = defaultIntValue;
            countRefTypes = defaultIntValue;
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
    
    public class Datas
    {
        public string Name { get; set; }
        public DataMethods DataMethod { get; set; }
        public override string ToString()
        {
            return Name; 
        }
    }
}
