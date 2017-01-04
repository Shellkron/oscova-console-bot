using System;
using Syn.Bot.Oscova;

namespace OscovaConsoleBot
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var bot = new OscovaBot();
            bot.Dialogs.Add(new AppDialog());
            //bot.Language.LexicalDatabase = new LexicalDatabase();
            bot.Train();

            bot.MainUser.ResponseReceived += (sender, eventArgs) =>
            {
               Console.WriteLine(eventArgs.Response);
            };

            while (true)
            {
                var request = Console.ReadLine();
                var evaluationResult = bot.Evaluate(request);
                evaluationResult.Invoke();
                var serialized = evaluationResult.Serialize();

                Console.WriteLine(serialized);
            }
        }
    }
}