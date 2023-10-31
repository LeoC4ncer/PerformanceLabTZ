uint amountOfNumbers;
uint step;
string answer = "";

string line = Console.ReadLine().Trim();
amountOfNumbers = Convert.ToUInt32(line.Substring(0, line.IndexOf(' ')).Trim());
step = Convert.ToUInt32(line.Substring(line.IndexOf(' ')).Trim());

uint currentNumber = 1;
do
{
    answer += currentNumber.ToString();
    currentNumber += (step - 1);
    while (currentNumber > amountOfNumbers) 
        currentNumber -= amountOfNumbers;
} while (currentNumber != 1 );

Console.WriteLine(answer);
Console.ReadKey(true);