package lvl2;
//                       Варіант 5:
//         cтруктура даних: Двоспрямований список
//   тип елементів: Строковий (представляє цілі числа)
// 



public class Main 
{
    public static void main(String[] args) 
    {
        DoublyList list = new DoublyList();

        list.add("10");
        list.add("7");
        list.add("1");
        list.add("5");
        list.add("8");

        System.out.println("Contents of a doubly linked list: ");
        list.display();

        System.out.println("\nDelete 2nd and 3rd elements");
        list.removeByIndex(1);  
        list.removeByIndex(1);  

        System.out.println("Instead of after deleting: ");
        list.display();
    }
}
