// https://www.progcoder.com/

using ProGCoder_ExportExcel.Helpers;
using ProGCoder_ExportExcel.Models;

var currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? "";
var savePath = currentPath.Split("bin")[0] + @"ExcelFolder\";

var listStudents = new List<StudentModel>()
{
    new StudentModel()
    {
        Name = "ProG Coder",
        Address = "Đà Nẵng",
        Age = 23
    },
    new StudentModel()
    {
        Name = "Huy Nguyễn",
        Address = "Thái Bình",
        Age = 24
    },
    new StudentModel()
    {
        Name = "Xuân Huy",
        Address = "Hà Nội",
        Age = 25
    },
};

var listAnimals = new List<AnimalModel>()
{
    new AnimalModel()
    {
        Name = "Chó",
        Age = "1 Tuổi"
    },
    new AnimalModel()
    {
        Name = "Mèo",
        Age = "2 Tuổi"
    },
    new AnimalModel()
    {
        Name = "Gà",
        Age = "12 Tháng Tuôổi"
    },
};

var fileNameS = "Student_" + Guid.NewGuid().ToString().Split("-").First() + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

ExportExcelHelper<StudentModel>.GenerateExcel(listStudents, savePath + fileNameS, "ProG Coder");

var fileNameA = "Animal_" + Guid.NewGuid().ToString().Split("-").First() + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

ExportExcelHelper<AnimalModel>.GenerateExcel(listAnimals, savePath + fileNameA, "ProG Coder");

Console.WriteLine("Done!!!!");

// https://www.progcoder.com/
