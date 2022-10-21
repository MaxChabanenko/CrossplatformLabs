
static bool IsGoodSet(int[,] a)
{
    int sum;
    for (int i = 0; i <= a.GetLength(0) - 2; i++)
    {
        for (int j = 0; j <= a.GetLength(1) - 2; j++)
        {
            sum = 0;
            for (int k = 0; k < 2; k++)
            {
                for (int l = 0; l < 2; l++)
                {
                    if (Convert.ToBoolean(a[i + k, j + l]))
                        sum++;
                }
            }
            if (sum == 0 || sum == 4)
                return false;
        }
    }
    return true;
}
static int[,] RandomizeMatrix(int n, int w, int h)
{
    int[,] a = new int[h, w];
    int buf;
    for (int i = 0; i < h; i++)
    {
        for (int j = 0; j < w; j++)
        {
            buf = n % 2;
            a[i, j] = buf ;
            n = (n - buf) / 2;
        }
    }
    return a;
}
void Input(out int M, out int N,string fileName = "input.txt")
{
    using (TextReader reader = File.OpenText(fileName))
    {
        var value = reader.ReadLine().Split();
        var success1 = int.TryParse(value[0], out M);
        var success2 = int.TryParse(value[1], out N);
    }
}
void Output(string n, string fileName = "output.txt")
{
    using (StreamWriter sw = new StreamWriter(fileName))
    {
        sw.Write(n);
    }
}
try { 
int m, n;
Input(out m,out n);
    if (m * n < 1 || m * n > 30)
        throw new Exception();
int totalPermutations = (int)Math.Pow(2, m * n);
int count = 0;
for (int i = 0; i < totalPermutations; i++)
{
    if (IsGoodSet(RandomizeMatrix(i, m, n)))
        count++;
}
Output(count.ToString());
}
catch { Output("Помилка"); }