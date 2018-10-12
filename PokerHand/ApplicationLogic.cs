using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PokerHand
{
    public class ApplicationLogic
    {
        /// <summary>
        /// Pre Process File
        /// </summary>
        /// 
        /// <param name="filename"></param>
        public static bool PreProcessFile(string filename)
        {
            if (File.Exists(filename))
            {

                var fileContents = System.IO.File.ReadAllLines(filename);
                string[] playingCards;

                // Check All Cards Are Valid Cards.
                foreach (string deal in fileContents)
                {
                    //Helpers.Display(deal,1);
                    playingCards = deal.Split(" ");

                    foreach (var card in playingCards)
                    {

                        if (!CheckCard(card))
                        {
                            Helpers.Display(card + " is not a valid card!", 2);
                            return false;
                        }
                    }

                    // Check there are no duplicate cards in each deal

                    var result = playingCards.Distinct();
                    if (result.Count() < 5)
                    {
                        Helpers.Display(deal + " is not a valid hand, there are some duplicate cards in play.", 2);
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckCard(string card)
        {
            return PokerHand.Program.Store.ContainsValue(card);
        }

        public static void ProcessFile(string filename)
        {
            if (File.Exists(filename))
            {
                var fileContents = System.IO.File.ReadAllLines(filename);
                string[] playingCards;

                // Check All Cards Are Valid Cards.
                foreach (string deal in fileContents)
                {
                    Helpers.Display("", 2);
                    Helpers.Display(deal, 1);
                    playingCards = deal.Split(" ");
                    processHand(playingCards);

                }

            }

        }

        private static void processHand(string[] playingCards)
        {
            // check rules

            //  High card
            checkIfHighCard(playingCards);
            //  One pair
            checkIfOnePair(playingCards);
            //  Two pair
            checkIfATwoPair(playingCards);
            //  Three of a kind
            checkIfThreeOfAKind(playingCards);
            //  Straight
            //  checkIfAStraightAcesHigh(playingCards);
            //   checkIfAStraightAcesLow(playingCards);
            //  Flush
            checkIfFlush(playingCards);
            //  Full house
            checkIfAFullHouse(playingCards);
            //  Four of a kind
            checkIfFourOfAKind(playingCards);
            //  Straight flush
            checkIfAStraightFlush(playingCards);
            //  Royal Flush
            checkIfARoyalFlush(playingCards);
        }

        private static void checkIfATwoPair(string[] playingCards)
        {

        }
        private static void checkIfARoyalFlush(string[] playingCards)
        {

        }
        private static void checkIfAStraightFlush(string[] playingCards)
        {

        }
        private static void checkIfAFullHouse(string[] playingCards)
        {

        }
        private static void checkIfAStraightAcesHigh(string[] playingCards)
        {
            int cardlength = 0;
            int cardValue = 0;
            List<int> cards = new List<int>();
            foreach (var card in playingCards)
            {

                cardlength = card.Length - 1;
                cardValue = int.Parse(EvaluateCard(card.Substring(0, cardlength), cardlength));
                cards.Add(cardValue);

            }

            int cardCount = 0;

            // If the cards are in order then its a straight
            cardCount = cards.GroupBy(card => card).Count();

            if (cardCount == 5)
            {
                bool isConsecutive = cards.Select((i, j) => i - j).Distinct().Skip(1).Any();

                if (isConsecutive)
                {
                    Helpers.Display("Poker Hand : Straight (Aces High)", 1);
                }
            }
        }
        private static void checkIfAStraightAcesLow(string[] playingCards)
        {
            int cardlength = 0;
            string cardValue;
            List<int> cards = new List<int>();
            foreach (var card in playingCards)
            {

                cardlength = card.Length - 1;
                cardValue = EvaluateCard(card.Substring(0, cardlength), cardlength);
                if (cardValue == "14")
                {
                    cardValue = "1";
                }
                cards.Add(int.Parse(cardValue));

            }

            int cardCount = 0;

            // If the cards are in order then its a straight
            cardCount = cards.GroupBy(card => card).Count();

            if (cardCount == 5)
            {
                bool isConsecutive = cards.Select((i, j) => i - j).Distinct().Skip(1).Any();


                if (isConsecutive)
                {
                    Helpers.Display("Poker Hand : Straight (Aces low)", 1);
                }
                //     

            }
        }
        private static void checkIfFlush(string[] playingCards)
        {
            int cardlength = 0;
            List<string> cards = new List<string>();
            foreach (var card in playingCards)
            {
                // Helpers.Display(EvaluateCard(card),2);
                cardlength = card.Length;
                cards.Add(card.Substring(cardlength - 1, 1));

            }

            int cardCount = 0;

            // If there is just 1 card suit, then its a full house
            cardCount = cards.GroupBy(card => card).Count();

            if (cardCount == 1)
            {
                Helpers.Display("Poker Hand : Flush", 1);

            }
        }
        private static void checkIfOnePair(string[] playingCards)
        {
            int cardlength = 0;
            List<string> cards = new List<string>();
            foreach (var card in playingCards)
            {
                // Helpers.Display(EvaluateCard(card),2);
                cardlength = card.Length - 1;
                cards.Add(EvaluateCard(card.Substring(0, cardlength), cardlength));

            }

            int cardCount = 0;

            // If there are 4 unique cards, then there is one pair
            cardCount = cards.GroupBy(card => int.Parse(card)).Count();

            if (cardCount == 4)
            {
                Helpers.Display("Poker Hand : One Pair", 1);

            }

        }
        private static void checkIfFourOfAKind(string[] playingCards)
        {
            int cardlength = 0;
            List<string> cards = new List<string>();
            foreach (var card in playingCards)
            {
                // Helpers.Display(EvaluateCard(card),2);
                cardlength = card.Length - 1;
                cards.Add(EvaluateCard(card.Substring(0, cardlength), cardlength));

            }

            int cardCount = 0;

            // If there are 2 unique cards, then there is four of a kind
            cardCount = cards.GroupBy(card => int.Parse(card)).Count();

            if (cardCount == 2)
            {
                // check if there are four cards the same
                // Need to check its not a full house
                Helpers.Display("Poker Hand : Four of a kind", 1);

            }

        }
        private static void checkIfThreeOfAKind(string[] playingCards)
        {
            int cardlength = 0;
            List<string> cards = new List<string>();
            foreach (var card in playingCards)
            {
                // Helpers.Display(EvaluateCard(card),2);
                cardlength = card.Length - 1;
                cards.Add(EvaluateCard(card.Substring(0, cardlength), cardlength));

            }

            int cardCount = 0;

            // If there are 3 unique cards, then there are three of a kind
            
            cardCount = cards.GroupBy(card => int.Parse(card)).Count();

            if (cardCount == 3)
            {

                // Need to check the hand is not two pairs.
                Helpers.Display("Poker Hand : Three of a kind", 1);

            }

        }
        private static void checkIfHighCard(string[] playingCards)
        {
            List<string> cards = new List<string>();
            int cardlength = 0;
            foreach (var card in playingCards)

            {
                // Helpers.Display(EvaluateCard(card),2);
                cardlength = card.Length - 1;
                cards.Add(EvaluateCard(card.Substring(0, cardlength), cardlength));

            }

            int cardCount = 0;
            string highestCard = "";
            // If there are 5 unique cards, then there a highcard
            cardCount = cards.GroupBy(card => int.Parse(card)).Count();
            List<String> list;
            if (cardCount == 5)
            {
                list = cards.OrderByDescending(x => int.Parse(x)).ToList();
                highestCard = list.First();
                Helpers.Display("Poker Hand : High Card ", 1);

            }

        }

        public static string EvaluateCard(string card, int length)
        {
            string singleChar;
            singleChar = card.Substring(0, length);
            int num1;
            bool result = int.TryParse(singleChar, out num1);
            if (result == false)

            {
                switch (singleChar)
                {
                    case "J":
                        singleChar = "11";
                        break;
                    case "Q":
                        singleChar = "12";
                        break;
                    case "K":
                        singleChar = "13";
                        break;
                    case "A":
                        singleChar = "14";
                        break;
                    default:
                        break;
                }
            }

            return singleChar;
        }

        public static void InitialiseCardDeck()
        {

            Dictionary<int, String> Cards = new Dictionary<int, String>();
            int index = 0;
            foreach (string suitname in Enum.GetNames(typeof(Enums.Suit)))
            {

                // Add Numeric Playing Cards    
                for (int i = 2; i < 11; i++)
                {
                    index++;
                    PokerHand.Program.Store.Add(index, i.ToString() + suitname);
                }

                // Add J,Q,K,A

                // Jack
                index++;

                PokerHand.Program.Store.Add(index, "J" + suitname);
                // Queen
                index++;

                PokerHand.Program.Store.Add(index, "Q" + suitname);
                // King
                index++;

                PokerHand.Program.Store.Add(index, "K" + suitname);
                // Ace
                index++;

                PokerHand.Program.Store.Add(index, "A" + suitname);
            }

        }


    }


}
