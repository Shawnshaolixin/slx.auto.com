using MessagePack;

namespace UserServiceDefination.dto
{
    [MessagePackObject]
    public class AddRequestDTO
    {
        [Key(0)]
        public int A { get; set; }
        [Key(1)]
        public int B { get; set; }
    }
}
