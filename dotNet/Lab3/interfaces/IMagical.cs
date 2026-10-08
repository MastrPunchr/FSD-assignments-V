namespace Lab3;
public interface IMagical : IUsable
{
  public int MagicPower { get; set; }
  public void Recharge();
}