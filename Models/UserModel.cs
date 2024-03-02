using System;

namespace Permiakov.Lab1.Model
{
    internal class UserModel
    {
        public DateTime Birthday { get; set; }

        public bool HasBirthday => Birthday.Day == DateTime.Today.Day && Birthday.Month == DateTime.Today.Month;

        public string ChineseSign => CalculateChineseSign();

        public string WesternSign => CalculateWesternSign();

        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - Birthday.Year;
                if (DateTime.Today.Month < Birthday.Month || (DateTime.Today.Month == Birthday.Month && DateTime.Today.Day < Birthday.Day))
                {
                    age--;
                }
                return age;
            }
        }

        public UserModel(DateTime birthday)
        {
            Birthday = birthday;
        }

        private string CalculateWesternSign()
        {
            int month = Birthday.Month;
            int day = Birthday.Day;

            switch (month)
            {
                case 1 when day >= 20:
                case 2 when day <= 18:
                    return WesternSigns.Aquarius.ToString();
                case 2 when day >= 19:
                case 3 when day <= 20:
                    return WesternSigns.Pisces.ToString();
                case 3 when day >= 21:
                case 4 when day <= 19:
                    return WesternSigns.Aries.ToString();
                case 4 when day >= 20:
                case 5 when day <= 20:
                    return WesternSigns.Taurus.ToString();
                case 5 when day >= 21:
                case 6 when day <= 20:
                    return WesternSigns.Gemini.ToString();
                case 6 when day >= 21:
                case 7 when day <= 22:
                    return WesternSigns.Cancer.ToString();
                case 7 when day >= 23:
                case 8 when day <= 22:
                    return WesternSigns.Leo.ToString();
                case 8 when day >= 23:
                case 9 when day <= 22:
                    return WesternSigns.Virgo.ToString();
                case 9 when day >= 23:
                case 10 when day <= 22:
                    return WesternSigns.Libra.ToString();
                case 10 when day >= 23:
                case 11 when day <= 21:
                    return WesternSigns.Scorpio.ToString();
                case 11 when day >= 22:
                case 12 when day <= 21:
                    return WesternSigns.Sagittarius.ToString();
                default:
                    return WesternSigns.Capricorn.ToString();
            }
        }

        private string CalculateChineseSign()
        {
            int yearOffset = (Birthday.Year - 4) % 12;
            return ((ChineseSigns)yearOffset).ToString();
        }
    }

    internal enum WesternSigns
    {
        Capricorn,
        Aquarius,
        Pisces,
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
    }

    internal enum ChineseSigns
    {
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Goat,
        Monkey,
        Rooster,
        Dog,
        Pig,
    }
}
