<<<<<<< HEAD
﻿/*
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
using DevStyle;

namespace StudnetManager
{


    public class Student
    {
        public string Name { set; get; }
        public int StudentID;
        public double Korean;
        public double English;
        public double Math;
        public double Cs;
        public double Grade;
        public double Totalscore;
        public double Average;
        public int Rank;
    }
    public class Manager
    {
        public void Addinfo(Student st) // student생성후 정보입력
        {
            Console.Write("이름:");
            st.Name = Console.ReadLine();
            Console.Write("학번:");
            st.StudentID = int.Parse(Console.ReadLine());
            Console.Write("국어:");
            st.Korean = double.Parse(Console.ReadLine());
            Console.Write("영어:");
            st.English = double.Parse(Console.ReadLine());
            Console.Write("수학:");
            st.Math = double.Parse(Console.ReadLine());
            Console.Write("c#:");
            st.Cs = double.Parse(Console.ReadLine());
            GetAverage(st);
            GetTotalScore(st);
        }
        public void GetGrade(Student st)
        {
            st.Grade = (GetSubGrade(st.English) + GetSubGrade(st.Korean) + GetSubGrade(st.Math) + GetSubGrade(st.Cs)) / 4;
        }
        public double GetSubGrade(double Score)
        {
            if (Score >= 95)
            {
                return 4.5;
            }
            else if (Score < 95 && Score >= 90)
            {
                return 4.0;
            }
            else if (Score < 90 && Score >= 85)
            {
                return 3.5;
            }
            else if (Score < 85 && Score >= 80)
            {
                return 3.0;
            }
            else if (Score < 80 && Score >= 75)
            {
                return 2.5;
            }
            else if (Score < 75 && Score >= 70)
            {
                return 2.0;
            }
            else if (Score < 70 && Score >= 60)
            {
                return 1.0;
            }
            else
            {
                return 0.0;
            }
        }
        public void GetAverage(Student st)
        {
            st.Average = (st.Korean + st.Math + st.English + st.Cs) / 4;
        }
        public void GetTotalScore(Student st)
        {
            st.Totalscore = st.Korean + st.Math + st.English + st.Cs;
        }
        public void GetRank(List<Student> StudentList)                           //등수를 매기는 함수
        {
            int stdn = 0;
            int TAN = 0;
            foreach (var std in StudentList)
            {
                stdn += 1;
            }
            double[] TempArray = new double[stdn];
            foreach (var std in StudentList)
            {
                TempArray[TAN] = std.Totalscore;
                TAN += 1;
            }
            Array.Sort(TempArray);
            Array.Reverse(TempArray);
            foreach (var std in StudentList)
            {
                for (int p = 0; p < stdn; p++)
                {
                    if (std.Totalscore == TempArray[p])
                    {
                        std.Rank = p + 1;
                    }
                }
            }
        }
        public void PrintScholarshipStudent(List<Student> StudentList)           //장학생 출력 함수
        {
            int stdn = 0;
            foreach (var std in StudentList)
            {
                stdn += 1;
            }
            Console.WriteLine("==============================================================");
            Console.WriteLine("                         장학생 목록                          ");
            Console.WriteLine("==============================================================");
            for (int i = 1; i <= stdn; i++)
            {
                Console.WriteLine(" {0}등 : {1}", i, StudentList.Find(x => x.Rank == i).Name);
            }
            Console.WriteLine("==============================================================");
        }
        public Boolean Deleteinfo(List<Student> StudentList, string name)
        {
            try
            {
                if (StudentList.Remove(StudentList.Find(x => x.Name == name)))
                {
                    Console.WriteLine(name + " 학생의 정보가 삭제되었습니다.");
                    return true;
                }
                else
                {
                    Console.WriteLine("이름과 일치하는 정보가 없습니다..");
                    return false;
                }
                /*
                   public bool Remove(T item);
                   요약:
                     Removes all the elements that match the conditions defined by the specified predicate.
           
                   매개 변수:
                    match:
                     The System.Predicate`1 delegate that defines the conditions of the elements to
                     remove.
        
                   반환 값:
                    The number of elements removed from the System.Collections.Generic.List`1.
        
                   예외:
                    T:System.ArgumentNullException:
                    match is null.
                 */

                //StudentList.GetRank(StudnetList); // 다시 랭크를 산정한다
            }
            catch (System.ArgumentNullException)
            {
                // StudentList가 NULL일때
                Console.WriteLine("먼저 정보를 입력해 주세요");
                return false;
            }

        }
        public Boolean InsertInfo(List<Student> StudentList, Student std, int index)
        {
            try
            {
                StudentList.Insert(index, std);
                Console.WriteLine("삽입 완료하였습니다. ");
                return true;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("잘못된 인덱스 번호입니다.");
                return false;
            }
        }
    }
    public class MainApp
    {
        static void Main(string[] args)
        {
            bool exit = true;
            int menuselect;
            int people = 0;
            string str;
            string txtpath = "StudentInfo.txt";
            Student st = new Student();
            List<Student> studentList = new List<Student>();
            Manager M = new Manager();
            

            while (exit)
            {
                Console.WriteLine("┌─────────────────────────┐");
                Console.WriteLine("│ 1. 입력하기                                      │");
                Console.WriteLine("│ 2. 출력하기                                      │");
                Console.WriteLine("│ 3. 삭제하기                                      │");
                Console.WriteLine("│ 4. 삽입하기                                      │");
                Console.WriteLine("│ 5. 장학생                                        │");
                Console.WriteLine("│ 5. 나가기                                        │");
                Console.WriteLine("└─────────────────────────┘");

                Console.Write("원하는 메뉴를 입력하세요 : ");
                str = Console.ReadLine();
                menuselect = int.Parse(str);

                switch (menuselect)
                {
                    case 1:
                        M.Addinfo(st);
                        M.GetAverage(st);
                        M.GetGrade(st);
                        M.GetTotalScore(st);
                        studentList.Add(new Student(){Name = st.Name,StudentID = st.StudentID,Korean = st.Korean,English = st.English, Math = st.Math,Cs = st.Cs,Grade = st.Grade,Totalscore = st.Totalscore,Average = st.Average,Rank=st.Rank});
                        people += 1;
                        break;
                    case 2:
                        foreach (var student in studentList)
                        {
                            Console.WriteLine("이름:" + student.Name + 
                                "학번:" + student.StudentID + 
                                "국어:" + student.Korean + 
                                "영어:" + student.English + 
                                "수학:" + student.Math + 
                                "씨샵:" + student.Cs + 
                                "학점:" + student.Grade + 
                                "총점:" + student.Totalscore + 
                                "평균:" + student.Average +
                                "등수:" + student.Rank);
                        }
                        Console.WriteLine("사람수{0}", people);
                        break;
                    case 3:
                        Console.Write("삭제할 학생이름 : ");
                        string name = Console.ReadLine();
                        if (M.Deleteinfo(studentList, name)) // 삭제에 성공하면
                            people--;                        // 인원수에서 1 감소
                        else 
                            continue;                        // 아니면 실패했다고 출력하고 다시 넘김
                        break;
                    case 4: // 삽입
                        Console.WriteLine("삽입할 학생의 정보를 입력해주세요.");
                        M.Addinfo(st);
                        M.GetAverage(st);
                        M.GetGrade(st);
                        M.GetTotalScore(st);
                        Console.Write("삽입할 인덱스를 입력해주세요. : ");
                        int index = int.Parse(Console.ReadLine());
                        if (M.InsertInfo(studentList, st, index))
                            people++;
                        else
                            continue;
                        break;

                    case 5:
                        M.GetRank(studentList);
                        M.PrintScholarshipStudent(studentList);

                        break;
                    case 6:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("제대로입력해주세욥~");
                        break;
                }
            }

        }
    }
}
=======
﻿/*
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
using DevStyle;

namespace StudnetManager
{


    public class Student
    {
        public string Name;
        public int StudentID;
        public double Korean;
        public double English;
        public double Math;
        public double Cs;
        public double Grade;
        public double Totalscore;
        public double Average;
        public int Rank;
    }
    public class Manager
    {
        public void Addinfo(Student st) // student생성후 정보입력
        {
            Console.Write("이름:");
            st.Name = Console.ReadLine();
            Console.Write("학번:");
            st.StudentID = int.Parse(Console.ReadLine());
            Console.Write("국어:");
            st.Korean = double.Parse(Console.ReadLine());
            Console.Write("영어:");
            st.English = double.Parse(Console.ReadLine());
            Console.Write("수학:");
            st.Math = double.Parse(Console.ReadLine());
            Console.Write("c#:");
            st.Cs = double.Parse(Console.ReadLine());
            GetAverage(st); 
            GetTotalScore(st);
        }
        public void GetGrade(Student st)
        {
            st.Grade = (GetSubGrade(st.English) + GetSubGrade(st.Korean) + GetSubGrade(st.Math) + GetSubGrade(st.Cs)) / 4;
        }
        public double GetSubGrade(double Score)
        {
            if (Score >= 95)
            {
                return 4.5;
            }
            else if (Score < 95 && Score >= 90)
            {
                return 4.0;
            }
            else if (Score < 90 && Score >= 85)
            {
                return 3.5;
            }
            else if (Score < 85 && Score >= 80)
            {
                return 3.0;
            }
            else if (Score < 80 && Score >= 75)
            {
                return 2.5;
            }
            else if (Score < 75 && Score >= 70)
            {
                return 2.0;
            }
            else if (Score < 70 && Score >= 60)
            {
                return 1.0;
            }
            else
            {
                return 0.0;
            }
        }
        public void GetAverage(Student st)
        {
            st.Average = (st.Korean + st.Math + st.English + st.Cs) / 4;
        }
        public void GetTotalScore(Student st)
        {
            st.Totalscore = st.Korean + st.Math + st.English + st.Cs;
        }
        public void GetRank(Student[] StudentList)                           //등수를 매기는 함수
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
        public void Deleteinfo(Student[] StudentList, string name)
        {
            // name을 통해 리스트 내의 삭제정보 찾기
            try
            {
                int deIndex = Array.IndexOf(StudentList, name); // Indexof함수는 Array의 값이 NULL값일 경우 예외발생, 찾으면 해당 인덱스, 못찾으면 배열의 하한값-1 반환
                if (deIndex == -1)
                {
                    Console.WriteLine("해당 학생은 없습니다.");
                }
                else
                {
                    Array.Clear(StudentList, deIndex, 1); // array의 해당 인덱스의 정보를 제거한다
                }

                // Scholarship(); 장학생검색에 있는 정렬로 순위 다시 매기기 
            }
            catch (System.ArgumentNullException)    // Array배열이 NULL값일 경우 예외처리
            {
                Console.WriteLine("학생이 없습니다.");
            }
        }
        public void test(int[] StudentList)
        {
            Console.WriteLine(StudentList);
            Console.WriteLine(StudentList[0]);
        }
    }
    public class MainApp
    {
        static void Main(string[] args)
        {
            bool exit = true;
            int menuselect;
            int people = 0;
            string str;
            string txtpath = "StudentInfo.txt";
            Student st = new Student();
            List<Student> studentList = new List<Student>();
            Student[] studentList2 = new Student [10];
            Manager M = new Manager();


            while (exit)
            {
                Console.WriteLine("┌─────────────────────────┐");
                Console.WriteLine("│ 1. 입력하기(자동추가)                            │");
                Console.WriteLine("│ 2. 출력하기                                      │");
                Console.WriteLine("│ 3. 삭제하기                                      │");
                Console.WriteLine("│ 4. 장학생                                        │");
                Console.WriteLine("│ 5. 나가기                                        │");
                Console.WriteLine("└─────────────────────────┘");

                Console.Write("원하는 메뉴를 입력하세요 : ");
                str = Console.ReadLine();
                menuselect = int.Parse(str);

                switch (menuselect)
                {
                    case 1:
                        M.Addinfo(st);
                        M.GetAverage(st);
                        M.GetGrade(st);
                        M.GetTotalScore(st);
                        studentList.Add(new Student(){Name = st.Name,StudentID = st.StudentID,Korean = st.Korean,English = st.English, Math = st.Math,Cs = st.Cs,Grade = st.Grade,Totalscore = st.Totalscore,Average = st.Average,Rank=st.Rank});
                        
                        for (int i = 0; i < people; i++)
                        {
                            studentList2 = studentList.ToArray();
                            //Console.WriteLine(studentList2[i].Name);
                        }
                        people += 1;
                        Console.WriteLine(studentList2[0].Rank);
                        //M.GetRank(studentList2);
                        break;
                    case 2:
                        //Console.WriteLine(studentList2[0].Name + studentList2[1].Name);
                        
                        foreach (var student in studentList)
                        {
                            Console.WriteLine("이름:" + student.Name + 
                                "학번:" + student.StudentID + 
                                "국어:" + student.Korean + 
                                "영어:" + student.English + 
                                "수학:" + student.Math + 
                                "씨샵:" + student.Cs + 
                                "학점:" + student.Grade + 
                                "총점:" + student.Totalscore + 
                                "평균:" + student.Average +
                                "등수:" + student.Rank);
                        }
                        Console.WriteLine("사람수{0}", people);
                        break;
                    case 3:
                        Console.Write("삭제할 학생이름 : ");
                        string name = Console.ReadLine();
                        M.Deleteinfo(studentList2,name);
                        break;
                    case 4:
                        break;
                    case 5:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("제대로입력해주세욥~");
                        break;



                }
            }

        }
    }
}
/*var list = List.Empty(new{
               Name = default(string),
               StudentID = default(int),
               Korean = default(double),
               English = default(double),
               Math = default(double),
               Cs = default(double),
               Grade = default(double),
               Totalscore = default(double),
               Average = default(double),
               Rank = default(int)
            });*/

/*studentList2[people].Name = st.Name;
                        studentList2[people].StudentID = st.StudentID;
                        studentList2[people].Korean = st.Korean;
                        studentList2[people].English = st.English;
                        studentList2[people].Math = st.Math;
                        studentList2[people].Cs = st.Cs;
                        studentList2[people].Grade = st.Grade;
                        studentList2[people].Totalscore = st.Totalscore;
                        studentList2[people].Average = st.Average;
                        studentList2[people].Rank = st.Rank;*/
/*for (int j = 0; j <= people; j++) 
                        {
                            Console.WriteLine("이름:" + studentList2[j].Name +
                                    "학번:" + studentList2[j].StudentID +
                                    "국어:" + studentList2[j].Korean +
                                    "영어:" + studentList2[j].English +
                                    "수학:" + studentList2[j].Math +
                                    "씨샵:" + studentList2[j].Cs +
                                    "학점:" + studentList2[j].Grade +
                                    "총점:" + studentList2[j].Totalscore +
                                    "평균:" + studentList2[j].Average +
                                    "등수:" + studentList2[j].Rank);
                        }*/
>>>>>>> parent of 3759f45... remove
