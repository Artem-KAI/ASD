package lvl2;
//                       Варіант 5:
//         cтруктура даних: Двоспрямований список
//   тип елементів: Строковий (представляє цілі числа)
// 


// Опис структури даних зі зв’язним способом розміщення
class Node 
{
    String value; 
    Node next;
    Node prev;

    Node(String value) 
    {
        this.value = value;
        this.next = null;
        this.prev = null;
    }
}