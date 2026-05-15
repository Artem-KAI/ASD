package lvl2;
//                       Варіант 5:
//         cтруктура даних: Двоспрямований список
//   тип елементів: Строковий (представляє цілі числа)
// 



public class DoublyList 
{
    private Node head;
    private Node tail;

    public DoublyList()
    {
        this.head = null;
        this.tail = null;
    }

    public void add(String value) 
    {
        Node newNode = new Node(value);

        if (head == null) 
        {
            head = newNode;
            tail = newNode;
        } 
        else 
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }
    }

    public void removeByIndex(int index) 
    {
        if (head == null) 
        {
            return;
        }

        Node current = head;
        for (int i = 0; current != null && i < index; i++) 
        {
            current = current.next;
        }

        if (current == null) 
        { 
            return;  
        }

        // обробка лівого вузла 
        if (current.prev != null) 
        {
            current.prev.next = current.next;
        } 
        else 
        {
            head = current.next; // якщо зліва нікого нема то видаляємо голову 
        }
        // обробка правого вузла 
        if (current.next != null) {
            current.next.prev = current.prev;
        } 
        else {
            tail = current.prev; // якщо справа нікого нема то видаляємо хвіст
        }
    }


    public void display() 
    {
        Node current = head;
        while (current != null) 
            {
            System.out.print(current.value + " ");
            current = current.next;
        }
    }
}
