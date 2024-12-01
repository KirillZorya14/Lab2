using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Linq;

public class StudentService : IStudentService
{
    private static readonly string XmlPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "students.xml");

    public List<Student> GetStudents(string minGrade, string maxGrade)
    {
        float min = float.Parse(minGrade);
        float max = float.Parse(maxGrade);
        XDocument xdocument = XDocument.Load(XmlPath);

        List<Student> result = xdocument.Root.Elements()
            .Where(student =>
            {
                float avg = float.Parse(student.Element("averageGrade").Value);
                return avg >= min && avg <= max;
            })
            .Select(student => new Student(
                student.Element("name").Value,
                student.Element("surname").Value,
                student.Element("patronymic").Value,
                float.Parse(student.Element("averageGrade").Value)
            ))
            .ToList();

        return result;
    }

}
