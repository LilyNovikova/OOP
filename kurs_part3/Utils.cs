using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_part3
{
    public static class Utils<T>
    {      
        public static T[] ResizeArray(T[] array, uint NewSize)
        {
            var NewArray = new T[NewSize];
            if(array != null)
            {
                for (int i = 0; i < NewSize; i++)
                {
                    if (i < array.Length)
                        NewArray[i] = array[i];
                    else
                        NewArray[i] = default(T);
                }
            }
            return NewArray;
        }
    }
}
