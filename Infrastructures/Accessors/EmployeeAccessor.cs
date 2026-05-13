using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS_DB_Exercise.Infrastructures.Accessors;

public class EmployeeAccessor
{
    private readonly AppDbContext _context;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">演習用DbContext</param>
    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 演習-07 employeeテーブルから部署Idで該当社員を取得する
    /// </summary>
    /// <param name="deptId">部署Id</param>
    /// <returns>問合せ結果</returns>
    public List<EmployeeEntity>? FindByDeptId(int deptId)
    {
        var employees = _context.Employees
            .Where(e => e.DeptId == deptId)
            .ToList();
        // 取得した社員の件数が0件の場合はnullを返す
        if (employees.Count == 0)
        {
            return null;
        }

        return employees;
    }

    public List<EmployeeEntity> FindByContaintsName(string keyword)
    {
        var employees = _context.Employees
            .Where(e => e.Name!.Contains(keyword))
            .ToList();
        return employees;
    }

    public EmployeeEntity Create(EmployeeEntity employeeEntity)
    {
        var result = _context.Employees.Add(employeeEntity);
        _context.SaveChanges();
        return result.Entity;
    }

    public EmployeeEntity UpdateById(EmployeeEntity employeeEntity)
    {
        var result = _context.Employees.Find(employeeEntity.Id);
        if (employeeEntity == null)
        {
            return null;
        }
        result!.Name = employeeEntity.Name;
        _context.SaveChanges();
        return employeeEntity;
    }
    public EmployeeEntity DeleteById(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        return employee;
    }
    public EmployeeEntity FindByNameJoinDepartment(string name)
    {

        var employee1 = _context.Employees
            .Where(i => i.Name == name)
            .Include(i => i.Department) // カテゴリを結合して取得する
            .FirstOrDefault();
        return employee1;

    }
    public List<EmployeeEntity>? FindByNameContainsJoinDepartment(string name)
    {

        var employee = _context.Employees
        .Include(e => e.Department)
        .Where(i => i.Name.Contains(name))
        .ToList();
        if (employee.Count == 0)
        {
            return null!;
        }
        return employee!;
    }
}