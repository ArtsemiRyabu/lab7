using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using BlazorApp2.Shared.Models;

namespace BlazorApp2.Shared.ViewModels
{
    public class ComputerOrderViewModel
    {
        public int ComputerOrderId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        [Required(ErrorMessage = "Не указана дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Не указана дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExecutionDate { get; set; }
        [Required(ErrorMessage = "Не указана предоплата")]
        [Display(Name = "Предоплата")]
        public double Prepayment { get; set; }
        [Display(Name = "Имя клиента")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Не указана рабочая марка")]
        [Display(Name = "Рабочая марка")]
        public string WorkMark { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "Недопустимая цена")]
        [Display(Name = "Полная цена")]
        public double AllCost { get; set; }
        public string GuaranteePeriod { get; set; }
        [Display(Name = "Имя работника")]
        public string EmployeeName { get; set; }

        public ComputerOrderViewModel()
        {
            ComputerOrderId = 0;
            OrderDate = DateTime.Today;
            ExecutionDate = DateTime.Today;
        }
    }
}
