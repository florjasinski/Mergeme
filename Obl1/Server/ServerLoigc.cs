using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.DataAccess;
using Server.Domain;

namespace Server
{
    public class ServerLoigc
    
    {
        private Repository _dataStorage;

        public ServerLoigc()
        {
            _dataStorage = Repository.Instance;
        }

        public void RegisterUser(User user)
        {

            UserValidation(user);
            if (ExistUser(user.UserName))
            {
                Console.WriteLine("The user with username '" + user.UserName + "' already exists.");
            }
            else
            {

                _dataStorage.AddUser(user);
            }
        }

        public bool ExistUser(string userName)
        {
            return _dataStorage.Exist(userName);
        }

        private void UserValidation(User user)
        {
            if (String.IsNullOrWhiteSpace(user.UserName) || String.IsNullOrWhiteSpace(user.Password))
            {
                Console.WriteLine("This field cannot be empty.");
            }
        }

        public User LoginUser(string username, string password)
        {
            User user = GetUser(username);
            if (!user.Password.Equals(password))
            {
                Console.WriteLine("Incorrect credentials, please try again.");
            }

            return user;
        }
        

        public User GetUser(string userName)
        {
            UserNameValidation(userName);

            User user = _dataStorage.GetUser(userName);
            if (user == null)
            {
                Console.WriteLine("The user does not exit");
            }

            return user;
        }

        private void UserNameValidation(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new NullReferenceException();
            }
        }

        public void DeleteGame(string title)
        {
            
             _dataStorage.RemoveGame(title);   
            
        }

        public void ListGames()
        {
            var games = _dataStorage.GetGames();
            foreach (var game in games)
            {
                Console.WriteLine($"Game: {game.Title}, Genre: {game.Genre}, Year: {game.Year}");
            }
        }

        public void AddGame(Game game)
        {
            if (!_dataStorage.GetGames().Any(g => g.Title == game.Title))
            {
                _dataStorage.AddGame(game);
                
            }
            else
            {
                Console.WriteLine("A game with the title '" + game.Title + "' already exists.");
            }
        }

        public void UpdateGame(string title, string newTitle, string genre, int releaseYear, string platform, string publisher, int availableUnits, string coverImagePath = null)
        {
            Game game = _dataStorage.GetGameDetails(title);
            if (game != null)
            {
                
                game.Title = newTitle;
                game.Genre = genre;
                game.Year = releaseYear;
                game.Platform = platform;
                game.Publisher = publisher;
                game.AvailableUnits = availableUnits;
                game.CoverImagePath = coverImagePath;

                Console.WriteLine($"Game '{title}' updated successfully.");
            }
        }


        public List<Game> SearchGames(string criterion, string value)
        {
            var games = _dataStorage.GetGames();
            switch (criterion.ToLower())
            {
                case "rock":
                    return games.Where(g => g.Genre.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
                case "pop":
                    return games.Where(g => g.Platform.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
                default:
                    Console.WriteLine("Invalid search criterion. Please use a genre");
                    return new List<Game>();
            }
        }


        public bool PurchaseGame(string title, int quantity)
        {
            Game game = _dataStorage.GetGameDetails(title);
            if (game != null)
            {
                if (game.AvailableUnits >= quantity)
                {
                    game.AvailableUnits -= quantity;  
                    Console.WriteLine($"Game '{title}' purchased successfully. Units left: {game.AvailableUnits}");
                    return true;
                }
            }
            return false;
        }


        public void RateGame(string title, int score, string comment)
        {
            Game game = _dataStorage.GetGameDetails(title);
            if (game != null)
            {
                if (score < 1 || score > 10)
                {
                    Console.WriteLine("Invalid rating. Please provide a score between 1 and 10.");
                    return;
                }
                Rating rating = new Rating(score, comment);
                _dataStorage.AddRating(rating);
                Console.WriteLine($"Game '{title}' rated successfully.");
            }
            
        }   

    }
}
