using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameLibrary.Models;
using System.Net;
using BGGwrapper.Objects;
using BGGwrapper.Client;
using System.Linq.Expressions;

namespace GameLibrary.Controllers
{
    public class BoardGameController : Controller
    {
        private GameLibraryContext db = new GameLibraryContext();

        public ActionResult Index(string gameDomain, string searchString, int? gameMinPlayers)
        {
            //Domain List//
            var DomainLst = new List<string>();

            var existingDomains = from p in db.BoardGameSubdomains
                                  orderby p.value
                                  select p.value;

            DomainLst.AddRange(existingDomains.Distinct());
            ViewBag.gameDomain = new SelectList(DomainLst);

            var MinPlayersLst = new List<int>();



            var minPlayers = Enumerable.Range(1, 10).ToList();

            MinPlayersLst.AddRange(minPlayers.Distinct());
            ViewBag.gameMinPlayers = new SelectList(MinPlayersLst);

            var bgames = from s in db.BoardGames
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                bgames = bgames.Where(s => s.BoardGameName.FirstOrDefault(x => x.isPrimary == true).name.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!String.IsNullOrEmpty(gameDomain))
            {
                bgames = from s in bgames
                         join x in db.BoardGameSubdomains on s.ObjectID equals x.BoardGame.ObjectID
                         where x.value == gameDomain
                         select s;
            }

            if (gameMinPlayers != null)
            {
                bgames = (from s in bgames
                         where gameMinPlayers >= s.minPlayers && gameMinPlayers <= s.maxPlayers
                         select s);
            }

            

            return View(bgames);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardgame = db.BoardGames.Find(id);
            if (boardgame == null)
            {
                return HttpNotFound();
            }
            return View(boardgame);
        }

        //[Authorize(Users = "Admin")]
        public ActionResult UpdateGamesView()
        {
            return View();
        
        }


        //[Authorize(Users = "Admin")]
        public ActionResult UpdateGames()
        {
            IBGGClient kingmakers = new BGGXMLClient();

            List<CollectionItem> collection = new List<CollectionItem>();
            collection = kingmakers.getUserCollection("kingmakers");

            List<CollectionItem> SortedCollection = collection.OrderBy(o => o.ObjectID).ToList();

            foreach (CollectionItem game in SortedCollection)
            {
                if (db.CollectionItems.Find(game.ObjectID) == null)
                {
                    db.CollectionItems.Add(game);
                    db.SaveChanges();
                }

            }

            var SortedBoardGame = SortedCollection.ToArray();
            List<int> list = new List<int>();



            foreach (CollectionItem x in SortedBoardGame)
            {
                list.Add(x.ObjectID);
            }

            int[] terms = list.ToArray();

            List<BoardGame> boardgames = kingmakers.getBoardGame(terms);

            string br1 = "<br/><br/>";
            string br2 = "<br/>";
            string br3 = "<br/>";


            foreach (var item in boardgames)
            {
                item.description = item.description.Replace(br1, string.Empty);
                item.description = item.description.Replace(br2, string.Empty);
                item.description = item.description.Replace(br3, string.Empty);
            }


            foreach (BoardGame game in boardgames)
            {
                if (db.BoardGames.Find(game.ObjectID) == null)
                {
                    db.BoardGames.Add(game);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}