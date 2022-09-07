// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//implement functions dedicated to determine input type, and spit out error if input type is wrong for the given context
LinkedList<item> itemList = Initialization();
mainMenu(itemList);
SaveFunction(itemList);
//FUTURE CHANGE Change order things are input to Name Description Price Serial Number
//NEED to eventually make the program account for the wrong input

//this is a function that will sort the list of items by the price of the item
//recursive?! BINARY SORT
// it cannot be recursive if it takes in a linked list as an input
//to be recursive it would have to take an item pointer as input
LinkedListNode<item> GetMiddleNode(LinkedList<item> list)
{
    LinkedListNode<item> middleNode = list.First;
    int moves = list.Count / 2;
    for (int i = 0; i < moves; i++)
    {
        middleNode = middleNode.Next;
    }
    return middleNode;
}
/*LinkedList<item> SortListRecursive(LinkedListNode<item> mover,LinkedList<item> theList)
{
    // it will sort by price for now
    if(mover == null)
    {
        return theList;
    }
    else
    {
        if (mover.Value.price >= mover.Next.Value.price)
        {
            //when the next value is smaller or equal
            return SortListRecursive(mover.Next, theList);
        }
        else
        {
            //when the next value is bigger
            return SortListRecursive(mover.Next, theList);
        }
    }
}*/
void SaveFunction(LinkedList<item> itemList)
{
    //this function will take the linked list with all of the items, and save it to the input files
}
// this function will read the save file of all the information
//it is okay to assume the file is already sorted so no need for that
//parse through text file and put it in the linked list
LinkedList<item> Initialization()
{
    LinkedList<item> list = new LinkedList<item>();
    string filePath = "C:\\Users\\Ghost1086\\source\\repos\\ConsoleApp1\\ConsoleApp1\\SavedData.txt";
    //C:\Users\Ghost1086\source\repos\ConsoleApp1\ConsoleApp1\SavedData.txt

    if (System.IO.File.Exists(filePath))
    {
        //if the file exists
        System.IO.StreamReader lineReader;
        lineReader = new System.IO.StreamReader(filePath);
        string input;
        while((input = lineReader.ReadLine()) != null)
        {
            string[] parsedLine = input.Split("|", 4);
            item i1 = new item();
            i1.name = parsedLine[0];
            i1.description = parsedLine[1];
            i1.price = Convert.ToDouble(parsedLine[2]);
            i1.upc = Convert.ToInt32((parsedLine[3]));
            list.AddLast(i1);
        }
        lineReader.Dispose();
    }
    else
    {
        Console.WriteLine("No saved file available, creating a new save file");
        //if the file does not exist
        //still need to find out how to create a file
        
    }
    return list;
}
static item createItem()
    {
    item i1 = new item();
    string input;
    Console.Write("\nCreate new item\nPlease enter item Name: ");
    i1.name = Console.ReadLine();
    Console.Write("\nPlease enter item description: ");
    i1.description = Console.ReadLine();
    Console.Write("\nPlease enter item price: ");
    while (true)
    {
        input = Console.ReadLine();
        if(double.TryParse(input, out _))
        {
            i1.price = Convert.ToDouble(input);
            break;
        }
        else
        {
            Console.Write("\nInvalid input, please try again: ");
        }
    }
    Console.Write("\nPlease enter item UPC: ");
    while (true)
    {
        input = Console.ReadLine();
        if (Int32.TryParse(input, out _))
        {
            i1.upc = Convert.ToInt32(input);
            break;
        }
        else
        {
            Console.Write("\nInvalid input, please try again: ");
        }
    }
    return i1;
    /*
        Console.Write("Create new item\nPlease enter UPC: ");
        item i1 = new item();
        i1.upc = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nPlease enter price: ");
        i1.price = Convert.ToDouble(Console.ReadLine());
        Console.Write("\nPlease enter Name: " );
        i1.name = Console.ReadLine();
        Console.Write("\nPlease enter description: ");
        i1.description = Console.ReadLine();
        return i1;
    */
}
    void findItemUPC(LinkedList<item> itemlist)
    {
        Console.Write("\nPlease enter the UPC of the item: ");
        string input;
        while (true)
        {
            input=Console.ReadLine();
            if(Int32.TryParse(input, out _))
            {
            int inputUPC = Convert.ToInt32(input);
            LinkedListNode<item> search = itemlist.First;
            while (search != null)
            {
                if (search.Value.upc == inputUPC )
                {
                    printItem(search.Value);
                    break;
                }
                else
                {
                    search = search.Next;
                }
            }
                if (search == null)
                {
                    Console.Write("\nItem not found :(\n");
                }
            break;
        }
            else
            {
                Console.Write("\nInvalid UPC, please try again: ");
            }
        }
    }
    void findItemName(LinkedList<item> itemList) //Work in progress, search through the linked list to find a specific item by name.
    {
    Console.Write("\nPlease enter the name of the item: ");
    string Name = Console.ReadLine();
    LinkedListNode<item> search = itemList.First;
    while (search != null)
    {
        if(search.Value.name == Name)
        {
            printItem(search.Value);
            break;
        }
        else
        {
            search = search.Next;
        }
    }
    if(search == null)
    {
        Console.Write("\nItem not found :(\n");
    }
        /*        
        LinkedListNode<item> search = itemList.First;
        while (search != null)
        {
            if (search.Value.name == name)
                return search;

            search = search.Next;
        }
        //currently will return incorectly if something is not in the list the last item in the list*FIXED*
        return null;
           */
    }
    void printItem(item i1)
    {
        Console.WriteLine("\nItem: "+i1.name+"\nDescription: "+i1.description+"\nPrice: $"+i1.price+"\nUPC: "+i1.upc);
    }
void printMainMenu()
{
    Console.Write("\nWelcome to the inventory Main menu! (Version 1.0) Please make a Selection!\n------------------------------------------------\n\n-1: Terminate program\n\n0: Add item to inventory\n\n1: Search item in inventory by Name\n\n2: Search item in inventory by UPC\n\n");
}
    void mainMenu(LinkedList<item> itemList)
    {
    printMainMenu();
    string usr = Console.ReadLine();
    int input;
    if (double.TryParse(usr, out _))
    {
        input = Convert.ToInt32(usr);
    }
    else
    {
        input = 100;
    }
    switch (input)
        {
            case -1: //end inventory program

            break;
            case 0: // add item to inventory
                itemList.AddLast(createItem());
                mainMenu(itemList);
            break;
            case 1: //find and print item based on name
                findItemName(itemList);
                mainMenu(itemList);
                /*Console.WriteLine("\nEnter name of the item: ");
                string userInput = Console.ReadLine();
                LinkedListNode<item> test = findItemName(userInput, itemList);
            if (test != null){
                printItem(test.Value);
                mainMenu(itemList);
            }
            else {
                Console.WriteLine("\nCould not find item\n");
                mainMenu(itemList);
            }*/
            break;
            case 2://find and print item based on UPC
            findItemUPC(itemList);
            mainMenu(itemList);
            break;
        default:
            Console.Write("\nInvalid input please try again: \n");
            mainMenu(itemList);
            break;

        }
    }

public struct item{
    public int upc;
    public double price;
    public string name;
    public string description;
}