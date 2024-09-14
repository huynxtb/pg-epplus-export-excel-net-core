using System.ComponentModel;

namespace ProGCoder_ExportExcel.Models;

public class StudentModel
{
    [Description("Họ tên")]
    public string Name { get; set; }
    [Description("Địa chỉ")]
    public string Address { get; set; }
    [Description("Tuổi")]
    public int Age { get; set; }
}