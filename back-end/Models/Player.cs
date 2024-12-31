using Microsoft.EntityFrameworkCore;
namespace arcade.Models;

public class Player
{
    public int PlayerId { get; private set; }
    public string username { get; set; }
    public string password { get; set; }
    public int balance { get; private set; } = 0; //player money

    public Player(string username, string password){
        this.username = username;
        this.password = password;
    }
    public void addBalance(int amount)
    {
        if (amount < 0) {
            throw new Exception ("Amount need to be greater or equal than 0");
            return;
        }

        this.balance += amount;
    }

    public void subtractBalance(int amount)
    {
        if (amount < 0)
        {
            throw new Exception ("Amount need to be greater or equal than 0");
            return;
        }

        this.balance -= amount;
    }
}

