public class PlayerClass
{
    public int score = 0;

    public string name;

    public PlayerClass()
    {
        name = "";
    }

    public PlayerClass(string _name)
    {
        name = _name;
    }

    public PlayerClass(string _name, int _score)
    {
        name = _name;
        score = _score;
    }
}
