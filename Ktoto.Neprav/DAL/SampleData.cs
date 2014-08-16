using Ktoto.Neprav.Domain;

namespace Ktoto.Neprav.DAL
{
    public class SampleData
    {
        public static void FillDal(IDal dal)
        {
            var theme = new Theme
            {
                Name = "Грязные гомосеки"
            };

            // gay
            var gayBoris = new Author()
            {
                Name = "Пидор боря",
                Sex = Sex.Female
            };

            R.CreatedTheme(gayBoris, theme);

            var comment1 = new Comment()
            {
                Opinion = Opinion.Good,
                Text =
                    "обажаю гомосексуализм. первый раз попробовал в 5 лет и теперь втянулся, ваааще супер, мальчики такие клевые",
            };
            R.Commented(gayBoris, theme, comment1);

            // norm
            var anatoly = new Author()
            {
                Name = "Анатолий поцриоц",
                Sex = Sex.Male
            };
            var comment2 = new Comment()
            {
                Opinion = Opinion.Bad,
                Text =
                    "Фу грязные педики. Мне страшно за детей. Меня тянет блевать от них. Я так-то не против этих ебаных пидоров хуесосов, но только если они тихо сидят дома и боятся меня. Если я увижу такого рядом с ребенком я бля его в жопу выебу.",
            };
            R.Commented(anatoly, theme, comment2);

            // neu
            var nastic = new Author()
            {
                Name = "Настик1993",
                Sex = Sex.Female
            };
            var comment3 = new Comment()
            {
                Opinion = Opinion.Neutral,
                Text =
                    "У меня друг гей очень хороший мальчик. А плохие гомосеки парады устраивают. Вообще тема дял долгого разговора. Мне нравятся брутальные мальчики пишите вирт nastic@gmail.com.",
            };
            R.Commented(nastic, theme, comment3);

            dal.Attach(theme);
            dal.Attach(gayBoris);
            dal.Attach(anatoly);
            dal.Attach(nastic);
            dal.Attach(comment1);
            dal.Attach(comment2);
            dal.Attach(comment3);
        }
    }
}