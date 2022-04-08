using System.Collections.Generic;
Console.WriteLine("Выбирете задание 1 или 2.");
int choise_exercise = Convert.ToInt32(Console.ReadLine());
switch (choise_exercise)
{
    case 1:
        Exercice_1();
        break;
    case 2:
        Exercice_2();
        break;
}




void Exercice_1()
{
    int[] k = { 5, 82, 19, 51, 29, 33, 12, 107, 10 }; //Первоначально данный массив ключей
    int[] hash = new int[53]; //Хэш-таблица
    One_linked_list[] lists = new One_linked_list[53]; //Массив односвязанных списков

    for (int i = 0; i < 53; i++) //Цикл обнуления хэш таблицы и инизиализации экземпляров класса связанного списка**
    {
        hash[i] = 0;
        lists[i] = new One_linked_list();
    }//**Цикл обнуления хэш таблицы

    int hash_index; //Переменная для хранения результата вычисления хэш-функции и инизиализации экземпляров класса связанного списка

    for (int i = 0; i < k.Length; i++) //Цикл заполнения хэш-таблицы**
    {
        hash_index = hash_function(k[i], 53); //Получения значения хэша
        if (hash[hash_index] == 0) //Если в ячейке хэш таблицы не храниться значение...
        {
            hash[hash_index] = k[i]; //...вставляем в неё значение
        }
        else
        {
            lists[hash_index].Add_elements(k[i]); //Иначе вставляем значение в связанный список
        }
    }//**Цикл заполнения хэш-таблицы

    Console.WriteLine("\tХЭШ-ТАБЛИЦА");
    Console.WriteLine("____________________________");

    for (int i = 0; i < 53; i++) //Цикл вывода хэш-таблицы**
    {
        Console.Write("Индекс: " + i + "\tКлюч(-и): " + hash[i]);
        if (lists[i].empty == false) //Если связанный список в этой ячейке пуст
        {
            lists[i].Show();
        }
        Console.WriteLine();
    }//**Цикл вывода хэш-таблицы

    static int hash_function(int k, int m) //Функция вычисления хэш-функции**
    {
        int hash = k % m;
        return hash;
    } //**Функция вычисления хэш-функции

}





void Exercice_2()
{
    int[] k = { 10, 22, 31, 4, 15, 28, 17, 88, 59, 61, 62, 63, 64, 65 };

    int[] hash = new int[53]; //Хэш-таблица
    One_linked_list[] lists = new One_linked_list[53]; //Массив односвязанных списков

    for (int i = 0; i < 53; i++) //Цикл обнуления хэш таблицы и инизиализации экземпляров класса связанного списка**
    {
        hash[i] = 0;
        lists[i] = new One_linked_list();
    }//**Цикл обнуления хэш таблицы

    int hash_index; //Переменная для хранения результата вычисления хэш-функции и инизиализации экземпляров класса связанного списка

    for (int i = 0; i < k.Length; i++) //Цикл заполнения хэш-таблицы**
    {
        hash_index = hash_function(k[i], 53); //Получения значения хэша
        if (hash[hash_index] == 0) //Если в ячейке хэш таблицы не храниться значение...
        {
            hash[hash_index] = k[i]; //...вставляем в неё значение
        }
        else
        {
            lists[hash_index].Add_elements(k[i]); //Иначе вставляем значение в связанный список
        }
    }//**Цикл заполнения хэш-таблицы

    Console.WriteLine("\tХЭШ-ТАБЛИЦА");
    Console.WriteLine("____________________________");

    for (int i = 0; i < 53; i++) //Цикл вывода хэш-таблицы**
    {
        Console.Write("Индекс: " + i + "\tКлюч(-и): " + hash[i]);
        if (lists[i].empty == false) //Если связанный список в этой ячейке пуст
        {
            lists[i].Show();
        }
        Console.WriteLine();
    }//**Цикл вывода хэш-таблицы

    static int hash_function(int k, int m) //Функция вычисления хэш-функции**
    {
        double A = ((Math.Sqrt(5) - 1) / 2);
        int hash = (int)(m * (k * A % 1));
        return hash;
    } //**Функция вычисления хэш-функции
}
class One_linked_list //Класс связанного списка
{
    LinkedList<int> link = new LinkedList<int>(); //Создаем связанный список 
    public bool empty = true; //Индикатор пустотности или заполненности списка
    public void Add_elements(int k) //Функция добавления элемента
    {
        link.AddLast(k);
        empty = false;
    }

    public void Show() //Функция вывода списка
    {
        foreach (int value_list in link)
        {
            Console.Write("\t -> \t" + value_list);
        }
    }

}
