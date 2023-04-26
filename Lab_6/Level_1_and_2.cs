namespace Lab6;

class Level_1_and_2
{
     /*  //1.1
     // Результаты соревнований по прыжкам в длину определяются по сумме двух попыток.
     // В протоколе для каждого участника указывают- ся: фамилия, результаты первой и второй попыток.
     // Вывести протокол в виде таблицы с заголовком в порядке занятых мест.
     
     
    struct Sportsmen {
        public string surName { get; set; }
        public int[] scores { get; set; }
        public int totalScore {get; set;}
        public Sportsmen(string surName, int[] scores) 
        {
            this.surName = surName;
            this.scores = scores;
            for (int i = 0; i < scores.Length; i++) totalScore += scores[i];
        }
        public void Print() 
        {
                Console.WriteLine($"{surName} {totalScore}");
        }
    }

    static void Main(string[] args)
    {
        // объявления элементов(спортсменов)  
        Sportsmen[] sportsmens = new Sportsmen[5];
        sportsmens[0] = new Sportsmen("Tom", new int[] {25, 25});
        sportsmens[1] = new Sportsmen("Bob", new int[] { 426, 125});
        sportsmens[2] = new Sportsmen("Sos", new int[] { 125, 136});
        sportsmens[3] = new Sportsmen("Aoa", new int[] { 235, 235});
        sportsmens[4] = new Sportsmen("Mom", new int[] { 205, 25});
        
        //сортировка массива структур 
        for (int i = 0; i < sportsmens.Length; i++) {
            for (int j = i + 1; j < sportsmens.Length; j++) {
                if (sportsmens[i].totalScore < sportsmens[j].totalScore) {
                    (sportsmens[i], sportsmens[j]) = (sportsmens[j], sportsmens[i]);
                }
            }
        }
        
        foreach (var sortedSportsmen in sportsmens) {
            sortedSportsmen.Print();
        }
        Console.ReadKey();
    }
    */

     /* //1.2
     //Составить программу для обработки результатов кросса на 500 м для женщин.
     //Для каждой участницы ввести фамилию и результат. Получить результирующую таблицу, упорядоченную по результатам,
     //в которой содержится также информация о выполнении норматива. Определить суммарное количество участниц, выполнивших норматив.
     
     
    struct Women {
        public string surName { get; set; }
        public double score { get; set; }
        public string norm { get; set; }
        public Women(string surName, double score) {
            this.surName = surName;
            this.score = score;
            if (score > 120) norm = "No";
            else norm = "Yes";
        }
        public void Print() {
            Console.WriteLine($"{surName} {score} {norm}");
        }
    }

    static void Main(string[] args) {
        Women[] womens = new Women[5];
        womens[0] = new Women("Samanta", 145);
        womens[1] = new Women("Sam", 105);
        womens[2] = new Women("An", 95);
        womens[3] = new Women("Ann", 100);
        womens[4] = new Women("Mari", 205);

        int count = 0;
        for (int i = 0; i < womens.Length; i++) {
            if (womens[i].score <= 120) count++;
        }


        for (int i = 0; i < womens.Length; i++)
        {
            for (int j = i + 1; j < womens.Length; j++)
            {
                if (womens[i].score < womens[j].score)
                {
                    (womens[i], womens[j]) = (womens[j], womens[i]);
                }
            }
        }

        foreach (var sortedWomen in womens) {
            sortedWomen.Print();
        }
        Console.WriteLine($"Выполнили норматив: {count}");
        Console.ReadKey();
    }
    */

     /*  //2.3
     //На основании результатов соревнований по прыжкам в длину (фамилии и результаты трех попыток)
     //составить итоговый протокол соревнований, считая, что в зачет идет лучший результат.
     
     
    struct Sportsmen {
        public string surName { get; set; }
        public int[] results { get; set; }
        public int bestResult { get; set; }
        public Sportsmen(string surName, int[] results) {
            this.surName = surName;
            this.results = results;
            int max = results[0];
            for (int i = 0; i < results.Length; i++) {
                if (results[i] > max) max = results[i];
                bestResult = max;
            }
        }
        public void Print() {
            Console.WriteLine($"{surName} {bestResult}");
        }
    }

    static void Main(string[] args) {
        Sportsmen[] sportsmens = new Sportsmen[5];
        sportsmens[0] = new Sportsmen("Tom", new int[] { 100, 103, 102 });
        sportsmens[1] = new Sportsmen("Bob", new int[] { 200, 203, 210 });
        sportsmens[2] = new Sportsmen("Mom", new int[] { 180, 103, 154 });
        sportsmens[3] = new Sportsmen("Sos", new int[] { 200, 203, 202 });
        sportsmens[4] = new Sportsmen("Loh", new int[] { 280, 260, 285 });

        for (int i = 0; i < sportsmens.Length; i++)
        {
            for (int j = i + 1; j < sportsmens.Length; j++)
            {
                if (sportsmens[i].bestResult < sportsmens[j].bestResult)
                {
                    (sportsmens[i], sportsmens[j]) = (sportsmens[j], sportsmens[i]);
                }
            }
        }
        
        foreach (Sportsmen s in sportsmens) {
            s.Print();
        }
        
        Console.ReadKey();
    }
   */
    
    /*  //2.4
     //Соревнования по прыжкам в воду оценивают 7 судей.
     //Каждый спортсмен выполняет 4 прыжка. Каждый прыжок имеет одну из шести категорий сложности, оцениваемую коэффициентом (от 2,5 до 3,5).
     //Качество прыжка оценивается судьями по 6-балльной шкале. Далее лучшая и худшая оценки отбрасываются, остальные складываются,
     //и сумма умножается на коэффициент сложности. Получить итоговую таблицу, содержащую фамилии спортсменов, и итоговую оценку в порядке занятых мест.
     
     
    struct Sportsmen {
        public string surName { get; set; }
        public int[] Scores { get; set; }
        public double totalScore { get; set; }
        public double rate;
        public Sportsmen(string surName, int[] Scores, double rate){
            this.surName = surName;
            this.Scores = Scores;
            this.rate = rate;
                for (int i = 0; i < Scores.Length; i++) {
                    for (int j = i + 1; j < Scores.Length; j++) {
                        if (Scores[i] < Scores[j]) (Scores[i], Scores[j]) = (Scores[j], Scores[i]);
                    }
                }
            for (int i = 1; i < Scores.Length - 1; i++) {
                totalScore += Scores[i];
            }
            totalScore *= rate;
        }

        public void Print() {
            Console.WriteLine($"{surName} {totalScore}");
        }

    }

    static void Main(string[] args)
    {
        Sportsmen[] sportsmens = new Sportsmen[4];
        sportsmens[0] = new Sportsmen("Sam", new int[] { 4, 4, 5, 6, 3, 5, 2}, 2.7);
        sportsmens[1] = new Sportsmen("Chick", new int[] { 4, 4, 4, 5, 3, 5, 2 }, 2.8);
        sportsmens[2] = new Sportsmen("Tom", new int[] { 3, 3, 5, 6, 3, 5, 2 }, 3);
        sportsmens[3] = new Sportsmen("Eva", new int[] { 5, 5, 5, 6, 5, 5, 3 }, 3.2);

        for (int i = 0; i < sportsmens.Length; i++)
        {
            for (int j = i + 1; j < sportsmens.Length; j++)
            {
                if (sportsmens[i].totalScore < sportsmens[j].totalScore)
                {
                    (sportsmens[i], sportsmens[j]) = (sportsmens[j], sportsmens[i]);
                }
            }
        }

        foreach (var s in sportsmens)  s.Print();
        
        Console.ReadKey();
    }
    */
}
