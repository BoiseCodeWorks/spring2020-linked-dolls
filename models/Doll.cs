namespace linked.Models
{
    class Doll
    {
        public string Name { get; set; }
        public Doll OuterDoll { get; set; }
        public Doll InnerDoll { get; set; }
        public Doll(string name)
        {
            Name = name;
        }
    }
}