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
                return age >= 0 ? age : throw new InvalidOperationException("Age cannot be negative.");
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

            if ((month == 1 && day >= 20) || (month == 2 && day <= 18)) return WesternSigns.Aquarius.ToString();
            if ((month == 2 && day >= 19) || (month == 3 && day <= 20)) return WesternSigns.Pisces.ToString();
            if ((month == 3 && day >= 21) || (month == 4 && day <= 19)) return WesternSigns.Aries.ToString();
            if ((month == 4 && day >= 20) || (month == 5 && day <= 20)) return WesternSigns.Taurus.ToString();
            if ((month == 5 && day >= 21) || (month == 6 && day <= 20)) return WesternSigns.Gemini.ToString();
            if ((month == 6 && day >= 21) || (month == 7 && day <= 22)) return WesternSigns.Cancer.ToString();
            if ((month == 7 && day >= 23) || (month == 8 && day <= 22)) return WesternSigns.Leo.ToString();
            if ((month == 8 && day >= 23) || (month == 9 && day <= 22)) return WesternSigns.Virgo.ToString();
            if ((month == 9 && day >= 23) || (month == 10 && day <= 22)) return WesternSigns.Libra.ToString();
            if ((month == 10 && day >= 23) || (month == 11 && day <= 21)) return WesternSigns.Scorpio.ToString();
            if ((month == 11 && day >= 22) || (month == 12 && day <= 21)) return WesternSigns.Sagittarius.ToString();

            return WesternSigns.Capricorn.ToString();
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
