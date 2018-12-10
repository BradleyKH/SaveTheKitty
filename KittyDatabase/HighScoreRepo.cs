using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KittyDatabase.Models;

namespace KittyDatabase
{
    public class HighScoreRepo
    {
        public static string connectionString { get; set; }

        public static List<HighScore> GetHighScores()
        {
            var conn = new MySqlConnection(connectionString);
            var HighScores = new List<HighScore>();

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, player, score, date FROM high_scores ORDER BY score DESC LIMIT 20;";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var hs = new HighScore()
                    {
                        Id = (int)reader["id"],
                        Player = reader["player"].ToString(),
                        Score = (int)reader["score"],
                        Date = Convert.ToDateTime(reader["date"])
                    };

                    HighScores.Add(hs);
                }

                return HighScores;
            }
        }

        public static int CreateHighScore(HighScore hs)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();
                var today = DateTime.Today;
                var todayStr = today.Year + "-" + today.Month + "-" + today.Day;

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO high_scores (player, score, date) " +
                    "VALUES (@player, @score, @date);";
                cmd.Parameters.AddWithValue("player", hs.Player);
                cmd.Parameters.AddWithValue("score", hs.Score);
                cmd.Parameters.AddWithValue("date", todayStr);

                return cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteHighScore(int id)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM high_scores WHERE id = @id;";
                cmd.Parameters.AddWithValue("id", id);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
