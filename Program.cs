using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace WritingFunctions
{
    
    class Program
    {
        
        public class dijstra

        {
            public dijstra(double[,] G, int s)
            {
                initial(0, s);
                while (queue.Count > 0)
                {
                    int u = getNextVertex();
                    for (int i = 0; i < s; i++)
                    {
                        WriteLine("Under Node (" + u + "," + i + " ) all dist:" + G[u, i] + " Path Distance = " + dist[u] + " Path Distance = "  + dist[i]);
                        if (G[u, i] > 0)
                        {
                            if (dist[i] > dist[u] + G[u, i])
                            {
                                dist[i] = dist[u] + G[u, i];
                            }
                        }
                        WriteLine("Post Node (" + u + "," + i + " ) all dist:" + G[u, i] + " Path Distance = " + dist[u] + " Path Distance = " + dist[i]);
                    }
                }
            }

            public double[] dist { get; set; }
            int getNextVertex()
            {
                var min = double.PositiveInfinity;
                
                int vertex = -1;
                foreach (int val in queue)
                {
                    if (dist[val] <= min)
                    {
                        min = dist[val];
                        vertex = val;
                        WriteLine("Node " + vertex + " Path Distance = " + min);
                    }
                }
                queue.Remove(vertex);
                return vertex;
            }
            List<int> queue = new List<int>();
            public void initial(int s, int len)
            {
                dist = new double[len];

                for (int i = 0; i < len; i++)
                {
                    dist[i] = double.PositiveInfinity;
                    queue.Add(i);
                  //  WriteLine("i " + i   );
                }
                dist[0] = 0;
            }

        }
        static bool Person_is_seller(string fname)
        {
            return fname.EndsWith("m");
        }

        static int SumArray(int[] fmyarr, int i, int n)
        {
            
            if (i == n)
            {
                return 0;
            }
            else
            {
             return fmyarr[i] +  SumArray(fmyarr, i+1,n);            
            }

        }
        static int CountArray(int[] fmyarr, int i, int n)
        {

            if (i == n)
            {
                return 0;
            }
            else
            {
                return  1 + CountArray(fmyarr, i + 1, n);
            }

        }
        static int MaxArray(int[] fmyarr, int i, int n)
        {
            int sub_max = 0;
            if (fmyarr.Length == 2)
            {
                if (fmyarr[0] > fmyarr[1])
                {
                    return fmyarr[0];
                }
                else
                {
                    return fmyarr[1];
                }
            }
            else
            {
                if (i == n)
                {
                    return 0;
                }
                else
                {
                    sub_max = MaxArray(fmyarr, i + 1, n);
                    if (fmyarr[i] > sub_max)
                    {
                        return fmyarr[i];
                    }
                    else
                    {
                        return sub_max;
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            //Динамическое программирование Самая длинная общая подстрока
            WriteLine();
            WriteLine("Max substr :");
            string[] word_a = new string[5];
            string[] word_b = new string[5];
            word_a[0] = "b";
            word_a[1] = "l";
            word_a[2] = "u";
            word_a[3] = "e";
            word_b[0] = "c";
            word_b[1] = "l";
            word_b[2] = "u";
            word_b[3] = "e";
            word_b[4] = "s";
            int[,] cell = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    
                    if (word_a[i] == word_b[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            cell[i, j] = 1;
                        } else
                        {
                            cell[i, j] = cell[i - 1, j - 1] + 1;
                        }                        
                    }
                    else
                    {
                  //      if (i == 0 || j == 0)
                   //     {
                   //         if (i == 0 && j == 0)
                    //        {
                                cell[i, j] = 0;
                    //        } else
                    //        if (i == 0)
                    //        {
                    //            cell[i, j] = cell[i, j - 1];
                    //        } else
                    //        {
                    //            cell[i, j] = cell[i - 1, j];
                    //        }


                     //   }
                     //   else
                     //   {

                     //       if (cell[i - 1, j] > cell[i, j - 1])
                     //       {
                     //           cell[i, j] = cell[i - 1, j];
                     //       }
                     //       else
                     //       {
                     //           cell[i, j] = cell[i, j - 1];
                     //       }
                     //   }
                    }
                    WriteLine(word_a[i] +" "+ word_b[j]+" "+ cell[i, j]);
                }
                
            }

            //Задача с покрытием множества
            WriteLine();
            WriteLine("Task with a covering of many:");
            HashSet<string> states_needed = new HashSet<string> (new string[] {  "mt", "wa", "or", "id", "nv", "ut", "ca", "az" });
            Dictionary<string, HashSet<string>> stations = new Dictionary<string, HashSet<string>>();
            stations.Add("kone", new HashSet<string> { "id", "nv", "ut" });
            stations.Add("ktwo", new HashSet<string> { "wa", "id", "mt" });
            stations.Add("kthree", new HashSet<string> { "or", "nv", "ca" });
            stations.Add("kfour", new HashSet<string> {  "nv", "ut" });
            stations.Add("kfive", new HashSet<string> { "ca", "az" });
            HashSet<string> final_stations = new HashSet<string>();
            HashSet<string> states_covered ;
           // HashSet<string> covered;
            HashSet<string> states_for_station;
            string best_station ;
            string station;
            while (states_needed.Count > 0)
            {
                best_station = "";
                states_covered = new HashSet<string>();
                foreach (var key in stations)
                {
                    station = key.Key;
                 //   WriteLine(station);
                    states_for_station = key.Value;
                   // foreach (string s in states_for_station)
                   // {

                  //      WriteLine(s);
                   // }
                   // covered = 
                        states_for_station.IntersectWith(states_needed);
                    if (states_for_station.Count() > states_covered.Count())
                    {
                        best_station = station;
                        states_covered = states_for_station;
                    }
                }
              
               
                foreach (string cov in states_covered)
                {
                    states_needed.Remove(cov);
                }
                final_stations.Add(best_station);
                 
            }
            WriteLine("The best:");
            foreach (string s in final_stations)
            {
                
                WriteLine(s);
            }


            WriteLine();
            WriteLine("Algoritm Deixtra (graf):");

            List<string> listBox = new List<string>();
            double[,] G = new double[5, 5];
            G[0, 1] = 10;
            G[1, 2] = 20;
            G[2, 3] = 1;
            G[3, 1] = 1;
            G[2, 4] = 30;
            
            dijstra dist = new dijstra(G, 5);
            var item = dist.dist;
            for (int i = 0; i < item.Length; i++)
            {
                listBox.Add("Node " + i + " Path Distance = " + item[i]);
                WriteLine("Node " + i + " Path Distance = " + item[i]);
            }

            //Graf and Hash-table
            WriteLine();
            WriteLine("Graf and hashtable:");

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            graph.Add("You", new List<string> {"Alice","Bob","Claire" });
            graph.Add("Alice", new List<string> { "Peggy" });
            graph.Add("Bob", new List<string> { "Anuj", "Peggy" });
            graph.Add("Claire", new List<string> { "Thom", "Jonny" });
            graph.Add("Anuj", new List<string> { });
            graph.Add("Thom", new List<string> { });
            graph.Add("Peggy", new List<string> { });
            graph.Add("Jonny", new List<string> { });
            string person="";
            List<string> searched = new List<string>();
            Queue<string> search_queue = new Queue<string>();
            List<string> values = graph["You"];
            foreach (string s in values)
            {
                search_queue.Enqueue(s);
                WriteLine(s);
            }
            while (search_queue.Count() > 0)
            {
                person = search_queue.Dequeue();
                if (!searched.Contains(person))
                {
                    if (Person_is_seller(person))
                    {
                        WriteLine($"{person} is a mango seller!");
                        searched.Add(person);
                    }
                    else
                    {
                        values.RemoveRange(0,values.Count());
                        values = graph[person];
                        searched.Add(person);
                        foreach (string s in values)
                        {
                            search_queue.Enqueue(s);
                            WriteLine(s);
                        }
                    }

                }
                
            }
            WriteLine();
            ///recursion and array
            WriteLine("Recursion:");

            int[] myarr = { 9, 3, 11, 10 };
            int mysum = 0;
            foreach (int pin in myarr)
            {
               
                Console.WriteLine(pin);
            }
            Console.WriteLine("Summa:");
            mysum = myarr[0] + SumArray(myarr, 1, myarr.Length);
            Console.WriteLine(mysum);
            Console.WriteLine("Count");
            mysum = 1 + CountArray(myarr, 1, myarr.Length);
            Console.WriteLine(mysum);
            Console.WriteLine("Max");
            mysum = MaxArray(myarr, 0, myarr.Length);
            Console.WriteLine(mysum);
        }
    }
}
