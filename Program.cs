using System;

namespace Sort
{
    class Program
    {
        struct Sample                       //학생 정보 구조체입니다. (임시)
        {
            public int key;                 //등수를 매길 자료가 될 변수. 총합 점수로 하시면 됩니다.
            public int rank;                //등수
        }

        static void PrintStudentList(Sample[] StudentList)                      //학생 정보 출력함수 (임시)
        {
            for (int i = 0; i < StudentList.Length; i++)
            {
                Console.WriteLine("점수 : {0}, 등수 : {1}", StudentList[i].key, StudentList[i].rank);
            }
        }

        static void PrintStudent(Sample StudentList)                      //학생 정보 출력함수 (임시)
        {
            Console.WriteLine("점수 : {0}, 등수 : {1}", StudentList.key, StudentList.rank);
        }
        
        //#############################################################################################
        //여기부터 맡은 부분입니다.

        static void GetRank(Sample[] StudentList)                           //등수를 매기는 함수
        {
            int[] TempArray = new int[StudentList.Length];
            for (int i = 0; i < StudentList.Length; i++)
            {
                TempArray[i] = StudentList[i].key;
            }

            Array.Sort(TempArray);

            for (int i = 0; i < StudentList.Length; i++)
            {
                for (int j = 0; j < StudentList.Length; j++)
                {
                    if (StudentList[i].key == TempArray[j])
                    {
                        StudentList[i].rank = StudentList.Length - j;
                        break;
                    }
                }
            }
        }

        static void PrintScholarshipStudent(Sample[] StudentList)           //장학생 출력 함수
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("장학생 목록");
            Console.WriteLine("==============================================================");
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 0; j < StudentList.Length; j++)
                {
                    if (StudentList[j].rank == i)
                    {
                        PrintStudent(StudentList[j]);
                        break;
                    }
                }
            }
            Console.WriteLine("==============================================================");
        }

        //##########################################################################################

        static void Main(string[] args)                         //결과 확인용입니다.
        {
            int[] Student = { 200, 220, 180, 320, 50 };
            Sample[] StudentList = new Sample[5];
            for (int i = 0; i < StudentList.Length; i++)
            {
                StudentList[i].key = Student[i];
            }

            GetRank(StudentList);

            PrintStudentList(StudentList);

            PrintScholarshipStudent(StudentList);
        }
    }
}
