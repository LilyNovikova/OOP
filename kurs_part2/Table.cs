﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_part2
{
    public class Table : IEnumerable
    {
        private List<Set> sets;
        public int RowsCount { get; private set; } = 0;
        public int ColumnsCount { get; private set; } = 0;
        public Table(string[] names, int[][] data)
        {
            Set[] SetArray = new Set[data.Length];

            //инициализируем все наборы
            for (int i = 0; i < data.Length; i++)
            {
                SetArray[i] = new Set(names[i], data[i]);
            }
            //конверитруем в список и добавляем наборы в таблицу
            sets = SetArray.ToList<Set>();

            RowsCount = data.Length;
            if (data.Length != 0)
                ColumnsCount = data[0].Length;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)sets).GetEnumerator();
        }

        public void Optimize()
        {
            //сравнение  каждого из наборов с каждым
            for (int i = 0; i < sets.Count; i++)
            {
                Set current1 = sets.ElementAt(i);
                for (int j = i+1; j < sets.Count; j++)
                {
                    Set current2 = sets.ElementAt(j);
                    //если 2 больше 1, удаляем 1
                    if (current1.Less(current2))
                    {
                        sets.Remove(current1);
                        i--;
                        RowsCount--;
                        break;
                    }
                    else //если 1 больше 2, удаляем 2
                        if (current2.Less(current1))
                    {
                        sets.Remove(current2);
                        i--;
                        RowsCount--;
                        break;
                    }
                }
            }
        }

        public override string ToString()
        {
            if (this == null)
                throw new NullReferenceException();
            string str = "";
            foreach (Set set in sets)
            {
                str += set + ";\n";
            }
            return str.TrimEnd('\n');
        }
    }
}
