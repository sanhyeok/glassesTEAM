/*
 *  프로그램명 : 성적관리 프로그램
 *  작성자 : 4TEAM   
 *  작성일 : 2019-10-02
 *  프로그램 설명 : 학생의 성적을 관리하는 프로그램
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //파일입출력 네임스페이스

namespace StudentManagement
{
    public class Student
    {
        // 학생 정보 : 이름 학번 국어 영어 수학 C# 총점 평균 등수
        private string Name;
        private int StudentID;
        private double Korean;
        private double English;
        private double Math;
        private double Cs;
        private double Totalscore;
        private double Average;
        private int Rank;


        public class Menu { } //메뉴창
        public class Input { 

        } //입력받기
        public class Output { } //출력하기
        public class Grade { } //성적계산하기
        public class Add { } //Info추가
        public class Insert { } //Info삽입
        public class Delete { } //Info삭제
        public class Scholarship { } //장학생

        public class Student_Management
        {
            static void Main(string[] args)
            {
                bool exit = true;
                int menuselect;
                string str;
                string txtpath = "StudentInfo.txt";
                Student[] student = new Student;

                while (exit) 
                {
                    Console.WriteLine("┌─────────────────────────┐");
                    Console.WriteLine("│ 1. 학생부 명단 확인하기                          │");
                    Console.WriteLine("│ 2. 학생 추가하기                                 │");
                    Console.WriteLine("│ 3. info 추가                                     │");
                    Console.WriteLine("│ 4. info 삭제                                     │");
                    Console.WriteLine("│ 5. 나가기                                        │");
                    Console.WriteLine("└─────────────────────────┘");

                    Console.Write("원하는 메뉴를 입력하세요 : ");
                    str = Console.ReadLine();
                    menuselect = int.Parse(str);

                        switch (menuselect)
                        {
                            case 1:
                                Console.WriteLine("Case 1");
                                break;
                            case 2:
                            Console.Write("학생정보를 입력하세요 : ");
                            str = Console.ReadLine();
                            System.IO.File.AppendAllText(txtpath, str, Encoding.Default);
                            break;
                            case 3:
                            Console.Write("추가정보를 입력하세요 : ");
                            str = Console.ReadLine();
                            str = str + "\n";
                            System.IO.File.AppendAllText(txtpath, str, Encoding.Default);
                            break;
                            case 4:
                                break;
                            case 5:
                                exit = false;
                                break;
                            default :
                            Console.WriteLine("제대로입력해^^");
                            break;


                    
                        }
                }

            }
        }
    }
}
