/*
 *  프로그램명 : 실습 1_Calculator
 *  작성자 : 2015041074 정선우
 *  작성일 : 2019-09-19
 *  프로그램 설명 : 피연산자 2개와 연산자를 입력받아 계산한다
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_09_19_HCI_정선우
{
    class Calculator
    {
        public static void Calc(int operand1, char operator_, int operand2, int sum)    // 피연산자와 연산자를 이용하여 sum에 계산결과를 출력
        {
            switch (operator_)
            {
                case '+':
                    sum = operand1 + operand2;
                    Console.WriteLine(operand1 + " " + operator_ + " " + operand2 + " = " + sum);
                    break;
                case '-':
                    sum = operand1 - operand2;
                    Console.WriteLine(operand1 + " " + operator_ + " " + operand2 + " = " + sum);
                    break;
                case '*':
                    sum = operand1 * operand2;
                    Console.WriteLine(operand1 + " " + operator_ + " " + operand2 + " = " + sum);
                    break;
                case '/':
                    sum = operand1 / operand2;
                    Console.WriteLine(operand1 + " " + operator_ + " " + operand2 + " = " + sum);
                    break;
                default:
                    Console.WriteLine("해당되는 연산자의 연산결과가 없습니다.");
                    break;
            }
        }
        public static int Int_exception(string val) // 숫자 검출하는 함수
        {
            while (!int.TryParse(val, out int num))  // 입력받은 val 문자열이 int형이 아닐 경우 False을 반환하고 num은 유지한다.
                                                     // int형일 경우 True를 반환하고 num을 str에 대입한다.
            {
                Console.Write("다시 입력하세요 : ");
                val = Console.ReadLine();
            }
            return int.Parse(val); 
        }
        public static char Char_exception(string val)   // 연산자를 검출하는 함수
        {
            while ((!char.TryParse(val, out char operator_)) || !((operator_ == '+') || (operator_ == '-') || (operator_ == '*') || (operator_ == '/')))
                // char형이면서 4가지 연산자 중 하나인지 확인한다.
            {
                Console.Write("지원하지 않는 연산자입니다. 다시 입력하세요 : ");
                val = Console.ReadLine();
            }
            return char.Parse(val);
        }
        static void Main(string[] args)
        {
            string str;     // 입력받는 문자열
            int operand1 = 0;  // 피연산자 1
            int operand2 = 0;  // 피연산자 2
            int sum = 0;    // 계산결과
            char operator_=' ';     // 연산자

            Console.Write("첫번째 숫자를 입력하세요 : ");
            str = Console.ReadLine();
            operand1 = Int_exception(str);


            Console.Write("연산자를 입력하세요 (+,-,*,/) : ");
            str = Console.ReadLine();
            operator_ = Char_exception(str);

            Console.Write("두번째 숫자를 입력하세요 : ");
            str = Console.ReadLine();
            operand2 = Int_exception(str);

            Calc(operand1, operator_, operand2, sum);
        }
    }
}