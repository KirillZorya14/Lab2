using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IStudentService
{
    [OperationContract]
    [WebGet(UriTemplate = "/GetStudents?minGrade={minGrade}&maxGrade={maxGrade}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<Student> GetStudents(string minGrade, string maxGrade);
}

[DataContract]
public class Student
{
    [DataMember]
    public string FirstName { get; set; }

    [DataMember]
    public string LastName { get; set; }

    [DataMember]
    public string Patronymic { get; set; }

    [DataMember]
    public float AverageGrade { get; set; }

    public Student(string firstName, string lastName, string patronymic, float averageGrade)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Patronymic = patronymic;
        this.AverageGrade = averageGrade;
    }
}
