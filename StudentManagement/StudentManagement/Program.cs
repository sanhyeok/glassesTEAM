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
                //StudentInfo 파일이 없으면 생성한다.
                /*String Infofilename = @"StudentInfo.txt";

                if (File.Exists(Infofilename))
                {
                    System.Console.WriteLine("학생정보가 있습니다.");
                }
                else
                {
                    System.Console.WriteLine("학생정보가 없습니다.");
                    System.IO.File.Create(Infofilename);
                    Console.WriteLine("Create :: " + Infofilename);
                }
                */
            }
        }
    }
}
