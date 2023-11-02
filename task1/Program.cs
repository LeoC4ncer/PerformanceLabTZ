public class Program
{
    public static void Main(string[] args)
    {
        uint amountOfNumbers;
        uint step;
        string answer = "";

        amountOfNumbers = Convert.ToUInt32(args[0]);
        step = Convert.ToUInt32(args[1]);

        uint currentNumber = 1;
        do
        {
            answer += currentNumber.ToString();
            currentNumber += (step - 1);
            while (currentNumber > amountOfNumbers)
                currentNumber -= amountOfNumbers;
        } while (currentNumber != 1);

        Console.WriteLine(answer);
    }
}