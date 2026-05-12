using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CS_DB_Exercise.Infrastructures.Entities
{
    [Table("employee")]
    public class EmployeeEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("dept_id")]
        public int Dept_id { get; set; }
        public override string ToString()
        {
            return $"従業員Id:{Id} , 従業員名:{Name},部署Id:{Dept_id}";
        }
    }
}