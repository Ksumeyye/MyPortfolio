namespace MyPortfolio.DAL.Entities
{
	public class Admin
	{
        public int AdminId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<MyProfile> MyProfiles { get; set; }
    }
}
