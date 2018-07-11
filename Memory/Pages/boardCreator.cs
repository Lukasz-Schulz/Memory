using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory.Pages
{
    public class BoardCreator
    {
        private List<Card> ListOfAvailibleCards = new List<Card>();
        private List<Card> ListOfSelectedCardsWithLocalisations = new List<Card>();

        public string getJsonOfCards(int numberOfCards)
        {
            AddSelectedCardsToListAndGiveThemLocalisation(numberOfCards);

            string jsonString="[";            
            for(int i = 0; i < ListOfSelectedCardsWithLocalisations.Count; i++)
            {
                jsonString += JsonConvert.SerializeObject(ListOfSelectedCardsWithLocalisations[i]);
                if (i != ListOfSelectedCardsWithLocalisations.Count-1)
                {
                    jsonString += ", ";
                }
                else
                {
                    jsonString += "]";
                }
            }

            return jsonString;
        }

        public void AddCardToList(Card newCard)
        {
            ListOfAvailibleCards.Add(newCard);
        }

        public void AddSelectedCardsToListAndGiveThemLocalisation(int numberOfCards)
        {
            List<int> listOfLocalisations = new List<int>();
            List<int> listOfSelectedIds = DrawCardsIds(numberOfCards);
            for(int i = 0; i < listOfSelectedIds.Count; i++)
            {
                for(int j = 0; j < ListOfAvailibleCards.Count; j++)
                {
                    if(listOfSelectedIds[i] == ListOfAvailibleCards[j].Id)
                    {
                        AddFirstLocalisation(numberOfCards, listOfLocalisations, j);
                        AddSecondLocalisation(numberOfCards, listOfLocalisations, j);

                        ListOfSelectedCardsWithLocalisations.Add(ListOfAvailibleCards[j]);
                    }
                }
            }
        }

        void AddFirstLocalisation(int numberOfCards, List<int> listOfLocalisations, int currentIndex)
        {
            int firstRandom = new Random().Next(0, numberOfCards * 2);
            if (!(listOfLocalisations.Contains(firstRandom)))
            {
                listOfLocalisations.Add(firstRandom);
                ListOfAvailibleCards[currentIndex].FirstLocalisation = firstRandom;
            }
            else
            {
                AddFirstLocalisation(numberOfCards, listOfLocalisations, currentIndex);
            }
        }

        void AddSecondLocalisation(int numberOfCards, List<int> listOfLocalisations, int currentindex)
        {
            int secondRandom = new Random().Next(0, numberOfCards * 2);
            if (!(listOfLocalisations.Contains(secondRandom)))
            {
                listOfLocalisations.Add(secondRandom);
                ListOfAvailibleCards[currentindex].SecondLocalisation = secondRandom;
            }
            else
            {
                AddSecondLocalisation(numberOfCards, listOfLocalisations, currentindex);
            }
        }

            public List<int> DrawCardsIds(int numberOfCards)
        {
            List<int> drawnCardsIds = new List<int>();

            for (int i = 0; i < numberOfCards; i++)
            {
                CheckIfCardIdIsAlreadyInDeck(drawnCardsIds);
            }

            return drawnCardsIds;
        }

        private void CheckIfCardIdIsAlreadyInDeck(List<int> list)
        {
            int numberToCheck = new Random().Next(0, ListOfAvailibleCards.Count);

            if (!(list.Contains(numberToCheck)))
            {
                list.Add(numberToCheck);
            }
            else
            {
                CheckIfCardIdIsAlreadyInDeck(list);
            }
        }
    }
}
