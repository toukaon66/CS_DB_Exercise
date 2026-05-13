using CS_DB_Exercise.Infrastructures.Accessors;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;

namespace CS_DB_Exercise;

class Program
{

    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();

        // EmployeeおよびDepartmentテーブルアクセスクラスを生成する
        var employeeAccessor = new EmployeeAccessor(context);
        // var departmentAccessor = new DepartmentAccessor(context);

        // 演習-10 employeeテーブルの社員名を変更する
        // Exercise10(employeeAccessor);
        Console.Write("社員名を入力してください->");
        var name1 = Console.ReadLine();
        var employee = employeeAccessor.FindByNameJoinDepartment(name1);
        Console.WriteLine(employee);
        Console.WriteLine(employee.Department);
        if(name1==null)
        {
            Console.WriteLine($"社員名:{name1}の社員は存在しませんでした");
            return;
        }
        // var i = 10;
        // string a = "たｋはあし";
        // var b = "たかはし";
        // Human human = new Human();
        // var km = human.walk();
    }

    /// <summary>
    /// 演習-10 employeeテーブルの社員名を変更する
    /// </summary>
    /// <param name="employeeAccessor">Employeeテーブルアクセスクラス</param>
    /// <returns></returns>
    private static void Exercise10(EmployeeAccessor employeeAccessor)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();

        // EmployeeおよびDepartmentテーブルアクセスクラスを生成する
        var employeeAccessor1 = new EmployeeAccessor(context);
        // var departmentAccessor = new DepartmentAccessor(context);

        // 演習-11 employeeテーブルの社員を削除する
        Exercise11(employeeAccessor);
    }

    /// <summary>
    /// 演習-11 employeeテーブルの社員を削除する
    /// </summary>
    /// <param name="employeeAccessor">Employeeテーブルアクセスクラス</param>
    /// <returns></returns>
    private static void Exercise11(EmployeeAccessor employeeAccessor)
    {

        Console.Write("社員Idを入力してください->");
        var empId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-11 指定された社員Idの社員を削除する\r\n");
        // 指定された社員Idの社員を削除する
        var result = employeeAccessor.DeleteById(empId);
        // 削除結果がnullの場合は該当社員が存在しないため削除できなかった旨を表示する
        if (result == null)
        {
            Console.WriteLine($"社員Id:{empId}の社員は存在しないため削除できませんでした");
            return;
        }
        Console.WriteLine($"社員Id:{empId}の社員を削除しました");
    }
}
