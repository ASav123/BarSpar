
// Base class that tells us if a bottle is safe to drink (a property of the bottle). Can be inherited by most bottles (the safe ones)
class Safe
{
    public bool IsSafe;

    public Safe(bool isSafe = true)
    {
        this.IsSafe = isSafe;
    }

    public bool GetIsSafe()
    {
        return this.IsSafe;
    }
}

