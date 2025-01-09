
// Base class that tells us if a bottle is safe to drink (a property of the bottle). Can be inherited by most bottles (the safe ones)
class Safe
{
    private bool _isSafe;

    public Safe(bool isSafe = true)
    {
        _isSafe = isSafe;
    }

    public bool GetIsSafe()
    {
        return _isSafe;
    }
}

