using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class Doctor
{
    public int Experience { get; set; }
    public string Specialization { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public int Age { get; set; }

    public Doctor(int experience, string specialization, string fName, string lName, int age)
    {
        Experience = experience;
        Specialization = specialization;
        FName = fName;
        LName = lName;
        Age = age;
    }

    public void Cure(Patient patient)
    {
        Random random = new Random();
        bool isHealthy = random.Next(2) == 0; // 50% шанс на выздоровление

        if (isHealthy == true)
        {
            Console.WriteLine("Пациент {0} {1} теперь здоров!", patient.FName, patient.LName);
            patient.Status = "Здоров";
        }
        else
        {
            Console.WriteLine("Пациент {0} {1} остался болен", patient.FName, patient.LName);
            patient.Status = "Болен";
        }
    }

    public void CardOfDocotor(Doctor doctor)
    {
        Console.WriteLine("_______________________________________________________________________");
        Console.WriteLine($"Специальность: {doctor.Specialization}");
        Console.WriteLine($"Имя: {doctor.FName}");
        Console.WriteLine($"Фамилия: {doctor.LName}");
        Console.WriteLine($"Стаж: {doctor.Experience}");
        Console.WriteLine($"Возраст: {doctor.Age}");
    }
}



public class Patient
{
    public string FName { get; set; }
    public string LName { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }

    public Patient(string fName, string lName, int age, string address, string status)
    {
        FName = fName;
        LName = lName;
        Age = age;
        Address = address;
        Status = status;
    }
    public void MedicalCard(Patient patient)
    {
        Console.WriteLine("Карта пациента {0} {1}:", patient.FName, patient.LName);
        Console.WriteLine($"Имя: {patient.FName}");
        Console.WriteLine($"Фамилия: {patient.LName}");
        Console.WriteLine($"Возраст: {patient.Age}");
        Console.WriteLine($"Адресс: {patient.Address}");
        Console.WriteLine($"Статус пациента: {patient.Status}");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        List<Doctor> doctors = new List<Doctor>()
        {
            new Doctor(7,  "Терапевт",     "Пётр",     "Медведев",     35),
            new Doctor(3,   "Офтальмолог",  "Дмитрий",  "Терентьев",    28),
            new Doctor(11,  "Невролог",     "Ярослава", "Кузьмина",     41)
        };

        List<Patient> patients = new List<Patient>()
        {
            new Patient("Полина",   "Архипова", 25, "ул. Алтайская",        "Болен"),
            new Patient("Варвара",  "Акимова",  47, "ул. Сибирская",        "Болен"),
            new Patient("Алексей",  "Морозов",  32, "ул. Учебная",          "Болен"),
            new Patient("Кирилл",   "Черных",   60, "ул. Красноармейская",  "Болен")
        };

        Console.WriteLine("\t\t+--------------------------+");
        Console.WriteLine("\t\t|Онлайн-больница \"На грани\"| ");
        Console.WriteLine("\t\t+--------------------------+");

        int menu = 0;

        while (true)
        {
            Console.WriteLine("\nВыберете необходимую функцию:");
            Console.WriteLine("1. Узнать количество пациентов в клинике.");
            Console.WriteLine("2. Посмотреть медицинскую карту.");
            Console.WriteLine("3. Посмотреть историю лечения больных.");
            Console.WriteLine("4. Узнать количество врачей в клинике.");
            Console.WriteLine("5. Узнать специальности врачей.");
            Console.WriteLine("6. Выход.\n");

            try { menu = UInt16.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("Ошибка, введите числовое значение!"); }

            switch (menu)
            {
                case 1:
                    Console.WriteLine($"Количество пациентов: {patients.Count}");
                    break;
                case 2:
                    Console.WriteLine("Медицинские карты пациентов:\n");
                    foreach (Patient patient in patients)
                    {
                        patient.MedicalCard(patient);
                        Console.WriteLine("_______________________________________________________________________");
                        Console.WriteLine();
                        
                    }
                    break;
                case 3:
                    Console.WriteLine("История лечения больных:\n");
                    foreach (Doctor doctor in doctors)
                    {
                        foreach (Patient patient in patients)
                        {
                            Console.WriteLine("Пациент {0} {1} записался к врачу специальности  \"{2}\"", patient.FName, patient.LName, doctor.Specialization);
                            Console.WriteLine("Пациент {0} {1} пришел к врачу {2} {3}", patient.FName, patient.LName, doctor.FName, doctor.LName);
                            doctor.Cure(patient);
                            Console.WriteLine("_______________________________________________________________________");
                            Console.WriteLine();
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine($"Количество врачей в клинике: {doctors.Count}");
                    break;
                case 5:
                    Console.WriteLine("Врачи нашей клиники: ");
                    foreach (Doctor doctor in doctors)
                    {
                        doctor.CardOfDocotor(doctor);
                    }    
                    break;
                case 6:
                    Console.WriteLine("Ждём Вас снова в онлайн-больнице \"На грани\"!");
                    return;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
        }
        
    }
}