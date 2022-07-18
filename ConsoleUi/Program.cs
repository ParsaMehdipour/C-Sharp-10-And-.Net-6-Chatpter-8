using System.Numerics;
using System.Text.RegularExpressions;
using static System.Console;

#region Working with big numbers

WriteLine("-----------------------------------");
WriteLine("****Working with big numbers:");
ulong big = ulong.MaxValue;
WriteLine($"{big,40:N0}");
BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,40:N0}");

WriteLine("-----------------------------------");
WriteLine("****Working with complex numbers:");
Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 3, imaginary: 7);
Complex c3 = c1 + c2;
// output using default ToString implementation
WriteLine($"{c1} added to {c2} is {c3}");
// output using custom format
WriteLine("{0} + {1}i added to {2} + {3}i is {4} + {5}i",
    c1.Real, c1.Imaginary,
    c2.Real, c2.Imaginary,
    c3.Real, c3.Imaginary);

#endregion

#region Working with text

WriteLine("-----------------------------------");
WriteLine("****Working with text:");
string city = "London";
WriteLine($"{city} is {city.Length} characters long.");


string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellín";
string[] citiesArray = cities.Split(',');
WriteLine($"There are {citiesArray.Length} items in the array.");
foreach (string item in citiesArray)
{
    WriteLine(item);
}

WriteLine("----------Getting part of a string----------");
string fullName = "Alan Jones";
int indexOfTheSpace = fullName.IndexOf(' ');
string firstName = fullName.Substring(
    startIndex: 0, length: indexOfTheSpace);
string lastName = fullName.Substring(
    startIndex: indexOfTheSpace + 1);
WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");


string givenName = "Jones, Alan";
string last = givenName.Substring(startIndex: 0, length: 5);
string first = givenName.Substring(startIndex: 7) + " ";
WriteLine(first + last);

WriteLine("----------Checking a string for content----------");
string company = "Microsoft";
bool startsWithM = company.StartsWith("M");
bool containsN = company.Contains("N");
WriteLine($"Text: {company}");
WriteLine($"Starts with M: {startsWithM}, contains an N: {containsN}");


WriteLine("----------Joining, formatting, and other string members----------");
string recombined = string.Join(" => ", citiesArray);
WriteLine(recombined);

string fruit = "Apples";
decimal price = 0.39M;
DateTime when = DateTime.Today;
WriteLine($"Interpolated: {fruit} cost {price:C} on {when:dddd}.");
WriteLine(string.Format("string.Format: {0} cost {1:C} on {2:dddd}.",
    arg0: fruit, arg1: price, arg2: when));
WriteLine("WriteLine: {0} cost {1:C} on {2:dddd}.",
    arg0: fruit, arg1: price, arg2: when);


#endregion

#region Working with only a date or a time

WriteLine("-----------------------------------");
WriteLine("****Working with only a date or a time:");
DateOnly queensBirthday = new(year: 2022, month: 4, day: 21);
WriteLine($"The Queen's next birthday is on {queensBirthday}.");
TimeOnly partyStarts = new(hour: 20, minute: 30);
WriteLine($"The Queen's party starts at {partyStarts}.");
DateTime calendarEntry = queensBirthday.ToDateTime(partyStarts);
WriteLine($"Add to your calendar: {calendarEntry}.");

DateOnly dateOnly = new(year: 2000, month: 4, day: 23);
TimeOnly timeOnly = new(hour: 20, minute: 30);

DateTime dateTime = dateOnly.ToDateTime(timeOnly);
WriteLine(dateTime);

#endregion

#region Pattern matching with regular expressions

WriteLine("-----------------------------------");
WriteLine("****Pattern matching with regular expressions:");
//Write("Enter your age: ");
//string? input = ReadLine();
//Regex ageChecker = new(@"^\d+$");

//if (ageChecker.IsMatch(input))
//{
//    WriteLine("Thank you!");
//}
//else
//{
//    WriteLine($"This is not a valid age: {input}");
//}

string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";
WriteLine($"Films to split: {films}");
string[] filmsDumb = films.Split(',');
WriteLine("Splitting with string.Split method:");

foreach (string film in filmsDumb)
{
    WriteLine(film);
}

Regex csv = new("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
MatchCollection filmsSmart = csv.Matches(films);
WriteLine("Splitting with regular expression:");
foreach (Match film in filmsSmart)
{
    WriteLine(film.Groups[2].Value);
}
#endregion
