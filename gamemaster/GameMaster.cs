﻿using shared;
using cards;
using drawphasemanager;
using mainphasemanager;
using battlephasemanager;

using System.Collections.Generic;

namespace gamemaster
{

    public interface IGameMaster
    {
        public void StartGame();
    }
    public class GameMaster : IGameMaster
    {

        public Player HumanPlayer { get; }
        public Player AiPlayer { get; }

        bool isTheAIturn;

        public IDrawPhaseManager DrawPhaseManager { get; }
        public IMainPhaseManager MainPhaseManager { get; }
        public IBattlePhaseManager BattlePhaseManager { get; }
        public IMainPhaseManagerIA MainPhaseManagerIA { get; }

        public GameMaster(List<BaseCard> humanPlayerDeck, List<BaseCard> aiPlayerDeck)
        {
            List<BaseCard> empty = new List<BaseCard>(Player.NumCardBoard) { null, null, null, null, null};

            HumanPlayer = new Player(false, humanPlayerDeck, GameConst.DefaultPlayerLife, GameConst.InitialMana, GameConst.InitialMana, empty, new List<BaseCard>());
            AiPlayer = new Player(true, aiPlayerDeck, GameConst.DefaultPlayerLife, GameConst.InitialMana, GameConst.InitialMana, empty, new List<BaseCard>());
            isTheAIturn = false;
            DrawPhaseManager = new DrawPhaseManagerImpl(HumanPlayer, AiPlayer);
            MainPhaseManager = new MainPhaseManagerImpl(HumanPlayer, AiPlayer);
            BattlePhaseManager = new BattlePhaseManager(HumanPlayer, AiPlayer);
            MainPhaseManagerIA = new MainPhaseManagerIA(HumanPlayer, AiPlayer);
        }

        public void StartGame()
        {
            DrawPhaseManager.FirstDraw();

            DrawPhaseManager.Draw(true);
            MainPhaseManagerIA.StartAIMainPhase();

            DrawPhaseManager.Draw(false);
        }

    }
}
