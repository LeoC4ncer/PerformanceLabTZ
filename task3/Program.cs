using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    static void MatchValue(Value value, Test test)
    {
        if (value.id == test.id)
        {
            test.value = value.value;
        }

        if (test.values != null)
        {
            foreach (Test testInside in test.values)
                MatchValue(value, testInside);
        }
    }

    static Test CheckValue(Test test)
    {
        
        Test testToReport = new Test();
        testToReport.id = test.id;
        testToReport.title = test.title;
        testToReport.value = test.value;

        if (test.values != null)
        {
            foreach (Test testInside in test.values)
            {
                Test testToAdd = CheckValue(testInside);
                if (testToAdd != null)
                {
                    testToReport.values.Add(testToAdd);
                }
            }    

        }
        if (test.value != null || testToReport.values.Any())
        {
            if(!testToReport.values.Any())
            {
                testToReport.values = null;
            }
            if (testToReport.value == null)
            {
                testToReport.value = "";
            }
            return testToReport;
        }
            
        else
            return null;
    }

    public static void Main(string[] args)
    {
        string fileTests = args[0];
        string fileValues = args[1];
        
        string jsonString = File.ReadAllText(Path.GetFullPath(fileTests));
        Tests tests = JsonSerializer.Deserialize<Tests>(jsonString)!;

        jsonString = File.ReadAllText(Path.GetFullPath(fileValues));
        Values values = JsonSerializer.Deserialize<Values>(jsonString)!;

        foreach (Value value in values.values)
        {
            foreach(Test test in tests.tests)
            {
                
                MatchValue(value, test);
            }
                
        }
        
        Tests report = new Tests();

        foreach (Test test in tests.tests)
        {
                report.AddTest(CheckValue(test));
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        jsonString = JsonSerializer.Serialize(report.tests, options);
        
        File.WriteAllText("report.json", jsonString);

    }

}

public class Tests
{
    public List<Test> tests { get; set; } = new List<Test>();

    public void AddTest(Test test)
    {
       if (test != null)
            this.tests.Add(test);
    }

}

public class Test
{
    public int id { get; set; }
    public string title { get; set; }
    public string value { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Test> values { get; set; } = new List<Test>();


}
public class Values
{
    public List<Value> values { get; set; }
}

public class Value
{
    public int id { get; set; }
    public string value { get; set; }
}

