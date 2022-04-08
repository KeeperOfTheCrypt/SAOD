Console.WriteLine("Выбор задания: Первое задание - 1;Вторая часть первого задания - 2;Второе задание - 3");
int i = Convert.ToInt32(Console.ReadLine());
switch (i)
{
    case 1:
        Exes_1();
        break;
    case 2:
        Exes_1_2();
        break;
    case 3:
        Exes_2();
        break;
}
static void Exes_1() //Связанный список с помощью встроенных библиотек
{
    int ext; //Перепенная инициирующая прекращение процесса заполнения
    LinkedList<string> ex_9 = new LinkedList<string>(); //Инициализация связнного списка
    while (true) //Цикл ввода данных в связнный список
    {
        ex_9.AddLast(Console.ReadLine()); //Добавление в конце связанного списка
        Console.WriteLine("1-продолжить;0-Стоп.");
        ext = Convert.ToInt32(Console.ReadLine());
        if (ext == 0) //Прекратить или продолжить ввод?
        {
            break;
        }
    }
    LinkedListNode<string> node; //Инициализация списка указателей
    for (node = ex_9.First; node != null; node = node.Next)
    {
        Console.Write((node.Value).ToString() + "\t"); //Используя раннее инициализированный
                                                       //список указателей, перемещаемся по связанному списку
                                                       //начиная с конца
    }
}
static void Exes_1_2() //Связанный список с помощью нескольких массив
{
    var rand = new Random(); //Инициализация генератора случайных чисел
    int[] key = new int[100]; //Массив значений
    int[] next = new int[100]; //Массив указателей на последующие элементы
    int[] pref = new int[100]; //Массив указателей на предыдущие элементы
    int ext, n, n_pref; //n-номер текущего элемента. n_pref-номер предшевствующего элемента
    n = rand.Next(1, 99); //Ставим изначальный элемент на случайную позицию
    key[n] = Convert.ToInt32(Console.ReadLine()); //Вводим значение изначального элемента
    while (true) //Цикл ввода массивов
    {
        n_pref = n; //Сохраняем номер текущего элемента
        n = rand.Next(1, 99); //Генерируем номер для нового элемента
        if (key[n] == 0) //Если он не занят...
        {
            key[n] = Convert.ToInt32(Console.ReadLine()); //Вводим значение нового элемента
            next[n_pref] = n; //Следующий элемент предыдущего - текущий
            pref[n] = n_pref; //Предыдущий элемент текущего - предыдущего
        }
        else continue; //Если занято, начинаем заново
        Console.WriteLine("1-продолжить;0-Стоп.");
        ext = Convert.ToInt32(Console.ReadLine());
        if (ext == 0) break; //Стоп-условие
    }
    while (n_pref > 0) //Цикл вывода
    {
        Console.Write(key[n] + "\t");
        ext = n;
        n = n_pref;
        n_pref = pref[ext];
    }
    Console.Write(key[n] + "\t");
}

static void Exes_2() //Составление бинарного дерева с помощью таблицы
{
    int[,] tree = new int[4, 100]; //Таблица, которая будет содержать бинарное дерево
    int some; //Вводимое число
    int ext;
    some = Convert.ToInt32(Console.ReadLine()); //Ввод числа
    for (int i = 0; i <= 99; i++) //Присваивание всем значением первого столбца в таблице значения "-1".
                                  //Делается это для того, чтобы можно было 
    {
        tree[0, i] = -1;
    }
    tree[0, 0] = 1; //Ввод номера коренной ячейки
    tree[1, 0] = some; //Ввод значения коренной ячейки
    int j; //Переменная для поиска свободной ячейки
    while (true) //Цикл ввода ячеек
    {
        j = 0; //Начиная с первой ячейки...
        some = Convert.ToInt32(Console.ReadLine()); //Вводим значение, которое необходимо вставить
        Add(ref tree, some, j); //Вызов класса вставки ячейки

        Console.WriteLine("1-Продолжить;0-Стоп.");
        ext = Convert.ToInt32(Console.ReadLine());
        if (ext == 0) break; //Стоп-условие
    }
    Console.WriteLine("№\t" + "key\t" + "left\t" + "right\t");
    for (int i = 0; tree[0, i] != -1; i++)
    {
        Console.WriteLine(tree[0, i] + "\t" + tree[1, i] + "\t" + tree[2, i] + "\t" + tree[3, i] + "\t");
    }
}
static void Add(ref int[,] tree, int some, int j) //Класс вставки новой ячейки
{
    int i;
    if (some < tree[1, j]) //Если введенное значение меньше значения данной ячейки...
    {
        if (tree[2, j] == 0) //Если нет наследника
        {
            for (i = j + 1; i <= 99; i++) // До конца таблицы..
            {
                if (tree[0, i] == -1) //Если ячейка не занята...
                {
                    tree[0, i] = i + 1; //Ставим номер на пустой ячейке
                    tree[1, i] = some;  //Ставим значение в пустую ячейку
                    tree[2, j] = i + 1; //Устанавливаем наследование
                    break;
                }
            }
        }
        else // Если наследников нет
        {
            i = tree[2, j]; // Ставим номер наследника как основной
            Add(ref tree, some, i - 1); // Рекурсия
        }
    }
    else if (some > tree[1, j])
    {
        if (tree[3, j] == 0)
        {
            for (i = j + 1; i <= 99; i++)
            {
                if (tree[0, i] == -1)
                {
                    tree[0, i] = i + 1;
                    tree[1, i] = some;
                    tree[3, j] = i + 1;
                    break;
                }
            }
        }
        else
        {
            i = tree[3, j];
            Add(ref tree, some, i - 1);
        }

    }

}
