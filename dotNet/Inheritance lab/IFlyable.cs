namespace Inheritance;

public interface IFlyable
{
    int MaxAltitude { get; set; }

    void TakeOff();
    void Land();
    void Fly(int altitude);
}