using MyFirstProject.Models;
using MyFirstProject.Repositories;
using Dapper;

namespace MyFirstProject.Repositoriesl;
public interface ICategoryRepository
{
    Task<Category> Create(Category item);
    Task Update(long id,Category item);
    Task Delete(long Id);
    Task<Category> GetCategoryById(long Id);
    Task<List<Category>> GetCategoryList();
}

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public CategoryRepository(IConfiguration configuration):base(configuration)
    {

    }
    public async Task<Category> Create(Category item)
    {
       
       var query =$@"INSERT INTO category(id, category_name, display_order, created_date_time) VALUES(@id,@Name,@DisplayOrder,@CreatedDateTime)  RETURNING *";
    
        using(var conn = NewConnection)
        {
           var res =  await conn.QuerySingleOrDefaultAsync<Category>(query,item);
           return res;
        }
    
    }

    public Task Delete(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetCategoryById(long id)
    {
       var query= @$"select * from category where id=@id";
       using(var conn = NewConnection){
           var result = await conn.QueryFirstOrDefaultAsync<Category>(query ,new { id });
           return result;
       }
    }

    public async Task<List<Category>> GetCategoryList()
    {
        var query=$@"SELECT * FROM category";
        List<Category> res;
        using(var conn = NewConnection)
            res = (await conn.QueryAsync<Category>(query)).AsList(); // Execute the query
      return res;
    }

    
}
