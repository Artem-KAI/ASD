package lvl1;
//                Варіант 5:
//         cтруктура даних: список
//       тип елементів: цілі числа
//   розміщення в пам’яті: векторне (масив)
//



public class Main {
    public static void main(String[] args) {
        // Створення екземпляра структури 
        List myList = new List(10);
 
        System.out.println("Inserting elements: 3, 7, 12, 5, 9");
        myList.add(3);
        myList.add(7);
        myList.add(12);
        myList.add(5);
        myList.add(9);

        System.out.print("All list: ");
        myList.display();
 
        System.out.println("\nDelete 2nd and 3rd elements");
        myList.remove(1);  
        myList.remove(1);  

        System.out.print("Instead of after deleting: ");
        myList.display();
    }
}