﻿namespace WorkingWithMultipleTable_Prod.Models.ViewModel
{
    public class EmployeeDepartmentSummaryViewModel
    {

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string DepartmentName { get; set; } = default;
        public string DepartmentCode { get; set; } = default;
    }
}