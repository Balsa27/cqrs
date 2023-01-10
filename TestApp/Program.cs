// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using OAuth._Test;

var creditCard = CreditCard.FromValue(1);

Console.WriteLine($"Credit card: {creditCard}, discount {creditCard.Discount:P}");

Console.ReadKey();