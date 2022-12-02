using System.Text;
namespace lab3
{
    public class Program3
    {
        static void Input(out int N, out int[,] A, string fileName = "input.txt")
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
        static void Output(string n, string fileName = "output.txt")
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(n);
            }
        }
        static void Input2(out int N, out int[,] A, string text)
        {
            var textLines = text.Split(',', '\n', StringSplitOptions.RemoveEmptyEntries);
            N = Convert.ToInt32(textLines[0]);
            A = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                var firstSplit = textLines[i + 1].Split(' ',StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < N; j++)
                    A[i, j] = Convert.ToInt32(firstSplit[j]);
            }

        }
        public static string Calculate(string input)
        {
            int n;
            int[,] a;
            Input2(out n, out a, input);

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
                    sb.Append(',');
            }
            return sb.ToString();
        }
        public static void Main(string[] args)
        {
            int n;
            int[,] a;
            try
            {
                Input(out n, out a, args[0]);

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
        }
    }
}
