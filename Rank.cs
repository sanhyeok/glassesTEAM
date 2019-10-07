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


        public class Menu { } //메뉴창 (case 문)
        public class Input { } //입력받기
        public class Output //출력하기
        {
            static void GetRank(Student[] StudentList)                           //등수를 매기는 함수
            {
                double[] TempArray = new double[StudentList.Length];
                for (int i = 0; i < StudentList.Length; i++)
                {
                    TempArray[i] = StudentList[i].Totalscore;
                }

                Array.Sort(TempArray);

                for (int i = 0; i < StudentList.Length; i++)
                {
                    for (int j = 0; j < StudentList.Length; j++)
                    {
                        if (StudentList[i].Totalscore == TempArray[j])
                        {
                            StudentList[i].Rank = StudentList.Length - j;
                            break;
                        }
                    }
                }
            }
        }
        public class Grade { } //성적계산하기
        public class Add { } //Info추가
        public class Insert { } //Info삽입
        public class Delete { } //Info삭제
        public class Scholarship //장학생
        {
            static void PrintScholarshipStudent(Student[] StudentList)           //장학생 출력 함수
            {
                Console.WriteLine("==============================================================");
                Console.WriteLine("                         장학생 목록                          ");
                Console.WriteLine("==============================================================");
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 0; j < StudentList.Length; j++)
                    {
                        if (StudentList[j].Totalscore == i)
                        {
                            //Output.PrintStudent(StudentList[j]);              //이 부분 출력 부분에서 함수가 호출되어야 합니다.
                            break;
                        }
                    }
                }
                Console.WriteLine("==============================================================");
            }
        }

        public class Student_Management
        {
            static void Main(string[] args)
            {
                
            }
        }
    }
}