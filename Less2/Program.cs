using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Less2
{
    
    /// <summary>
    /// Практическая работа с применением рефлексиеи.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //MethodComparer methodComparer = new MethodComparer() { Field = MethodComparer.CompareField.byLenghtOfNameMethod };
            //List<MethodInfo> methods = typeof(int).GetMethods().ToList();
            //methods.Sort(methodComparer);
            //Console.WriteLine();
            //Console.WriteLine("{0} {1,20} {2,20}", "Name", "Number param", "Lenth name");
            //foreach (var item in methods)
            //{
            //    Console.WriteLine("{0} {1,20} {2,20}", item.Name, item.GetParameters().Length, item.Name.Length);
            //}

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Информация по типам:");
                Console.WriteLine("1 – Общая информация по типам");
                Console.WriteLine("2 – Выбрать тип из списка");
                Console.WriteLine("3 – Параметры консоли");
                Console.WriteLine("0 - Выход из программы");
                switch (Console.ReadKey(true).Key)
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

        /// <summary>
        /// Общая информация по типам
        /// </summary>
        private static void ShowAllTypeInfo()
        {
            Console.Clear();
            InfoOfAssembly dataAssembly = SolverForTask1.GetAllInfo();

            Console.WriteLine("Общая информация по типам:{0, 55}", "шт.");
            Console.WriteLine("Подключенные сборки: {0, 59}", dataAssembly.countConnectingAssemblies);
            Console.WriteLine("Всего типов по всем подключенным сборкам: {0, 38}", dataAssembly.countUniqueTepesInCurrentAssembly);
            Console.WriteLine("Ссылочные типы: {0, 64}", dataAssembly.countRefTypes);
            Console.WriteLine("Значимые типы: {0, 65}", dataAssembly.countValueType);
            Console.WriteLine("Типы интерфейсы: {0, 63}", dataAssembly.countInterface);
            Console.WriteLine("Тип с максимальным числом методов: {0} {1,31}", dataAssembly.nameType, dataAssembly.maxNumberMethodsOfType);
            Console.WriteLine("Самое длинное название метода: {0} {1,15}", dataAssembly.maxLenghtName, dataAssembly.maxLenghtNameOfMethod);
            Console.WriteLine("Метод с наибольшим числом аргументов: {0} {1,35}", dataAssembly.nameMethodMaxParam, dataAssembly.maxCountArgumentsInMethod);
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в главное меню");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Выбрать тип из списка
        /// </summary>
        private static void SelectType()
        {
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
                
                switch (Console.ReadKey(true).Key)
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
        /// Изменение настроек консоли.
        /// </summary>
        private static void ChangeConsoleView()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Изменение настроек консоли.");
                Console.WriteLine("1 – Изменение фона консоли.");
                Console.WriteLine("2 – Изменение цвета текста в консоли");
                Console.WriteLine("0 - Выход в главное меню");
                switch (Console.ReadKey(true).Key)
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
        /// Сводный данные о выбранном типе.
        /// </summary>
        private static void ShowInfoAboutChooseType(Type type)
        {
            Console.Clear();
            var dataOfChooseType = SolverForTask1.GetDataOfChooseType(type);
            Console.WriteLine("Информация по типу: " + dataOfChooseType.Name);
            Console.WriteLine("Значимый тип: " + dataOfChooseType.IsValueType);
            Console.WriteLine("Пространство имен: " + dataOfChooseType.NamespaceName);
            Console.WriteLine("Имя сборки: " + dataOfChooseType.NameAssembly);
            Console.WriteLine("Общее число элементов: "+ dataOfChooseType.AllCountElements);
            Console.WriteLine("Число методов: "+ dataOfChooseType.CountMethods);
            Console.WriteLine("Число свойств: " + dataOfChooseType.CountProperties);
            Console.WriteLine("Число полей: " + dataOfChooseType.CountFields);
            Console.WriteLine("Список полей: " + dataOfChooseType.NamesFields);
            Console.WriteLine("Список свойств: {0}" , dataOfChooseType.NamesProperties);
            Console.WriteLine("Нажмите ‘M’ для вывода дополнительной информации по методам:");
            Console.WriteLine("Нажмите ‘0’ для выхода в главное меню");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.M:
                    Console.Clear();
                    while (true)
                    {

                        Dictionary<string, DataMethods>  groupedMethods = SolverForTask1.GetMethodsGroupedByName(type, out int maxLenthMethodsName);
                        List<Datas> data = new();
                        Console.WriteLine($"Выбирите способ сортировки информации о методах типа {type.Name}");
                        Console.WriteLine("1 – по Имени.");
                        Console.WriteLine("2 – по длине имени");
                        Console.WriteLine("3 – по количеству параметров.");
                        Console.WriteLine("0 – Выход в главное меню");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                data = SolverForTask1.Sorted(groupedMethods, new MethodComparer() { Field = MethodComparer.CompareField.byNameMethod });
                                break;
                            case ConsoleKey.D2:
                                data = SolverForTask1.Sorted(groupedMethods, new MethodComparer() { Field = MethodComparer.CompareField.byLenghtOfNameMethod });
                                break;
                            case ConsoleKey.D3:
                                data = SolverForTask1.Sorted(groupedMethods, new MethodComparer() { Field = MethodComparer.CompareField.byCountArguments });
                                break;
                            case ConsoleKey.D0:
                                Console.Clear();
                                return;
                            default:
                                ErrorMsg();
                                break;
                        }
                        //тут получить сгруппированную структуру по какому то критерию SortedParam { ...}


                        //вывод на консоль сгруппированных методов
                        ShowGroupedMethods(type.Name, data, maxLenthMethodsName);
                        Console.ReadKey(true);
                        break;
                    }
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
        /// Вывод на консоль сгруппированные методы
        /// </summary>
        /// <param name="groupedMethods">Сгруппированные методы типа.</param>
        /// <param name="maxLenthMethodsName">Макс длина метода в типе.</param>
        private static void ShowGroupedMethods(string name, List<Datas> groupedMethods, int maxLenthMethodsName)
        {
            string s1 = "Название метода", s2 = "Макс число парамтеров у метода", s3 = "Число перегрузок", s4 = "Число параметров";
            // 
            Console.Clear();

            Console.WriteLine($"Информация о методах типа {name}:\n");

            if (maxLenthMethodsName < 30)
            {
                Console.WriteLine("{0, -30}|{1, -40}|{2, -30}|{3, -30}", s1, s2, s3, s4);
                foreach (var method in groupedMethods)
                {
                    if (method.DataMethod.NumberOverloadsMethod == 0)
                    {
                        continue;
                    }
                    // название метода
                    string nOper = method.Name;
                    // число перегрузок
                    int sOper = method.DataMethod.NumberOverloadsMethod;
                    // мин число параметров 
                    int tOper = method.DataMethod.MinCountParam;
                    // макс число параметров
                    int fOper = method.DataMethod.MaxCountParam;
                    Console.WriteLine("{0, -30}|{1, -40}|{2, -30}|{3}...{4}", nOper, fOper, sOper, tOper, fOper);
                }
            }
            else
            {
                Console.WriteLine("{0, -50}|{1, -50}|{2, -50}{2, -50}", s1, s2, s3, s4);
                foreach (var method in groupedMethods)
                {

                    if (method.DataMethod.NumberOverloadsMethod == 0)
                    {
                        continue;
                    }
                    // название метода
                    string nOper = method.Name;
                    // число перегрузок
                    int sOper = method.DataMethod.NumberOverloadsMethod;
                    // мин число параметров 
                    int tOper = method.DataMethod.MinCountParam;
                    // макс число параметров
                    int fOper = method.DataMethod.MaxCountParam;
                    Console.WriteLine("{0, -50}|{1, -50}|{2, -50}|{3}...{4}", nOper, fOper, sOper, tOper, fOper);
                }
            }
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

        #region Оформление консоли
        
        /// <summary>
        /// Изменение цвета текста в консоли
        /// </summary>
        private static void ChangeColorTextConsole()
        {
            Console.Clear();
            Console.WriteLine("Изменение цвета текста консоли.");
            Console.WriteLine("1 – Красный");
            Console.WriteLine("2 – Желтый");
            Console.WriteLine("3 – Серый");
            Console.WriteLine("4 – Черный");
            Console.WriteLine("0 - Возврат в предыдущее меню");
            switch (Console.ReadKey(true).Key)
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
            Console.Clear();
            Console.WriteLine("Изменение фона консоли.");
            Console.WriteLine("1 – Красный");
            Console.WriteLine("2 – Желтый");
            Console.WriteLine("3 – Серый");
            Console.WriteLine("4 – Черный");
            Console.WriteLine("0 - Возврат в предыдущее меню");
            switch (Console.ReadKey(true).Key)
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
        #endregion

        
    }
}
