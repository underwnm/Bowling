using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingProject
{
    class ScoreCalculator
    {
        private Frame[] frames = new Frame[10];
        private int currentFrame;
        public int score;
        private Frame lastFrame { get { return frames[currentFrame - 1]; } }
        private Frame twoFramesAgo { get { return frames[currentFrame - 2]; } }
        public void GetFrameScore(Frame frame)
        {
            AddBonusToScore(frame);
            score += frame.total;
            frames[currentFrame++] = frame;
        }
        private void AddBonusToScore(Frame frame)
        {
            if (CheckIfLastTwoFramesWereStrikes())
            {
                score += frame.total + frame.firstThrow;
            }
            else if (CheckIfLastFrameWasAStrike())
            {
                score += frame.total;
            }
            else if (CheckIfLastFrameWasASpare())
            {
                score += frame.firstThrow;
            }
        }
        private bool CheckIfLastTwoFramesWereStrikes()
        {
            return CheckIfLastFrameWasAStrike() && currentFrame > 1 && twoFramesAgo.isStrike;
        }
        private bool CheckIfLastFrameWasAStrike()
        {
            return currentFrame > 0 && lastFrame.isStrike;
        }
        private bool CheckIfLastFrameWasASpare()
        {
            return currentFrame > 0 && lastFrame.isSpare;
        }
    }
}
