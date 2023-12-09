using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class ProgressTracking
    {
        public string ProgressBar(int progressBarWidth)
        {
            int progress = (int)Math.Ceiling((double)Character.XP / Character.ToNextLevel * progressBarWidth);
            string progressbar = "";
            for (int i = 0; i < progressBarWidth; i++)
            {
                if (i < progress)
                {
                    progressbar += "#";
                }
                else
                {
                    progressbar += "-";
                }
            }
            return $"[{progressbar}]";
        }
    }
}
