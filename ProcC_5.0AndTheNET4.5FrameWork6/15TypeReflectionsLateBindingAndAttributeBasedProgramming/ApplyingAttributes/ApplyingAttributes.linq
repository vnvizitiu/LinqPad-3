<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
</Query>


    #region Simple classes for testing
    // This class can be saved to disk.
    [Serializable]
    public class Motorcycle
    {
        // However this field will not be persisted.
        [NonSerialized]
        float weightOfCurrentPassengers;

        // These fields are still serializable.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }

    [Serializable, Obsolete("Use another vehicle!")]
    public class HorseAndBuggy
    {
        // ...
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            HorseAndBuggy mule = new HorseAndBuggy();
        }
    }
