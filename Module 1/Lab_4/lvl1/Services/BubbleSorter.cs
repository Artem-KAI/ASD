using lvl1.Modoels;

namespace lvl1.Services
{
    public static class BubbleSorter
    {
        public static void Sort(Student[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(array[j].Group, array[j + 1].Group) > 0)// IT-21 > AC-11  true (> 0)  
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
    }
}