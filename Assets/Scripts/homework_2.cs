using System;
using System.Linq.Expressions;
using UnityEngine;
using static UnityEditor.Progress;


public class MyList
{
    private int[] m_array = new int[4];
    public int num=0;
    public int power_array = 0;

    public int Count { get => num; private set { Count = num; } }
    public int Capacity
    {
        get
        {
            int n = 2; // число возводимое в степень
            int power = 0; //степень
            while(m_array.Length > Math.Pow(n, power))
            {
                power++;
            }
            return power;
        }
        set
        {
            power_array = value;
        }
    }
    public MyList()
    {

    }

    public MyList(int capacity)
    {
        Capacity = capacity;
        Debug.Log("Capacity is: " + Math.Pow(2, Capacity));
    }

    public int this[int index]
    {
        get
        {
            return m_array[index];
        }
        set
        {
            m_array[index] = value;
        }
    }

    public void Add(int item)
    {
        if(num < 4)
        {
            m_array[num] = item;
            num++;
        }
    }

    public void Insert(int index, int item)
    {
        m_array[index] = item;
    }

    public int IndexOf(int item)
    {
        return -1;
    }

    public bool Remove(int item)
    {
        int current, next;
        for (int i = 0; i < m_array.Length; i++) 
        {
            if (i+1 < m_array.Length && m_array[i] == item)
            {
                current = m_array[i];
                next = m_array[i + 1];
                m_array[i] = next;
                m_array[i + 1] = current;
                break;
            }   
        }
        int[] newArray = new int[3];

        for (int i = 0; i < m_array.Length && i < newArray.Length; i++)
        {
            newArray[i] = m_array[i];
        }
        m_array = newArray;
        num--;
        return true;
    }
    public void RemoveAt(int index)
    {
        int current, next;
        for (int i = 0; i < m_array.Length; i++)
        {
            if (i + 1 < m_array.Length && i == index)
            {
                current = m_array[i];
                next = m_array[i + 1];
                m_array[i] = next;
                m_array[i + 1] = current;
                break;
            }
        }
        int[] newArray = new int[3];

        for (int i = 0; i < m_array.Length && i < newArray.Length; i++)
        {
            newArray[i] = m_array[i];
        }
        m_array = newArray;
        num--;
    }

    public bool Contains(int item)
    {
        bool check = false;
        for (int i = 0; i < m_array.Length; i++)
        {
            if (m_array[i] == item)
            {
                 check = true;
                break;
            }
        }
        return check;
    }

    public void Clear()
    {
        for (int i = 0; i < m_array.Length; i++)
        {
            m_array[i] = 0;
        }
    }
}


public class homework_2 : MonoBehaviour
{
    public void Start()
    {
        MyList myList = new MyList();

        // Добавление чисел в массив
        myList.Add(1);
        myList.Add(5);
        myList.Add(9);
        myList.Add(7);
        myList.Insert(1, 3);
        Debug.Log("| Finish adding numbers to the array |");
        for (int i = 0; i < myList.Count; ++i)
        {
            Debug.Log(myList[i]);
        }

        // Проверка, сколько ячеек занимает массив.
        myList.Capacity = 4;
        Debug.Log("| Capacity is |" + myList.power_array);

        // 1. Поиск числа в массиве. 2. Удаление числа из массива
        if (myList.Contains(3) == true)
        {
            Debug.Log("| The number 3 was found |");
            myList.Remove(3);
        }
        else 
        {
            Debug.Log("| The number 3 was not found |");
        }
        Debug.Log("| Completing first method Remove |");
        for (int i = 0; i < myList.Count; ++i)
        {
            Debug.Log(myList[i]);
        }

        //Удаление элемента по индексу
        myList.RemoveAt(0);
        Debug.Log("| Completing second method RemoveAT |");
        for (int i = 0; i < myList.Count; ++i)
        {
            Debug.Log(myList[i]);
        }

        // Очистка
        myList.Clear();
        Debug.Log("| Cleaning process |");
        for (int i = 0; i < myList.Count; ++i)
        {
            Debug.Log(myList[i]);
        }
        myList.Capacity = 4;
        Debug.Log("| Capacity is |" + myList.power_array);
    }
}
