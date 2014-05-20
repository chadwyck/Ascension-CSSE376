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
        public string currentDirName;
        
        public CardImport(Game gme, string pth) {
            game = gme;
            
        }
        public void cardImportP(Game gme, String path, PortalDeck deck)
        {


            string currentDirName = @"" + System.IO.Directory.GetCurrentDirectory();
            if (currentDirName.Contains("UnitTestProject1"))
            {
                currentDirName = currentDirName.Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 26) + "Ascension\\CardSets\\" + path;
            }
            else
            {
                currentDirName = currentDirName.Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 19) + "Ascension\\CardSets\\" + path;
            }
           
            
            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.txt");

            foreach (string cardFile in files)
            {
                
                deck.add(fileToCard(cardFile,path));
            }
            
            
            
         
        }
        public void cardImportH(Game gme, String path, HandDeck deck)
        {

            
            string currentDirName = @"" + System.IO.Directory.GetCurrentDirectory();
            if (currentDirName.Contains("UnitTestProject1"))
            {
                currentDirName = currentDirName.Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 26) + "Ascension\\CardSets\\" + path;
            }else {
                currentDirName = currentDirName.Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 19) + "Ascension\\CardSets\\" + path;
            }
           
            System.Console.WriteLine(currentDirName);
            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.txt");

            foreach (string cardFile in files)
            {
                var card = fileToCard(cardFile, path);
                deck.add(card);
            }
          
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
               public int atMost { get; set; }
               


        }
        
        private List<CardAction> cardActionGen(List<imCardAction> acts){
            List<CardAction> ret = new List<CardAction>();
            foreach (var act in acts)
            {
                if(act.type.Equals("changeMetric")){
                    ret.Add(new ChangeMetricCount(act.metricID,act.incrementBy, game));
                }
                if (act.type.Equals("firstTimeGet"))
                {
                    ret.Add(new FirstTimeGet(act.faction, act.cardType, act.metricID, act.incrementBy, game));
                }
                 if (act.type.Equals("forEachCardType"))
                {
                    ret.Add(new ForEachCardType(act.faction, act.cardType, act.playedOne, act.metricID, act.incrementBy, game));
                }
               if (act.type.Equals("moveFromTo"))
                {
                  
                    ret.Add(new MoveFromTo(act.fromCC, act.toCC,act.userChoice,act.optional,game));
                }
                if(act.type.Equals("allConstructsMechana"))
                {
                    ret.Add(new AllConstructsMechana(game));
                }
                if (act.type.Equals("mechanaDirectToPlay"))
                {
                    ret.Add(new MechanaDirectToPlay(game));
                }
                if (act.type.Equals("mechanaDraw"))
                {
                    ret.Add(new MechanaDraw(game));
                }
                if (act.type.Equals("copyActions"))
                {
                    ret.Add(new CopyActions(game));
                }
                if (act.type.Equals("moveBlahOrLess"))
                {
                    ret.Add(new MoveBlahOrLess(act.fromCC,act.cardType,act.metricID,act.atMost,game));
                }
                if (act.type.Equals("banishToTakeTurn"))
                {
                    ret.Add(new BanishToTakeTurn(game));
                }
                if (act.type.Equals("takeFromOpponent"))
                {
                    ret.Add(new TakeFromOpponent(game));
                }
                if (act.type.Equals("chooseMetricToChange"))
                {
                    ret.Add(new ChooseMetricToChange(game));
                }
                if (act.type.Equals("drawIfConstructs"))
                {
                    ret.Add(new DrawIfConstructs(game));
                }
                if (act.type.Equals("gainForEachFaction"))
                {
                    ret.Add(new GainForEachFaction(game));
                }
               
            }
        return ret;
        }
        private Card fileToCard(String file, String path)
        {
            var json = System.IO.File.ReadAllText(file);
           
            imCard card = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<imCard>(json);
            System.Drawing.Bitmap image = null;
             string currentDirName = @"" + System.IO.Directory.GetCurrentDirectory();
            if(currentDirName.Contains("UnitTestProject1")){
                currentDirName = currentDirName.Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 26) + "Ascension\\CardSets\\" + path;
            }else {
                currentDirName = currentDirName.Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 19) + "Ascension\\CardSets\\" + path;
            }
        
           
            if (card.cardImage != "")
            {
                image = new System.Drawing.Bitmap(currentDirName+ card.cardImage);
            }

            Card newCard = new Card(game, card.cardName, image, card.runeCost, card.powerCost, card.endGameHonorGain, card.faction, card.cardType,
                 cardActionGen(card.actions));

            return newCard;
            
        }
    }

}
