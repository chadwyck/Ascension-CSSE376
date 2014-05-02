using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    public class AI : Player
    {
        //int playerNum;

        //private const int HONOR = 0, RUNES = 1, POWER = 2; // metricIDs

        //public Game game { get; protected set; }

        //public int playerNumber { get; private set; }

        //public int playerPower { get; private set; }

        //public int playerRunes { get; private set; }

        //public int playerHonor { get; private set; }

        //public int currentRunes { get; private set; }

        //public int currentPower { get; private set; }

        //public ConstructDeck constructs { get; private set; }

        //public HandDeck deck { get; private set; }

        //public InHand hand { get; private set; }

        //public InPlay onBoard { get; private set; }

        //public DiscardDeck discardPile { get; private set; }
        public AI(Game game, int playerNum) : base(game, playerNum) { }
        //public AI(Game game, int playerNum): base()
        //{
        //    base.game = game;
        //    base.playerNumber = playerNum;
        //    base.playerHonor = 0;
        //    base.currentRunes = 0;
        //    base.currentPower = 0;
        //    base.deck = new HandDeck();
        //    base.discardPile = new DiscardDeck(base.deck);
        //    base.deck.setDiscard(base.discardPile);
        //    base.constructs = new ConstructDeck(base.discardPile);
        //    base.onBoard = new InPlay(base.discardPile);
        //    base.hand = new InHand(base.discardPile, base.onBoard, base.deck);


        //    base.playerRunes = 0;
        //    base.playerPower = 0;
        //    base.game = game;

        //    Card apprentice = new Card(base.game, "Apprentice", null, 0, 0, 0, "lifebound", "hero",
        //        new List<CardAction> { new ChangeMetricCount(RUNES, 5, game),
        //                               new FirstTimeGet("fallen", "monster", HONOR, 5, game) });

        //    Card militia = new Card(base.game, "Militia", null, 0, 0, 0, null, "basic",
        //        new List<CardAction> { new ChangeMetricCount(POWER, 3, base.game),
        //                               new MoveFromTo("deck", "hand", false, false,base.game),
        //                               new ForEachCardType("lifebound","hero",false,HONOR,2,base.game)});
        //    for (int j = 0; j < 8; j++)
        //        base.deck.add(apprentice);
        //    base.deck.add(militia);
        //    base.deck.add(militia);
        //}
    }
}
