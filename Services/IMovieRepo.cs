using MongoDBEFCore.CRUD;

namespace MongoDBEFCore.CRUD;

public interface IMovieRepo
{
    public List<Movie> GetAllMovieList(); 
    public bool AddMovie(Movie movie);
}
