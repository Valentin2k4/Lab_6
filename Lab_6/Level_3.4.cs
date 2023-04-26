 namespace Lab6;

// Лыжные гонки проводятся отдельно для двух групп участников.
// Результаты соревнований заданы в виде фамилий участников и их результатов в каждой группе.
// Расположить результаты соревнований в каждой группе в порядке занятых мест.
// Объединить результаты обеих групп с сохранением упорядоченности и вывести в виде таблицы с заголовком.

public class Lebel_3_4
{
    public static void Main(string[] args)
    {
        List<Sportsmen> sportsmens_1 = new List<Sportsmen>();
        sportsmens_1.Add(new Sportsmen("Ann", 140));
        sportsmens_1.Add(new Sportsmen("Ben", 1000));
        sportsmens_1.Add(new Sportsmen("Tom", 320));

        sortSportsmens(sportsmens_1);

        List<Sportsmen> sportsmens_2 = new List<Sportsmen>();
        sportsmens_2.Add(new Sportsmen("Sara", 400));
        sportsmens_2.Add(new Sportsmen("Ivan", 200));
        sportsmens_2.Add(new Sportsmen("Josh", 130));

        sortSportsmens(sportsmens_2);

        Sportsmen.Print(sportsmens_1);
        Sportsmen.Print(sportsmens_2);

        var TotalResult = new List<Sportsmen>(CombiningTheResult(sportsmens_1, sportsmens_2));
        PrintParticipantTable(TotalResult);
        Console.ReadKey();
    }

    public struct Sportsmen
    {
        public string surName { get; set; }
        public int result { get; set; }
        public Sportsmen(string surName, int result)
        {
            this.surName = surName;
            this.result = result;
        }
        public static void Print(List<Sportsmen> sportsmens)
        {
            foreach (var sportsmen in sportsmens)
            {
                Console.WriteLine($"{sportsmen.surName}\tResult: {sportsmen.result}");
            }
            Console.WriteLine();
        }
    }

    public static List<Sportsmen> CombiningTheResult(List<Sportsmen> group_1, List<Sportsmen> group_2)
    {
        List<Sportsmen> allsportsmens = new List<Sportsmen>();
        while (group_1.Count > 0 || group_2.Count > 0)
        {
            if (group_1.Count == 0)
            {
                allsportsmens.Add(group_2[0]);
                group_2.RemoveAt(0);
            }
            else if (group_2.Count == 0)
            {
                allsportsmens.Add(group_1[0]);
                group_1.RemoveAt(0);
            }
            else if (group_1[0].result > group_2[0].result)
            {
                allsportsmens.Add(group_1[0]);
                group_1.RemoveAt(0);
            }
            else
            {
                allsportsmens.Add(group_2[0]);
                group_2.RemoveAt(0);
            }
        }
        return allsportsmens;
    }

    public static List<Sportsmen> sortSportsmens(List<Sportsmen> sportsmens)
    {
        for (int i = 0; i < sportsmens.Count; i++)
        {
            for (int j = i + 1; j < sportsmens.Count; j++)
            {
                if (sportsmens[i].result < sportsmens[j].result)
                {
                    (sportsmens[i], sportsmens[j]) = (sportsmens[j], sportsmens[i]);
                }
            }
        }
        return sportsmens;
    }

    public static void PrintParticipantTable(List<Sportsmen> group)
    {
        foreach (var participant in group)
        {
            Console.WriteLine($"{participant.surName}\tResult: {participant.result}");
        }

    }
}






