using lvl2.Models;

namespace lvl2.Services
{
    public static class IndexSorter
    {
        public static int[] Sort(Student[] students)
        {
            int n = students.Length;

            int[] indices = new int[n];

            for (int i = 0; i < n; i++) 
                indices[i] = i;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    Student s1 = students[indices[i]];
                    Student s2 = students[indices[j]];

                    if (ShouldSwap(s1, s2))
                    {
                        int temp = indices[i];
                        indices[i] = indices[j];
                        indices[j] = temp;
                    }
                }
            }
            return indices;
        }

        private static bool ShouldSwap(Student s1, Student s2)
        {
            int groupComparison = string.Compare(s1.Group, s2.Group);

            if (groupComparison > 0)
            {
                return true; 
            }

            // Якщо групи однакові, порівнюємо номери квитків
            if (groupComparison == 0)
            {
                return string.Compare(s1.StudentId, s2.StudentId) > 0;
            }

            return false;
        }
    }
}