public class Attack 
{
    public int Damage { get; private set; }
    public bool IsCritical { get; private set; }

    public Attack(int damage, bool isCritical)
    {
        Damage = damage;
        IsCritical = isCritical;
    }
}
