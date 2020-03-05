using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.OtherClasses
{
    public class JaygashtClass
    {
        public void test()
        {
            List<List<ObjectsToSend>> myList = new List<List<ObjectsToSend>>();
            myList.Add(new List<ObjectsToSend>());
            myList.Add(new List<ObjectsToSend>());
            myList.Add(new List<ObjectsToSend>());
            List<ObjectsToSend> Test = new List<ObjectsToSend>();
            ObjectsToSend aa = new ObjectsToSend()
            { id = 1, name = "1" };
            Test.Add(aa);
            aa = new ObjectsToSend()
            { id = 2, name = "1" };
            Test.Add(aa);
            aa = new ObjectsToSend()
            { id = 3, name = "1" };
            Test.Add(aa);
            myList[0] = Test;
            Test = new List<ObjectsToSend>();
            //================================= end of mylist[0]
            aa = new ObjectsToSend()
            { id = 4, name = "2" };
            Test.Add(aa);
            aa = new ObjectsToSend()
            { id = 5, name = "2" };
            Test.Add(aa);
            aa = new ObjectsToSend()
            { id = 6, name = "2" };
            Test.Add(aa);
            myList[1] = Test;
            Test = new List<ObjectsToSend>();
            //================================= end of mylist[1]

            aa = new ObjectsToSend()
            { id = 7, name = "3" };
            Test.Add(aa);
            aa = new ObjectsToSend()
            { id = 8, name = "3" };
            Test.Add(aa);
            aa = new ObjectsToSend()
            { id = 9, name = "3" };
            Test.Add(aa);
            myList[2] = Test;
            Test = new List<ObjectsToSend>();
            //================================= end of mylist[2]
            List<List<ObjectsToSend>> AA = new List<List<ObjectsToSend>>();
            foreach (string x in Jaygasht(0, myList))
            {


                List<ObjectsToSend> bb = JsonConvert.DeserializeObject<List<ObjectsToSend>>("[" + x.TrimEnd(',') + "]");
                AA.Add(bb);
            }
            foreach (var VARIABLE in AA)
            {
                foreach (var VARIABLE2 in VARIABLE)
                {
                    Console.Write($"id:{VARIABLE2.id} and name:{VARIABLE2.name} ||");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

         List<string> Jaygasht(int a, List<List<ObjectsToSend>> Position)
        {
            List<string> retval = new List<string>();
            if (a == Position.Count)
            {
                retval.Add("");
                return retval;
            }
            foreach (ObjectsToSend y in Position[a])
            {
                foreach (string x2 in Jaygasht(a + 1, Position))
                {
                    //.Replace("{", "[").Replace("}", "]")
                    retval.Add(JsonConvert.SerializeObject(y) + "," + x2.ToString());
                }
            }
            return retval;
        }
    }

    public class ObjectsToSend
    {
        public string name { get; set; }
        public int id { get; set; }
    }
}