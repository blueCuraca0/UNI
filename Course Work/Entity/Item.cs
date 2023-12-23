using System;

public class Item
{

    private static int numItems = 0;

    public int ID;

    private string name;
    public string Name
    { 
        get { return name; } 
        set 
        {
            if (value != null && value != "") name = value;
            else
            {
                name = "[non-existing name]";
                Console.WriteLine("Помилка: Назва товару не може бути порожньою.");
            }
        }
    }

    private int price;
    public int Price
    {
        get { return price; }
        set
        {
            if (value > 0) price = value;
            else
            {
                price = -1;
                Console.WriteLine("Помилка: Ціна не може бути не додатньою.");
            }
        }
    }

    private int quantity;
    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (quantity >= 0) quantity = value;
            else
            {
                quantity = -1;
                Console.WriteLine("Помилка: Кількість товарів не може бути менше 0.");
            }
        }
    }

    public Item(string itemName, int price, int quantity)
    {
        Name = itemName;
        Price = price;
        Quantity = quantity;
        ID = numItems;
        numItems++;
    }

}