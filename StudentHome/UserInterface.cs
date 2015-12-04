﻿using System;
using System.Diagnostics;
using StudentHome.Core;
using StudentHome.Domain;
using StudentHome.Repository;
using StudentHome.Service;

namespace StudentHome
{
    public class UserInterface
    {
        private AppManager appManager;
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("0 - Iesire");
                Console.WriteLine("1 - Adauga camin");
                Console.WriteLine("2 - Afiseaza lista de camine");
                Console.WriteLine("3 - Adauga student");
                Console.WriteLine("4 - Afiseaza lista de studenti");
                Console.WriteLine("5 - Adauga angajat");
                Console.WriteLine("6 - Afiseaza lista de angajati");
                Console.Write("Comanda : ");
                string option = Console.ReadLine();
                try
                {
                    switch (option)
                    {
                        case "0":
                            appManager.SaveAllToXml();
                            return;
                        case "1":
                            AddStudentHome();
                            break;
                        case "2":
                            ShowStudentHomes();
                            break;
                        case "3":
                            AddStudent();
                            break;
                        case "4":
                            ShowStudents();
                            break;
                        case "5":
                            AddEmployee();
                            break;
                        case "6":
                            ShowEmployees();
                            break;
                        default:
                            Console.WriteLine("Optiune invalida! Va rog reintroduceti comanda :");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    Trace.WriteLine(e.StackTrace);
                }
            }


        }

        private void ShowEmployees()
        {
            try
            {
                int numberOfEmployees = appManager.CountEmployees();
                int i = 0;
                do
                {
                    i++;
                    Pageable pageable = new Pageable();
                    pageable.setPageNumber(i);
                    pageable.setPageSize(Constants.PAGE_SIZE);
                    Page<Domain.Employee> page = appManager.GetEmployeePage(pageable);

                    String pageToString = string.Format("----------------------  PAGE {0} : ------------------------------", i);
                    Console.WriteLine(pageToString);
                    foreach (var item in page.getItems())
                    {
                        Console.WriteLine(item);
                    }
                }
                while (i * Constants.PAGE_SIZE < numberOfEmployees);
            }
            catch (ServiceException e)
            {
                Trace.WriteLine("showStudents - ServiceException " + e.Message);
            }
        }

        private void AddEmployee()
        {
            try
            {
                string CNP, nume, prenume, post;
                IOEmployee(out CNP, out nume, out prenume, out post);
                appManager.AddEmployee(CNP, nume, prenume, post);
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Va rog introduceti date valide!");
                AddEmployee();
            }
            catch (RepositoryException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Va rog introduceti date valide!");
                AddEmployee();
            }
        }

        private void IOEmployee(out string cnp, out string nume, out string prenume, out string post)
        {
            Console.Write("PIN : ");
            cnp = Console.ReadLine();
            Console.Write("Name angajat : ");
            nume = Console.ReadLine();
            Console.Write("Surname angajat : ");
            prenume = Console.ReadLine();
            Console.Write("Job : ");
            post = Console.ReadLine();
        }

        private void ShowStudents()
        {
            try
            {
                int numberOfStudents = appManager.CountStudents();
                int i = 0;
                do
                {
                    i++;
                    Pageable pageable = new Pageable();
                    pageable.setPageNumber(i);
                    pageable.setPageSize(Constants.PAGE_SIZE);
                    Page<Domain.Student> page = appManager.GetStudentPage(pageable);

                    String pageToString = string.Format("----------------------  PAGE {0} : ------------------------------", i);
                    Console.WriteLine(pageToString);
                    foreach (var item in page.getItems())
                    {
                        Console.WriteLine(item);
                    }
                }
                while (i * Constants.PAGE_SIZE < numberOfStudents);
            }
            catch (ServiceException e)
            {
                Trace.WriteLine("showStudents - ServiceException " + e.Message);
            }
        }

        private void AddStudent()
        {
            try
            {
                string CNP, nume, prenume;
                double mediaAnuala;
                IOStudent(out CNP, out nume, out prenume, out mediaAnuala);
                appManager.AddStudent(CNP, nume, prenume, mediaAnuala);
            }
            catch (FormatException)
            {
                Trace.WriteLine("Va rog introduceti un numar real!");
                AddStudent();
            }
            catch (OverflowException)
            {
                Trace.WriteLine("Va rog introduceti un numar mai mic!");
                AddStudent();
            }
            catch (ValidationException e)
            {
                Trace.WriteLine(e.Message);
                Console.WriteLine("Va rog introduceti date valide!");
                AddStudent();
            }
            catch (RepositoryException e)
            {
                Trace.WriteLine(e.Message);
                Console.WriteLine("Va rog introduceti date valide!");
                AddStudent();
            }
        }

        private void IOStudent(out string cnp, out string nume, out string prenume, out double mediaAnuala)
        {
            Console.Write("PIN : ");
            cnp = Console.ReadLine();
            Console.Write("Name student : ");
            nume = Console.ReadLine();
            Console.Write("Surname student : ");
            prenume = Console.ReadLine();
            Console.Write("Annual Grade : ");
            mediaAnuala = double.Parse(Console.ReadLine());
        }

        private void AddStudentHome()
        {
            try
            {
                string nume;
                int numarPersoaneInCamera, numarCamere, regie;
                IOStudentHome(out nume, out numarPersoaneInCamera, out numarCamere, out regie);
                appManager.AddStudentHome(nume, numarPersoaneInCamera, numarCamere, regie);
            }
            catch (FormatException)
            {
                Trace.WriteLine("Va rog introduceti un numar intreg!");
                AddStudentHome();
            }
            catch (OverflowException)
            {
                Trace.WriteLine("Va rog introduceti un numar mai mic!");
                AddStudentHome();
            }
            catch (ValidationException e)
            {
                Trace.WriteLine(e.Message);
                Console.WriteLine("Va rog introduceti date valide!");
                AddStudentHome();
            }
            catch (RepositoryException e)
            {
                Trace.WriteLine(e.Message);
                Console.WriteLine("Va rog introduceti date valide!");
                AddStudentHome();
            }

        }

        private void ShowStudentHomes()
        {
            try
            {
                int numberOfStudentHomes = appManager.CountStudentHomes();
                int i = 0;
                do
                {
                    i++;
                    Pageable pageable = new Pageable();
                    pageable.setPageNumber(i);
                    pageable.setPageSize(Constants.PAGE_SIZE);
                    Page<Domain.StudentHome> page = appManager.GetStudentHomePage(pageable);

                    String pageToString = string.Format("----------------------  PAGE {0} : ------------------------------", i);
                    Console.WriteLine(pageToString);
                    foreach (var item in page.getItems())
                    {
                        Console.WriteLine(item);
                    }
                }
                while (i * Constants.PAGE_SIZE < numberOfStudentHomes);
            }
            catch (ServiceException e)
            {
                Trace.WriteLine("showStudentHomes - ServiceException " + e.Message);
            }
        }

        private void IOStudentHome(out string nume, out int numarPersoaneInCamera, out int numarCamere, out int regie)
        {
            Console.Write("Nume camin : ");
            nume = Console.ReadLine();
            Console.Write("Numar persoane in camera : ");
            numarPersoaneInCamera = int.Parse(Console.ReadLine());
            Console.Write("Numar camere : ");
            numarCamere = int.Parse(Console.ReadLine());
            Console.Write("Regie : ");
            regie = int.Parse(Console.ReadLine());
        }
    }
}
