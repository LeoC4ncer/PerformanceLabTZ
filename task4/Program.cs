
public class Program
{
    public static void Main(string[] arg)
    {
        string fileName = arg[0];
        fileName = Path.GetFullPath(fileName);
        List<int> nums = new List<int>();

        using (StreamReader sr = new StreamReader(fileName))
        {
            string num = sr.ReadLine();
            while (num != null)
            {
                nums.Add(Convert.ToInt32(num));
                num = sr.ReadLine();
            }
        }

        int averageNum = 0;
        foreach (int num in nums)
            averageNum += num;
        averageNum /= nums.Count;

        int numsHigher = 0;
        foreach (int num in nums)
            if (num > averageNum)
                numsHigher++;

        if ((numsHigher * 2) > nums.Count)
            averageNum++;

        int numOfMoves = 0;
        foreach (int num in nums)
            numOfMoves += Math.Abs(num - averageNum);

        Console.WriteLine(numOfMoves);
    }
}
