using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingProject
{
    public class Game
    {
        private FileReader file;
        private ScoreCalculator score;
        private int firstThrow;
        private int secondThrow;
        private string textFile;
        private string[] games;
        public Game()
        {
            textFile = "//Mac/Home/Documents/Visual Studio 2015/Projects/BowlingProject/BowlingProject/scores.txt";
            file = new FileReader(textFile);
            score = new ScoreCalculator();
            games = file.ReadFromFile();
        }
        public void GetScoreForEachGame()
        {
            foreach (string game in games)
            {
                char[] frame = game.ToCharArray();
                for (int i = 0; i < frame.Length; i++)
                {
                    if (frame[i] == 'X')
                    {
                        firstThrow = 10;
                        secondThrow = 0;
                    }
                    else
                    {
                        firstThrow = Convert.ToInt16(frame[i].ToString());
                        if (frame[i] < frame.Length - 1)
                        {
                            CheckSecondThrow(frame[i + 1]);
                        }
                        i++;
                    }
                    Frame eachFrame = new Frame(firstThrow, secondThrow);
                    score.StartFrame(eachFrame);
                }
                Console.WriteLine("Final Score: {0}", score.score);
            }
            Console.ReadKey();
        }
        private void CheckSecondThrow(char frame)
        {
            if (frame == '/')
            {
                secondThrow = 10 - firstThrow;
            }
            else
            {
                secondThrow = Convert.ToInt16(frame.ToString());
            }
        }
    }
}
