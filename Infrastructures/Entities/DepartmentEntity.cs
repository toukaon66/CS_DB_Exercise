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
        public int Id {get;set;}
       [Column("name")]
       public string? Name {get;set;}
        public override string ToString()
        {
            return $"部署Id:{Id} , 部署名:{Name}";
        }
    }
}