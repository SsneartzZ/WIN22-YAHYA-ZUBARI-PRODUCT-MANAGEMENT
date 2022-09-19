using System;
using System.Collections.Generic;
namespace WIN22YahyaZubariProductManager

{

    public class Program
{
       
    public static Dictionary<string, Article> Articles = new Dictionary<string, Article>();

    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine("1: Add Product");
        Console.WriteLine("2: Search Product");
        Console.WriteLine("3: Exit");

        int inputValue; // Create input reader

        if (int.TryParse(Console.ReadLine(), out inputValue)) // If true (it works) we enter Switch
        {
            switch (inputValue)
            {
                case 1:
                    AddProductMenu();
                    break;
                case 2:
                    SearchProductMenu();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    WrongInputHandler();
                    break;
            }
        }
        else
        {
            WrongInputHandler();
        }


    }

    static void WrongInputHandler()
    {
        Console.Clear();
        Console.WriteLine("Wrong input, try again!");
        Console.WriteLine();
        Menu();
    }

    static void SearchProductMenu()
    {
        Console.Clear();
        Console.WriteLine("Search for a Product:");
        string search = Console.ReadLine();
        Article article = Articles[search];

        PrintProduct(article);

        Console.WriteLine("Press Any Key to return to Menu");
        Console.ReadKey();
        Console.Clear();
        Menu();

    }

    static void AddProductMenu()
    {
        Console.Clear();
        Console.WriteLine("Add a Product:");

        PrintProduct();

        Console.SetCursorPosition(9, 1);
        string article = Console.ReadLine();
        Console.SetCursorPosition(6, 2);
        string name = Console.ReadLine();
        Console.SetCursorPosition(13, 3);
        string description = Console.ReadLine();
        Console.SetCursorPosition(12, 4);
        string imageurl = Console.ReadLine();
        Console.SetCursorPosition(7, 5);
        int price;
        int.TryParse(Console.ReadLine(), out price);


        if (!Articles.ContainsKey(article))
        {
            Articles.Add(article, new Article()
            {
                ArticleNumber = article,
                Name = name,
                Description = description,
                ImageURL = imageurl,
                Price = price
            });
        }

        Console.Clear();
        Menu();


    }

    static void PrintProduct(Article articleToPrint)
    {
        Console.Write($"Article: {articleToPrint.ArticleNumber}\n");
        Console.Write($"Name: {articleToPrint.Name}\n");
        Console.Write($"Description: {articleToPrint.Description}\n");
        Console.Write($"Image URL: {articleToPrint.ImageURL}\n");
        Console.Write($"Price: {articleToPrint.Price}\n");
    }

    static void PrintProduct()
    {
        Console.Write("Article:\n");
        Console.Write("Name:\n");
        Console.Write("Description:\n");
        Console.Write("Image URL:\n");
        Console.Write("Price:\n");
    }
}
}
