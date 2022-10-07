//CHabanenko IPZ-41 Variant 60
int Input(string fileName = "input.txt")
{
    using (TextReader reader = File.OpenText(fileName))
    {
        int number;
        string value = reader.ReadLine();
        bool success = int.TryParse(value, out number);
        return number;
    }
}
void Output(int n,string fileName = "output.txt")
{
    using (StreamWriter sw = new StreamWriter(fileName))
    {
        sw.Write(n);
    }
}
int count = 0;
int Divide(int number)
{
    //умова завдання
    if (number <= 0 || number > 1018)
        return -1;
    //групи з 3 не ділимо
    if (number < 3)
        return count;
    if (number == 3)
        count++;
    else
    {
       int left = (int)Math.Ceiling((decimal)number / 2);
       Divide(left);
       Divide(number-left);
    }
    return count;
}
Output(Divide(Input()));


