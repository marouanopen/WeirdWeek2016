using System;
using System.Timers;

namespace SocCar
{
    public delegate void UpdateHandler(object sender, EventArgs e);

    public class GameManager
    {

        public int scoreRood;
        public int scoreBlauw;

        public GameManager()
        {
            scoreRood = 0;
            scoreBlauw = 0;
        }

        public event UpdateHandler GoalMade;

        protected void OnGoal(EventArgs e)
        {
            GoalMade(this, e);
        }

        public void newGame()
        {
            scoreBlauw = 0;
            scoreRood = 0;
        }
        
        public void goal(string color)
        {
            if (color == "rood")
            {
                scoreRood++;
            }
            else
            {
                scoreBlauw++;
            }
        }
        
    }
}
