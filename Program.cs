using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Queries;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var accessor = new DepartmentAccessor(new AppDbContext());
        //DepartmentAccessorのインスタンス生成をする
        var departments = accessor.FindAll();
        Console.WriteLine("すべての部署を取得する");
        foreach(var d in departments)
        {
            Console.WriteLine(d);
        }

        var department = accessor.FindById(1);
        Console.WriteLine($"存在する部署Id:{department!.ToString()}");
        //DepartmentAccessorのFindAllメソッドを呼ぶ
        //↑で取得したデータを出力する
         // 指定した部署Idの部署を取得する(存在しない部署Id)
        department = accessor.FindById(101);
        if (department == null)
        {
            Console.WriteLine($"部署Id:101の部署は存在しません。"); // 指定した部署Idの部署を取得する(存在しない部署Id)
            department = accessor.FindById(101);
        }
    }
}
