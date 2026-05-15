package lvl1;
//                Варіант 5:
//         cтруктура даних: список
//       тип елементів: цілі числа
//   розміщення в пам’яті: векторне (масив)
//



public class List {
    private int[] data;
    private int size;

    public List(int length) 
    {
        this.data = new int[length];
        this.size = 0;
    }

 
    public void add(int value) 
    {
        if (size < data.length) 
        {
            data[size++] = value;
        } 
        else 
        {
            System.out.println("Error: List is full");
        }
    }

    public void remove(int index) 
    {
        if (index < 0 || index >= size) 
        {
            System.out.println("Error: incorrect index");
            return;
        }
        
        for (int i = index; i < size - 1; i++) 
        {
            data[i] = data[i + 1];
        }

        size--;
    }

    public void display() 
    {
        if (size == 0) 
        {
            System.out.println("List is empty");
            return;
        }

        for (int i = 0; i < size; i++)
        {
            System.out.print(data[i] + " ");
        }
        
    }
}