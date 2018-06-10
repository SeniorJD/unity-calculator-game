using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelGenerator
{
    public class Task
    {
        string task;
        string expectedResult;

        public Task(string task, string expectedResult)
        {
            this.task = task;
            this.expectedResult = expectedResult;
        }

        public string getTask()
        {
            return task;
        }

        public string getExpectedResult()
        {
            return expectedResult;
        }
    }

    public abstract Task GenerateTask();
    public virtual Task GenerateTask(int score)
    {
        return GenerateTask();
    }

    public static LevelGenerator GetGenerator(int gameType, int levelType, int levelIndex)
    {
        switch (gameType)
        {
            case GameData.TIME_ATTACK_GAME_TYPE:
                return getTimeAttackGenerator();
            case GameData.STORY_GAME_TYPE:
                return getLevelsGenerator(levelType, levelIndex);
        }
        return null;
    }

    static LevelGenerator getTimeAttackGenerator()
    {
        return new TimeAttackGenerator();
    }

    static LevelGenerator getLevelsGenerator(int levelType, int levelIndex)
    {
        switch (levelType)
        {
            case GameData.PLUS_LEVEL_TYPE:
                return getLevelsPlusGenerator(levelIndex);
            case GameData.MINUS_LEVEL_TYPE:
                return getLevelsMinusGenerator(levelIndex);
            case GameData.MULTIPLY_LEVEL_TYPE:
                return getLevelsMultiplyGenerator(levelIndex);
                //            case DIVIDE:
                //                return getLevelsDivideGenerator(levelIndex);
        }

        throw new System.Exception("Unknown level type: " + levelType);
    }

    static LevelGenerator getLevelsPlusGenerator(int levelIndex)
    {
        switch (levelIndex)
        {
            case 0:
                return new LevelsPlus0Generator();
            case 1:
                return new LevelsPlus1Generator();
            case 2:
                return new LevelsPlus2Generator();
            case 3:
                return new LevelsPlus3Generator();
            case 4:
                return new LevelsPlus4Generator();
            case 5:
                return new LevelsPlus5Generator();
            case 6:
                return new LevelsPlus6Generator();
            case 7:
                return new LevelsPlus7Generator();
            case 8:
                return new LevelsPlus8Generator();
            case 9:
                return new LevelsPlus9Generator();
            case 10:
                return new LevelsPlus10Generator();
            case 11:
                return new LevelsPlus11Generator();
            case 12:
                return new LevelsPlus12Generator();
            case 13:
                return new LevelsPlus13Generator();
            case 14:
                return new LevelsPlus14Generator();
        }

        return null;
    }

    static LevelGenerator getLevelsMinusGenerator(int levelIndex)
    {
        switch (levelIndex)
        {
            case 0:
                return new LevelsMinus0Generator();
            case 1:
                return new LevelsMinus1Generator();
            case 2:
                return new LevelsMinus2Generator();
            case 3:
                return new LevelsMinus3Generator();
            case 4:
                return new LevelsMinus4Generator();
            case 5:
                return new LevelsMinus5Generator();
            case 6:
                return new LevelsMinus6Generator();
            case 7:
                return new LevelsMinus7Generator();
            case 8:
                return new LevelsMinus8Generator();
            case 9:
                return new LevelsMinus9Generator();
            case 10:
                return new LevelsMinus10Generator();
            case 11:
                return new LevelsMinus11Generator();
            case 12:
                return new LevelsMinus12Generator();
            case 13:
                return new LevelsMinus13Generator();
            case 14:
                return new LevelsMinus14Generator();
        }
        return null;
    }

    static LevelGenerator getLevelsMultiplyGenerator(int levelIndex)
    {
        switch (levelIndex)
        {
            case 0:
                return new LevelsMultiply0Generator();
            case 1:
                return new LevelsMultiply1Generator();
            case 2:
                return new LevelsMultiply2Generator();
            case 3:
                return new LevelsMultiply3Generator();
            case 4:
                return new LevelsMultiply4Generator();
            case 5:
                return new LevelsMultiply5Generator();
            case 6:
                return new LevelsMultiply6Generator();
            case 7:
                return new LevelsMultiply7Generator();
            case 8:
                return new LevelsMultiply8Generator();
            case 9:
                return new LevelsMultiply9Generator();
            case 10:
                return new LevelsMultiply10Generator();
            case 11:
                return new LevelsMultiply11Generator();
            case 12:
                return new LevelsMultiply12Generator();
            case 13:
                return new LevelsMultiply13Generator();
            case 14:
                return new LevelsMultiply14Generator();
        }
        return null;
    }

    // GENERATOR CLASSES
    class TimeAttackGenerator : LevelGenerator
    {

        public override Task GenerateTask(int score)
        {
            Debug.Log(score);
            int levelTypeIndex = (score / 10) / 15;
            int levelDifficultyIndex = (score / 10) % 15;

            if (levelTypeIndex > 2)
            {
                levelTypeIndex = 2;
                levelDifficultyIndex = 14;
            }

            return getLevelsGenerator(levelTypeIndex, levelDifficultyIndex).GenerateTask();

            //return GenerateTask();
        }

        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 100);
            int i2 = NextInt(r, 100);

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                result = i1 + i2;
                task = i1 + "+" + i2;
            }
            else
            {
                result = i1 - i2;
                task = i1 + "-" + i2;
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus0Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 10);
            int i2 = NextInt(r, 10);

            string task;
            int result;

            result = i1 + i2;
            task = i1 + "+" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus1Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 10) + 10;
            int i2 = NextInt(r, 10) + 10;

            string task;
            int result;

            result = i1 + i2;
            task = i1 + "+" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus2Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 20) + 10;
            int i2 = NextInt(r, 20) + 10;

            string task;
            int result;

            result = i1 + i2;
            task = i1 + "+" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus3Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 30) + 30;
            int i2 = NextInt(r, 20) + 10;

            string task;
            int result;

            result = i1 + i2;
            task = i1 + "+" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus4Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 30) + 30;
            int i2 = NextInt(r, 30) + 30;

            string task;
            int result;

            result = i1 + i2;
            task = i1 + "+" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus5Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 40) + 40;
            int i2 = NextInt(r, 40) + 40;

            string task;
            int result;

            result = i1 + i2;
            task = i1 + "+" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus6Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 50) + 50;
            int i2 = NextInt(r, 50) + 50;

            string task;
            int result;

            result = i1 + i2;
            task = i1 + "+" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus7Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 20);
            int i2 = NextInt(r, 20);
            int i3 = NextInt(r, 20);

            string task;
            int result;

            result = i1 + i2 + i3;
            task = i1 + "+" + i2 + "+" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus8Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 20) + 20;
            int i2 = NextInt(r, 20) + 20;
            int i3 = NextInt(r, 20) + 20;

            string task;
            int result;

            result = i1 + i2 + i3;
            task = i1 + "+" + i2 + "+" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus9Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 30) + 30;
            int i2 = NextInt(r, 20) + 10;
            int i3 = NextInt(r, 30) + 30;

            string task;
            int result;

            result = i1 + i2 + i3;
            task = i1 + "+" + i2 + "+" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus10Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 70) + 30;
            int i2 = NextInt(r, 20) + 30;
            int i3 = NextInt(r, 70) + 90;

            string task;
            int result;

            result = i1 + i2 + i3;
            task = i1 + "+" + i2 + "+" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus11Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 50) + 50;
            int i2 = NextInt(r, 50) + 20;
            int i3 = NextInt(r, 50) + 50;

            string task;
            int result;

            result = i1 + i2 + i3;
            task = i1 + "+" + i2 + "+" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus12Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 100) + 100;
            int i2 = NextInt(r, 50) + 20;
            int i3 = NextInt(r, 50) + 20;

            string task;
            int result;

            result = i1 + i2 + i3;
            task = i1 + "+" + i2 + "+" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus13Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 100) + 100;
            int i2 = NextInt(r, 50) + 50;
            int i3 = NextInt(r, 100) + 50;

            string task;
            int result;

            result = i1 + i2 + i3;
            task = i1 + "+" + i2 + "+" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsPlus14Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 100) + 100;
            int i2 = NextInt(r, 100) + 100;
            int i3 = NextInt(r, 100) + 100;

            string task;
            int result;

            result = i1 + i2 + i3;
            task = i1 + "+" + i2 + "+" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus0Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int test1 = NextInt(r, 10);
            int test2 = NextInt(r, 10);

            int i1 = test2 > test1 ? test2 : test1;
            int i2 = test2 > test1 ? test1 : test2;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus1Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int test1 = NextInt(r, 10) + 10;
            int test2 = NextInt(r, 10);

            int i1 = test2 > test1 ? test2 : test1;
            int i2 = test2 > test1 ? test1 : test2;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus2Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int test1 = NextInt(r, 20) + 10;
            int test2 = NextInt(r, 10);

            int i1 = test2 > test1 ? test2 : test1;
            int i2 = test2 > test1 ? test1 : test2;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus3Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int test1 = NextInt(r, 30) + 30;
            int test2 = NextInt(r, 20);

            int i1 = test2 > test1 ? test2 : test1;
            int i2 = test2 > test1 ? test1 : test2;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus4Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 30) + 30;
            int i2 = NextInt(r, 20) + 10;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus5Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 40) + 40;
            int i2 = NextInt(r, 20) + 10;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus6Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 50) + 50;
            int i2 = NextInt(r, 30) + 10;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus7Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 50) + 50;
            int i2 = NextInt(r, 30) + 30;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus8Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 50) + 50;
            int i2 = NextInt(r, 50) + 50;

            string task;
            int result;

            result = i1 - i2;
            task = i1 + "-" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus9Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 20);
            int i2 = NextInt(r, 10) + 10;
            int i3 = NextInt(r, 20);

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                result = i1 + i2;
                task = i1 + "+" + i2;

                result = result - i3;
                task = task + "-" + i3;
            }
            else
            {
                result = i1 - i2;
                task = i1 + "-" + i2;

                if (Random.Range(0, 100) > 49)
                {
                    result = result + i3;
                    task = task + "+" + i3;
                }
                else
                {
                    result = result - i3;
                    task = task + "-" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus10Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 20) + 20;
            int i2 = NextInt(r, 20) + 10;
            int i3 = NextInt(r, 30) + 10;

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                result = i1 + i2;
                task = i1 + "+" + i2;

                result = result - i3;
                task = task + "-" + i3;
            }
            else
            {
                result = i1 - i2;
                task = i1 + "-" + i2;

                if (Random.Range(0, 100) > 49)
                {
                    result = result + i3;
                    task = task + "+" + i3;
                }
                else
                {
                    result = result - i3;
                    task = task + "-" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus11Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 20) + 40;
            int i2 = NextInt(r, 20) + 20;
            int i3 = NextInt(r, 50) + 10;

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                result = i1 + i2;
                task = i1 + "+" + i2;

                result = result - i3;
                task = task + "-" + i3;
            }
            else
            {
                result = i1 - i2;
                task = i1 + "-" + i2;

                if (Random.Range(0, 100) > 49)
                {
                    result = result + i3;
                    task = task + "+" + i3;
                }
                else
                {
                    result = result - i3;
                    task = task + "-" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus12Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 40) + 40;
            int i2 = NextInt(r, 30) + 20;
            int i3 = NextInt(r, 40) + 40;

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                result = i1 + i2;
                task = i1 + "+" + i2;

                result = result - i3;
                task = task + "-" + i3;
            }
            else
            {
                result = i1 - i2;
                task = i1 + "-" + i2;

                if (Random.Range(0, 100) > 49)
                {
                    result = result + i3;
                    task = task + "+" + i3;
                }
                else
                {
                    result = result - i3;
                    task = task + "-" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus13Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 50) + 50;
            int i2 = NextInt(r, 30) + 30;
            int i3 = NextInt(r, 50) + 50;

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                result = i1 + i2;
                task = i1 + "+" + i2;

                result = result - i3;
                task = task + "-" + i3;
            }
            else
            {
                result = i1 - i2;
                task = i1 + "-" + i2;

                if (Random.Range(0, 100) > 49)
                {
                    result = result + i3;
                    task = task + "+" + i3;
                }
                else
                {
                    result = result - i3;
                    task = task + "-" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMinus14Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 50) + 100;
            int i2 = NextInt(r, 50) + 50;
            int i3 = NextInt(r, 50) + 50;

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                result = i1 + i2;
                task = i1 + "+" + i2;

                result = result - i3;
                task = task + "-" + i3;
            }
            else
            {
                result = i1 - i2;
                task = i1 + "-" + i2;

                if (Random.Range(0, 100) > 49)
                {
                    result = result + i3;
                    task = task + "+" + i3;
                }
                else
                {
                    result = result - i3;
                    task = task + "-" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply0Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 5);
            int i2 = NextInt(r, 5);

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply1Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 5) + 5;
            int i2 = NextInt(r, 5);

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply2Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 5) + 5;
            int i2 = NextInt(r, 5) + 5;

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply3Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 5) + 10;
            int i2 = NextInt(r, 5) + 5;

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply4Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 5) + 10;
            int i2 = NextInt(r, 5) + 10;

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply5Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 5) + 15;
            int i2 = NextInt(r, 5) + 10;

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply6Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 5) + 15;
            int i2 = NextInt(r, 5) + 15;

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply7Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 10) + 20;
            int i2 = NextInt(r, 10) + 10;

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply8Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 10) + 20;
            int i2 = NextInt(r, 10) + 20;

            string task;
            int result;

            result = i1 * i2;
            task = i1 + "x" + i2;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply9Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 5) + 10;
            int i2 = NextInt(r, 5) + 5;
            int i3 = NextInt(r, 5) + 10;

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                if ((i1 + i2 + i3) % 2 == 0)
                {
                    result = i1 * i2 + i3;
                    task = i1 + "*" + i2 + "+" + i3;
                }
                else
                {
                    result = i1 + i2 * i3;
                    task = i1 + "+" + i2 + "*" + i3;
                }

            }
            else
            {
                if ((i1 + i2 + i3) % 2 == 0)
                {
                    result = i1 * i2 - i3;
                    task = i1 + "*" + i2 + "-" + i3;
                }
                else
                {
                    result = i1 - i2 * i3;
                    task = i1 + "-" + i2 + "*" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply10Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 10) + 20;
            int i2 = NextInt(r, 5) + 10;
            int i3 = NextInt(r, 10) + 20;

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                if ((i1 + i2 + i3) % 2 == 0)
                {
                    result = i1 * i2 + i3;
                    task = i1 + "*" + i2 + "+" + i3;
                }
                else
                {
                    result = i1 + i2 * i3;
                    task = i1 + "+" + i2 + "*" + i3;
                }

            }
            else
            {
                if ((i1 + i2 + i3) % 2 == 0)
                {
                    result = i1 * i2 - i3;
                    task = i1 + "*" + i2 + "-" + i3;
                }
                else
                {
                    result = i1 - i2 * i3;
                    task = i1 + "-" + i2 + "*" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply11Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 20) + 30;
            int i2 = NextInt(r, 10) + 10;
            int i3 = NextInt(r, 20) + 20;

            string task;
            int result;

            if (Random.Range(0, 100) > 49)
            {
                if ((i1 + i2 + i3) % 2 == 0)
                {
                    result = i1 * i2 + i3;
                    task = i1 + "*" + i2 + "+" + i3;
                }
                else
                {
                    result = i1 + i2 * i3;
                    task = i1 + "+" + i2 + "*" + i3;
                }

            }
            else
            {
                if ((i1 + i2 + i3) % 2 == 0)
                {
                    result = i1 * i2 - i3;
                    task = i1 + "*" + i2 + "-" + i3;
                }
                else
                {
                    result = i1 - i2 * i3;
                    task = i1 + "-" + i2 + "*" + i3;
                }
            }

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply12Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 10) + 10;
            int i2 = NextInt(r, 10);
            int i3 = NextInt(r, 10);

            string task;
            int result;

            result = i1 * i2 * i3;
            task = i1 + "*" + i2 + "*" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply13Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 10) + 10;
            int i2 = NextInt(r, 10) + 10;
            int i3 = NextInt(r, 10) + 10;

            string task;
            int result;

            result = i1 * i2 * i3;
            task = i1 + "*" + i2 + "*" + i3;

            return new Task(task, result.ToString());
        }
    }

    class LevelsMultiply14Generator : LevelGenerator
    {


        public override Task GenerateTask()
        {
            Random r = new Random();
            int i1 = NextInt(r, 10) + 20;
            int i2 = NextInt(r, 10) + 10;
            int i3 = NextInt(r, 10) + 20;

            string task;
            int result;

            result = i1 * i2 * i3;
            task = i1 + "*" + i2 + "*" + i3;

            return new Task(task, result.ToString());
        }
    }

    int NextInt(Random r, int maxRange)
    {
        return Random.Range(1, maxRange);
    }
}
