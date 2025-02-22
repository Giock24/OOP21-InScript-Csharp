﻿namespace shared
{
    public interface GameConst
    {
        public static readonly int DefaultPlayerLife = 0;
        public static readonly int MinPlayerLife = -10;
        public static readonly int InitialMana = 0;
        public static readonly int MaximumMana = 10;
        public static readonly int ManaPlusOne = 1;
        public static int MaximumUseEffect = 1;
        public static int FirstRoundPlaced = 1;
        public static int NoEnoughMana = 0;

        /**
         * this is the number of card that each player have in the hand before the drawingPhase
         */
        public static readonly int InitialNumCardsInHand = 3;
    }
}
