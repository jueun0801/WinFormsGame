using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    interface CRUD
    {
        int GetMaxId();
        void AddScore(Score score);
        ICollection<Score> GetAllScores();
        /*Score FindScore(int Player);
        void UpdateRecord(int Player, Score score);*/
        //void DeleteScore(Score score);

    }
    class ScoreRepository : CRUD
    {
        ScoreboardEntities2 entities;
        public ScoreRepository()
        {
            entities = new ScoreboardEntities2();
        }

        public void AddScore(Score score)
        {
            entities.Scores.Add(score);
            entities.SaveChanges();
        }

        /*public void DeleteScore(Score score)
        {
            entities.Scores.Remove(score);
            entities.SaveChanges();
        }*/

        /*public Score FindScore(int Player)
        {
            return entities.Scores.Find(Player);
        }*/

        public ICollection<Score> GetAllScores()
        {
            return entities.Scores.ToList();
        }

        public int GetMaxId()
        {
            return entities.Scores.Max(p => p.Player);
        }

        /*public void UpdateRecord(int Player, Score score)
        {
            throw new NotImplementedException();
        }*/
    }
}
