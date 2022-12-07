using Domain;

namespace Service.Interface
{
    public interface IGenrateToken
    {
        string GenerateToken(TblUserDetail user);
    }
}
