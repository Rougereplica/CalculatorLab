using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;  //to use Stack

namespace CPE200Lab1
{
    class RpnCalculatorEngine : CalculatorEngine { 


        public string RpnProcess(string stringInput)
        {

            string[] parts = stringInput.Split(' ');
            string result = null;
             
            
            Stack rpnStack = new Stack();
            

           for (int count = 0; count < parts.Length; count++){
                string input = parts[count];    // = each parts one-by-one
                
                if (isNumber(input))
                {
                    rpnStack.Push(input);

                }
                else if (isOperator(input))
                {
                    string rpnOperate = input;
                    string secondRpnOperand = rpnStack.Pop().ToString();
                    string firstRpnOperand = rpnStack.Pop().ToString();
                    result = calculate(rpnOperate, firstRpnOperand, secondRpnOperand, 4);
                    rpnStack.Push(result);

                }else if (input == "1/x" || input == "√"  )
                {      
                     
                    string rpnOperate = input;
                    string firstRpnOperand = rpnStack.Pop().ToString();
                    result = unaryCalculate(rpnOperate, firstRpnOperand);
                    rpnStack.Push(result);

                }
                else if (input == "%")
                {

                    string operate = input;

                    string secondRpnOperand = rpnStack.Pop().ToString();

                    if (rpnStack.Count == 0)
                        return "E";

                    string firstRpnOperand = rpnStack.Pop().ToString();


                    rpnStack.Push(firstRpnOperand.ToString());

                    result = calculate(operate, firstRpnOperand, secondRpnOperand, 4);

                    rpnStack.Push(result);

                }
            }

            
            return result;
 
        }


    }

    

}
