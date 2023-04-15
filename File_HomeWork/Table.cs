using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_HomeWork
{
    public class Table
    {
        private List<ThisIsClass> list;

        public Table()
        {
            list = new List<ThisIsClass>();
        }

        public void ListlAdd(ThisIsClass a)
        {
            list.Add(a);
        }
        public void ListClear()
        {
            list.Clear();
        }

        public void ListDelete(ThisIsClass a)
        {
            if (list.Contains(a))
            {
                list.Remove(a);
            }
        }

        public string[] namelList()
        {
            string[] name = new string[list.Count];

            for (int i = 0; i < name.Length; i++)
            {
                name[i] = list[i].Name;
            }


            return name;
        }
        public string[] poplList()
        {
            string[] pop = new string[list.Count];

            for (int i = 0; i < pop.Length; i++)
            {
                pop[i] = list[i].Pop;
            }


            return pop;
        }
        public string[] lenglList()
        {
            string[] leng = new string[list.Count];

            for (int i = 0; i < leng.Length; i++)
            {
                leng[i] = list[i].lenght;
            }


            return leng;
        }
    }
}
