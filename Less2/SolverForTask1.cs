using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Less2.Program;

namespace Less2
{
    public static class SolverForTask1
    {
        
        public static bool CheckType(string typeName, out Type type)
        {
            Dictionary<string, Type>  dbTypes = new Dictionary<string, Type>();
            Assembly[] refAssemblies1 = AppDomain.CurrentDomain.GetAssemblies();
            List<Type> types = GetListTypesInAssembly(refAssemblies1);
            foreach (var typer in types)
            {
                if (!dbTypes.ContainsKey(typer.FullName))
                    dbTypes.Add(typer.FullName, typer);
            }
            if (dbTypes.ContainsKey(typeName))
            {
                type = dbTypes[typeName];
                return true;
            }
            type = null;
            return false;
        }
        
        

        // methods get all info about Assembly
        /// <summary>
        /// Получение сведений о сборке.
        /// </summary>
        public static InfoOfAssembly GetAllInfo()
        {
            InfoOfAssembly infoAssembly = new();

            Assembly[] refAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            // количество подключенных сборок
            infoAssembly.countConnectingAssemblies = refAssemblies.Length;
            // Получили список типов           
            List<Type> types = GetListTypesInAssembly(refAssemblies);
            
            List<string> uniqueNamesTypes = new();

            // Get params
            foreach (var type in types)
            {
                if (!uniqueNamesTypes.Contains(type.FullName))
                {
                    
                    // Считаем число ссылочных, значимых типов и число интерфейсов.
                    infoAssembly = GetCountRefAndValueTypesInAssembly(infoAssembly, type);

                    // поолучаем методы типа
                    var methods = type.GetMethods();
                    // определяем тип с макс числом методов
                    infoAssembly = GetTypeWithMaxValueMethods(infoAssembly, type, methods);

                    string nameMethod;

                    
                    // пробегаем по массиву методов типа
                    foreach (var method in methods)
                    {
                        // имя метода
                        nameMethod = method.Name;
                        // Метод с макс числом аргументов
                        infoAssembly = GetNameMethodWithMaxValueArguments(infoAssembly, nameMethod, method);
                        // опредляем самое длинное название метода
                        infoAssembly = GetLongestNameOfMethod(infoAssembly, nameMethod);
                    }
                    // добавляем в уникальный массив
                    uniqueNamesTypes.Add(type.Namespace);
                }
            }
            infoAssembly.countUniqueTepesInCurrentAssembly = uniqueNamesTypes.Count();
            return infoAssembly;
        }
        /// <summary>
        /// Получение самого длинного имени метода у типа.
        /// </summary>
        private static InfoOfAssembly GetLongestNameOfMethod(InfoOfAssembly infoAssembly, string nameMethod)
        {
            if (nameMethod.Length > infoAssembly.maxLenghtNameOfMethod)
            {
                // длина названия
                infoAssembly.maxLenghtNameOfMethod = nameMethod.Length;
                // название типа
                infoAssembly.maxLenghtName = nameMethod;
            }

            return infoAssembly;
        }

        /// <summary>
        /// Получение метода с макс числом параметров.
        /// </summary>
        private static InfoOfAssembly GetNameMethodWithMaxValueArguments(InfoOfAssembly infoAssembly, string nameMethod, MethodInfo method)
        {
            int countParams = method.GetParameters().Length;

            // метод типа с макс числом параметров nameMethodMaxParam
            if (countParams > infoAssembly.maxCountArgumentsInMethod)
            {
                // число аргументов
                infoAssembly.maxCountArgumentsInMethod = countParams;
                // имя типа
                infoAssembly.nameMethodMaxParam = nameMethod;
            }

            return infoAssembly;
        }

        /// <summary>
        /// Получение типа с макс числом методов.
        /// </summary>
        private static InfoOfAssembly GetTypeWithMaxValueMethods(InfoOfAssembly infoAssembly, Type type, MethodInfo[] methods)
        {
            if (methods.Length > infoAssembly.maxNumberMethodsOfType)
            {
                // число методов
                infoAssembly.maxNumberMethodsOfType = methods.Length;
                // имя типа
                infoAssembly.nameType = type.Name;
            }

            return infoAssembly;
        }
        /// <summary>
        /// Подсчет числа типов: значимых, ссылочных, интерфейсов
        /// </summary>
        private static InfoOfAssembly GetCountRefAndValueTypesInAssembly(InfoOfAssembly infoAssembly, Type type)
        {
            // считаем значимые типы
            if (type.IsValueType)
                infoAssembly.countValueType++;
            // считаем число интерфейсов
            else if (type.IsInterface)
            {
                infoAssembly.countInterface++;
                infoAssembly.countRefTypes++;
            }
            // считаем число ссылочных типов
            else
                infoAssembly.countRefTypes++;
            return infoAssembly;
        }
        /// <summary>
        /// Получение данных о типах в сборке
        /// </summary>
        private static List<Type> GetListTypesInAssembly(Assembly[] refAssemblies)
        {
            List<Type> types = new List<Type>();
            foreach (Assembly asm in refAssemblies)
                types.AddRange(asm.GetTypes());
            return types;
        } 
        public static  string GetListNamesOfType(Type type, NamesForType targetNames)
        {
            switch (targetNames)
            {
                case NamesForType.NamesFields:
                    return GetFieldsNames(type);
                case NamesForType.NamesProperty:
                    return GetPropertiesNames(type);
                case NamesForType.NamesMethods:
                    return GetMethodsNames(type);
                default:
                    throw new Exception();
            }
        }
        private static string GetFieldsNames(Type type)
        {
            // 
            if (type.GetFields().Length < 1)
            {
                return "-";
            }
            return type.GetFields().Select(x => x.Name).Aggregate((w1,w2) => w1 + " " + w2);
        }
        private static string GetPropertiesNames(Type type)
        {
            if (type.GetProperties().Length < 1)
            {
                return "-";
            }
            return type.GetProperties().Select(x => x.Name).Aggregate((w1, w2) => w1 + " " + w2);
        }
        private static string GetMethodsNames(Type type)
        {
            if (type.GetMethods().Length < 1)
            {
                return "-";
            }
            return type.GetMethods().Select(x => x.Name).Aggregate((w1, w2) => w1 + " " + w2);
        }
        internal static Dictionary<string, DataMethods> GetMethodsGroupedByName(Type type, out int maxLenthMethodsName)
        {
            MethodInfo[] methods = type.GetMethods();
            Dictionary<string, DataMethods> dB = new();
            maxLenthMethodsName = 0;
            foreach (var method in methods)
            {
                string name = method.Name;
                int countParams = method.GetParameters().Length;
                maxLenthMethodsName = (maxLenthMethodsName < name.Length) ? name.Length : maxLenthMethodsName;
                if (dB.ContainsKey(name))
                {
                    var temp = dB[name];
                    temp.NumberOverloadsMethod++;
                    temp.MaxCountParam =
                        (temp.MaxCountParam < countParams)
                            ? countParams : temp.MaxCountParam;
                    temp.MinCountParam =
                        (temp.MinCountParam > countParams)
                            ? countParams : temp.MinCountParam;
                    dB[name] = temp;
                }
                else
                {
                    int count = method.GetParameters().Length;
                    dB.Add(name, new DataMethods(numberOverMerth: 0, minParam: count, count));
                }
            }
            return dB;
        }
        /// <summary>
        /// Получение данных о выбранном типе.
        /// </summary>
        internal static (string Name, bool IsValueType, string NamespaceName, string NameAssembly, int AllCountElements,
                        int CountMethods, int CountProperties, int CountFields, string NamesFields, string NamesProperties) GetDataOfChooseType(Type type)
        {
            // string
            string nameOfType = type.Name;
            // bool
            bool isValueType = type.IsValueType;
            // string
            string namespaceName = type.Namespace;
            // string
            string nameAssembly = type.Assembly.GetName().Name;
            // int
            int allCountElements = type.GetMembers().Length;
            // int
            int countMethods = type.GetMethods().Length;
            // int
            int countProperties = type.GetProperties().Length;
            // int
            int countFields = type.GetFields().Length;
            // string
            string namesFields = GetListNamesOfType(type, NamesForType.NamesFields);
            // string
            string namesProperties = GetListNamesOfType(type, NamesForType.NamesProperty);
            return (nameOfType, isValueType, namespaceName, nameAssembly,
                    allCountElements, countMethods, countProperties, countFields,
                    namesFields, namesProperties);
        }

        internal static List<Datas> Sorted(Dictionary<string, DataMethods> groupedMethods, MethodComparer methodComparer)
        {
            List<Datas> datas = GetNeedStruct(groupedMethods);
            datas.Sort(methodComparer);
            return datas;
        }
        /// <summary>
        /// Объединяет данные для сортировки.
        /// </summary>
        private static List<Datas> GetNeedStruct(Dictionary<string, DataMethods> groupedMethods)
        {
            List<Datas> datas = new List<Datas>();

            foreach (KeyValuePair<string, DataMethods> dataMethod in groupedMethods)
            {
                Datas temp = new Datas();
                temp.Name = dataMethod.Key;
                temp.DataMethod = dataMethod.Value;
                datas.Add(temp);
                temp = null;
            }

            return datas;
        }
    }
    

    /// <summary>
    /// Критерий получения имён 
    /// </summary>
    public enum NamesForType
    {
        /// <summary>
        ///  Имена для полей
        /// </summary>
        NamesFields = 1,
        /// <summary>
        /// Имена для свойств
        /// </summary>
        NamesProperty,
        /// <summary>
        /// Имена для методов
        /// </summary>
        NamesMethods
    }

    /// <summary>
    /// Информация о типе
    /// </summary>
    public struct DataMethods
    {
        int numberOverloadsMethod;
        int minCountParam;
        int maxCountParam;
        /// <summary>
        /// Число перегрузок метода
        /// </summary>
        public int NumberOverloadsMethod
        {
            get => numberOverloadsMethod;
            set => numberOverloadsMethod = (value >= 0) ? value : throw new Exception();
        }
        /// <summary>
        /// Минимальное число параметров у метода
        /// </summary>
        public int MinCountParam
        {
            get => minCountParam;
            set => minCountParam = (value >= 0) ? value : throw new Exception();
        }
        /// <summary>
        /// Максимальное число параметров у метода
        /// </summary>
        public int MaxCountParam
        {
            get => maxCountParam;
            set => maxCountParam = (value >= 0) ? value : throw new Exception();
        }
        /// <summary>
        /// Конструктор 1
        /// </summary>
        /// <param name="numberOverMerth">Число перегрузок у метода.</param>
        /// <param name="minParam">Минимальное число параметров.</param>
        /// <param name="maxParam">Максимальное число параметров.</param>
        public DataMethods(int numberOverMerth = 0, int minParam = 0, int maxParam = 0)
        {
            numberOverloadsMethod = numberOverMerth;
            minCountParam = minParam;
            maxCountParam = maxParam;
        }
    }
}
