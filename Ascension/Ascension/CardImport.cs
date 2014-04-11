using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ascension;
using System.IO;


namespace Ascension
{
   public class  CardImport
    {
        private Game game;
        
        private PortalDeck deck { get; set; }
        public CardImport() {
            deck = new PortalDeck();
        }
        public PortalDeck cardImport(Game gme)
        {
            deck = new PortalDeck();
            string currentDirName = /*@""+System.IO.Directory.GetCurrentDirectory()+"\\CardSets\\Standard\\";*/ @"C:\Users\barnesgl\Documents\Documents\Classes\2013-2014\Q3\CSSE376\Ascension-CSSE376\Ascension\Ascension\CardSets\Standard\";
            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.txt");

            foreach (string cardFile in files)
            {
                deck.add(fileToCard(cardFile));
            }
            
            
            
            return deck;
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
        private Card fileToCard(String file)
        {
            var json = System.IO.File.ReadAllText(file);
            imCard card = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<imCard>(json);
            return new Card(game, card.cardName, null, card.runeCost, card.powerCost, card.endGameHonorGain, card.faction, card.cardType,
                 cardActionGen(card.actions));
            
        }
    }

}
