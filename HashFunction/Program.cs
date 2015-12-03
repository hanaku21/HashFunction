using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HashFunction
{
    class Program
    {
        static Hashtable hash1 = new Hashtable();
        
        static void Main(string[] args)
        {
            //create hash table into 50 record
            createHash();

            bool isTrue = true;
            string x = string.Empty;
            int[] dataint =  null;
            char[] dilimeter = { ' ' };
            //input data
            do
            {
                dataint = null;
                Console.WriteLine("Insert Input Data (Seperate number by white-space)");
                Console.Write("Input :");
                x = Console.ReadLine();

                string[] data = x.Split(dilimeter, StringSplitOptions.RemoveEmptyEntries);
                if (data.Length > 100)
                {
                    Console.WriteLine("Error, Input Data is above 100 values ");
                    continue;
                }

                dataint = new int[data.Length];
                int i = 0;
                foreach (string m in data)
                {
                    isTrue = int.TryParse(m, out dataint[i]);
                    if (!isTrue)
                    {
                        Console.WriteLine("Error, Input Data are not number.Try Again.");
                        dataint = null;
                        break;
                    }
                    else
                    {
                        if (dataint[i] > 1000 || dataint[i] < 0)
                        {
                            Console.WriteLine("Error, Input Data not in 0 - 1000.");
                            isTrue = false;
                            dataint = null;
                            break;
                        }
                    }
                            i++;
                }

            } while (!isTrue);

            //do division method
            if(dataint!= null)
                CalCulate(dataint);
            
            //add data into hash table
            if(dataint != null)
                ShowData();
        }

        static void createHash()
        {
            for (int i = 0; i < 50; i++)
            {
                hash1.Add(i,string.Empty);
            }
        }

        static void CalCulate(int[] data)
        {
            int lenght = hash1.Count;
            int key;
            foreach (int m in data)
            {
                key = m % lenght;
                hash1[key] = hash1[key] + " " + m.ToString();
            }

        }

        static void ShowData()
        {
            for (int i = 0; i < hash1.Count ; i++)
            {
                Console.WriteLine(i + " :" + hash1[i].ToString());
            }
            Console.ReadKey();
        }

    }
}
