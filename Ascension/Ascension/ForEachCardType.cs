﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    class ForEachCardType : ChangeMetricCount
    {
        string faction, cardType;
        bool playedOne;
        public ForEachCardType(string faction, string cardType, bool playedOne, int metricID, int incrementBy, Game game)
            : base(metricID, incrementBy, game)
        {
            this.faction = faction;
            this.cardType = cardType;
            this.playedOne = playedOne;
        }

        override public void doAction()
        {
            int numCorrCards = this.game.cardsPlayed.numberOf(faction, cardType);
            if (playedOne)
            {
                if (numCorrCards > 0)
                {
                    base.doAction();
                }
            }
            else
            {
                for (int i = 0; i < numCorrCards; i++)
                {
                    base.doAction();
                }
            }
        }

        private int numOf()
        {
            if (faction == null)
            {
                return this.game.cardsPlayed.numberOfCardType(cardType);
            }
            if (cardType == null)
            {
                return this.game.cardsPlayed.numberOfCardType(faction);
            }
            return this.game.cardsPlayed.numberOf(faction, cardType);
        }
    }
}