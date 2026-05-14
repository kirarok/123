namespace BoilerCalc
{
    /// <summary>
    /// Класс, представляющий характеристику твердого топлива (угля)
    /// </summary>
    public class Coal
    {
        public int Id { get; set; }                      // № п/п
        public string Basin { get; set; }                // Бассейн (месторождение)
        public string Mark { get; set; }                 // Марка угля
        public double Wp { get; set; }                   // Рабочая влага W⁠P, %
        public double Ap { get; set; }                   // Зольность A⁠P, %
        public double SpKolk { get; set; }               // Сера колчеданная S⁠Pколч, %
        public double SpOrg { get; set; }                // Сера органическая S⁠Pорг, %
        public double Cp { get; set; }                   // Углерод C⁠P, %
        public double Hp { get; set; }                   // Водород H⁠P, %
        public double Np { get; set; }                   // Азот N⁠P, %
        public double Op { get; set; }                   // Кислород O⁠P, %
        public double Qpn { get; set; }                  // Низшая теплота сгорания Q⁠Pн, МДж/кг
        public double Vr { get; set; }                   // Выход летучих V⁠r, %
        public double Klo { get; set; }                  // Коэффициент шлакования Kло

        /// <summary>
        /// Полная сера в топливе (S⁠Pколч + S⁠Pорг)
        /// </summary>
        public double SpTotal => SpKolk + SpOrg;

        /// <summary>
        /// Низшая теплота сгорания в кДж/кг
        /// </summary>
        public double QpnKj => Qpn * 1000;

        /// <summary>
        /// Низшая теплота сгорания в ккал/кг
        /// </summary>
        public double QpnKcal => Qpn * 238.846;

        public override string ToString()
        {
            return $"{Basin} ({Mark})";
        }
    }

    /// <summary>
    /// База данных характеристик твердых топлив
    /// На основе таблицы "ФИЗИКО-ХИМИЧЕСКИЕ ХАРАКТЕРИСТИКИ ТВЕРДЫХ ТОПЛИВ"
    /// </summary>
    public static class CoalDatabase
    {
        public static List<Coal> Coals { get; } = new List<Coal>
        {
            new Coal { Id = 1, Basin = "Донецкий", Mark = "Д", Wp = 13.0, Ap = 27.8, SpKolk = 1.7, SpOrg = 1.2, Cp = 44.1, Hp = 3.3, Np = 0.9, Op = 8.0, Qpn = 17.25, Vr = 43.0, Klo = 1.28 },
            new Coal { Id = 2, Basin = "Донецкий", Mark = "Г", Wp = 10.0, Ap = 28.8, SpKolk = 2.0, SpOrg = 1.0, Cp = 48.3, Hp = 3.4, Np = 0.9, Op = 5.6, Qpn = 18.92, Vr = 40.0, Klo = 1.25 },
            new Coal { Id = 3, Basin = "Донецкий", Mark = "Ж", Wp = 6.0, Ap = 30.1, SpKolk = 1.8, SpOrg = 0.7, Cp = 53.4, Hp = 3.3, Np = 1.0, Op = 3.7, Qpn = 21.14, Vr = 32.0, Klo = 1.5 },
            new Coal { Id = 4, Basin = "Кузнецкий", Mark = "Д", Wp = 11.5, Ap = 15.9, SpKolk = 0.0, SpOrg = 0.4, Cp = 56.4, Hp = 4.0, Np = 1.9, Op = 9.9, Qpn = 21.9, Vr = 40.5, Klo = 1.12 },
            new Coal { Id = 5, Basin = "Кузнецкий", Mark = "Г", Wp = 8.5, Ap = 16.9, SpKolk = 0.0, SpOrg = 0.4, Cp = 60.1, Hp = 4.2, Np = 2.0, Op = 7.9, Qpn = 23.57, Vr = 39.5, Klo = 1.3 },
            new Coal { Id = 6, Basin = "Кузнецкий", Mark = "2СС", Wp = 8.5, Ap = 16.5, SpKolk = 0.0, SpOrg = 0.4, Cp = 66.0, Hp = 3.5, Np = 1.6, Op = 3.5, Qpn = 25.33, Vr = 20.0, Klo = 1.5 },
            new Coal { Id = 7, Basin = "Карагандинский", Mark = "К", Wp = 9.0, Ap = 34.6, SpKolk = 0.0, SpOrg = 0.7, Cp = 46.8, Hp = 2.9, Np = 0.8, Op = 5.2, Qpn = 18.13, Vr = 28.0, Klo = 1.4 },
            new Coal { Id = 8, Basin = "Экибастузский", Mark = "СС", Wp = 6.5, Ap = 36.9, SpKolk = 0.4, SpOrg = 0.3, Cp = 44.8, Hp = 3.0, Np = 0.8, Op = 7.3, Qpn = 17.38, Vr = 25.0, Klo = 1.4 },
            new Coal { Id = 9, Basin = "Подмосковный", Mark = "2Б", Wp = 32.1, Ap = 30.6, SpKolk = 1.6, SpOrg = 0.9, Cp = 24.3, Hp = 0.9, Np = 0.4, Op = 8.2, Qpn = 8.67, Vr = 48.0, Klo = 1.7 },
            new Coal { Id = 10, Basin = "Печорский (Интинское м.)", Mark = "Д", Wp = 11.5, Ap = 28.8, SpKolk = 1.7, SpOrg = 0.8, Cp = 44.2, Hp = 2.9, Np = 1.5, Op = 8.6, Qpn = 16.87, Vr = 40.0, Klo = 1.15 },
            new Coal { Id = 11, Basin = "Печорский (Воркутинское м.)", Mark = "Ж", Wp = 8.0, Ap = 29.4, SpKolk = 0.6, SpOrg = 0.4, Cp = 52.6, Hp = 3.3, Np = 1.5, Op = 4.2, Qpn = 20.77, Vr = 33.0, Klo = 1.15 },
            new Coal { Id = 12, Basin = "Кизеловский", Mark = "Ж", Wp = 6.0, Ap = 32.0, SpKolk = 3.7, SpOrg = 1.6, Cp = 48.6, Hp = 3.5, Np = 0.6, Op = 4.0, Qpn = 19.68, Vr = 43.0, Klo = 1.0 },
            new Coal { Id = 13, Basin = "Кизеловский", Mark = "Г", Wp = 7.5, Ap = 37.9, SpKolk = 3.0, SpOrg = 1.3, Cp = 41.5, Hp = 3.2, Np = 0.5, Op = 5.1, Qpn = 16.71, Vr = 45.0, Klo = 1.0 },
            new Coal { Id = 14, Basin = "Челябинский", Mark = "3Б", Wp = 17.0, Ap = 35.7, SpKolk = 0.0, SpOrg = 0.8, Cp = 33.6, Hp = 2.5, Np = 0.9, Op = 9.5, Qpn = 12.56, Vr = 44.0, Klo = 1.32 },
            new Coal { Id = 15, Basin = "Ткибульское", Mark = "Д", Wp = 13.0, Ap = 34.8, SpKolk = 1.3, SpOrg = 0.7, Cp = 37.3, Hp = 3.1, Np = 0.5, Op = 9.3, Qpn = 14.70, Vr = 46.0, Klo = 1.1 },
            new Coal { Id = 16, Basin = "Ангренское", Mark = "2Б", Wp = 34.5, Ap = 14.4, SpKolk = 0.0, SpOrg = 1.3, Cp = 39.1, Hp = 1.9, Np = 0.2, Op = 8.6, Qpn = 13.44, Vr = 33.5, Klo = 2.1 },
            new Coal { Id = 17, Basin = "Ирша-Бородинское", Mark = "2Б", Wp = 33.0, Ap = 7.4, SpKolk = 0.0, SpOrg = 0.2, Cp = 42.6, Hp = 3.0, Np = 0.6, Op = 13.2, Qpn = 15.28, Vr = 47.0, Klo = 1.2 },
            new Coal { Id = 18, Basin = "Назаровское", Mark = "2Б", Wp = 39.0, Ap = 7.9, SpKolk = 0.0, SpOrg = 0.4, Cp = 37.2, Hp = 2.5, Np = 0.5, Op = 12.5, Qpn = 12.85, Vr = 47.0, Klo = 1.1 },
            new Coal { Id = 19, Basin = "Березовское", Mark = "2Б", Wp = 33.0, Ap = 4.7, SpKolk = 0.0, SpOrg = 0.2, Cp = 44.2, Hp = 3.1, Np = 0.4, Op = 14.4, Qpn = 15.66, Vr = 48.0, Klo = 1.3 },
            new Coal { Id = 20, Basin = "Боготольское", Mark = "1Б", Wp = 44.0, Ap = 6.7, SpKolk = 0.0, SpOrg = 0.5, Cp = 34.3, Hp = 2.4, Np = 0.3, Op = 11.8, Qpn = 11.81, Vr = 48.0, Klo = 1.4 },
            new Coal { Id = 21, Basin = "Переясловский", Mark = "3Б", Wp = 28.6, Ap = 5.1, SpKolk = 0.0, SpOrg = 0.2, Cp = 49.4, Hp = 3.4, Np = 0.7, Op = 12.6, Qpn = 18.44, Vr = 46.6, Klo = 1.1 },
            new Coal { Id = 22, Basin = "Ирбейский, пласт Спутник", Mark = "2Б", Wp = 35.0, Ap = 10.4, SpKolk = 0.0, SpOrg = 0.5, Cp = 37.5, Hp = 2.2, Np = 0.6, Op = 13.9, Qpn = 16.99, Vr = 45.8, Klo = 0.0 },
            new Coal { Id = 23, Basin = "Ирбейский, пласт Латынцевский", Mark = "2Б", Wp = 30.0, Ap = 14.0, SpKolk = 0.0, SpOrg = 0.5, Cp = 38.1, Hp = 2.3, Np = 0.7, Op = 14.3, Qpn = 16.68, Vr = 46.8, Klo = 0.0 },
            new Coal { Id = 24, Basin = "Черемховское", Mark = "Д", Wp = 15.0, Ap = 29.8, SpKolk = 0.0, SpOrg = 0.9, Cp = 42.5, Hp = 3.1, Np = 0.6, Op = 8.1, Qpn = 16.41, Vr = 47.0, Klo = 1.3 },
            new Coal { Id = 25, Basin = "Азейское (Азейский разрез)", Mark = "3Б", Wp = 25.8, Ap = 16.3, SpKolk = 0.0, SpOrg = 0.3, Cp = 42.7, Hp = 3.2, Np = 0.9, Op = 10.7, Qpn = 15.67, Vr = 46.5, Klo = 1.05 },
            new Coal { Id = 26, Basin = "Азейское (Тулунский разрез)", Mark = "3Б", Wp = 25.6, Ap = 18.6, SpKolk = 0.0, SpOrg = 0.4, Cp = 40.7, Hp = 3.1, Np = 0.7, Op = 10.9, Qpn = 15.00, Vr = 47.2, Klo = 0.94 },
            new Coal { Id = 27, Basin = "Мугунское", Mark = "3Б", Wp = 24.9, Ap = 16.5, SpKolk = 0.0, SpOrg = 0.3, Cp = 43.1, Hp = 3.5, Np = 0.9, Op = 10.8, Qpn = 16.09, Vr = 50.4, Klo = 0.9 },
            new Coal { Id = 28, Basin = "Жеронское", Mark = "Д", Wp = 17.7, Ap = 23.0, SpKolk = 0.0, SpOrg = 0.4, Cp = 45.1, Hp = 2.8, Np = 0.8, Op = 10.1, Qpn = 16.30, Vr = 38.5, Klo = 1.07 },
            new Coal { Id = 29, Basin = "Жеронское", Mark = "СС", Wp = 12.1, Ap = 24.6, SpKolk = 0.0, SpOrg = 0.4, Cp = 52.8, Hp = 3.0, Np = 1.1, Op = 6.0, Qpn = 19.99, Vr = 25.4, Klo = 1.3 },
            new Coal { Id = 30, Basin = "Головинское", Mark = "Д", Wp = 14.0, Ap = 19.7, SpKolk = 0.0, SpOrg = 1.2, Cp = 51.4, Hp = 3.9, Np = 0.9, Op = 8.9, Qpn = 19.69, Vr = 46.0, Klo = 0.0 },
            new Coal { Id = 31, Basin = "Холбольджинское (Гусиноозерское)", Mark = "3Б", Wp = 26.0, Ap = 18.5, SpKolk = 0.0, SpOrg = 0.4, Cp = 39.4, Hp = 2.8, Np = 0.6, Op = 12.3, Qpn = 14.32, Vr = 43.0, Klo = 0.9 },
            new Coal { Id = 32, Basin = "Татауровское", Mark = "2Б", Wp = 33.0, Ap = 10.7, SpKolk = 0.0, SpOrg = 0.2, Cp = 41.1, Hp = 2.8, Np = 0.7, Op = 11.5, Qpn = 14.69, Vr = 45.0, Klo = 1.15 },
            new Coal { Id = 33, Basin = "Харанорское", Mark = "1Б", Wp = 40.0, Ap = 13.2, SpKolk = 0.0, SpOrg = 0.3, Cp = 33.5, Hp = 2.2, Np = 0.5, Op = 10.3, Qpn = 11.39, Vr = 44.0, Klo = 1.15 },
            new Coal { Id = 34, Basin = "Тарбагатайское", Mark = "3Б", Wp = 31.5, Ap = 15.4, SpKolk = 0.0, SpOrg = 1.8, Cp = 41.1, Hp = 3.0, Np = 0.9, Op = 6.0, Qpn = 15.78, Vr = 45.0, Klo = 1.3 },
            new Coal { Id = 35, Basin = "Артемовское", Mark = "3Б", Wp = 23.0, Ap = 33.1, SpKolk = 0.0, SpOrg = 0.3, Cp = 29.4, Hp = 2.5, Np = 0.6, Op = 11.1, Qpn = 11.14, Vr = 50.0, Klo = 0.92 },
            new Coal { Id = 36, Basin = "Партизанский", Mark = "Г", Wp = 5.5, Ap = 34.0, SpKolk = 0.0, SpOrg = 0.4, Cp = 49.8, Hp = 3.2, Np = 0.8, Op = 6.3, Qpn = 19.47, Vr = 36.0, Klo = 0.0 },
            new Coal { Id = 37, Basin = "Партизанский", Mark = "Ж", Wp = 5.5, Ap = 32.1, SpKolk = 0.0, SpOrg = 0.4, Cp = 52.7, Hp = 3.2, Np = 0.7, Op = 5.4, Qpn = 20.52, Vr = 31.0, Klo = 0.0 },
            new Coal { Id = 38, Basin = "Партизанский", Mark = "Т", Wp = 5.0, Ap = 28.5, SpKolk = 0.0, SpOrg = 0.5, Cp = 58.8, Hp = 2.7, Np = 0.7, Op = 3.8, Qpn = 22.19, Vr = 12.0, Klo = 0.0 },
            new Coal { Id = 39, Basin = "Ургальское", Mark = "Г", Wp = 10.0, Ap = 31.1, SpKolk = 0.0, SpOrg = 0.4, Cp = 46.6, Hp = 3.4, Np = 0.8, Op = 7.7, Qpn = 18.04, Vr = 42.0, Klo = 1.05 },
            new Coal { Id = 40, Basin = "Райчихинское", Mark = "2Б", Wp = 37.0, Ap = 13.9, SpKolk = 0.0, SpOrg = 0.3, Cp = 34.9, Hp = 2.1, Np = 0.5, Op = 11.3, Qpn = 11.72, Vr = 43.0, Klo = 1.3 },
            new Coal { Id = 41, Basin = "Бикинское", Mark = "1Б", Wp = 41.0, Ap = 23.0, SpKolk = 0.0, SpOrg = 0.3, Cp = 23.8, Hp = 1.9, Np = 0.6, Op = 9.4, Qpn = 7.83, Vr = 53.0, Klo = 1.25 },
            new Coal { Id = 42, Basin = "Джебарики-Хая", Mark = "Д", Wp = 11.0, Ap = 13.4, SpKolk = 0.0, SpOrg = 0.2, Cp = 58.6, Hp = 4.1, Np = 0.5, Op = 12.2, Qpn = 22.32, Vr = 42.0, Klo = 1.0 },
            new Coal { Id = 43, Basin = "Нерюнгринское", Mark = "3СС", Wp = 10.0, Ap = 19.8, SpKolk = 0.0, SpOrg = 0.2, Cp = 60.0, Hp = 3.1, Np = 0.6, Op = 6.3, Qpn = 22.48, Vr = 20.0, Klo = 2.1 },
            new Coal { Id = 44, Basin = "Аркагалинское (открытые)", Mark = "Д", Wp = 17.0, Ap = 17.4, SpKolk = 0.0, SpOrg = 0.3, Cp = 48.9, Hp = 3.3, Np = 0.7, Op = 12.4, Qpn = 18.00, Vr = 41.0, Klo = 1.0 },
            new Coal { Id = 45, Basin = "Аркагалинское (подземные)", Mark = "Д", Wp = 16.0, Ap = 14.3, SpKolk = 0.0, SpOrg = 0.3, Cp = 52.3, Hp = 3.6, Np = 0.8, Op = 12.7, Qpn = 19.43, Vr = 40.0, Klo = 1.1 },
            new Coal { Id = 46, Basin = "Анадырское", Mark = "3Б", Wp = 22.0, Ap = 13.3, SpKolk = 0.0, SpOrg = 0.6, Cp = 47.9, Hp = 3.7, Np = 0.7, Op = 11.8, Qpn = 17.92, Vr = 47.0, Klo = 0.9 },
            new Coal { Id = 47, Basin = "Южный Сахалин", Mark = "3Б", Wp = 20.0, Ap = 25.6, SpKolk = 0.0, SpOrg = 0.5, Cp = 39.4, Hp = 3.0, Np = 1.1, Op = 10.4, Qpn = 15.03, Vr = 48.0, Klo = 0.9 },
            new Coal { Id = 48, Basin = "Южный Сахалин", Mark = "Д", Wp = 11.0, Ap = 24.0, SpKolk = 0.0, SpOrg = 0.3, Cp = 49.4, Hp = 3.8, Np = 1.1, Op = 10.4, Qpn = 19.55, Vr = 49.0, Klo = 0.9 },
            new Coal { Id = 49, Basin = "Южный Сахалин", Mark = "Г", Wp = 10.5, Ap = 19.7, SpKolk = 0.0, SpOrg = 0.3, Cp = 56.5, Hp = 4.2, Np = 1.4, Op = 7.4, Qpn = 22.23, Vr = 42.0, Klo = 1.2 }
        };

        /// <summary>
        /// Получить уголь по ID
        /// </summary>
        public static Coal GetById(int id)
        {
            return Coals.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Получить угли по марке (Д, Г, Ж, К, СС, Т, 1Б, 2Б, 3Б)
        /// </summary>
        public static List<Coal> GetByMark(string mark)
        {
            return Coals.Where(c => c.Mark == mark).ToList();
        }

        /// <summary>
        /// Получить угли по бассейну (месторождению)
        /// </summary>
        public static List<Coal> GetByBasin(string basin)
        {
            return Coals.Where(c => c.Basin.Contains(basin, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Поиск угля по названию месторождения
        /// </summary>
        public static Coal FindByName(string name)
        {
            return Coals.FirstOrDefault(c => c.Basin.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Получить все уникальные марки углей
        /// </summary>
        public static List<string> GetAllMarks()
        {
            return Coals.Select(c => c.Mark).Distinct().OrderBy(m => m).ToList();
        }

        /// <summary>
        /// Получить все уникальные бассейны
        /// </summary>
        public static List<string> GetAllBasins()
        {
            return Coals.Select(c => c.Basin).Distinct().OrderBy(b => b).ToList();
        }
    }
}
