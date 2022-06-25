namespace Quiz_Royale.DataAccess.API.Data
{
    public class PlayerCreationData
    {
        public string Username { get; set; }

        public PlayerCreationData(string username)
        {
            Username = username;
        }
    }
}
