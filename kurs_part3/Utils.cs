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

        public static string ArrayToText(T[]array)
        {
            string text = "";
            foreach(T item in array)
            {
                text += item.ToString() + '\n';
            }
            return text;
        }

        public static string ArrayToString(T[] array)
        {
            string text = "";
            foreach (T item in array)
            {
                text += item.ToString() + ' ';
            }
            return text;
        }
    }
}
