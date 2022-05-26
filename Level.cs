using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royal_Shooting_range.GameClasses
{
    public partial class Level
    {
        public new readonly string Name;
        public Target[] Targets;
        public Barrier Barrier;
        public int count;
        public Level currentLevel;

        public Level(string name, Target[] targets, Barrier barrier)
        {
            Name = name;
            Targets = targets;
            Barrier = barrier;
            count = 1;
        }

        public Level()
        {
            currentLevel = null;
        }

        public bool IsCompleted => count == 0;

        public static IEnumerable<Level> CreateLevels()
        {
            yield return new Level("Level 1", new []{ new Target(1200, 400), new Target(1000, 300), new Target(1300, 350) }, new Barrier(900, 200));
            yield return new Level("Level 2", new []{ new Target(1232, 234), new Target(1122, 276), new Target(1340, 350) }, new Barrier(500, 400));
        }
    }
}
