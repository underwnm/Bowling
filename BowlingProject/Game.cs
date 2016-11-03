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
        private Frame eachFrame;
        private int currentFrame;
        private int firstThrow;
        private int secondThrow;
        private int thirdThrow;
        private string textFile;
        private string[] games;
        public Game()
        {
            textFile = "//Mac/Home/Documents/Visual Studio 2015/Projects/BowlingProject/BowlingProject/scores.txt";
            file = new FileReader(textFile);
            games = file.ReadFromFile();
        }
        public void GetScoreForEachGame()
        {
            foreach (string game in games)
            {
                score = new ScoreCalculator();
                currentFrame = 1;
                char[] scoringForTenFrames = game.ToCharArray();
                for (int i = 0; i < scoringForTenFrames.Length; i++)
                {
                    if (scoringForTenFrames[i] == 'X')
                    {
                        if (currentFrame < 10)
                        {
                            firstThrow = 10;
                            secondThrow = 0;
                            i++;
                        }
                        else
                        {
                            firstThrow = 10;
                            GetSecondThrow(scoringForTenFrames[i]);
                            i++;
                            GetThirdThrow(scoringForTenFrames[i]);
                            i++;
                        }
                    }
                    else
                    {
                        if (currentFrame < 10)
                        {
                            firstThrow = Convert.ToInt16(scoringForTenFrames[i].ToString());
                            i++;
                            GetSecondThrow(scoringForTenFrames[i]);
                            i++;
                        }
                        else
                        {
                            GetThirdThrow(scoringForTenFrames[i]);
                            i++;
                        }
                    }
                    if (currentFrame < 10)
                    {
                        eachFrame = new Frame(firstThrow, secondThrow);
                        score.GetFrameScore(eachFrame);
                        currentFrame++;
                    }
                    else
                    {
                        TenthFrame lastFrame = new TenthFrame(firstThrow, secondThrow, thirdThrow);
                        score.GetFrameScore(lastFrame);
                    }
                }
                Console.WriteLine("Final Score: {0}", score.score);
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        private void GetSecondThrow(char frame)
        {
            if (frame == 'X')
            {
                secondThrow = 10;
            }
            else if (frame == '/')
            {
                secondThrow = 10 - firstThrow;
            }
            else
            {
                secondThrow = Convert.ToInt16(frame.ToString());
            }
        }
        private void GetThirdThrow(char? frame)
        {
            if (frame == null)
            {
                thirdThrow = 0;
            }
            else if (frame == 'X')
            {
                thirdThrow = 10;
            }
            else if (frame == '/')
            {
                secondThrow = 10 - firstThrow;
            }
            else
            {
                thirdThrow = Convert.ToInt16(frame.ToString());
            }
        }
    }
}
