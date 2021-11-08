using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoList
{
    class ToDoList
    {
      
        public void Start()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("      TWOJA LISTA TODO");
                Console.WriteLine("-------------------------------");
                ReadFromToDoList("ToDoList.txt");
                Console.WriteLine();
                Console.WriteLine(" Aby dodać zadanie wciśnij 1");
                Console.WriteLine(" Aby usunąć zadanie wciśnij 2");
                var userDecision = int.Parse(Console.ReadLine());
                switch (userDecision)
                {
                    case 1:
                        {
                            AddToToDoList("ToDoList.txt");
                        }
                        break;
                    case 2:
                        {
                            RemoveFromToDoList("ToDoList.txt");
                        }
                        break;
                }
            }
            
        }
        private void ReadFromToDoList(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var counter = 1;
            foreach (var line in lines)
            {
                Console.WriteLine(" " + counter + "-" + line);
                counter++;
            }
        }

        private void AddToToDoList(string filePath)
        {
            Console.WriteLine("Wpisz zadanie do wykonania: ");

            var newTask = Console.ReadLine();
            File.AppendAllText(filePath, newTask + Environment.NewLine);
        }
        private void RemoveFromToDoList(string filePath)
        {
            Console.WriteLine("Wprowadź zadanie, które chcesz usunąć: ");
            var removeFromList = int.Parse(Console.ReadLine());
            var lines = File.ReadAllLines(filePath).ToList<string>();
            var lineTemp = lines;
            var counter = 1;
            foreach (var line in lines)
            {
                if (counter == removeFromList)
                {
                    lineTemp.Remove(line);
                    File.WriteAllLines(filePath, lineTemp);
                    break;
                }
                counter++;
            }
        }
    }
}
