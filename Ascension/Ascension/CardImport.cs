using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ascension;


namespace Ascension
{
    class CardImport
    {
        private Game game;
        public List<Card> deck { get; private set; }
        public CardImport(String file, Game gme)
        {
            game = gme;
            deck = new List<Card>();
            var json = System.IO.File.ReadAllText(@"C:\Users\barnesgl\Documents\Documents\Classes\2013-2014\Q3\CSSE376\Ascension-CSSE376\Ascension\Ascension\MilitiaTest.txt");
            imCard card =  new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<imCard>(json);
            deck.Add(new Card(game, card.cardName, null, card.runeCost, card.powerCost, card.endGameHonorGain, card.faction, card.cardType,
                cardActionGen(card.actions)));

        }
        private class imCard{
        

            public string cardName { get; set; }

            public string cardImage { get; set; }

            public int runeCost { get;  set; }

            public int powerCost { get; set; }

            public int cardsToDraw { get; set; }

            public int endGameHonorGain { get; set; }

            public string faction { get;  set; }

            public string cardType { get; set; }

            public List<imCardAction> actions { get; set; }

            
        }
        private class imCardAction {

               public string type { get; set; }
               public int metricID { get; set; }
               public int incrementBy { get; set; }

        }
        //private class imChangeMetricCount: imCardAction {
           //     public int metricID { get; set; }
         //     public int incrementBy { get; set; }
        //}
        private List<CardAction> cardActionGen(List<imCardAction> acts){
            List<CardAction> ret = new List<CardAction>();
            foreach (var act in acts)
            {
                if(act.type.Equals("changeMetric")){
                    ret.Add(new ChangeMetricCount(act.metricID,act.incrementBy, game));
                }
            }
        return ret;
        }
    }

}
