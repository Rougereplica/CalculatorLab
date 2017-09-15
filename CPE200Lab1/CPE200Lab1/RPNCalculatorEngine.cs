using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
           //List<string> parts = new List<string>();
           
            string result;
            string firstOperand, secondOperand;
            bool afterOp = false;
            int opCount = 0;
            int numCount = 0;

            if (str == "" || str == null)
            {
                return "E";

            }
            else
            { 
                for (int count = 0; count < parts.Count; count++)
                {
                    string token = parts[count];


                    if (parts.Count == 1 && Convert.ToInt32(token) != 0)
                    {

                        return "E";

                    }

                    else if (isNumber(token))
                    {
                        if (afterOp == true)
                        {
                            return "E";
                        }
                        else
                        {

                            rpnStack.Push(token);
                            numCount++;

                        }
                    }
                    else if (isOperator(token))
                    {
                        opCount++;

                        if (rpnStack.Count == 0 || rpnStack.Count == 1)
                        {

                            return "E";

                        }

                        secondOperand = rpnStack.Pop();


                        firstOperand = rpnStack.Pop();

                        if (firstOperand == null)
                        {
                            return "E";
                        }

                        result = calculate(token, firstOperand, secondOperand, 4);

                        if (result is "E")
                        {
                            return result;
                        }

                        rpnStack.Push(result);


                        afterOp = true;


                        // if (rpnStack.Count )


                    }


                }

            }

            if (rpnStack.Count != 1 )
            {
                return "E";
            }
            result = rpnStack.Pop();
            return result;
        }
    }
}
