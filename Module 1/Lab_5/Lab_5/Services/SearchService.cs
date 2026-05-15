using lvl1.Models;

namespace lvl1.Services
{
    public static class SearchService
    { 
        public static int InterpolationSearch(Student[] array, int key)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high &&
                key >= array[low].RecordBookNumber &&
                key <= array[high].RecordBookNumber)
            {
                if (low == high)
                {
                    if (array[low].RecordBookNumber == key) 
                        return low;

                    return -1;
                }
                 
                // формула 
                int pos = low + (int)((double)(high - low) /
                          (array[high].RecordBookNumber - array[low].RecordBookNumber) *
                          (key - array[low].RecordBookNumber));

                if (array[pos].RecordBookNumber == key)
                    return pos;

                if (array[pos].RecordBookNumber < key)
                    low = pos + 1;
                else
                    high = pos - 1;
            }
            return -1;
        }
    }
}