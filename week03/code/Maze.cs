public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        var currentLocation = (_currX, _currY);
        if (!_mazeMap[currentLocation][0])
            throw new InvalidOperationException("Can't go that way!");
        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        var currentLocation = (_currX, _currY);
        if (!_mazeMap[currentLocation][1])
            throw new InvalidOperationException("Can't go that way!");
        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        var currentLocation = (_currX, _currY);
        if (!_mazeMap[currentLocation][2])
            throw new InvalidOperationException("Can't go that way!");
        _currY++;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        var currentLocation = (_currX, _currY);
        if (!_mazeMap[currentLocation][3])
            throw new InvalidOperationException("Can't go that way!");
        _currY--;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}