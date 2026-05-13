using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CS_DB_Exercise.Infrastructures.Entities
{
    [Table("department")]
    public class DepartmentEntity
    {
        [Key]
    [Column("id")]
    public int Id { get; set; }         // 部署Id（主キー）
    [Column("name")]
    public string? Name { get; set; }   // 部署名

    public List<EmployeeEntity>? Employees { get; set; }

    public override string ToString()
    {
        return $"部署Id:{Id} , 部署名:{Name}";
    }
    }
}