namespace MoqDemo.Lib
{
    public interface IThingDependency
    {
        string JoinUpper(string a, string b);
        int Meaning { get; }
    }
}