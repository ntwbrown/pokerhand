using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PokerHand
{
    public class Enums
    {
        // H, D, S, C for Hearts, Diamonds, Spades and Clubs 
        public enum Suit { H, D, S, C };
   
        public enum PokerHands
        {
            [Description("High Card")]
            HighCard =1,
            [Description("One pair")]
            Onepair =2,
            [Description("Two pair")]
            Twopair =3,
            [Description("Three of a kind")]
            Threeofakind =4,
            [Description("Straight")]
            Straight =5,
            [Description("Flush")]
            Flush = 5,
            [Description("Fullhouse")]
            Fullhouse = 6,
            [Description("Fourofakind")]
            Fourofakind = 7,
            [Description("Straight flush")]
            Straightflush = 8,
            [Description("Royal Flush")]
            RoyalFlush = 9

        }      
    }

}
