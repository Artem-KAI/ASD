using System;

namespace lvl2
{
    public static class CombinatoricsMath
    {
        public static double CalculateNumbersWithRepetition(int totalDigitsCount, bool hasZero, int numberLength)
        {
            // 1. Базова перевірка: якщо довжина числа або кількість цифр нульова (чи від'ємна), числа не існує
            if (numberLength <= 0 || totalDigitsCount <= 0)
            {
                return 0;
            }

            // 2. Визначаємо, скільки варіантів є для ПЕРШОЇ цифри числа
            int firstPositionOptions;
            if (hasZero == true)
            {
                // Число не може починатися з нуля (наприклад, 024 - це двозначне число 24)
                // Тому відкидаємо нуль для першої позиції
                firstPositionOptions = totalDigitsCount - 1;
            }
            else
            {
                // Якщо нуля в наборі немає, можна використовувати всі доступні цифри
                firstPositionOptions = totalDigitsCount;
            }

            // 3. Визначаємо варіанти для РЕШТИ позицій
            // Скільки позицій залишилося заповнити? (Загальна довжина мінус перша цифра)
            int remainingPositionsCount = numberLength - 1;

            // Оскільки цифри МОЖУТЬ повторюватися, на кожну з решти позицій можна ставити БУДЬ-ЯКУ цифру.
            // Математично це піднесення до степеня: (всі цифри) ^ (кількість позицій, що залишились)
            double remainingPositionsOptions = Math.Pow(totalDigitsCount, remainingPositionsCount);

            // 4. За правилом множення у комбінаториці: 
            // Множимо варіанти для першої цифри на варіанти для всіх інших
            return firstPositionOptions * remainingPositionsOptions;
        }
    }
}