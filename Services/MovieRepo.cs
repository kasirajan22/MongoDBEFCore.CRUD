using MongoDBEFCore.CRUD;

namespace MongoDBEFCore.CRUD;

public class MovieRepo : IMovieRepo
{
    private readonly MongoDBContext _context;

    public MovieRepo(MongoDBContext _context)
    {
        this._context = _context;
    }

    public List<Movie> GetAllMovieList()
    {
        var response = _context.movies.ToList();
        return response;
    }

    public bool AddMovie(Movie movie)
    {
        try
        {
            _context.movies.Add(movie);
            _context.SaveChanges();
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
}
