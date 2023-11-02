using System.Globalization;
public class Program
{
    public static void Main(string[] args)
    {
        string fileCircle = args[0];
        string filePoints = args[1];

        fileCircle = Path.GetFullPath(fileCircle);
        filePoints = Path.GetFullPath(filePoints);

        int answer;
        int radius;
        float pointX, pointY, circleX, circleY;

        using (StreamReader sr = new StreamReader(fileCircle))
        {
            string line = sr.ReadLine();
            circleX = Convert.ToSingle(line.Substring(0, line.IndexOf(' ')).Replace(',', '.'), new CultureInfo("en-US"));
            circleY = Convert.ToSingle(line.Substring(line.IndexOf(' ')).Replace(',', '.'), new CultureInfo("en-US"));
            radius = Convert.ToInt32(sr.ReadLine());
        }

        using (StreamReader sr = new StreamReader(filePoints))
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                pointX = Convert.ToSingle(line.Substring(0, line.IndexOf(' ')).Replace(',', '.'), new CultureInfo("en-US"));
                pointY = Convert.ToSingle(line.Substring(line.IndexOf(' ')).Replace(',', '.'), new CultureInfo("en-US"));
                if (Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2) == radius * radius)
                    answer = 0;
                else
                {
                    if (Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2) < radius * radius)
                        answer = 1;
                    else
                        answer = 2;
                }

                Console.WriteLine(answer);

                line = sr.ReadLine();
            }
        }
    }
}
