using System;
using System.Reflection;
using System.Collections.Generic;

namespace Less2
{
    
    /// <summary>
    /// Приложение по работе с рефлексией.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Работа с консолью
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // Viewer 

            Viewer viewer1 = Viewer.Singletone();
            
            
            while (true)
            {
                ConsoleKey key;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Информация по типам:");
                    Console.WriteLine("1 – Общая информация по типам");
                    Console.WriteLine("2 – Выбрать тип из списка");
                    Console.WriteLine("3 – Параметры консоли");
                    Console.WriteLine("0 - Выход из программы");
                    key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            ShowAllTypeInfo();
                            break;
                        case ConsoleKey.D2:
                            SelectType();
                            break;
                        case ConsoleKey.D3:
                            ChangeConsoleView();
                            break;
                        case ConsoleKey.D0:
                            Console.Clear();
                            Console.WriteLine("Работа завершена. До свидания.");
                            return;
                        default:
                            ErrorMsg();
                            break;
                    }
                }
            }

        }

        /// <summary>
        /// Выбрать тип из списка
        /// </summary>
        private static void SelectType()
        {
            ConsoleKey key;
            Type type;
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Информация по типам");
                Console.WriteLine("Выберите тип:");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1 – uint");
                Console.WriteLine("2 – int");
                Console.WriteLine("3 – long");
                Console.WriteLine("4 – float");
                Console.WriteLine("5 – double");
                Console.WriteLine("6 – char");
                Console.WriteLine("7 - string");
                Console.WriteLine("8 – Vector");
                Console.WriteLine("9 – Matrix");
                Console.WriteLine("0 – Выход в главное меню");
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        type = typeof(uint);
                        ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D2:
                        type = typeof(int);
                        ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D3:
                        type = typeof(long);
                        ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D4:
                        type = typeof(float);
                        ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D5:
                        type = typeof(double);
                        ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D6:
                        type = typeof(char);
                        ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D7:
                        type = typeof(string);
                        ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.WriteLine("Пока ничего нет.");
                        Console.ReadLine();
                        //type = typeof(string);
                        //ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D9:
                        Console.Clear();
                        Console.WriteLine("Пока ничего нет.");
                        Console.ReadLine();
                        //type = typeof(string);
                        //ShowInfoAboutChooseType(type);
                        break;
                    case ConsoleKey.D0:
                        Console.Clear();
                        return;
                    default:
                        ErrorMsg();
                        break;
                }
            }
        }
        /// <summary>
        /// Общая информация по типам
        /// </summary>
        /// <param name="type"></param>
        private static void ShowInfoAboutChooseType(Type type)
        {
            ConsoleKey key;
            Console.Clear();
            //TODO убрать методы енамТитл и сделать стринг.Join
            Console.WriteLine("Информация по типу: " + type.Name);
            Console.WriteLine("Значимый тип: " + type.IsValueType);
            Console.WriteLine("Пространство имен: " + type.Namespace);
            Console.WriteLine("Пространство имен: " + type.Assembly.GetName().Name);
            Console.WriteLine("Общее число элементов: "+ type.GetMembers().Length);
            Console.WriteLine("Число методов: "+ type.GetMethods().Length);
            Console.WriteLine("Число свойств: " + type.GetProperties().Length);
            Console.WriteLine("Число полей: " + type.GetFields().Length);
            Console.WriteLine("Список полей: " + enumTitle(type.GetFields()));
            Console.WriteLine("Список свойств: " + enumTitle(type.GetProperties()));
            Console.WriteLine("Нажмите ‘M’ для вывода дополнительной информации по методам:");
            Console.WriteLine("Нажмите ‘0’ для выхода в главное меню");
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.M:
                    Console.Clear();
                    GetMethodsGroupedByName(type);
                    key = Console.ReadKey(true).Key;
                    break;
                case ConsoleKey.D0:
                    Console.Clear();
                    return;
                default:
                    ErrorMsg();
                    break;
            }
            
        }
        /// <summary>
        /// Информация о типе
        /// </summary>
        public struct DataMethods
        {
            /// <summary>
            /// Число перегрузок метода
            /// </summary>
            int numberOverloadsMethod;
            /// <summary>
            /// Минимальное число параметров у метода
            /// </summary>
            int minCountParam;
            /// <summary>
            /// Максимальное число параметров у метода
            /// </summary>
            int maxCountParam;

            public int NumberOverloadsMethod
            {
                get => numberOverloadsMethod;
                set => numberOverloadsMethod = (value >= 0) ? value : throw new Exception();
            }
            public int MinCountParam
            {
                get => minCountParam;
                set => minCountParam = (value >= 0) ? value : throw new Exception();
            }
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
        /// <summary>
        /// Сгрупированные методы типа по именам
        /// </summary>
        /// <param name="type">Анализируемые тип.</param>
        private static void GetMethodsGroupedByName(Type type)
        {
            var methods = type.GetMethods();
            Dictionary<string, DataMethods> dB = new Dictionary<string, DataMethods>();
            int maxLenthMethodsName = -1;
            foreach (var method in methods)
            {
                string name = method.Name;
                maxLenthMethodsName = (name.Length > maxLenthMethodsName) ? name.Length : maxLenthMethodsName;
                if (dB.ContainsKey(name))
                {
                    var temp = dB[name];
                    temp.NumberOverloadsMethod++;
                    temp.MaxCountParam = (temp.MaxCountParam < method.GetParameters().Length) ? method.GetParameters().Length : temp.MaxCountParam;
                    dB[name] = temp;
                }
                else
                {
                    int count = method.GetParameters().Length;
                    dB.Add(name, new DataMethods(numberOverMerth: 1, minParam: count, count));
                }
            }
            string s1 = "Название метода", s2 = "Число перегрузок", s3 = "Число параметров";
            
            Console.WriteLine(type.Name);
            if (maxLenthMethodsName < 30)
            {
                Console.WriteLine("{0, -30}|{1, -30}|{2, -30}\n", s1, s2, s3);
                foreach (KeyValuePair<string, DataMethods> item in dB)
                {
                    var nOper = item.Key;
                    var sOper = item.Value.NumberOverloadsMethod;
                    var tOper = item.Value.MinCountParam;
                    var fOper = item.Value.MaxCountParam;
                    if (tOper == fOper)
                    {
                        Console.WriteLine("{0, -30}|{1, -30}|Без параметров", nOper, sOper);
                    }
                    else
                        Console.WriteLine("{0, -30}|{1, -30}|{2}...{3}", nOper, sOper, tOper, fOper);
                } 
            }
            else
            {
                Console.WriteLine("{0, -50}|{1, -50}|{2, -50}\n", s1, s2, s3);
                foreach (KeyValuePair<string, DataMethods> item in dB)
                {
                    var nOper = item.Key;
                    var sOper = item.Value.NumberOverloadsMethod;
                    var tOper = item.Value.MinCountParam;
                    var fOper = item.Value.MaxCountParam;
                    if (tOper == fOper)
                    {
                        Console.WriteLine("{0, -50}|{1, -50}|Без параметров", nOper, sOper);
                    }
                    else
                        Console.WriteLine("{0, -50}|{1, -50}|{2}...{3}", nOper, sOper, tOper, fOper);
                }
            }
        }

        /// <summary>
        /// Перечисление всех полей
        /// </summary>
        /// <param name="fieldInfos">Массив полей.</param>
        /// <returns>Все поля объекта.</returns>
        private static string enumTitle(FieldInfo[] fieldInfos)
        {
            if (fieldInfos.Length == 0)
            {
                return "-";
            }
            string msg = "";
            foreach (var field in fieldInfos)
            {
                msg += field.Name + " ";
            }
            return msg;
        }
        /// <summary>
        /// Перечисление всех свойств
        /// </summary>
        /// <param name="fieldInfos">Массив свойств объекта</param>
        /// <returns>Все свойства.</returns>
        private static string enumTitle(PropertyInfo[] fieldInfos)
        {
            if (fieldInfos.Length == 0)
            {
                return "-";
            }
            string msg = "";
            foreach (var field in fieldInfos)
            {
                msg += field.Name + " ";
            }
            return msg;
        }
        /// <summary>
        /// Общая информация по типам
        /// </summary>
        private static void ShowAllTypeInfo()
        {
            Console.Clear();
            
            // Создаем 
            Assembly[] refAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<Type> types = new();

            foreach (Assembly asm in refAssemblies)
                types.AddRange(asm.GetTypes());

            List<string> numberNamespace = new ();
            InfoOfAssembly infoAssembly = new ();

            string temp;
            int countParams;
            foreach (var type in types)
            {
                if (!numberNamespace.Contains(type.Namespace))
                {
                    if (type.IsValueType)
                        infoAssembly.countValueType++;
                    else if (type.IsInterface)
                        infoAssembly.countInterface++;

                    var methods = type.GetMethods();
                    if (methods.Length > infoAssembly.maxNumberMethodsOfType)
                    {
                        infoAssembly.maxNumberMethodsOfType = methods.Length;
                        infoAssembly.nameType = type.Name;
                    }
                    
                    foreach (var method in methods)
                    {
                        temp = method.Name;
                        countParams = method.GetParameters().Length;
                        if (countParams > infoAssembly.maxCountArgumentsInMethod)
                        {
                            infoAssembly.maxCountArgumentsInMethod = countParams;
                            infoAssembly.nameMethodMaxParam = temp;
                        }
                        if (temp.Length > infoAssembly.maxLenghtNameOfMethod)
                        {
                            infoAssembly.maxLenghtNameOfMethod = temp.Length;
                            infoAssembly.maxLenghtName = temp;
                        }
                    }
                    numberNamespace.Add(type.Namespace);
                }
            }

            ConsoleKey key;
            // весь текст загнать 
            Console.WriteLine("Общая информация по типам:{0, 55}", "шт.");
            Console.WriteLine("Подключенные сборки: {0, 55}",refAssemblies.Length);
            Console.WriteLine("Всего типов по всем подключенным сборкам: " + numberNamespace.Count);
            Console.WriteLine("Ссылочные типы: " + (numberNamespace.Count - infoAssembly.countValueType));
            Console.WriteLine("Значимые типы: " + infoAssembly.countValueType);
            Console.WriteLine("Типы интерфейсы - " + infoAssembly.countInterface);
            Console.WriteLine("Тип с максимальным числом методов:" + infoAssembly.maxNumberMethodsOfType + " " + infoAssembly.nameType);
            Console.WriteLine("Самое длинное название метода:" + infoAssembly.maxLenghtNameOfMethod + " " + infoAssembly.maxLenghtName);
            Console.WriteLine("Метод с наибольшим числом аргументов:" + infoAssembly.maxCountArgumentsInMethod + " " + infoAssembly.nameMethodMaxParam);
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в главное меню");
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню".Length);
            key = Console.ReadKey(true).Key;
        }
        /// <summary>
        /// Изменение настроек консоли.
        /// </summary>
        private static void ChangeConsoleView()
        {
            ConsoleKey key;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Изменение настроек консоли.");
                Console.WriteLine("1 – Изменение фона консоли.");
                Console.WriteLine("2 – Изменение цвета текста в консоли");
                Console.WriteLine("0 - Выход в главное меню");
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        ChangeBackgroundColor();
                        break;
                    case ConsoleKey.D2:
                        ChangeColorTextConsole();
                        break;
                    case ConsoleKey.D0:
                        Console.Clear();
                        return;
                    default:
                        ErrorMsg();
                        break;
                }
            }
        }
        /// <summary>
        /// Изменение цвета текста в консоли
        /// </summary>
        private static void ChangeColorTextConsole()
        {
            ConsoleKey key;
            Console.Clear();
            Console.WriteLine("Изменение цвета текста консоли.");
            Console.WriteLine("1 – Красный");
            Console.WriteLine("2 – Желтый");
            Console.WriteLine("3 – Серый");
            Console.WriteLine("4 – Черный");
            Console.WriteLine("0 - Возврат в предыдущее меню");
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    SetColorTextConsole(ConsoleColor.Red);
                    break;
                case ConsoleKey.D2:
                    SetColorTextConsole(ConsoleColor.Yellow);
                    break;
                case ConsoleKey.D3:
                    SetColorTextConsole(ConsoleColor.Gray);
                    break;
                case ConsoleKey.D4:
                    SetColorTextConsole(ConsoleColor.Black);
                    break;
                case ConsoleKey.D0:
                    Console.Clear();
                    return;
                default:
                    ErrorMsg();
                    break;
            }
        }
        /// <summary>
        /// Изменение цвета фона консоли
        /// </summary>
        private static void ChangeBackgroundColor()
        {
            ConsoleKey key;
            Console.Clear();
            Console.WriteLine("Изменение фона консоли.");
            Console.WriteLine("1 – Красный");
            Console.WriteLine("2 – Желтый");
            Console.WriteLine("3 – Серый");
            Console.WriteLine("4 – Черный");
            Console.WriteLine("0 - Возврат в предыдущее меню");
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    SetBackgroundColor(ConsoleColor.Red);
                    break;
                case ConsoleKey.D2:
                    SetBackgroundColor(ConsoleColor.Yellow);
                    break;
                case ConsoleKey.D3:
                    SetBackgroundColor(ConsoleColor.Gray);
                    break;
                case ConsoleKey.D4:
                    SetBackgroundColor(ConsoleColor.Black);
                    break;
                case ConsoleKey.D0:
                    Console.Clear();
                    return;
                default:
                    ErrorMsg();
                    break;
            }
        }
        /// <summary>
        /// Установка цвета текста в консоли
        /// </summary>
        /// <param name="color"></param>
        /// <summary>
        /// Установка цвета текста консоли
        /// </summary>
        /// <param name="color">Цвет текста.</param>
        private static void SetColorTextConsole(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            if (Console.ForegroundColor == Console.BackgroundColor)
            {
                Console.BackgroundColor -= 1;
            }
            Console.Clear();
        }
        /// <summary>
        /// Установка цвета фона консоли
        /// </summary>
        /// <param name="color"></param>
        /// <summary>
        /// Установка цвета текста консоли
        /// </summary>
        /// <param name="color">Цвет текста.</param>
        private static void SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            if (Console.BackgroundColor == Console.ForegroundColor)
            {
                Console.ForegroundColor += 1;
            }
            Console.Clear();
        }
        /// <summary>
        /// Не корректный выбор
        /// </summary>
        private static void ErrorMsg()
        {
            Console.Clear();
            Console.WriteLine("Вы выбрали некоректное действие.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
