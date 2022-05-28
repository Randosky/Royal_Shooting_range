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
        public Barrier[] Barriers;
        public int count;
        public Level currentLevel;
        public float ArrowSpeed;

        public Level(string name, Target[] targets, Barrier[] barriers, float arrowSpeed)
        {
            Name = name;
            Targets = targets;
            Barriers = barriers;
            count = Targets.Length;
            ArrowSpeed = arrowSpeed;
        }

        public Level()
        {
            currentLevel = null;
        }

        public bool IsCompleted => count == 0;

        public static IEnumerable<Level> CreateLevels()
        {
            Random rand = new Random();
            float rndX1 = rand.Next(900, 1200);
            float rndY1 = rand.Next(300, 400);
            float rndX2 = rand.Next(900, 1200);
            float rndY2 = rand.Next(300, 400);
            float rndX3 = rand.Next(900, 1200);
            float rndY3 = rand.Next(300, 400);
            float rndX4 = rand.Next(450, 800);
            float rndY4 = rand.Next(300, 600);
            float rndX5 = rand.Next(450, 800);
            float rndY5 = rand.Next(300, 600);
            float rndS1 = rand.Next(3, 7);
            float rndS2 = rand.Next(3, 7);
            float rndS3 = rand.Next(3, 7);
            int rndD1 = rand.Next(1, 5);
            int rndD2 = rand.Next(1, 5);
            int rndD3 = rand.Next(1, 5);
            float rndAS = (float)rand.NextDouble();
            if (rndAS > 0.7f) rndAS -= 0.3f;

            yield return new Level("Level 1", 
                new []{ new Target(1200, 400, "Down", 0, 1f), new Target(1000, 300, "Up", 0, 1f), new Target(1300, 350, "Up", 0, 2f), new Target(1000, 600, "Down", 0, 2f) },
                new Barrier[]{new Barrier(900, 300)},
                0.2f);

            yield return new Level("Level 2", 
                new []{ new Target(1232, 234, "Down", 0, 2f), new Target(1122, 276, "Round1", 0.2f, 5), new Target(1340, 350, "Up", 0, 3f) },
                new Barrier[] { new Barrier(500, 400) },
                0.2f);

            yield return new Level("Level 3", 
                new []{ new Target(1214, 150, "Round1", 0.25f, 2), new Target(1122, 276, "Round2", 0.2f, 5), new Target(1400, 500, "Up", 0, 4f) },
                new Barrier[] { new Barrier(900, 200), new Barrier(500, 620)},
                0.3f);

            yield return new Level("Level 4",
                new[] { new Target(1214, 150, "Round2", 0.25f, 6), new Target(1122, 276, "Round1", 0.2f, 5), new Target(1150, 400, "Round3", 0.25f, 10) },
                new Barrier[] { new Barrier(900, 200), new Barrier(500, 620) },
                0.3f);

            yield return new Level("Level 5",
                new[] { new Target(1300, 150, "Round4", 0.25f, 7), new Target(1122, 276, "Round3", 0.2f, 8), new Target(1200, 500, "Round5", 0.25f, 10) },
                new Barrier[] { new Barrier(900, 200), new Barrier(500, 620) },
                0.4f);

            yield return new Level("Random Level",
                new[] { new Target(rndX1, rndY1, "Round" + rndD1.ToString(), 0.2f, rndS1), new Target(rndX2, rndY2, "Round" + rndD2.ToString(), 0.2f, rndS2), new Target(rndX3, rndY3, "Round" + rndD3.ToString(), 0.2f, rndS3)},
                new Barrier[] {new Barrier(rndX4, rndY4), new Barrier(rndX5, rndY5)},
                    rndAS);
        }
    }
}
