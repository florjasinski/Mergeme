using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.DataAccess;
using Server.Domain;

namespace Server.DataAccess
{
    public class Repository
    {

        private static Repository instance = null;
        private static readonly object locker = new object();


        private List<User> _users;
        private List<Game> _games;
        private List<Rating> _ratings;


        private Repository()
        {
            _users = new List<User>();
            _games = new List<Game>();
            _ratings = new List<Rating>();
        }


        public static Repository Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Repository();
                    }
                    return instance;
                }
            }
        }



        public void AddUser(User user)
        {
            lock (locker)
            {
                _users.Add(user);
            }
        }


        public bool Exist(string userName)
        {
            return _users.Any(x => x.UserName == userName);
        }

        public bool AuthenticateUser(string username, string password)
        {
            lock (locker)
            {
                var user = _users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
                return user != null && user.Password == password;
            }
        }

        public void RemoveUser(string username)
        {
            lock (locker)
            {
                var user = _users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                {
                    _users.Remove(user);
                    Console.WriteLine($"User '{username}' has been removed.");
                }
                else
                {
                    Console.WriteLine($"User '{username}' not found.");
                }
            }
        }
        public List<User> GetUsers()
        {
            lock (locker)
            {
                return _users;
            }
        }

        public User GetUser(string userName)
        {
            User user = _users.FirstOrDefault(u => u.UserName.Equals(userName));

            lock (locker)
            {
                return user;
            }
        }


        public List<User> ListAllUsers()
        {
            lock (locker)
            {
                return new List<User>(_users);
            }
        }


        public void AddGame(Game game)
        {
            lock (locker)
            {

                _games.Add(game);

            }
        }

        public void RemoveGame(string title)
        {
            lock (locker)
            {
                var game = _games.FirstOrDefault(g => g.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                if (game != null)
                {
                    _games.Remove(game);

                }
            }
        }


        public Game GetGameDetails(string title)
        {
            lock (locker)
            {
                return _games.FirstOrDefault(g => g.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            }
        }


        public List<Game> GetGames()
        {
            return _games;
        }

        public void AddRating(Rating rating)
        {
            lock (locker)
            {

                _ratings.Add(rating);

            }
        }
    }
}