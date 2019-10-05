using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 프로그램명 : Delete_std.cs
 * 작성자 : 정선우
 *  내용  : 입력받은 이름의 학생정보를 제거한다 
 *  일자  : 2019-09-05
 */
namespace Delete_std
{
    class Student
    {
        //private Student[] array;
        //public Student()
        //{
        //    array = new Student[3];
        //}

        //public void getName()
        //{
        //    Console.WriteLine("이름 : ");
        //    Name = Console.ReadLine();
        //}
        //public string Name
        //{
        //    set; get;
        //}
        //public int Rank { set; get; }


        public void Delete(string name)
        {
            // name을 통해 리스트 내의 삭제정보 찾기
            try
            {
                int deIndex = Array.IndexOf(array, name); // Indexof함수는 Array의 값이 NULL값일 경우 예외발생, 찾으면 해당 인덱스, 못찾으면 배열의 하한값-1 반환
                if (deIndex == -1)
                {
                    Console.WriteLine("해당 학생은 없습니다.");
                }
                else
                {
                    Array.Clear(array, deIndex, 1); // array의 해당 인덱스의 정보를 제거한다
                }

                // Scholarship(); 장학생검색에 있는 정렬로 순위 다시 매기기 
            }
            catch (System.ArgumentNullException)    // Array배열이 NULL값일 경우 예외처리
            {
                Console.WriteLine("학생이 없습니다.");
            }
        }
    }
}