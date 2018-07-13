using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Memory.Pages
{
    public class IndexModel : PageModel
    {
        public BoardCreator boardCreator = new BoardCreator();

        public IndexModel()
        {
            boardCreator.AddCardToList(new Card("images/bobr.jpg", 0));
            boardCreator.AddCardToList(new Card("images/bocian.jpg", 1));
            boardCreator.AddCardToList(new Card("images/dzik.jpg", 2));
            boardCreator.AddCardToList(new Card("images/jeż.jpg", 3));
            boardCreator.AddCardToList(new Card("images/kuna.jpg", 4));
            boardCreator.AddCardToList(new Card("images/lis.jpg", 5));
            boardCreator.AddCardToList(new Card("images/pliszka.jpg", 6));
            boardCreator.AddCardToList(new Card("images/niedzwiedz.jpg", 7));
            boardCreator.AddCardToList(new Card("images/sowa.jpg", 8));
            boardCreator.AddCardToList(new Card("images/sroka.jpg", 9));
            boardCreator.AddCardToList(new Card("images/wiewiorka.jpg", 10));
            boardCreator.AddCardToList(new Card("images/wrobel.jpg", 11));
            boardCreator.AddCardToList(new Card("images/zajac.jpg", 12));            
        }
    }
}
