using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
class SuperClass
{
    private double[,] array;

    private bool is_prime(int x)
    {
        for (int i = 2; i < x; i++)
        {
            if (x % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    private ArrayList prime(int x)
    {
        int z = 0;
        int y = 3;
        ArrayList tempList = new ArrayList();
        tempList.Add(2);
        while (z < x * x)
        {
            if (is_prime(y))
            {
                tempList.Add(y);
                z++;
            }
            y++;
        }
        return tempList;
    }
    public SuperClass(SuperClass New, bool x = false)
    {
        int row = New.array.GetUpperBound(0) + 1;
        int collon = New.array.Length / row;
        if (x == false)
        {
            array = new double[row, collon];
        }
        else
        {
            array = new double[collon, row];
        }

    }

    public SuperClass(int n, bool x)
    {
        array = new double[n, n];
        int z = 0;
        ArrayList temp = prime(n);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = Convert.ToDouble(temp[z]);
                z++;
            }
        }
    }

    public SuperClass(int n)
    {
        Random rand = new Random();
        array = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = rand.Next(0, 10);
            }
        }
        double temp;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (array[j, i] > array[c, i])
                    {
                        temp = array[j, i];
                        array[j, i] = array[c, i];
                        array[c, i] = temp;
                    }
                }
            }
        }
    }

    public SuperClass(int n, int m)
    {
        array = new double[n, m];
        for (int i = 0; i < m; i++)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                Console.WriteLine("Введите следующий элемент массива: ");
                try
                {
                    array[j, i] = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    array[j, i] = 0;
                }
            }
        }

    }

    public void estimation()
    {
        int row = array.GetUpperBound(0) + 1;
        int collon = array.Length / row;
        ArrayList tempList = new ArrayList();
        double temp = 0;
        for (int i = 0; i < collon; i++)
        {
            for (int j = 0; j < row; j++)
            {
                temp += array[j, i];
            }
            if (temp/row >= 4.5)
            {
                tempList.Add(i);
            }
            temp = 0;
        }
        Console.WriteLine("Индексы учеников, чей средний бал больше 4.5");
        foreach (var i in tempList)
        {
            Console.WriteLine(i);
        }
    }
    public SuperClass T(SuperClass S)
    {
        int row = S.array.GetUpperBound(0) + 1;
        int cols = S.array.Length / row;
        SuperClass arr = new SuperClass(S, true);
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < row; j++)
            {
                arr.array[i, j] = S.array[j, i];
            }
        }
        return arr;
    }
    public static SuperClass operator +(SuperClass S1, SuperClass S2)
    {
        int row = S2.array.GetUpperBound(0) + 1;
        int cols = S2.array.Length / row;
        SuperClass arr = new SuperClass(S2);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                arr.array[i, j] = S1.array[i, j] + S2.array[i, j];
            }
        }
        return arr;
    }
    public static SuperClass operator -(SuperClass S1, SuperClass S2)
    {
        int row = S2.array.GetUpperBound(0) + 1;
        int cols = S2.array.Length / row;
        SuperClass arr = new SuperClass(S2);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                arr.array[i, j] = S1.array[i, j] - S2.array[i, j];
            }
        }
        return arr;
    }
    public static SuperClass operator *(int x, SuperClass y)
    {
        int row = y.array.GetUpperBound(0) + 1;
        int cols = y.array.Length / row;
        SuperClass arr = new SuperClass(y);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                arr.array[i, j] = y.array[i, j] * x;
            }
        }
        return arr;
    }
    public override string ToString()
    {
        string text = "";
        int row = array.GetUpperBound(0) + 1;
        int cols = array.Length / row;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                text += array[i, j] + " ";
            }
            text += "\n";
        }
        return text;
    }
}

class FileWork
{
    string path;
    
    public string Path
    {
        get { return path; }
        set { path = value; }
    }
    public FileWork(string _path)
    {
        path = _path;
    }
    public void rand_file(int x = 0)
    {
        Random rand = new Random();
        if (x == 0)
        {
            using (BinaryWriter write = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 100; i++)
                {
                    write.Write(rand.Next(1, 100));
                }
            }
        }
        else if (x == 1)
        {
            using (StreamWriter write = new StreamWriter(path, false))
            {
                for (int i = 0; i < 100; i++)
                {
                    string text = Convert.ToString(rand.Next(1, 100) + "\n");
                    write.Write(text);
                }
            }
        }
        else if (x == 2)
        {
            using (StreamWriter write = new StreamWriter(path, false))
            {
                string text = "";
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        text += Convert.ToString(rand.Next(1, 10) + " ");
                    }
                    text += Convert.ToString(rand.Next(1, 10));
                    write.Write(text + "\n");
                    text = "";
                }
            }
        }
    }
    public int number_squares()
    {
        int z = 0;
        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            int read = 0;
            double sread = 0;
            for (int i = 0; i < 100; i++)
            {
                read = reader.ReadInt32();
                sread = Math.Sqrt(read);
                if ((sread % 2 != 0) && (sread == Convert.ToInt32(sread)))
                {
                    z++;
                }
            }
        }
        return z;
    }
    public double max_min()
    {
        double z = 0;
        double max = 0;
        double min = 0;
        using (StreamReader read = new StreamReader(path))
        {
            max = Convert.ToDouble(read.ReadLine());
            min = Convert.ToDouble(read.ReadLine());
            double x = 0;
            if (max < min)
            {
                z = max;
                max = min;
                min = z;
            }
            for (int i = 0; i < 100 - 2; i++)
            {
                x = Convert.ToDouble(read.ReadLine());
                if (x > max)
                {
                    max = x;
                }
                else if (x < min)
                {
                    min = x;
                }
            }
            z = (max + min) / 2;
        }
        return z;
    }
    public double even()
    {
        double z = 1;
        using (StreamReader read = new StreamReader(path))
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (var v in read.ReadLine().Split(new char[] { ' ' }))
                {
                    if (Convert.ToInt32(v) % 2 == 0)
                    {
                        z *= Convert.ToDouble(v);
                    }
                }
            }
        }
        return z;
    }
    public void copyL(string copyPath)
    {
        using (StreamWriter write = new StreamWriter(copyPath, false))
        {
            using (StreamReader read = new StreamReader(path))
            {
                bool y = false;
                string text = read.ReadLine();
                do
                {
                    y = false;
                    foreach (var v in "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM")
                    {
                        if (text.IndexOf(v) != -1)
                        {
                            y = true;
                            break;
                        }
                    }
                    if (y == false)
                    {
                        write.WriteLine(text);
                    }
                    text = read.ReadLine();
                } while (text != null);
            }
        }
    }
    public void inputFile(ArrayList toys) {
        using (FileStream write = new FileStream(path, FileMode.OpenOrCreate))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HelloWorld.toy));
            foreach (var v in toys)
            {
                xmlSerializer.Serialize(write, v);
            }
        }
    }
}

public class HelloWorld
{

    public struct toy()
    {
        string name;
        double prise;
        int min;
        int max;
        public void input(string name, double prise, int min, int max)
        {
            this.name = name;
            this.prise = prise;
            this.min = min;
            this.max = max;
            this.max = max;
        }
        public override string ToString()
        {
            return ("Название: " + name + "\nЦена: " + Convert.ToString(prise) + "\nДиапозон: " + Convert.ToString(min) + " — " + Convert.ToString(max));
        }
    }
    static void Main()
    {
        string control = "";
        while (control != "exit")
        {
            Console.WriteLine("Введите команду:\none — первый блок задач\ntwo — второй блок задач\nexit — выйти");
            control = Console.ReadLine();
            if (control == "exit")
            {
                Console.WriteLine("До свидания!");
                continue;
            }
            else if (control == "one")
            {
                Console.WriteLine("Заполните три массива\nВведите число столбцов");
                int n = 0;
                int m = 0;
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Нет");
                }
                Console.WriteLine("Введите число строк");
                try
                {
                    m = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Нет");
                }
                SuperClass S1 = new SuperClass(n, m);
                Console.WriteLine("Введите целое число");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Нет");
                }
                SuperClass S2 = new SuperClass(n);
                SuperClass S3 = new SuperClass(n, true);
                Console.WriteLine(S1);
                Console.WriteLine(S2);
                Console.WriteLine(S3);
                Console.WriteLine("Первый заполненный массив:");
                S1.estimation();
                Console.WriteLine("Ат-Вт+2*С = ");
                try
                {
                    Console.WriteLine(S1.T(S1) - S2.T(S2) + 2 * S3);
                }
                catch
                {
                    Console.WriteLine("Матрицы не соответствуют требованиям арифметических операций");
                }

            }
            else if (control == "two")
            {
                FileWork F = new FileWork("File.bin");
                F.rand_file();
                Console.WriteLine("Всего в файле найдено квадратов нечётных чисел:");
                Console.WriteLine(F.number_squares());
                F.Path="File.txt";
                F.rand_file(1);
                Console.WriteLine("Среднее арефмитическое максимального и минимального числа:");
                Console.WriteLine(F.max_min());
                F.Path = "File_2.txt";
                F.rand_file(2);
                Console.WriteLine("Произведение чётных чисел в файле:");
                Console.WriteLine(F.even());
                F.Path = "TextFile.txt";
                F.copyL("newTextFile.txt");
                Console.WriteLine("Строки перенесены.");
                /*                ArrayList toys = new ArrayList();
                                string name = null;
                                double prise = 0;
                                int min = 0;
                                int max = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    toy temp = new toy();
                                    Console.WriteLine("Введите имя игрушки");
                                    name = Console.ReadLine();
                                    Console.WriteLine("Введите цену игрушки");
                                    prise = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Введите нижнюю возростную границу игрушки");
                                    min = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите верхнюю возростную границу игрушки");
                                    max = Convert.ToInt32(Console.ReadLine());
                                    temp.input(name, prise, min, max);
                                    toys.Add(temp);
                                 }
                                F.inputFile(toys);*/


            }
        }
    }
}
