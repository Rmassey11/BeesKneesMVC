namespace BeesKneesMVC.Models
{
    public class BeesKnees
    {
        public int BeesValue { get; set; }
        public int KneesValue { get; set; }
        public List<string> Result { get; set; } = new();
    }
}
