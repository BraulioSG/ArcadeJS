namespace arcade.Models;

public class Player
{
    private int id { get; set; }
    private string username { get; set; }
    private string password { get; set; }
    private int balance { get; set; } = 0; //player money
}
