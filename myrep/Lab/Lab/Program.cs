﻿namespace Lab
{
    internal class Program
    {
        public static void Main()
        {
            MyCompany company = new();
            company.Init();
            Timeboard timeboard = new();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("***********************************");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить сотрудника");
                Console.WriteLine("2. Просмотреть всех сотрудников");
                Console.WriteLine("3. Просмотреть табель рабочего времени");
                Console.WriteLine("4. Заполнить табель рабочего времени");
                Console.WriteLine("5. Посчитать зарплату сотрудику");
                Console.WriteLine("6. Выйти");

                var enter = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int count = 0;
                switch (enter)
                {
                    case 1:
                        {
                            count++;
                            var number = count;
                            Console.WriteLine("Введите ФИО сотрудника");
                            var name = Console.ReadLine() ?? string.Empty;
                            Console.WriteLine("Введите разряд");
                            var rate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите дату приёма на должность(год, месяц, день через Enter)");
                            var year = Convert.ToInt32(Console.ReadLine());
                            var month = Convert.ToInt32(Console.ReadLine());
                            var day = Convert.ToInt32(Console.ReadLine());
                            DateOnly date = new(year, month, day);
                            bool ismemberoflaborunion;
                            Console.WriteLine("Является ли сотрудник членом профсоюза?(Да, Нет)");
                            if (Console.ReadLine() == "Да") ismemberoflaborunion = true;
                            else ismemberoflaborunion = false;
                            Employee employee = new(number, name, rate, date, ismemberoflaborunion);
                            Console.WriteLine("0. Электрик\n1. Плотник\n2. Резчик по дереву");
                            Console.WriteLine("3. Столяр\n4. Маляр\n5. Каменщик");
                            Console.WriteLine("Введите номер должности");
                            var code = Convert.ToInt32(Console.ReadLine());
                            foreach (var position in company.GetAllPositions())
                            {
                                if (position.GetCode() == code)
                                {
                                    employee.SetPosition(position);
                                    employee.SetHourlyRate();
                                    break;
                                }
                            }
                            employee.AddEmployee(company);
                            Console.WriteLine("Добавить еще одного сотрудника?(Да, Нет)");
                            if (Console.ReadLine() == "Да")
                            {
                                Console.Clear();
                                goto case 1;
                            }
                            else Console.Clear();
                            break;
                        }

                    case 2:
                        {
                            PrintEmp();
                            break;
                        }

                    case 3:
                        {
                            var timesheet = timeboard.GetTimesheet();
                            foreach (KeyValuePair<DateOnly, SortedDictionary<int, int>> day in timesheet)
                            {
                                foreach (KeyValuePair<int, int> code_hours in day.Value)
                                {
                                    var employee = company.GetEmploymentByCode(code_hours.Key, code_hours);
                                    if (day.Key >= employee.GetEmploymentDate()) Console.WriteLine($"Дата: {day.Key} - {day.Key.DayOfWeek},\nРаботник - {employee.GetFullName()},\nВремя работы в часах: {code_hours.Value}\number");
                                }
                                Console.WriteLine("***********************************");
                            }
                            break;
                        }

                    case 4:
                        {
                            PrintEmplNum();
                            var number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите дату(год, месяц, день через Enter)");
                            var year = Convert.ToInt32(Console.ReadLine());
                            var month = Convert.ToInt32(Console.ReadLine());
                            var day = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите количество отработанных часов");
                            var hours = Convert.ToInt32(Console.ReadLine());
                            timeboard.ReadTimesheet(year, month, day, number, hours);
                            break;
                        }

                    case 5:
                        {
                            PrintEmplNum();
                            var number = Convert.ToInt32(Console.ReadLine());
                            Employee currentemployee = new();
                            foreach (var employee in company.GetAllEmployees())
                            {
                                if (employee.GetNumber() == number) currentemployee = employee;
                                else
                                {
                                    Console.WriteLine("Нет такого сотрудника");
                                    goto case 5;
                                }
                            }

                            Console.WriteLine("Введите дату начальной даты(год, месяц, день через Enter)");
                            var startyear = Convert.ToInt32(Console.ReadLine());
                            var startmonth = Convert.ToInt32(Console.ReadLine());
                            var startday = Convert.ToInt32(Console.ReadLine());
                            timeboard.ReadStartDate(startyear, startmonth, startday);
                            Console.WriteLine("Введите дату конечной даты(год, месяц, день через Enter)");
                            var endyear = Convert.ToInt32(Console.ReadLine());
                            var endmonth = Convert.ToInt32(Console.ReadLine());
                            var endday = Convert.ToInt32(Console.ReadLine());
                            timeboard.ReadEndDate(endyear, endmonth, endday);
                            Console.Write($"Заработная плата сотрудника равна - {currentemployee.GetSalary(timeboard)} рублей");
                            break;

                        }
                    case 6: { Console.Clear(); exit = true; break; }
                }
            }

            void PrintEmplNum()
            {
                var employees = company.GetAllEmployees();
                var number = 0;
                foreach (var employee in employees)
                {
                    number++;
                    Console.WriteLine($"{number}. {employee.GetFullName()}, {employee.GetPosition().GetName()}");
                }
                Console.WriteLine("Введите табельный номер работника");
            }

            void PrintEmp()
            {
                Console.WriteLine("Список сотрудников:");
                foreach (var employee in company.GetAllEmployees())
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}
