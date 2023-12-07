using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public class Day7 : Day66
    {
        enum Card
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }
        enum CardType
        {
            HighCard = 1,
            OnePair = 2,
            TwoPair = 3,
            ThreeOfKind = 4,
            FullHouse = 5,
            FourOfKind = 6,
            FiveOfKind = 7
        }
        class Hand : IComparable<Hand>
        {
            public Card[] Cards;
            public ulong Bid;
            public CardType CardType;
            public Hand()
            {
                Cards = new Card[5];
            }

            public int CompareTo(Hand other)
            {
                if (CardType == other.CardType)
                {
                    for (int i = 0; i < Cards.Length; i++)
                    {
                        int comparison = Cards[i].CompareTo(other.Cards[i]);
                        if (comparison != 0)
                        {
                            return comparison;
                        }
                    }
                }
                else
                {
                    return CardType.CompareTo(other.CardType);
                }
                return 0;
            }
        }
        string[] _lines;
        Hand[] _arrayOfHands;
        private Card CharToEnum(char card)
        {
            switch (card)
            {
                case '2':
                    return Card.Two;
                case '3':
                    return Card.Three;
                case '4':
                    return Card.Four;
                case '5':
                    return Card.Five;
                case '6':
                    return Card.Six;
                case '7':
                    return Card.Seven;
                case '8':
                    return Card.Eight;
                case '9':
                    return Card.Nine;
                case 'T':
                    return Card.Ten;
                case 'J':
                    return Card.Jack;
                case 'K':
                    return Card.King;
                case 'Q':
                    return Card.Queen;
                case 'A':
                    return Card.Ace;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        public override void ParseInput(string strInput)
        {
            _lines = strInput.Split("\r\n");
            _arrayOfHands = new Hand[_lines.Length];
            for (int i = 0; i < _lines.Length; i++)
            {
                _arrayOfHands[i] = ParseHand(_lines[i]);
            }
        }

        private Hand ParseHand(string line)
        {
            Hand hand = new Hand();
            hand.Bid = ulong.Parse(line.Split(' ')[1]);
            hand.Cards = line.Split(' ')[0].Select(eachCard => CharToEnum(eachCard)).ToArray();
            hand.CardType = DefineHandType(hand.Cards);
            return hand;
        }

        private CardType DefineHandType(Card[] cards)
        {
            Card[] distinctCards = cards.Distinct().ToArray();

            switch (distinctCards.Count())
            {
                case 1:
                    return CardType.FiveOfKind;
                case 2:
                    if (cards.Where(x => x == distinctCards[0]).Count() == 4 ||
                        cards.Where(x => x == distinctCards[1]).Count() == 4)
                    {
                        return CardType.FourOfKind;
                    }
                    return CardType.FullHouse;
                case 3:
                    if (cards.Where(x => x == distinctCards[0]).Count() == 3 ||
                        cards.Where(x => x == distinctCards[1]).Count() == 3 ||
                        cards.Where(x => x == distinctCards[2]).Count() == 3)
                    {
                        return CardType.ThreeOfKind;
                    }
                    return CardType.TwoPair;
                case 4:
                    return CardType.OnePair;
                case 5:
                    return CardType.HighCard;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object StarOne()
        {
            ulong totalWinnings = 0;
            Array.Sort(_arrayOfHands);
            for (int i = 0; i < _arrayOfHands.Length; i++)
            {
                var rank = i + 1;
                totalWinnings += (ulong)rank * _arrayOfHands[i].Bid;
            }
            return totalWinnings;
        }


        public override object StarTwo()
        {
            ulong totalWinnings = 0;
            foreach (var hand in _arrayOfHands)
            {
                hand.CardType = DefineHandTypeStarTwoRules(hand.Cards);
            }
            Array.Sort(_arrayOfHands, new HandComparerStarTwo());
            for (int i = 0; i < _arrayOfHands.Length; i++)
            {
                var rank = i + 1;
                totalWinnings += (ulong)rank * _arrayOfHands[i].Bid;
            }

            return totalWinnings;
        }

        private CardType DefineHandTypeStarTwoRules(Card[] cards)
        {
            if (!cards.Contains(Card.Jack))
            {
                return DefineHandType(cards);
            }
            else
            {
                //Card.Jack is now Joker
                int jokerCount = cards.Count(x => x == Card.Jack);
                Card[] distinctCards = cards.Distinct().ToArray();
                Card[] distinCardsWithoutJoker = cards.Where(card => card != Card.Jack).Distinct().ToArray();

                switch (distinctCards.Count())
                {
                    case 1:
                        return CardType.FiveOfKind;
                    case 2:
                        return CardType.FiveOfKind;
                    case 3:
                        if (cards.Where(x => x == distinCardsWithoutJoker[0]).Count() + jokerCount == 4 ||
                            cards.Where(x => x == distinCardsWithoutJoker[1]).Count() + jokerCount == 4)
                        {
                            return CardType.FourOfKind;
                        }
                        return CardType.FullHouse;
                    case 4:
                        if (cards.Where(x => x == distinCardsWithoutJoker[0]).Count() + jokerCount == 3 ||
                            cards.Where(x => x == distinCardsWithoutJoker[1]).Count() + jokerCount == 3 ||
                            cards.Where(x => x == distinCardsWithoutJoker[2]).Count() + jokerCount == 3)
                        {
                            return CardType.ThreeOfKind;
                        }
                        return CardType.TwoPair;
                    case 5:
                        return CardType.OnePair;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }
        }
        class HandComparerStarTwo : Comparer<Hand>
        {
            public override int Compare(Hand x, Hand y)
            {
                CardType CardType = x.CardType;

                if (CardType == y.CardType)
                {
                    for (int i = 0; i < x.Cards.Length; i++)
                    {
                        int leftCard = x.Cards[i] == Card.Jack ? 1 : (int)x.Cards[i];
                        int rightCard = y.Cards[i] == Card.Jack ? 1 : (int)y.Cards[i];
                        int comparison = leftCard.CompareTo(rightCard);
                        if (comparison != 0)
                        {
                            return comparison;
                        }
                    }
                }
                else
                {
                    return CardType.CompareTo(y.CardType);
                }
                return 0;
            }
        }

    }
}