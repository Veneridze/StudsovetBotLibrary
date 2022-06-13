namespace StudsovetBot.objects
{
    public struct Contact
    {
        public byte id { get; set; }
        public byte priority { get; set; }
        public string name { get; set; }
        public string post { get; set; }
        public decimal phone { get; set; }
        public string tg_link { get; set; }
        public string vk_link { get; set; }
    }
}
