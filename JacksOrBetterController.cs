using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoPoker2.Business;
using VideoPoker2.Models;
using VideoPoker2.ViewModels;

namespace VideoPoker2.Controllers
{
    public class JacksOrBetterController : Controller
    {
        private VideoPokerEntities context = new VideoPokerEntities();
        private static List<Card> _dealCards = new List<Card>();
        private static List<Card> _drawCards = new List<Card>();
        private static UserAccount _userAccountInfo = new UserAccount();

        public ActionResult Index()
        {
            _userAccountInfo = context.UserAccounts.Where(u => u.UserId == 1).FirstOrDefault();
            GameViewModel gameStatus = new GameViewModel
            {
                Message = "Good Luck",
                GameOver = false,
                Paytable = context.Payouts.ToList(),
                Credits = (int)_userAccountInfo.Credits
                
            };
            return View(gameStatus);
        }

        public ActionResult Deal(int betAmt)
        {
            _userAccountInfo = context.UserAccounts.Where(u => u.UserId == 1).FirstOrDefault();
            List<int> shuffle = ShuffleDeck();
            _dealCards = new List<Card>();
            foreach (var item in shuffle)
            {
                var card = context.Cards.Where(c => c.Id == item).FirstOrDefault();
                _dealCards.Add(card);
            }
            foreach (var item in _dealCards)
            {
                item.ImageName = item.ImageName.Insert(0, "/Images/");
            }
            GameViewModel gameStatus = new GameViewModel
            {
                Message = "Hold / Draw 1 to 5 Cards",
                Hand = _dealCards.Take(5).ToList(),
                GameOver = false,
                BetAmount = betAmt            
            };
            gameStatus.Paytable = context.Payouts.ToList();
            gameStatus.Credits = (int)_userAccountInfo.Credits - gameStatus.BetAmount;
            HandInfo.EvaluateHand(gameStatus, _dealCards, _userAccountInfo);
            return Json(gameStatus, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test(string name, string location)
        {
            return View();
        }
        public ActionResult Draw(int[] arr, int betAmt)
        {
            _drawCards = new List<Card>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    _drawCards.Add(_dealCards[i + 5]);
                else
                    _drawCards.Add(_dealCards[i]);
            }
            GameViewModel gameStatus = new GameViewModel
            {
                Message = "Game Over",
                Hand =_drawCards,
                GameOver = true,
                Credits = (int)_userAccountInfo.Credits,
                BetAmount = betAmt,
                Paytable=context.Payouts.ToList()
            };
            HandInfo.EvaluateHand(gameStatus, _drawCards, _userAccountInfo);
            return Json(gameStatus, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeBetAmount(int betAmt)
        {
            GameViewModel gameStatus = new GameViewModel
            {
                BetAmount = betAmt
            };
            if (betAmt < 5)
                gameStatus.BetAmount++;
            else
                gameStatus.BetAmount = 1;
            return Json(gameStatus, JsonRequestBehavior.AllowGet);
        }

        public List<int> ShuffleDeck()
        {
            List<int> cards = new List<int>();
            int count = 0;
            Random r = new Random();
            cards.Clear();
            do
            {
                int card = r.Next(0, 52);
                if (!cards.Contains(card))
                {
                    cards.Add(card);
                    count++;
                }
            } while (count < 52);
            return cards.Take(10).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}