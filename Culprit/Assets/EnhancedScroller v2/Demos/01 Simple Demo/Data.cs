namespace EnhancedScrollerDemos.SuperSimpleDemo
{
    /// <summary>
    /// Super simple data class to hold information for each cell.
    /// </summary>
    /// 
    [System.Serializable]
    public class Data
    {
        public int indexStage;
    }
    public class DataStage : Data
    {
        public int amountUnitStage;
    }
    public class DataUnitStage : Data
    {
        public int indexUnitStage;
    }
}