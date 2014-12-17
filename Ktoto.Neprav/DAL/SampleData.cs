using System;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.DAL
{
    public class SampleData
    {
        public static void FillDal(IDal dal)
        {

	        var R = new R(dal);
            var theme = new Theme
            {
                Name = "Грязные гомосеки",
				Created = DateTimeOffset.Now
            };

	        var pwdData = PwdManager.ComputeHash("123456");
            // ps
            var ps = new Author()
            {
                UserId = 5349661
            };

            R.CreatedTheme(ps, theme);

            var comment1 = new Comment()
            {
                Opinion = OpinionColor.Good,
                Text =
                    "обажаю гомосексуализм. первый раз попробовал в 5 лет и теперь втянулся, ваааще супер, мальчики такие клевые",
            };
            R.Commented(ps, theme, comment1);

			pwdData = PwdManager.ComputeHash("123456");
			// norm
            var sm = new Author()
            {
                UserId = 1484336
            };
            var comment2 = new Comment()
            {
				Opinion = OpinionColor.Bad,
                Text =
                    "Фу грязные педики. Мне страшно за детей. Меня тянет блевать от них. Я так-то не против этих ебаных пидоров хуесосов, но только если они тихо сидят дома и боятся меня. Если я увижу такого рядом с ребенком я бля его в жопу выебу.",
            };
            R.Commented(sm, theme, comment2);

			pwdData = PwdManager.ComputeHash("123456");
			// neu
            var vo = new Author()
            {
                UserId = 106613956
            };
            var comment3 = new Comment()
            {
				Opinion = OpinionColor.Good,
                Text =
                    "У меня друг гей очень хороший мальчик. А плохие гомосеки парады устраивают. Вообще тема дял долгого разговора. Мне нравятся брутальные мальчики пишите вирт vasya_ogarkov@gmail.com.",
            };
            R.Commented(vo, theme, comment3);

            dal.Attach(theme);
            dal.Attach(ps);
            dal.Attach(sm);
            dal.Attach(vo);
            dal.Attach(comment1);
            dal.Attach(comment2);
            dal.Attach(comment3);
        }
    }
}