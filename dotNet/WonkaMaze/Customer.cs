namespace WonkaMaze;

public class Customer
{
    public static int CustomerCount { get; private set; }
    public int CustomerNo { get; private set; }
    public int ArrivalTime { get;  set; }
    public int OompaWaitTime { get;  set; }
    public int LoompaWaitTime { get;  set; }

    public Customer(int arrivalTime, int oompaWaitTime, int loompaWaitTime)
    {
        CustomerCount++;
        CustomerNo = CustomerCount;
        ArrivalTime = arrivalTime;
        OompaWaitTime = oompaWaitTime;
        LoompaWaitTime = loompaWaitTime;
    }
}