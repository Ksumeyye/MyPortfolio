using Microsoft.AspNetCore.Http;
namespace MyPortfolio.DAL.Entities;

public class MyProfile
{
    public int MyProfileId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
	public string ImageURL { get; set; }
	public string Job {  get; set; }
    public int AdminId { get; set; }
    public virtual Admin Admin { get; set; }
}
