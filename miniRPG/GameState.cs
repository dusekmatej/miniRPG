using System.Drawing;

namespace miniRPG;

public static class GameState
{
    public static class Currencies
    {
        public static int Money { get; set; } = 100;
    }
    
    // Mining variables
    public static class Mining
    {
        public static string LastMaterial { get; set; } = "none";
        public static int StoneAmount { get; set; } = 10;
        public static int IronAmount { get; set; } = 20;
        public static int GoldAmount { get; set; } = 30;
        public static int DiamondAmount { get; set; }
        public static int EmeraldAmount { get; set; }

        public static int InventoryFill { get; set; } = StoneAmount + IronAmount + GoldAmount + DiamondAmount + EmeraldAmount;

        public static class Experience
        {
            public static int Current { get; set; } = 0;
            public static int[] Intervals { get; set; } = new int[]
            {   0, 100, 200, 300, 400, 500, 600, 700, 800, 900,
                1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700,
                1800, 1900, 2000 };
            public static int Level { get; set; } = 1;
            
            public static int StoneSell { get; set; } = 2;
            public static int IronSell { get; set; } = 5;
            public static int GoldSell { get; set; } = 10;
            public static int DiamondSell { get; set; } = 20;
            public static int EmeraldSell { get; set; } = 50;
            
            public static int StoneMine { get; set; } = 1;
            public static int IronMine { get; set; } = 2;
            public static int GoldMine { get; set; } = 3;
            public static int DiamondMine { get; set; } = 10;
            public static int EmeraldMine { get; set; } = 35;
        }

        public class Upgrades
        {   
            public static int SpeedLevel { get; set; } = 0;
            //0     1    2    3    4    5     6    7   8
            public static double[] Speed { get; set; } = [1000, 800, 600, 500, 400, 300, 200, 100, 50];
            public static int[] SpeedCost { get; set; } = [];
        }
        
        
        public static class Store
        {
            public static int StonePrice { get; set; } = 5;
            public static int IronPrice { get; set; } = 10;
            public static int GoldPrice { get; set; } = 20;
            public static int DiamondPrice { get; set; } = 50;
            public static int EmeraldPrice { get; set; } = 100;
        
            public static int StoneSellPrice { get; set; } = 3;
            public static int IronSellPrice { get; set; } = 7;
            public static int GoldSellPrice { get; set; } = 15;
            public static int DiamondSellPrice { get; set; } = 40;
            public static int EmeraldSellPrice { get; set; } = 80;
        }
    }
    
    #region Debug and other settings 
    public static bool IsRunning { get; set; } = true;
    public static bool LogEntered { get; set; } = false;
    public static bool LogAllowed { get; set; } = true;
    public static ConsoleColor CurrentColor { get; set; } = ConsoleColor.Red;

    #endregion
}