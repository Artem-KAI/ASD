using System;

namespace lvl2
{
    public class SyntaxAnalyzer
    { 
        private enum State
        {
            S0_Start,          
            S1_Plus,           
            S2_Digits_Final,   
            S3_Letters_Final,  
            Error              
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
                        return false;  
                }
            }
             
            return currentState == State.S2_Digits_Final || currentState == State.S3_Letters_Final;
        }
    }
}