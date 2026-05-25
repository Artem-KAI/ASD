using System;

namespace lvl2
{
    public class SyntaxAnalyzer
    {
        // Перелік станів скінченного автомата прихований всередині класу
        private enum State
        {
            S0_Start,          // Початковий стан (очікує '+')
            S1_Plus,           // Отримано '+', очікує цифру
            S2_Digits_Final,   // Отримано цифри (фінальний стан)
            S3_Letters_Final,  // Отримано літери A-Z (фінальний стан)
            Error              // Стан помилки
        }
 
        public bool Analyze(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            State currentState = State.S0_Start;

            foreach (char c in input)
            {
                switch (currentState)
                {
                    case State.S0_Start:
                        if (c == '+')
                            currentState = State.S1_Plus;
                        else
                            currentState = State.Error;
                        break;

                    case State.S1_Plus:
                        if (char.IsDigit(c))
                            currentState = State.S2_Digits_Final;
                        else
                            currentState = State.Error;
                        break;

                    case State.S2_Digits_Final:
                        if (char.IsDigit(c))
                            currentState = State.S2_Digits_Final; // Зациклення на цифрах
                        else if (c >= 'A' && c <= 'Z')
                            currentState = State.S3_Letters_Final; // Перехід до літер
                        else
                            currentState = State.Error;
                        break;

                    case State.S3_Letters_Final:
                        if (c >= 'A' && c <= 'Z')
                            currentState = State.S3_Letters_Final; // Зациклення на літерах
                        else
                            currentState = State.Error;
                        break;

                    case State.Error:
                        return false; // Достроковий вихід при помилці
                }
            }

            // Рядок вважається валідним лише якщо автомат зупинився в одному з фінальних станів
            return currentState == State.S2_Digits_Final || currentState == State.S3_Letters_Final;
        }
    }
}