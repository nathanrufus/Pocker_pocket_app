using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerPocket.Models
{
    public class DeckModel
    {
        private static readonly string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private Stack<CardModel> _cards;

        public DeckModel()
        {
            _cards = new Stack<CardModel>(Suits.SelectMany(suit => Ranks.Select(rank => new CardModel { Suit = suit, Rank = rank })).OrderBy(card => Guid.NewGuid()));
        }

        public CardModel DealCard()
        {
            return _cards.Pop();
        }

        public void Shuffle()
        {
            _cards = new Stack<CardModel>(_cards.OrderBy(card => Guid.NewGuid()));
        }
    }
}
