namespace WebJob1Test
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public new string ToString => $"[{Id}] {Name}-{Email}";
    }
}
