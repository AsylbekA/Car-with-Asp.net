using OnlineStore.DbContext;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class FootballController : Controller
    {
        CarContext db = new CarContext();

        #region Player
        // GET: Football
        public async Task<ActionResult> Index()
        {
            try
            {
                var player = await db.Players.Include(p => p.Team).ToListAsync();
                return View(player.ToList());
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }
            return View();
        }

        public async Task<ActionResult> PlayerDetails(int? Id)
        {
            try
            {
                if (Id.HasValue)
                {
                    Player player = await db.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == Id);
                    if (player == null)
                    {
                        return RedirectToAction("Index");
                    }

                    return View(player);
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreatePlayer()
        {
            try
            {
                SelectList teams = new SelectList(db.Teams, "Id", "Name");
                ViewBag.Teams = teams;
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreatePlayer(Player player)
        {
            try
            {
                if (player != null)
                {
                    db.Players.Add(player);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }
            return HttpNotFound();
        }

        [HttpGet]
        public async Task<ActionResult> EditPlayer(int? Id)
        {
            try
            {
                if (Id == null)
                {
                    return HttpNotFound();
                }
                Player player = await db.Players.FindAsync(Id);
                if (player != null)
                {
                    SelectList team = new SelectList(db.Teams, "Id", "Name");
                    ViewBag.Teams = team;
                    return View(player);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditPlayer(Player player)
        {
            try
            {
                if (player != null)
                {
                    db.Entry(player).State = EntityState.Modified;
                    db.SaveChangesAsync();
                    return RedirectToAction("PlayerDetails", new { Id = player.Id });
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> DeletePlayer(int? Id)
        {
            try
            {
                if (Id.HasValue)
                {
                    Player player = await db.Players.FindAsync(Id);
                    return View(player);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("DeletePlayer")]
        public async Task<ActionResult> DeleteConfirmedPlayer(int? Id)
        {
            try
            {
                if (Id.HasValue)
                {
                    Player player = await db.Players.FindAsync(Id);
                    if (player == null)
                    {
                        return HttpNotFound();
                    }
                    db.Players.Remove(player);
                    db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Teams

        public async Task<ActionResult> ListTeams()
        {
            try
            {
                IEnumerable<Team> team = await db.Teams.ToListAsync();
                return View(team);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }
            return View();
        }

        public ActionResult TeamDetails(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Team team = db.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == id);
                    if (team == null)
                    {
                        return HttpNotFound();
                    }
                    return View(team);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult CreateTeams()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeams(Team team)
        {
            try
            {
                if (team != null)
                {
                    db.Teams.Add(team);
                    db.SaveChangesAsync();
                    return RedirectToAction("ListTeams");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }


            return HttpNotFound();
        }

        [HttpGet]
        public async Task<ActionResult> EditTeam(int? Id)
        {
            try
            {
                if (Id == null)
                {
                    return HttpNotFound();
                }
                Team team = await db.Teams.FindAsync(Id);
                return View(team);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

            return View();
        }

        [HttpPost]
        public ActionResult EditTeam(Team team)
        {
            try
            {
                if (team == null)
                {
                    return RedirectToAction("ListTeams");
                }

                db.Entry(team).State = EntityState.Modified;
                db.SaveChangesAsync();
                return RedirectToAction("ListTeams");

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

        }


        public async Task<ActionResult> DeleteTeams(int? Id)
        {
            try
            {
                if (Id == null)
                {
                    return RedirectToAction("ListTeams");
                }

                Team team = await db.Teams.FindAsync(Id);
                if (team == null)
                {
                    return HttpNotFound();
                }

                return View(team);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }

            return View();
        }

        [HttpPost, ActionName("DeleteTeama")]
        public async Task<ActionResult> DeleteConfirmedTeams(int? Id)
        {
            try
            {
                if (Id == null)
                {
                    return HttpNotFound();
                }

                Team team = await db.Teams.FindAsync(Id);
                if (team != null)
                {
                    db.Teams.Remove(team);
                    db.SaveChangesAsync();
                }
                return View("ListTeams");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                throw;
            }
        }
        #endregion

    }
}