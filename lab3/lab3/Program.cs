using System.Text;

void Input( out int N, out int[,] A, string fileName = "input.txt")
{
    using (TextReader reader = File.OpenText(fileName))
    {
        N = Convert.ToInt32(reader.ReadLine());
        A = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            var firstSplit = reader.ReadLine().Split();
            for (int j = 0; j < N; j++)
                A[i, j] = Convert.ToInt32(firstSplit[j]);
        }
    }
}
void Output(string n, string fileName = "output.txt")
{
    using (StreamWriter sw = new StreamWriter(fileName))
    {
        sw.Write(n);
    }
}
int n;
int[,] a;
try
{
    Input(out n, out a);

    for (int k = 0; k < n; k++)
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (i != j)
                    a[i, j] = Math.Min(a[i, j], a[i, k] + a[k, j]);

    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
            sb.Append(a[i, j].ToString() + ' ');
       
        if (i < n - 1)
            sb.Append(Environment.NewLine);
    }
    Output(sb.ToString());
}
catch { Output("Помилка"); }
