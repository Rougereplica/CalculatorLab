using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        protected Stack<string> mystack = new Stack<string>();
        protected string firstOperand;
        protected string secondOperand;

        public new string Process(string str)
        {
            if (str == null || str == "") { 
            return "E";
        }

          //  Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            
            bool afterOp = false;
            int opCount = 0;
            int numCount = 0;

            for (int count = 0; count < parts.Count; count++)
            {
                string token = parts[count];

                if (parts[count] == "++")
                    return "E";

                if (mystack.Count == 0)
                {
                    if (isOperator(token))
                    {
                        return "E";
                    }
                }


             /*   if (token == "+1" || token == "++" || token == "1+")
                {

                    return "E";
                }

                /*    if (parts.Count == 1 && Convert.ToDouble(token)!=0)
                    {

                        return "E";

                    }*/

                if (isNumber(token))
                {
                    for (int i = 0; i < token.Length; i++)
                    {
                        

                    }
                    if (afterOp == true)
                    {
                        return "E";
                    }
                    else
                    {

                        mystack.Push(token);
                        numCount++;

                    }
                }
                else if (isOperator(token))
                {
                    if (mystack.Count == 0)
                    {
                        result = "E";

                    }


                    if (mystack.Count == 1)
                    {
                        result = "E";
                        mystack.Push(result);

                    }

                    else
                    {
                       
                        secondOperand = mystack.Pop();

                        if (mystack.Count != 0)
                        {
                            result = "E";

                        }

                        firstOperand = mystack.Pop();

                        /*     if (mystack.Count == 0 )
                             {
                                 result = "E";

                             }
                          //   else*/
                        {

                            result = calculate(token);
                            //result = calculate(token, firstOperand, secondOperand, 4);
                        }


                        if (result is "E")
                        {
                            return result;
                        }

                        mystack.Push(result);
                        afterOp = true;
                        opCount++;

                    }

                }
                
                            
            }

            if(mystack.Count != 1)
            {
                return "E";
            }

            result = mystack.Pop();
            return result;
        }

        public string calculate(string operate)

        {
            int maxOutputSize = 8;

           switch (operate)
           {
               case "+":
                   return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
               case "-":
                   return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
               case "X":
                   return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
               case "÷":
                   // Not allow devide be zero
                   if (secondOperand != "0")
                   {
                       double result;
                       string[] parts;
                       int remainLength;

                       result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));



                       // split between integer part and fractional part
                       if (Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand) == 0)
                       {
                           //    Convert.ToInt32(result);
                           return result.ToString(); //Convert.ToString(result);

                       }



                       //      

                       parts = result.ToString().Split('.');
                       // if integer part length is already break max output, return error
                       if (parts[0].Length > maxOutputSize)
                       {
                           return "E";
                       }
                       // calculate remaining space for fractional part.
                       remainLength = maxOutputSize - parts[0].Length - 1;
                       // trim the fractional part gracefully. =

                       double checkMod;
                       string firstResult;
                       firstResult = result.ToString("N4");
                       string[] Decimal = firstResult.Split('.');
                       checkMod = Convert.ToDouble(Decimal[1]);
                       if (checkMod % 10 == 0 || Convert.ToDouble(Decimal[1]) % 100 == 0 || Convert.ToDouble(Decimal[1]) % 1000 == 0 || Convert.ToDouble(Decimal[1]) % 10000 == 0)
                       {
                           //return result.ToString("N4");
                           return result.ToString("G29");
                       }
                       //return result.ToString("G29");
                       return result.ToString("N4");



                   }
                   break;
               case "%":
                   //your code here
                   break;
           }
           return "E";
         }
     }

}

