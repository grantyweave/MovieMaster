using MovieMaster;

MovieDbContext Db = new MovieDbContext();

Console.WriteLine("Would you like to search by Genre or Title?");

var userInput = Console.ReadLine().ToLower();

if (userInput == "genre")
{
    Console.WriteLine("What genre would you like?");

    foreach (var genre in GetMovieGenres())
    {
        Console.WriteLine(genre);
    }
    var userSelectedGenre = Console.ReadLine();

    Console.WriteLine("Here are the movies that match your choice.");
    foreach (var movie in SearchByGenre(userSelectedGenre))
    {
        Console.WriteLine(movie.ToString());
    }
}


else if (userInput == "title")
{
    Console.WriteLine("What title would you like?");

    foreach (var title in GetMovieTitles())
    {
        Console.WriteLine(title);
    }
    var userSelectedTitle = Console.ReadLine();
    var userSelectedMovie = SearchByTitle(userSelectedTitle).First();
    Console.WriteLine("Here is your movie.");
    Console.WriteLine(userSelectedMovie.ToString());
    
}


else
{
    Console.WriteLine("Invalid Input");
}

//List<Movie> Movies = GenerateMovies();

//Db.Movies.AddRange(Movies);

//Db.SaveChanges();

List<Movie> GenerateMovies()
{
    List<Movie> Movies = new()
    {
        new Movie { Title = "Gone With The Wind", Genre = "Drama", Runtime = 300, Id = 1 },
        new Movie { Title = "The Wizard of Oz", Genre = "Musical", Runtime = 150, Id = 2 },
        new Movie { Title = "Casablanca", Genre = "Drama", Runtime = 200, Id = 3 },
        new Movie { Title = "Breakfast At Tiffany's", Genre = "Comedy", Runtime = 200, Id = 4 },
        new Movie { Title = "Lawrence of Arabia", Genre = "Drama", Runtime = 200, Id = 5 },
        new Movie { Title = "West Side Story", Genre = "Musical", Runtime = 150, Id = 6 },
        new Movie { Title = "Citizen Kane", Genre = "Drama", Runtime = 250, Id = 7 },
        new Movie { Title = "Psycho", Genre = "Horror", Runtime = 170, Id = 8 },
        new Movie { Title = "Rebel Without a Cause", Genre = "Drama", Runtime = 170, Id = 9 },
        new Movie { Title = "A Raisin in the Sun", Genre = "Drama", Runtime = 200, Id = 10 },
        new Movie { Title = "Laura", Genre = "Drama", Runtime = 140, Id = 11 },
        new Movie { Title = "The Women", Genre = "Drama", Runtime = 120, Id = 12 },
        new Movie { Title = "The Godfather", Genre = "Drama", Runtime = 300, Id = 13 },
        new Movie { Title = "The Best Years of Our Lives", Genre = "Drama", Runtime = 200, Id = 14 },
        new Movie { Title = "Meet Me In St. Louis", Genre = "Drama", Runtime = 200, Id = 15 }
    };
    return Movies;


}

List<Movie> SearchByGenre(string genre)
{
    var movies = Db.Movies.Where(x => x.Genre == genre).ToList();
    return movies;
}

List<Movie> SearchByTitle(string title)
{
    var movies = Db.Movies.Where(x => x.Title == title).ToList();
    return movies;
}

List<string> GetMovieGenres()
{
    var genres = Db.Movies.Select(x => x.Genre).Distinct().ToList();
    return genres;
}

List<string> GetMovieTitles()
{
    var titles = Db.Movies.Select(x => x.Title).Distinct().ToList();
    return titles;
}