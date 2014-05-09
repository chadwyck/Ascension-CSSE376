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
        
        public CardCollection deck { get; private set; }
        public CardImport(Game gme, string pth) {
            game = gme;
            deck = cardImport(game, pth);
        }
        public CardCollection cardImport(Game gme, String path)
        {   
            if(path.Equals("\\Portal\\"))
            deck = new PortalDeck();
            if(path.Equals("\\PlayerHand\\"))
            deck = new HandDeck();
            string currentDirName = @""+System.IO.Directory.GetCurrentDirectory().Substring(0,System.IO.Directory.GetCurrentDirectory().Length-10)+"\\CardSets" +path;
            
            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.txt");

            foreach (string cardFile in files)
            {
                
                deck.add(fileToCard(cardFile,path));
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
               public bool userChoice{get;set;}
               public bool optional { get; set; }
               public string faction {get; set;}
               public string cardType { get; set;}
               public bool playedOne { get; set; }
               public string fromCC { get; set; }
               public string toCC { get; set; }
               


        }
        
        private List<CardAction> cardActionGen(List<imCardAction> acts){
            List<CardAction> ret = new List<CardAction>();
            foreach (var act in acts)
            {
                if(act.type.Equals("changeMetric")){
                    ret.Add(new ChangeMetricCount(act.metricID,act.incrementBy, game));
                }
                //if (act.type.Equals("firstTimeGet"))
                //{
                //    ret.Add(new FirstTimeGet(act.faction, act.cardType,act.metricID, act.incrementBy, game));
                //}
                 if (act.type.Equals("forEachCardType"))
                {
                    ret.Add(new ForEachCardType(act.faction, act.cardType, act.playedOne, act.metricID, act.incrementBy, game));
                }
               //if (act.type.Equals("moveFromTo"))
               // {
                  
               //     ret.Add(new MoveFromTo(act.fromCC, act.toCC,act.userChoice,act.optional,game));
               // }
               
            }
        return ret;
        }
        private Card fileToCard(String file, String path)
        {
            var json = System.IO.File.ReadAllText(file);
           
            imCard card = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<imCard>(json);
            System.Drawing.Bitmap image = null;
            string currentDirName = @"" + System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 10) + "\\CardSets\\" + path + card.cardImage;
            if (card.cardImage != "")
            {
                image = new System.Drawing.Bitmap(currentDirName);
            }
            
            return new Card(game, card.cardName, image, card.runeCost, card.powerCost, card.endGameHonorGain, card.faction, card.cardType,
                 cardActionGen(card.actions));
            
        }
    }

}
